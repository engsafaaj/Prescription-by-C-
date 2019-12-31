using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Prescription.DAL
{
    class DAL
    {
        SqlConnection con;
        public DAL()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBPRESRIPTION.mdf;Integrated Security=True");
        }
        //Open Con
        public void conopen()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        //Close Con
        public void conclose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //Fun Load To data
        public DataTable read(string store, SqlParameter[] pram)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pram != null)
            {
                cmd.Parameters.AddRange(pram);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Void For Insert,Delete,Update
        public void Excute(string store, SqlParameter[] pram)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pram != null)
            {
                cmd.Parameters.AddRange(pram);
            }
            cmd.ExecuteNonQuery();
           
        }
    }
}
