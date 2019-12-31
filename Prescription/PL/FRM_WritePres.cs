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
    public partial class FRM_WritePres: Form
    {
        // This for Move Form
        int move;
        int movex;
        int movey;
        // Instance from class
        BL.CLS_PRES BLPRES = new BL.CLS_PRES();
        BL.CLS_TREAT BLTREAT = new BL.CLS_TREAT();

        public FRM_WritePres()
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

       
        private void panel4_Click(object sender, EventArgs e)
        {
            PL.FRM_Control frmcon = new FRM_Control();
            frmcon.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PL.FRM_Control frmcon = new FRM_Control();
            frmcon.Show();
            this.Hide();

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            PL.FRM_HOME frmhome = new FRM_HOME();
            frmhome.Show();
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(txt_name.Text=="" || txt_age.Text=="" || txt_type.Text == "")
            {
                MessageBox.Show("اكمل متطلبات الادخال اولا");

            }
            else
            {
                BLPRES.Insert_PAT_INFO(txt_name.Text,Convert.ToInt32( txt_age.Text), txt_type.Text);
                pat_treat_info.BringToFront();
                txt_name.Text = "";
                txt_age.Text = "";
                txt_type.Text = "";

            }
        }

        private void FRM_WritePres_Activated(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BLPRES.loadTreat();
            AutoCompleteStringCollection COOL = new AutoCompleteStringCollection();
            foreach(DataRow row in dt.Rows)
            {
                COOL.Add(row[0].ToString());
            }
            txt_treat_name.AutoCompleteCustomSource = COOL;
           
            
           


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void FRM_WritePres_Load(object sender, EventArgs e)
        {
            pn_pat_info.BringToFront();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (txt_treat_name.Text == "" )
            {
                MessageBox.Show("رجائا اكمل متطلبات العلاج");

            }
            else
            {
                DataTable dt2 = new DataTable();
                dt2 = BLTREAT.loadPat();
                int lastrow = dt2.Rows.Count-1;
                object ob1 = dt2.Rows[lastrow][0];
                int PAT_ID = Convert.ToInt32(ob1);
                BLPRES.Insert_TREAT_INFO(PAT_ID, txt_treat_name.Text, txt_all.Text, txt_dur.Text, txt_time.Text);
                txt_treat_name.Text = txt_all.Text = txt_dur.Text = txt_time.Text = "";
                MessageBox.Show("تمت اضافة العلاج");

            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = BLTREAT.loadPat();
            int pat_id;
            string pat_name;
            int pat_age;
            string pat_type;
            int lastrow = dt2.Rows.Count - 1;
            object ob1 = dt2.Rows[lastrow][0];
            object ob2 = dt2.Rows[lastrow][1];
            object ob3 = dt2.Rows[lastrow][2];
            object ob4 = dt2.Rows[lastrow][3];
            pat_id = Convert.ToInt32(ob1);
            pat_name = Convert.ToString(ob2);
            pat_age = Convert.ToInt32(ob3);
            pat_type = Convert.ToString(ob4);



            //Load Treat for Patients
            PL.FRM_PRINT frmprint = new FRM_PRINT();
            DataTable dt = new DataTable();
            dt = BLTREAT.Load_TREAT_PAT(Convert.ToInt32(pat_id));
            frmprint.dgvprint.DataSource = dt;
            frmprint.dgvprint.Columns[0].HeaderText = "اسم العلاج";
            frmprint.dgvprint.Columns[1].HeaderText = "كل";
            frmprint.dgvprint.Columns[2].HeaderText = "لمدة";
            frmprint.dgvprint.Columns[3].HeaderText = "الوقت";
            frmprint.txt_name.Text = pat_name;
            frmprint.txt_age.Text = pat_age.ToString();
            frmprint.txt_type.Text = pat_type;
            frmprint.Show();
            txt_treat_name.Text = txt_all.Text = txt_dur.Text = txt_time.Text = "";
            pn_pat_info.BringToFront();


        }
    }
}
