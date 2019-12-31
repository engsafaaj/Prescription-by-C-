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
    public partial class FRM_Login: Form
    {
        // This for Move Form
        int move;
        int movex;
        int movey;
        BL.CLS_USERS BLUSER = new BL.CLS_USERS();
        public FRM_Login()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movex = e.X;
            movey = e.Y;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movex, MousePosition.Y - movey);
            }

        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            if(txt_username.Text=="" || txt_password.Text == "")
            {
                MessageBox.Show("ادخل معلومات تسجيل الدخول");

            }
            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLUSER.load_Login(txt_username.Text, txt_password.Text);
                    if (dt.Rows.Count > 0)
                    {
                        object ID = dt.Rows[0][0];
                        object name = dt.Rows[0][1];
                        object roll = dt.Rows[0][4];
                        int use_id = Convert.ToInt32(ID);
                        BLUSER.Edit_STATE(use_id);
                        PL.FRM_HOME FRMMAIN = new FRM_HOME();
                        FRMMAIN.txt_doc_name.Text ="د"+" . "+ name.ToString();
                        FRMMAIN.txt_doc_name2.Text = name.ToString();
                        FRMMAIN.txt_doc_roll.Text = roll.ToString();
                        Properties.Settings.Default.usename = "د" + " . " + name.ToString();
                        Properties.Settings.Default.roll = roll.ToString();
                        Properties.Settings.Default.Save();
                        FRMMAIN.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("خطا في معلومات تسجيل الدخول");
                    }

                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
                
            }
        }
    }

      
    }

