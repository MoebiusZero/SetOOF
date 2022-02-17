using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.IO;

namespace SetOFF
{
    public partial class OutofOfficeForm : Form
    {
        public class Message
        {
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public int ext_expires_in { get; set; }
            public string access_token { get; set; }
        }
        public class ScheduledStartDateTime
        {
            public DateTime dateTime { get; set; }
            public string timeZone { get; set; }
        }

        public class ScheduledEndDateTime
        {
            public DateTime dateTime { get; set; }
            public string timeZone { get; set; }
        }

        public class AutomaticRepliesSetting
        {
            public string status { get; set; }
            public string externalAudience { get; set; }
            public string internalReplyMessage { get; set; }
            public string externalReplyMessage { get; set; }
            public ScheduledStartDateTime scheduledStartDateTime { get; set; }
            public ScheduledEndDateTime scheduledEndDateTime { get; set; }
        }

        public class Language
        {
            public string locale { get; set; }
            public string displayName { get; set; }
        }

        public class TimeZone
        {
            public string name { get; set; }
        }

        public class WorkingHours
        {
            public List<string> daysOfWeek { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
            public TimeZone timeZone { get; set; }
        }

        public class Root_Mailsettings
        {
            [JsonProperty("@odata.context")]
            public string OdataContext { get; set; }
            public string archiveFolder { get; set; }
            public string timeZone { get; set; }
            public string delegateMeetingMessageDeliveryOptions { get; set; }
            public string dateFormat { get; set; }
            public string timeFormat { get; set; }
            public string userPurpose { get; set; }
            public string userPurposeV2 { get; set; }
            public AutomaticRepliesSetting automaticRepliesSetting { get; set; }
            public Language language { get; set; }
            public WorkingHours workingHours { get; set; }
        }
        public class Users
        {
            public List<string> businessPhones { get; set; }
            public string displayName { get; set; }
            public string givenName { get; set; }
            public string jobTitle { get; set; }
            public string mail { get; set; }
            public string mobilePhone { get; set; }
            public string officeLocation { get; set; }
            public string preferredLanguage { get; set; }
            public string surname { get; set; }
            public string userPrincipalName { get; set; }
            public string id { get; set; }
        }

        public class Root_Users
        {
            [JsonProperty("@odata.context")]
            public string OdataContext { get; set; }

            [JsonProperty("@odata.nextLink")]
            public string OdataNextLink { get; set; }
            public List<Users> value { get; set; }
        }
        public class Error
        {
            public string code { get; set; }
            public string message { get; set; }
        }

        public OutofOfficeForm()
        {
            InitializeComponent();

            //Get access token
            var accesstoken = GetToken();

            string content = "";
            string url = "https://graph.microsoft.com/v1.0/users";

            do
            {            
                //Get a list of all users and populate them into the combo box
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("authorization", "Bearer " + accesstoken);
                IRestResponse response = client.Execute(request);

                var resp = JsonConvert.DeserializeObject<Root_Users>(response.Content);
                url = resp.OdataNextLink;
                content = response.Content;

                foreach (var user in resp.value)
                {
                    if (user.mail != null)
                    {
                        cmb_users.Items.Add(user.userPrincipalName);
                    }
                  
                }
            }
            while (content.Contains("@odata.nextLink"));    
        }

