using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcIdentity.Service
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _conf;
        private MailJetOptions _mailJetOptions;

        public MailJetEmailSender(IConfiguration conf)
        {
            _conf = conf;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions = _conf.GetSection("MailJet").Get<MailJetOptions>();
            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                 new JObject {
                  {
                   "From",
                   new JObject {
                    {"Email", "johnmayweather1@protonmail.com"},
                    {"Name", "john"}
                   }
                  }, {
                   "To",
                   new JArray {
                    new JObject {
                     {
                      "Email",
                      email
                     }, {
                      "Name",
                      "john"
                     }
                    }
                   }
                  }, {
                   "Subject",
                   subject
                  },{
                   "HTMLPart",
                   htmlMessage
                  }, 
                 }
             });
             await client.PostAsync(request);
        }
    }
}
