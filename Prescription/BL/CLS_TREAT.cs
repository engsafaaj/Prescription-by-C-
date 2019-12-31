using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Prescription.BL
{
    class CLS_TREAT
    {
        //Instance From DAL
        DAL.DAL DAL = new Prescription.DAL.DAL();
        //Load Data Treatments
        public DataTable loadTreat()
        {
            SqlParameter[] pr = null;
            return DAL.read("SP_LOADTREAT", pr);
        }
        //INSERT Data Treatments
        public void Insert_Treat(string Treat_Name)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("TREAT_NAME", Treat_Name);
            DAL.conopen();
            DAL.Excute("SP_INSERTTREAT", pr);
            DAL.conclose();
        }
        //DELTE Data Treatments
        public void Delete_Treat(int TREAT_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("TREAT_ID", TREAT_ID);
            DAL.conopen();
            DAL.Excute("SP_DELETETEAT", pr);
            DAL.conclose();
        }
        //Update Data Treatments
        public void Update_Treat(int TREAT_ID,string Treat_Name)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("TREAT_ID", TREAT_ID);
            pr[1] = new SqlParameter("Treat_Name", Treat_Name);
            DAL.conopen();
            DAL.Excute("SP_UPDATETREAT", pr);
            DAL.conclose();
        }
        //Search Data Treatments
        public DataTable SearchTreat(string Treat_Name)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("Treat_Name", Treat_Name);
            return DAL.read("SP_SEARCHTREAT", pr);
        }

        //Start Method Of Patients
        //Load Data Treatments
        public DataTable loadPat()
        {
            SqlParameter[] pr = null;
            return DAL.read("SP_LAODPAT", pr);
        }
        //DELTE Data PATIENTS
        public void Delete_Pat(int PATIENTS_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("PATIENTS_ID", PATIENTS_ID);
            DAL.conopen();
            DAL.Excute("SP_DELETEPAT", pr);
            DAL.conclose();
        }
        //Search Data Patients
        public DataTable SearchPat(string PAT_SEARCH)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("PAT_SEARCH", PAT_SEARCH);
            return DAL.read("SP_SEARCHPAT", pr);
        }
        //Load Data Treat for patients
        public DataTable Load_TREAT_PAT(int PATIENTS_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("PATIENTS_ID", PATIENTS_ID);
            return DAL.read("SP_LOADPATTREAT", pr);
        }
        //Start Method Of Users

        //Load Data Users
        public DataTable loadUsers()
        {
            SqlParameter[] pr = null;
            return DAL.read("SP_LOADUSER", pr);
        }
        //INSERT Data Users
        public void Insert_Users(string NAME,string USER_NAME, string PASSWORD,string USER_ROLL,string USER_STATE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("NAME", NAME);
            pr[1] = new SqlParameter("USER_NAME", USER_NAME);
            pr[2] = new SqlParameter("PASSWORD", PASSWORD);
            pr[3] = new SqlParameter("USER_ROLL", USER_ROLL);
            pr[4] = new SqlParameter("USER_STATE", USER_STATE);
            DAL.conopen();
            DAL.Excute("SP_INSERTUSERS", pr);
            DAL.conclose();
        }
        //updtae Data Users
        public void Edit_Users(int USER_ID,string NAME, string USER_NAME, string PASSWORD, string USER_ROLL)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("USER_ID", USER_ID);
            pr[1] = new SqlParameter("NAME", NAME);
            pr[2] = new SqlParameter("USER_NAME", USER_NAME);
            pr[3] = new SqlParameter("PASSWORD", PASSWORD);
            pr[4] = new SqlParameter("USER_ROLL", USER_ROLL);
            DAL.conopen();
            DAL.Excute("SP_UPDTAEUSER", pr);
            DAL.conclose();
        }

        //DELTE Data USERS
        public void Delete_User(int USER_ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("USER_ID", USER_ID);
            DAL.conopen();
            DAL.Excute("SP_DELETEUSER", pr);
            DAL.conclose();
        }

    }
}
