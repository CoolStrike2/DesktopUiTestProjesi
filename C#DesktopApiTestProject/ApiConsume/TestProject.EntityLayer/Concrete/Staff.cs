using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public bool Activity { get; set; }

    }
}
