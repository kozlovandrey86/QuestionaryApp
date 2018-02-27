using Questionary.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuestionaryService1
{
    [ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class QuestionaryService : IQuestionaryService
    {
        IRepository _repository;
        public QuestionaryService(IRepository repository)
        {
            _repository = repository;
        }

        public int Add(Questionary.DAL.Questionary questionary)
        {
            CheckSecurityToken();
            return _repository.Add(questionary);
            
        }

        public List<Questionary.DAL.Questionary> List()
        {
            CheckSecurityToken();
            return _repository.List();
           
        }

        public void Delete(int id) {
            CheckSecurityToken();
            _repository.Delete(id);
            
        }

        public void Update(Questionary.DAL.Questionary questionary) {
            CheckSecurityToken();
            _repository.Update(questionary);
            
        }

        public bool Login(string login) {
            CheckSecurityToken();
            return _repository.Login(login);
           
        }


        private void CheckSecurityToken()
        {
            string token = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("token", "http://localhost:49875/");

            if (string.Compare(token, "securitytoken") != 0)
                throw new Exception("token is missing");
        }
    }
}
