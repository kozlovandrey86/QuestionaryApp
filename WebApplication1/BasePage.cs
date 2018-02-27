using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using WebApplication1.QuestionaryServiceReference;

namespace WebApplication1
{
    public class BasePage : Page
    {
        static QuestionaryServiceClient client;
        protected BasePage()
        {
            client = new QuestionaryServiceClient();
        }

        public static QuestionaryServiceClient GetClient()
        {
            new OperationContextScope(client.InnerChannel);
            MessageHeader head = MessageHeader.CreateHeader("token", "http://localhost:49875/", "securitytoken");
            OperationContext.Current.OutgoingMessageHeaders.Add(head);
            return client;
        }
    }
}