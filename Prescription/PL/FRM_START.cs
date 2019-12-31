using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prescription.PL
{
    public partial class FRM_START : Form
    {
        BL.CLS_USERS BLUSER = new BL.CLS_USERS();

        public FRM_START()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.load_START();
                if (dt.Rows.Count > 0)
                {
                    object ID = dt.Rows[0][0];
                    object name = dt.Rows[0][1];
                    object roll = dt.Rows[0][4];
                    int use_id = Convert.ToInt32(ID);
                    BLUSER.Edit_STATE(use_id);
                    PL.FRM_HOME FRMMAIN = new FRM_HOME();
                    FRMMAIN.txt_doc_name.Text = "د" + " . " + name.ToString();
                    FRMMAIN.txt_doc_name2.Text = name.ToString();
                    FRMMAIN.txt_doc_roll.Text = roll.ToString();
                    Properties.Settings.Default.usename = "د" + " . " + name.ToString();
                    Properties.Settings.Default.roll = roll.ToString();
                    Properties.Settings.Default.Save();
                    FRMMAIN.Show();
                    this.Hide();
                    timer1.Enabled = false;

                }
                else
                {
                    PL.FRM_Login frmlogin = new FRM_Login();
                    frmlogin.Show();
                    this.Hide();
                    timer1.Enabled = false;
                }

            }
            catch {  }
        }
    }
}
