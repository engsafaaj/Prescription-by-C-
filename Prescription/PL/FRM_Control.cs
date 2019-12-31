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
    public partial class FRM_Control : Form
    {
        // This for Move Form
        int move;
        int movex;
        int movey;
        //Instance from CLASS
        BL.CLS_TREAT BLTREAT = new BL.CLS_TREAT();
        public string user_state;
        public FRM_Control()
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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (Side_nav.Width == 65)
            {
                Side_nav.Width = 230;

            }
            else
            {
                Side_nav.Width = 65;

            }
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            PL.FRM_HOME frmhome = new FRM_HOME();
            frmhome.Show();
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txt_dept.Text == "" || txt_docdes.Text == "" || txt_height.Text == "" || txt_name.Text == "" || txt_otherdes.Text == "" || txt_phone.Text == "" || txt_title.Text == "" || txt_width.Text == "")
            {
                txt_note.Text = "اكمل متطلبات الادخال";
                bunifuTransition1.ShowSync(pn_not);
            }
            else
            {
                Properties.Settings.Default.width = Convert.ToInt32(txt_width.Text);
                Properties.Settings.Default.height = Convert.ToInt32(txt_height.Text);
                Properties.Settings.Default.name = txt_name.Text;
                Properties.Settings.Default.dep = txt_dept.Text;
                Properties.Settings.Default.docdes = txt_docdes.Text;
                Properties.Settings.Default.title = txt_title.Text;
                Properties.Settings.Default.phone = Convert.ToInt32(txt_phone.Text);
                Properties.Settings.Default.otherdes = txt_otherdes.Text;
                Properties.Settings.Default.Save();
                txt_note.Text = "تم الحفظ بنجاح";
                bunifuTransition1.ShowSync(pn_not);

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            PL.FRM_PRINT frmprint = new FRM_PRINT();
            frmprint.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pn_not.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pn_options.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn_treatments.BringToFront();

        }

        private void FRM_Control_Activated(object sender, EventArgs e)
        {
            //Load Treatments
            DataTable dt1 = new DataTable();
            dt1 = BLTREAT.loadTreat();
            dgv_treat.DataSource = dt1;
            dgv_treat.Columns[0].HeaderText = "التسلسل";
            dgv_treat.Columns[1].HeaderText = "اسم العلاج";
            //Load Patients
            DataTable dt2 = new DataTable();
            dt2 = BLTREAT.loadPat();
            dgv_pat.DataSource = dt2;
            dgv_pat.Columns[0].HeaderText = "التسلسل";
            dgv_pat.Columns[1].HeaderText = "اسم المريض";
            dgv_pat.Columns[2].HeaderText = "عمر المريض";
            dgv_pat.Columns[3].HeaderText = "جنس المريض";
            //Load users
            DataTable dt3 = new DataTable();
            dt3 = BLTREAT.loadUsers();
            dgv_users.DataSource = dt3;
            dgv_users.Columns[0].HeaderText = "التسلسل";
            dgv_users.Columns[1].HeaderText = "الاسم الكامل ";
            dgv_users.Columns[2].HeaderText = "اسم المستخدم";
            dgv_users.Columns[3].HeaderText = "كلمة السر";
            dgv_users.Columns[4].HeaderText = "الصلاحية";
            dgv_users.Columns[5].HeaderText = "حالة الدخول";
           

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            
           
                try
                {
                    if (txt_insert_treat.Text != dgv_treat.CurrentRow.Cells[1].Value.ToString())
                    {
                        BLTREAT.Insert_Treat(txt_insert_treat.Text);
                        MessageBox.Show("تمت عملية الاضافة بنجاح");
                    }
                    else
                    {
                        MessageBox.Show("ألعلاج موجود");

                    }

                }
                catch 
                {
                BLTREAT.Insert_Treat(txt_insert_treat.Text);
                MessageBox.Show("تمت عملية الاضافة بنجاح");
            }
            }
           
      

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            try
            {
                BLTREAT.Delete_Treat(Convert.ToInt32(dgv_treat.CurrentRow.Cells[0].Value));
                MessageBox.Show("تمت عملية الحذف بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_treat_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var st= dgv_treat.CurrentRow.Cells[1].Value;
            txt_insert_treat.Text = st.ToString();

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                BLTREAT.Update_Treat(Convert.ToInt32(dgv_treat.CurrentRow.Cells[0].Value), txt_insert_treat.Text);
                MessageBox.Show("تمت عملية التعديل بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_insert_treat_TextChanged(object sender, EventArgs e)
        {
            //Search Treatments

            DataTable dt = new DataTable();
            dt = BLTREAT.SearchTreat(txt_insert_treat.Text);
            dgv_treat.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pn_prescripton.BringToFront();
        }

        private void FRM_Control_Load(object sender, EventArgs e)
        {
            pn_options.BringToFront();
            if(user_state=="مدير")
            {
                button4.Enabled = true;
            }
            else { button4.Enabled = false; }

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            // delete patients
            try
            {
                BLTREAT.Delete_Pat(Convert.ToInt32(dgv_pat.CurrentRow.Cells[0].Value));
                MessageBox.Show("تمت عملية الحذف بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_pat_TextChanged(object sender, EventArgs e)
        {
            //Search Patients
            DataTable dt = new DataTable();
            dt = BLTREAT.SearchPat(txt_pat.Text);
            dgv_pat.DataSource = dt;
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            //Load Treat for Patients
            PL.FRM_PRINT frmprint = new FRM_PRINT();
            DataTable dt = new DataTable();
            dt = BLTREAT.Load_TREAT_PAT(Convert.ToInt32(dgv_pat.CurrentRow.Cells[0].Value));
            frmprint.dgvprint.DataSource = dt;
            frmprint.dgvprint.Columns[0].HeaderText = "اسم العلاج";
            frmprint.dgvprint.Columns[1].HeaderText = "كل";
            frmprint.dgvprint.Columns[2].HeaderText = "لمدة";
            frmprint.dgvprint.Columns[3].HeaderText = "الوقت";
            frmprint.txt_name.Text = dgv_pat.CurrentRow.Cells[1].Value.ToString();
            frmprint.txt_age.Text = dgv_pat.CurrentRow.Cells[2].Value.ToString();
            frmprint.txt_type.Text = dgv_pat.CurrentRow.Cells[3].Value.ToString();
            frmprint.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            pn_user.BringToFront();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            
                BLTREAT.Insert_Users(lb_name.Text,lb_username.Text,lb_useerpass.Text,lb_userroll.Text,"False");
                MessageBox.Show("تمت عملية الاضافة بنجاح");
              
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            BLTREAT.Edit_Users(Convert.ToInt32 (dgv_users.CurrentRow.Cells[0].Value),lb_name.Text, lb_username.Text, lb_useerpass.Text, lb_userroll.Text);
            MessageBox.Show("تمت عملية التعديل بنجاح");
        }

        private void dgv_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lb_name.Text = dgv_users.CurrentRow.Cells[1].Value.ToString();
            lb_username.Text = dgv_users.CurrentRow.Cells[2].Value.ToString();
            lb_useerpass.Text = dgv_users.CurrentRow.Cells[3].Value.ToString();
            lb_userroll.Text = dgv_users.CurrentRow.Cells[4].Value.ToString();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            BLTREAT.Delete_User(Convert.ToInt16(dgv_users.CurrentRow.Cells[0].Value));
            MessageBox.Show("تم الحذف بنجاح");

        }
    }
    }
   

