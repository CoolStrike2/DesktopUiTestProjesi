using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccessLayer.Abstact;
using TestProject.DataAccessLayer.Concrete;
using TestProject.DataAccessLayer.Repositories;
using TestProject.EntityLayer.Concrete;

namespace TestProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal:GenericRepository<Staff>,IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
            
        }
    }
}
