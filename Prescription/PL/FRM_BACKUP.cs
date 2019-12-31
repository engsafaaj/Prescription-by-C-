using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace Prescription.PL
{
    public partial class FRM_BACKUP: Form
    {
        // This for Move Form
        int move;
        int movex;
        int movey;
        string DBNAME;
        string DBSVAEPATH;
        string DBRESTORENAME;
        public FRM_BACKUP()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PL.FRM_WritePres frmwritepres = new FRM_WritePres();
            frmwritepres.Show();
            this.Hide();
        }

        

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            PL.FRM_HOME frmhome = new FRM_HOME();
            frmhome.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var rs = ofd.ShowDialog();
            if (rs == DialogResult.OK)
            {
                DBNAME = ofd.FileName;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            var rs = ofd.ShowDialog();
            if (rs == DialogResult.OK)
            {
                DBSVAEPATH = ofd.SelectedPath;
            }
        }
        
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBNAME + ";Integrated Security=True");
                string FileName = DBSVAEPATH + "\\DBPRESRIPTION";
                string quarystr = "BACKUP DATABASE [" + DBNAME + "] TO DISK='" + FileName + ".bak'";
                SqlCommand cmd = new SqlCommand(quarystr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم النسخ الاحتياطي بنجاح");

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var rs = ofd.ShowDialog();
            if (rs == DialogResult.OK)
            {
                DBRESTORENAME = ofd.FileName;
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DBNAME + ";Integrated Security=True");
                string quarystr = "ALTER DATABASE [" + DBNAME + "] SET OFFLINE WITH ROLLBACK IMMEDIATE;RESTORE DATABASE [" + DBNAME + "] FROM DISK='" + DBRESTORENAME + "'";
                SqlCommand cmd = new SqlCommand(quarystr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم استعادة النسخة بنجاح");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
