using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.DAL
{
    public interface IRepository
    {
        int Add(Questionary questionary);
        List<Questionary> List();
        void Delete(int id);
        void Update(Questionary questionary);
        bool Login(string login);

    }
}
