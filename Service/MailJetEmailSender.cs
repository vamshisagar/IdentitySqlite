﻿using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Service
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public MailJetOptions _mailJetOptions;
        public MailJetEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions = _configuration.GetSection("MailJet").Get<MailJetOptions>();

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey)
            {
                //Version = ApiVersion.V3_1,
            };
   MailjetRequest requests = new MailjetRequest {
     Resource = Send.Resource,
    }
    .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "vamshisagar@protonmail.com"}, 
        {"Name", "Vamshi"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          "vamshisagar@protonmail.com"
         }, {
          "Name",
          "Vamshi"
         }
        }
       }
      }, {
       "Subject",
      subject
      },  {
       "HTMLPart",
       htmlMessage
      }, {
       "HTMLPart",
       "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
      }, {
       "CustomID",
       "AppGettingStartedTest"
      }
     }
    });
   await client.PostAsync(requests);
//    if (response.IsSuccessStatusCode) {
//     Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
//     Console.WriteLine(response.GetData());
//    } else {
//     Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
//     Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
//     Console.WriteLine(response.GetData());
//     Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
//    }
  }
 }
}


