
namespace SetOFF
{
    partial class OutofOfficeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutofOfficeForm));
            this.bnt_update = new System.Windows.Forms.Button();
            this.lbl_internaltxt = new System.Windows.Forms.Label();
            this.lbl_externaltxt = new System.Windows.Forms.Label();
            this.OOFtext_Internal = new System.Windows.Forms.RichTextBox();
            this.OOFtext_External = new System.Windows.Forms.RichTextBox();
            this.lbl_users = new System.Windows.Forms.Label();
            this.cmb_users = new System.Windows.Forms.ComboBox();
            this.datetime_start = new System.Windows.Forms.DateTimePicker();
            this.datetime_end = new System.Windows.Forms.DateTimePicker();
            this.lbl_startdateoof = new System.Windows.Forms.Label();
            this.lbl_enddateoof = new System.Windows.Forms.Label();
            this.chk_statusoof = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bnt_update
            // 
            this.bnt_update.Location = new System.Drawing.Point(756, 725);
            this.bnt_update.Name = "bnt_update";
            this.bnt_update.Size = new System.Drawing.Size(316, 45);
            this.bnt_update.TabIndex = 1;
            this.bnt_update.Text = "Bijwerken";
            this.bnt_update.UseVisualStyleBackColor = true;
            this.bnt_update.Click += new System.EventHandler(this.bnt_update_Click);
            // 
            // lbl_internaltxt
            // 
            this.lbl_internaltxt.AutoSize = true;
            this.lbl_internaltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_internaltxt.Location = new System.Drawing.Point(382, 322);
            this.lbl_internaltxt.Name = "lbl_internaltxt";
            this.lbl_internaltxt.Size = new System.Drawing.Size(116, 20);
            this.lbl_internaltxt.TabIndex = 5;
            this.lbl_internaltxt.Text = "Interne Tekst";
            // 
            // lbl_externaltxt
            // 
            this.lbl_externaltxt.AutoSize = true;
            this.lbl_externaltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_externaltxt.Location = new System.Drawing.Point(1304, 322);
            this.lbl_externaltxt.Name = "lbl_externaltxt";
            this.lbl_externaltxt.Size = new System.Drawing.Size(120, 20);
            this.lbl_externaltxt.TabIndex = 6;
            this.lbl_externaltxt.Text = "Externe Tekst";
            // 
            // OOFtext_Internal
            // 
            this.OOFtext_Internal.Location = new System.Drawing.Point(56, 352);
            this.OOFtext_Internal.Name = "OOFtext_Internal";
            this.OOFtext_Internal.Size = new System.Drawing.Size(826, 322);
            this.OOFtext_Internal.TabIndex = 7;
            this.OOFtext_Internal.Text = "";
            // 
            // OOFtext_External
            // 
            this.OOFtext_External.Location = new System.Drawing.Point(974, 352);
            this.OOFtext_External.Name = "OOFtext_External";
            this.OOFtext_External.Size = new System.Drawing.Size(812, 322);
            this.OOFtext_External.TabIndex = 8;
            this.OOFtext_External.Text = "";
            // 
            // lbl_users
            // 
            this.lbl_users.AutoSize = true;
            this.lbl_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_users.Location = new System.Drawing.Point(840, 14);
            this.lbl_users.Name = "lbl_users";
            this.lbl_users.Size = new System.Drawing.Size(175, 20);
            this.lbl_users.TabIndex = 9;
            this.lbl_users.Text = "Selecteer Gebruiker:";
            // 
            // cmb_users
            // 
            this.cmb_users.FormattingEnabled = true;
            this.cmb_users.Location = new System.Drawing.Point(740, 62);
            this.cmb_users.Name = "cmb_users";
            this.cmb_users.Size = new System.Drawing.Size(380, 28);
            this.cmb_users.TabIndex = 10;
            this.cmb_users.SelectedIndexChanged += new System.EventHandler(this.cmb_users_SelectedIndexChanged);
            // 
            // datetime_start
            // 
            this.datetime_start.CustomFormat = "dd/MM/yyyy HH:mm tt";
            this.datetime_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_start.Location = new System.Drawing.Point(609, 142);
            this.datetime_start.Name = "datetime_start";
            this.datetime_start.Size = new System.Drawing.Size(253, 26);
            this.datetime_start.TabIndex = 11;
            this.datetime_start.Visible = false;
            // 
            // datetime_end
            // 
            this.datetime_end.CustomFormat = "dd/MM/yyyy HH:mm tt";
            this.datetime_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_end.Location = new System.Drawing.Point(1046, 142);
            this.datetime_end.Name = "datetime_end";
            this.datetime_end.Size = new System.Drawing.Size(252, 26);
            this.datetime_end.TabIndex = 12;
            this.datetime_end.Visible = false;
            // 
            // lbl_startdateoof
            // 
            this.lbl_startdateoof.AutoSize = true;
            this.lbl_startdateoof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_startdateoof.Location = new System.Drawing.Point(604, 118);
            this.lbl_startdateoof.Name = "lbl_startdateoof";
            this.lbl_startdateoof.Size = new System.Drawing.Size(236, 20);
            this.lbl_startdateoof.TabIndex = 13;
            this.lbl_startdateoof.Text = "Startdatum/tijd Out of Office";
            this.lbl_startdateoof.Visible = false;
            // 
            // lbl_enddateoof
            // 
            this.lbl_enddateoof.AutoSize = true;
            this.lbl_enddateoof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enddateoof.Location = new System.Drawing.Point(1041, 118);
            this.lbl_enddateoof.Name = "lbl_enddateoof";
            this.lbl_enddateoof.Size = new System.Drawing.Size(232, 20);
            this.lbl_enddateoof.TabIndex = 15;
            this.lbl_enddateoof.Text = "Einddatum/tijd Out of Office";
            this.lbl_enddateoof.Visible = false;
            // 
            // chk_statusoof
            // 
            this.chk_statusoof.AutoSize = true;
            this.chk_statusoof.Location = new System.Drawing.Point(1161, 68);
            this.chk_statusoof.Name = "chk_statusoof";
            this.chk_statusoof.Size = new System.Drawing.Size(154, 24);
            this.chk_statusoof.TabIndex = 16;
            this.chk_statusoof.Text = "Geen Tijdsbereik";
            this.chk_statusoof.UseVisualStyleBackColor = true;
            this.chk_statusoof.Visible = false;
            this.chk_statusoof.CheckedChanged += new System.EventHandler(this.chk_statusoof_CheckedChanged);
            // 
            // OutofOfficeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1852, 814);
            this.Controls.Add(this.chk_statusoof);
            this.Controls.Add(this.lbl_enddateoof);
            this.Controls.Add(this.lbl_startdateoof);
            this.Controls.Add(this.datetime_end);
            this.Controls.Add(this.datetime_start);
            this.Controls.Add(this.cmb_users);
            this.Controls.Add(this.lbl_users);
            this.Controls.Add(this.OOFtext_External);
            this.Controls.Add(this.OOFtext_Internal);
            this.Controls.Add(this.lbl_externaltxt);
            this.Controls.Add(this.lbl_internaltxt);
            this.Controls.Add(this.bnt_update);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OutofOfficeForm";
            this.Text = "Out off Office Instellen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bnt_update;
        private System.Windows.Forms.Label lbl_internaltxt;
        private System.Windows.Forms.Label lbl_externaltxt;
        private System.Windows.Forms.RichTextBox OOFtext_Internal;
        private System.Windows.Forms.RichTextBox OOFtext_External;
        private System.Windows.Forms.Label lbl_users;
        private System.Windows.Forms.ComboBox cmb_users;
        private System.Windows.Forms.DateTimePicker datetime_start;
        private System.Windows.Forms.DateTimePicker datetime_end;
        private System.Windows.Forms.Label lbl_startdateoof;
        private System.Windows.Forms.Label lbl_enddateoof;
        private System.Windows.Forms.CheckBox chk_statusoof;
    }
}

