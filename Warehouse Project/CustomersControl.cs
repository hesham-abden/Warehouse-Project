using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Project
{
    public partial class CustomersControl : UserControl
    {
        Customer customer = new Customer();
        public CustomersControl()
        {
            InitializeComponent();
        }
        public void UpdateList()
        {
            var list = Form1.ent.Customers.Select(m => new
            {
                ID = m.id,
                Name = m.name,
                Email = m.email,
                Phone = m.phone,
                Mobile = m.mobile,
                Fax = m.fax,
                Website = m.website
            });

            dataGridView1.DataSource = list.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int CustomerId = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            cust_id.Text = CustomerId.ToString();
            customer = Form1.ent.Customers.Find(CustomerId);
            cust_name.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            cust_email.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            cust_mobile.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            cust_fax.Text = dataGridView1.Rows[RowIndex].Cells[4].Value.ToString();
            cust_phone.Text = dataGridView1.Rows[RowIndex].Cells[5].Value.ToString();
            cust_site.Text = dataGridView1.Rows[RowIndex].Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tempid;
            if (int.TryParse(cust_id.Text, out tempid)
                && cust_name.Text != "")
            {
                var tempname = Form1.ent.Customers.Where(name => name.name == cust_name.Text).FirstOrDefault();
                if (Form1.ent.Customers.Find(tempid) == null && tempname == null)
                {
                    Customer newCustomer = new Customer();
                    newCustomer.id = tempid;
                    newCustomer.name = cust_name.Text;
                    newCustomer.phone = cust_phone.Text;
                    newCustomer.email = cust_email.Text;
                    newCustomer.fax = cust_fax.Text;
                    newCustomer.mobile = cust_mobile.Text;
                    newCustomer.website = cust_site.Text;
                    Form1.ent.Customers.Add(newCustomer);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Customer Added Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Customer Id/Name");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cust_name.Text != "")
            {
                var tempcust = Form1.ent.Customers.Where(s => s.name == cust_name.Text).Select(m => new
                {
                    ID = m.id,
                    Name = m.name,
                    Email = m.email,
                    Phone = m.phone,
                    Mobile = m.mobile,
                    Fax = m.fax,
                    Website = m.website
                });
                if (tempcust.Count() != 0)
                {
                    dataGridView1.DataSource = tempcust.ToList();
                }
                else
                {
                    MessageBox.Show("NOT FOUND!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cust_id.Text != ""
                && cust_name.Text != ""
                                        )
            {
                int tempid;
                if (int.TryParse(cust_id.Text, out tempid))
                {
                    var tempcust = Form1.ent.Customers.Where(name => name.id == tempid).FirstOrDefault();
                    if (tempcust != null)
                    {
                        customer.name = cust_name.Text;
                        customer.phone = cust_phone.Text;
                        customer.mobile = cust_mobile.Text;
                        customer.fax = cust_fax.Text;
                        customer.email = cust_email.Text;
                        customer.website = cust_site.Text;
                        Form1.ent.SaveChanges();
                        UpdateList();
                        MessageBox.Show("Customer Updated Sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("Customer Doesn`t Exists");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Input Data");
                }
            }
            else
            {
                MessageBox.Show("ID is not in the corret form");
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cust_id.Text != ""
               && cust_name.Text != ""
                )
            {
                var tempname = Form1.ent.Customers.
                    Where(name => name.name == cust_name.Text).FirstOrDefault();
                if (tempname != null)
                {
                    Form1.ent.Customers.Remove(tempname);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Customer Removed Sucessfully");
                }
                else
                {
                    MessageBox.Show("Customer Not Found");
                }

            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }
    }
}

