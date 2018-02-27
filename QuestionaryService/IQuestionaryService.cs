using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Questionary.DAL;

namespace QuestionaryService1
{
     

    [ServiceContract]
    public interface IQuestionaryService
    {

        [OperationContract]
        List<Questionary.DAL.Questionary> List();

        [OperationContract]
        int Add(Questionary.DAL.Questionary questionary);

        [OperationContract]
        void Delete(int id);

        [OperationContract]
        void Update(Questionary.DAL.Questionary questionary);

        [OperationContract]
        bool Login(string login);
    }

    
}
