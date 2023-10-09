using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace YuzTanima
{
    public partial class Student_Entry : Form
    {
        
        ConnectionString cs = new ConnectionString();
        classCommon cc = new classCommon();
        classFunction cf = new classFunction();
        string st1;
        string st2;
        public Student_Entry()
        {
            InitializeComponent();
        }

        
      public void Reset()
        {
        txtPresentAbsent.Text = "";
        txtStudentName.Text = "";
        txtSubject.Text = "";
        txtTerm.Text = "";
        txtYear.Text = "";
        txtStudentID.Text = "";
        txtID.Text = "";
        txtStudentName.Focus();
        
        btnUpdate.Enabled = false;
        
        auto();
        }
     
  
          
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        public void auto()
        {
            
                int Num = 0;
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string sql = "SELECT MAX(C_ID+1) FROM Student";
                cc.cmd = new SqlCommand(sql);
                cc.cmd.Connection = cc.con;
                if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtID.Text = Convert.ToString(Num);
                    txtStudentID.Text = "C-" + Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cc.cmd.ExecuteScalar());
                    txtID.Text = Convert.ToString(Num);
                    txtStudentID.Text = "C-" + Convert.ToString(Num);
                }
                cc.cmd.Dispose();
                cc.con.Close();
                cc.con.Dispose();
         
        }


       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
             
                  if (txtStudentID.Text == "")
                  {
                      MessageBox.Show("Please enter Student name!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      txtStudentID.Focus();
                      return;
                  }

                  if (txtYear.Text == "")
                  {
                      MessageBox.Show("Please enter Year!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      txtYear.Focus();
                      return;
                  }
                  if (txtTerm.Text == "")
                  {
                      MessageBox.Show("Please enter Term!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      txtTerm.Focus();
                      return;
                  }
                  if (txtPresentAbsent.Text == "")
                  {
                      MessageBox.Show("Please enter PresentAbsent.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      txtPresentAbsent.Focus();
                      return;
                  }
                  cc.con = new SqlConnection(cs.DBConn);
                  cc.con.Open();
                  string cb = "Update Student set StudentID=@d2,Name=@d3,Year=@d4,Term=@d5,Subject=@d6,PresentAbsent=@d7,Photo=@d8 where C_ID=@d1";
                  cc.cmd = new SqlCommand(cb);
                  cc.cmd.Connection = cc.con;
                  cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
                  cc.cmd.Parameters.AddWithValue("@d2", txtStudentID.Text);
                  cc.cmd.Parameters.AddWithValue("@d3", txtStudentName.Text);
                  cc.cmd.Parameters.AddWithValue("@d4", txtYear.Text);
                  cc.cmd.Parameters.AddWithValue("@d5", txtTerm.Text);
                  cc.cmd.Parameters.AddWithValue("@d6", txtSubject.Text);
                  cc.cmd.Parameters.AddWithValue("@d7", txtPresentAbsent.Text);
                  MemoryStream ms = new MemoryStream();
                  Bitmap bmpImage = new Bitmap(Picture.Image);
                  bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                  byte[] data = ms.GetBuffer();
                  SqlParameter p = new SqlParameter("@d8", SqlDbType.Image);
                  p.Value = data;
                  cc.cmd.Parameters.Add(p);
                  cc.cmd.ExecuteReader();
                  cc.con.Close();
                  st1 = lblUser.Text;
                  st2 = "updated the Student'" + txtStudentName.Text + "' having Student id '" + txtStudentID.Text + "'";
                  cf.LogFunc(st1, System.DateTime.Now, st2);
                btnUpdate.Enabled = false;
                MessageBox.Show("Successfully updated!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

    
      
        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }


        
        private void Browse_Click(object sender, EventArgs e)
        {
            
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
               
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Picture.Image = Image.FromFile(openFileDialog1.FileName);
                }

           
        }


       
      

        private void BRemove_Click(object sender, EventArgs e)
        {
          
        }


      
       

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}