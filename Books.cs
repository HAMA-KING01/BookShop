using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // this helps in initializing the dataBase for the data to be saved to it.........
using System.Security.Cryptography;

namespace BookShopManagementSysteem
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from BookTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            Con.Close(); 

        }
        private void Filter()
        {
            Con.Open();
            string query = "select * from BookTbl where BCat='" + CatCbSearchCb.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)// edit button
        {
            if (BTitle.Text == "" || BauthTB.Text == "" || BCatcb.SelectedIndex == -1 || PriceTb1.Text == "" || QtyTb1.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update BookTbl set BTitle='"+BTitle.Text+"',BAuthor='"+BauthTB.Text+ "',BCat='"+BCatcb.SelectedItem.ToString()+ "',BPrice="+PriceTb1.Text+ ",BQty="+QtyTb1.Text+"where BId=" + key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Updated Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        //int key = 0;
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    BTitle.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
        //    //BauthTB.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
        //    //CatCbSearchCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
        //    //QtyTb1.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
        //    //PriceTb1.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();

        //}

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

    

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
         
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hamak\Documents\BookShopMe.mdf;Integrated Security=True;Connect Timeout=30");

       
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

     

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            BTitle.Text = "";
            BauthTB.Text = "";
            BCatcb.SelectedIndex = -1;
            PriceTb1.Text = "";
            QtyTb1.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
           
        }

        private void SaveBtn_Click(object sender, EventArgs e)//add
        {
            if (BTitle.Text == "" || BauthTB.Text == "" || BCatcb.SelectedIndex == -1 || PriceTb1.Text == "" || QtyTb1.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "insert into BookTbl values('" + BTitle.Text + "','" + BauthTB.Text + "','" + BCatcb.SelectedItem.ToString() + "'," + QtyTb1.Text + "," + PriceTb1.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);// add new query
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book saved Successfully");
                    Con.Close();
                    populate();//refdtgv
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void CatCbSearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();// this is for the event witch is letter comitted i really dont know why we didn't go directly..
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            populate();
            CatCbSearchCb.SelectedIndex = -1;
        }
 
    

       

        int key = 0;
        private void BookDGV_Click(object sender, EventArgs e)
        {
              BTitle.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
           BauthTB.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
            CatCbSearchCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb1.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
           PriceTb1.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();
            key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
            //int index = 3;
            //DataGridViewRow selectedRow = BookDGV.Rows[index];
            //BTitle.Text = selectedRow.Cells[0].Value.ToString();
            //BauthTB.Text = selectedRow.Cells[1].Value.ToString();
            //CatCbSearchCb.SelectedItem = selectedRow.Cells[2].Value.ToString();
            //QtyTb1.Text = selectedRow.Cells[3].Value.ToString();
            //PriceTb1.Text = selectedRow.Cells[4].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)// delete button
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from BookTbl where BId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
