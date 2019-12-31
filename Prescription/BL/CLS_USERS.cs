using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Prescription.BL
{
    class CLS_USERS
    {
        //Instance From DAL
        DAL.DAL DAL = new Prescription.DAL.DAL();
        //Load Data For Login
        public DataTable load_Login(string USER_NAME,string USER_PASSWORD)
        {
            SqlParameter[] pr =new SqlParameter[2];
            pr[0] = new SqlParameter("USER_NAME", USER_NAME);
            pr[1] = new SqlParameter("USER_PASSWORD", USER_PASSWORD);

            return DAL.read("SP_LOGIN", pr);

        }
        public void Edit_STATE(int USER_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("USER_ID", USER_ID);
            
            DAL.conopen();
            DAL.Excute("SP_UPDATELOGIN", pr);
            DAL.conclose();
        }
        public void LOG_OUT()
        {
            SqlParameter[] pr =null;

            DAL.conopen();
            DAL.Excute("SP_logout", pr);
            DAL.conclose();
        }
        public DataTable load_START()
        {
            SqlParameter[] pr = null;
            

            return DAL.read("SP_STRAT", pr);

        }
    }
}
