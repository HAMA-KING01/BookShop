﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManagementSysteem
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hamak\Documents\BookShopMe.mdf;Integrated Security=True;Connect Timeout=30");

        // the populate function to show list of user table in the datagridView bar....
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
        private void UpdateBook()
        {
            int newQty = stock - Convert.ToInt32(QTYTB.Text);
            try
            {
                Con.Open();
                String query = "update BookTbl set BQty=" + newQty + " where BId=" + key + ";";
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
        int n = 0,Grdtotal=0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            
            if(QTYTB.Text== "" || Convert.ToInt32(QTYTB.Text) > stock)
            {
                MessageBox.Show("No Enough Stock");

            }
            else
            {
                int total = Convert.ToInt32(QTYTB.Text)* Convert.ToInt32(PriceTb1.Text);
                DataGridViewRow newrow  = new DataGridViewRow();
                newrow.CreateCells(BillDGV);
                newrow.Cells[0].Value = n + 1;
                newrow.Cells[1].Value = BTitle.Text;
                newrow.Cells[3].Value = QTYTB.Text;
                newrow.Cells[2].Value = PriceTb1.Text;
                newrow.Cells[4].Value = total;
                BillDGV.Rows.Add(newrow);
                n++;
                UpdateBook();
                Grdtotal += total;
                TotalLbl.Text = "$"+Grdtotal;



            }

        }
        int key = 0,stock= 0;
        private void BookDGV_Click(object sender, EventArgs e)
        {

            BTitle.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
           // QTYTB.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
           // CatCbSearchCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
           // QtyTb1.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb1.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(BTitle.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());

            }

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {

            if (ClientNameTb.Text == "" || BTitle.Text == "")
            {
                MessageBox.Show("Select Client Name");
            }
            else
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("ppnrm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                try
                {
                    Con.Open();
                    String query = "insert into BillTbl values('" + userLbl.Text + "','" + ClientNameTb.Text + "'," + Grdtotal + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill saved Successfully");
                    Con.Close();
                    //populate();
                    //Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            } 
        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void label5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            userLbl.Text = Login.Username;
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Book Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach(DataGridViewRow row in BillDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26,pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45,pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120,pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170,pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235,pos));

                pos += 20;
            }
            e.Graphics.DrawString("Grand Total $" + Grdtotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(60, pos + 50));
            e.Graphics.DrawString("******BookStore********", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(40, pos + 85));
            BillDGV.Rows.Clear();
            BillDGV.Refresh();
            pos = 100;
            Grdtotal = 0;

        }

        private void Reset()
        {
            BTitle.Text = "";
            ClientNameTb.Text = "";
            PriceTb1.Text = "";
            QTYTB.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)// RESET BUTTON
        {
            Reset(); 
        }
    }
}
