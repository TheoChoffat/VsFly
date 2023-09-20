using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFly
{
    [Table("Person")]
    public partial class Person
    {
        public DateTime Birthday { get; set; }
        public String Email { get; set; }
        public String FullName { get; set; }
        public String GivenName { get; set; }
        [Key]
        public int PersonID { get; set; }
        public String Surname { get; set; }
    }
}
