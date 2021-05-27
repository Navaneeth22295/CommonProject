using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MAFIL.Common.Utility
{
   public class Messenger
    {
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string MailName { get; set; }
        public string MessageTo { get; set; }
        public string MessageBody { get; set; }

        public bool SendMessage(string phoneNumber, string msg) // Messenger messenger
        {
            using (var client = new WebClient())
            {
                try
                {
                    var url = "";
                     url = "http://bankalerts.sinfini.com/api/web2sms.php?workingkey=Ad54e7d5d3d20a7fb840f358a2e959a91&sender=MAFILD&to=" + phoneNumber + " &message=" + HttpUtility.UrlEncode(msg) + "&type=xml";
                    string json = client.DownloadString(url.ToString());
                    return true;
                } catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
