using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.DAL
{
    public class Repository: IRepository
    {

        public int Add(Questionary questionary)
        {
            using (QuestionaryContext context = new QuestionaryContext())
            {
                SqlParameter firstName = new SqlParameter("@FirstName", questionary.FirstName);
                SqlParameter secondName = new SqlParameter("@SecondName", questionary.SecondName);
                SqlParameter birthday = new SqlParameter("@Birthday", questionary.Birthday);
                SqlParameter idinserted = new SqlParameter { ParameterName = "@insertedid", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                SqlParameter id = new SqlParameter("@id", questionary.Id);
                var resp = context.Database.SqlQuery<int>("ANKET_SAVE @FirstName, @SecondName, @Birthday, @id, @insertedid", firstName, secondName, birthday, id, idinserted);
                return resp.First();
            }
        }

        public List<Questionary> List()
        {
            using (QuestionaryContext context = new QuestionaryContext())
            {
                return context.Questionaries.SqlQuery("ANKET_SEARCH").ToList();
            }
        }

        public void Delete(int id)
        {
            using (QuestionaryContext context = new QuestionaryContext())
            {
                SqlParameter idparameter = new SqlParameter("@id", id);
                context.Database.ExecuteSqlCommand("ANKET_DELETE @id", idparameter);
            }
        }

        public void Update (Questionary questionary)
        {
            using (QuestionaryContext context = new QuestionaryContext())
            {
                SqlParameter firstName = new SqlParameter("@FirstName", questionary.FirstName);
                SqlParameter secondName = new SqlParameter("@SecondName", questionary.SecondName);
                SqlParameter birthday = new SqlParameter("@Birthday", questionary.Birthday);
                SqlParameter id = new SqlParameter("@id", questionary.Id);

                context.Database.ExecuteSqlCommand("ANKET_SAVE @FirstName, @SecondName, @Birthday, @id", firstName, secondName, birthday, id);
            }
        }

        public bool Login(string login)
        {
            using (QuestionaryContext context = new QuestionaryContext())
            {
                return context.Users.Any(u => u.Login.ToUpper() == login.ToUpper());
            }
        }
    }
}
