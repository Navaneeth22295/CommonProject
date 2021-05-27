using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAFIL.Common.Utility
{
    public class SendTextMessage
    {
        public static bool SendText(SMSMessageTypes messageType, string phoneNumber = "", string firstName = "", string otp = "")
        {

            Messenger msgObj = new Messenger();
            //try
            //{
                msgObj.MessageTo = phoneNumber;

                switch (messageType)
                {
                    case SMSMessageTypes.OTPMsg:
                        msgObj.MessageBody = "Dear Customer,Your OTP for Manappuram One Time Registration is " + otp + ". It is usable once and valid for 5 mins from the request. DO NOT SHARE WITH ANY ONE";
                        break;
                    default:
                        break;
                }
                var checkWthmsgIsSent = msgObj.SendMessage(msgObj.MessageTo, msgObj.MessageBody);
                return true;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

    }

}