        //Button to update Out of Office Signature
        private void bnt_update_Click(object sender, EventArgs e)
        {
            //Request Bearer token            
            var accesstoken = GetToken();

            //Request User ID
            string user = cmb_users.Text;
            var userid = GetIDUser(user);

            //Get the new Internal Message Text
            String internalmsg = OOFtext_Internal.Text.Replace("\n", "<br>");
            String externalmsg = OOFtext_External.Text.Replace("\n", "<br>");

            //Check if the OOF is scheduled or indefinitly
            string oofstatus = null; 
            if (chk_statusoof.Checked) {
                oofstatus = "alwaysEnabled"; 
            } else
            {
                oofstatus = "scheduled"; 
            }

            //Send the PATCH request
            var mailboxsettingsclient = new RestClient("https://graph.microsoft.com/beta/users/" + userid + "/mailboxsettings");
            var mailboxsettingreq = new RestRequest(Method.PATCH);

            mailboxsettingreq.AddHeader("authorization", "Bearer " + accesstoken);
            mailboxsettingreq.AddHeader("Content-Type", "application/json");
            mailboxsettingreq.AddJsonBody(new
            {
                automaticRepliesSetting = new
                {
                    status = oofstatus, 
                    internalReplyMessage = internalmsg,
                    externalReplyMessage = externalmsg,
                    scheduledStartDateTime = new
                    {
                        dateTime = datetime_start.Value,
                    },
                    scheduledEndDateTime = new
                    {
                        dateTime = datetime_end.Value,
                    }
                },
            });

            IRestResponse response = mailboxsettingsclient.Execute(mailboxsettingreq);
            var statuscode = response.StatusCode;

            if (statuscode.ToString() == "BadRequest")
            {
                MessageBox.Show("Unable to apply the OOF message for the user, ask the developer for assistance.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("OOF succesfully changed!", "Epic Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Get OOF text when the selected user has been selected or changed
        private void cmb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            var accesstoken = GetToken();

            string user = cmb_users.Text;

            if (user == string.Empty)
            {
                //Notify that no user was selected
                MessageBox.Show("Je hebt geen gebruiker geselecteerd, er is niks om op gehalen dummy", "Geen gebruiker geselecteerd");

                //Hide the date/time fields
                datetime_start.Visible = false;
                lbl_startdateoof.Visible = false;
                datetime_end.Visible = false;
                lbl_enddateoof.Visible = false;
                chk_statusoof.Visible = false;
            }
            else
            {
                //Show the date/time fields
                datetime_end.Visible = true;
                lbl_enddateoof.Visible = true;
                datetime_start.Visible = true;
                lbl_startdateoof.Visible = true;
                chk_statusoof.Visible = true;

                //Get the userID using the selected UPN
                var userid = GetIDUser(user);              

                //Get the mailboxsettings of the selected user      
                var mailboxsettingsclient = new RestClient("https://graph.microsoft.com/beta/users/" + userid + "/mailboxsettings");
                var mailboxsettingreq = new RestRequest(Method.GET);
                mailboxsettingreq.AddHeader("authorization", "Bearer " + accesstoken);
                IRestResponse mailboxsettingres = mailboxsettingsclient.Execute(mailboxsettingreq);
                var statuscode = mailboxsettingres.StatusCode;

                if (statuscode.ToString() == "NotFound")
                {
                    MessageBox.Show("User does not have a license and therefore no mailbox to pull OOF settings from. If you believe this is in error, check the user assigned licenses", "No Mailbox", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                } else
                {
                    var mailboxsettingresult = JsonConvert.DeserializeObject<Root_Mailsettings>(mailboxsettingres.Content);

                    var decodedinternalmsg = HtmlUtilities.ConvertToPlainText(mailboxsettingresult.automaticRepliesSetting.internalReplyMessage);
                    var decodedexternalmsg = HtmlUtilities.ConvertToPlainText(mailboxsettingresult.automaticRepliesSetting.externalReplyMessage);
                    var oofstatus = mailboxsettingresult.automaticRepliesSetting.status;
                    var startdateoof = mailboxsettingresult.automaticRepliesSetting.scheduledStartDateTime.dateTime;
                    var enddateoof = mailboxsettingresult.automaticRepliesSetting.scheduledEndDateTime.dateTime;

                    if (oofstatus == "alwaysEnabled")
                    {
                        //If the OOF status is AlwaysEnabled, then check the checkbox and disable the date/time fields
                        chk_statusoof.Checked = true;
                        datetime_end.Enabled = false;
                        datetime_start.Enabled = false;
                    }
                    else
                    {
                        //If the OOF status is not AlwaysEnabled, then uncheck the checkbox and enable the date/time fields
                        chk_statusoof.Checked = false;
                        datetime_end.Enabled = true;
                        datetime_start.Enabled = true;
                    }

                    //Get the configured OOF date/time schedule of the selected u ser
                    datetime_start.Value = startdateoof;
                    datetime_end.Value = enddateoof;

                    //Get the current OOF message set of the selected user
                    OOFtext_Internal.Text = decodedinternalmsg;
                    OOFtext_External.Text = decodedexternalmsg;
                }


                
            }
        }

        //Functions
        //Get the user ID from the selected user
        public string GetIDUser(string upn)
        {
            //Request Bearer token
            var accesstoken = GetToken();

            var userrestclient = new RestClient("https://graph.microsoft.com/beta/users/" + upn);
            var userreq = new RestRequest(Method.GET);
            userreq.AddHeader("authorization", "Bearer " + accesstoken);
            IRestResponse userres = userrestclient.Execute(userreq);

            var userresult = JsonConvert.DeserializeObject<Users>(userres.Content);
            var userid = userresult.id;
            
            return userid;
        }

        //Get Bearer Token Function
        public string GetToken()
        {
            var client = new RestClient("https://login.microsoftonline.com/<TENANT_ID HERE>/oauth2/v2.0/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("Grant_Type", "client_credentials");
            request.AddParameter("Scope", "https://graph.microsoft.com/.default");
            request.AddParameter("client_Id", "<CLIENT_ID HERE>");
            request.AddParameter("Client_Secret", "<CLIENT_SECRET HERE>");
            IRestResponse response = client.Execute(request);

            dynamic resp = JsonConvert.DeserializeObject<Message>(response.Content);
            string token = resp.access_token;
            return token;
        }

        private void chk_statusoof_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_statusoof.Checked)
            {
                //if Checked, disable the date/time fields
                datetime_end.Enabled = false;
                datetime_start.Enabled = false;
            } 
            else
            {
                //if unchecked, enable the date/time fields
                datetime_end.Enabled = true;
                datetime_start.Enabled = true;
            }                     
        }
    }
}

//Class to convert HTML text to plain text, makes it easier to read
public class HtmlUtilities
{
    /// <summary>
    /// Converts HTML to plain text / strips tags.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <returns></returns>
    public static string ConvertToPlainText(string html)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);

