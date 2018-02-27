using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.QuestionaryServiceReference;

namespace WebApplication1
{
    
    public partial class _Default : BasePage
    {

        [WebMethod]
        public static int Add(string firstName, string secondName, DateTime birhtday)
        {
            int id = GetClient().Add(new Questionary { FirstName = firstName, SecondName = secondName, Birthday = birhtday });
            return id;

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Questionary> GetAll() {
            return GetClient().List();
        }

        [WebMethod]
        public static void Deleted(int id) {
            GetClient().Delete(id);
        }

        [WebMethod]
        public static void Edit(int id, string firstName, string secondName, DateTime birhtday) {
            var q = new Questionary { FirstName = firstName, SecondName = secondName, Birthday = birhtday, Id = id};
            GetClient().Update(q);

        }
    }

    
}