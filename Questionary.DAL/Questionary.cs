using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.DAL
{
    public class Questionary
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
