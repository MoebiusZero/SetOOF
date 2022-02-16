# SetOOF
Small windows application to set Out of Office for all users within the organisation

## But Why?
When people leave the company some of them forget to set a Out of Office to let people know they no longer work here. Teamleads/Management then asks if the person who left has set an out of office and because i'm lazy and don't want to log into the Exchange ECP everytime I've created this small nifty application. 

## How does it work?
It uses an App registration in Azure AD and the Graph API to connect to the tenant and get a list of all active users and shared mailboxes and puts them in a nice listbox for you to select.
Once selected, it gets the Out of Office settings like the internal and external message, the datetime range set or if it's not set. 
Once loaded, you can set a new datetime range and the message and after that click one button to save it to the account.

## Does this only work for Microsoft 365?
Yes, we long phased out our on-premise Exchange server so I have no reason to make a on-premise version.

## Any dependancies?
Yes, it uses HtmlAgilityPack, NewtonSoft.Json, RestSharp and Costura.Fody. 
I just like to compile it into a single exe file instead of having dll files everywhere. 
The other dependancies should be self explanatory. If not...
**HTMLagility pack** to convert the out of office messages 
**Newtonsoft** to make the JSON results readable but also to send the changes in readable JSON format for the API
**RestSharp** Required to make the calls to the API. 