        StringWriter sw = new StringWriter();
        ConvertTo(doc.DocumentNode, sw);
        sw.Flush();
        return sw.ToString();         
    }


    /// <summary>
    /// Count the words.
    /// The content has to be converted to plain text before (using ConvertToPlainText).
    /// </summary>
    /// <param name="plainText">The plain text.</param>
    /// <returns></returns>
    public static int CountWords(string plainText)
    {
        return !String.IsNullOrEmpty(plainText) ? plainText.Split(' ', '\n').Length : 0;
    }


    public static string Cut(string text, int length)
    {
        if (!String.IsNullOrEmpty(text) && text.Length > length)
        {
            text = text.Substring(0, length - 4) + " ...";
        }
        return text;
    }


    private static void ConvertContentTo(HtmlNode node, TextWriter outText)
    {
        foreach (HtmlNode subnode in node.ChildNodes)
        {
            ConvertTo(subnode, outText);
        }
    }


    private static void ConvertTo(HtmlNode node, TextWriter outText)
    {
        string html;
        switch (node.NodeType)
        {
            case HtmlNodeType.Comment:
                // don't output comments
                break;

            case HtmlNodeType.Document:
                ConvertContentTo(node, outText);
                break;

            case HtmlNodeType.Text:
                // script and style must not be output
                string parentName = node.ParentNode.Name;
                if ((parentName == "script") || (parentName == "style"))
                    break;

                // get text
                html = ((HtmlTextNode)node).Text;

                // is it in fact a special closing node output as text?
                if (HtmlNode.IsOverlappedClosingElement(html))
                    break;

                // check the text is meaningful and not a bunch of whitespaces
                if (html.Trim().Length > 0)
                {
                    outText.Write(HtmlEntity.DeEntitize(html));
                }
                break;

            case HtmlNodeType.Element:
                switch (node.Name)
                {
                    case "p":
                        // treat paragraphs as crlf
                        outText.Write("\r\n");
                        break;
                    case "br":
                        outText.Write("\r\n");
                        break;
                }

                if (node.HasChildNodes)
                {
                    ConvertContentTo(node, outText);
                }
                break;
        }
    }
}