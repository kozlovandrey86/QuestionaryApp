using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.DAL
{
    public class QuestionaryContext: DbContext
    {
        public QuestionaryContext(): base("questionary")
        {
            

        }

        public DbSet<Questionary> Questionaries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
