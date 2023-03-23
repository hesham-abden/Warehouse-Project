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
    public partial class SuppliersControl : UserControl
    {   
        Supplier supplier=new Supplier();   
        public SuppliersControl()
        {
            InitializeComponent();
        }
        public void UpdateList()
        {
            var list = Form1.ent.Suppliers.Select(m => new
            {
                ID = m.id,
                Name = m.name,
                Email = m.email,
                Phone = m.phone,
                Mobile = m.mobile,
                Fax = m.fax,
                Website=m.website
            }) ;

            dataGridView1.DataSource = list.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int SupplierId = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            supp_id.Text = SupplierId.ToString();
            supplier= Form1.ent.Suppliers.Find(SupplierId);
            supp_name.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            supp_email.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            supp_mobile.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            supp_fax.Text = dataGridView1.Rows[RowIndex].Cells[4].Value.ToString();
            supp_phone.Text = dataGridView1.Rows[RowIndex].Cells[5].Value.ToString();
            supp_site.Text = dataGridView1.Rows[RowIndex].Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tempid;
            if (int.TryParse(supp_id.Text, out tempid)
                && supp_name.Text != "")
            {
                var tempname = Form1.ent.Suppliers.Where(name => name.name == supp_name.Text).FirstOrDefault();
                if (Form1.ent.Suppliers.Find(tempid) == null && tempname == null)
                {
                    Supplier newSupplier = new Supplier();
                    newSupplier.id = tempid;
                    newSupplier.name = supp_name.Text;
                    newSupplier.phone = supp_phone.Text;
                    newSupplier.email= supp_email.Text;
                    newSupplier.fax = supp_fax.Text;
                    newSupplier.mobile = supp_mobile.Text;
                    newSupplier.website = supp_site.Text;
                    Form1.ent.Suppliers.Add(newSupplier);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Supplier Added Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Supplier Id/Name");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (supp_name.Text != "")
            {
                var tempsupp = Form1.ent.Suppliers.Where(s => s.name == supp_name.Text).Select(m => new
                {
                    ID = m.id,
                    Name = m.name,
                    Email = m.email,
                    Phone = m.phone,
                    Mobile = m.mobile,
                    Fax = m.fax,
                    Website = m.website
                });
                if (tempsupp.Count()!=0)
                {
                    dataGridView1.DataSource = tempsupp.ToList();
                }
                else
                {
                    MessageBox.Show("NOT FOUND!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (supp_id.Text != ""
                && supp_name.Text != ""
                                        )
            {
                int tempid;
                if (int.TryParse(supp_id.Text, out tempid))
                {
                    var tempsupp = Form1.ent.Suppliers.Where(name => name.id == tempid).FirstOrDefault();
                    if (tempsupp != null)
                    {
                        supplier.name = supp_name.Text;
                        supplier.phone = supp_phone.Text;
                        supplier.mobile = supp_mobile.Text;
                        supplier.fax = supp_fax.Text;
                        supplier.email = supp_email.Text;
                        supplier.website = supp_site.Text;
                        Form1.ent.SaveChanges();
                        UpdateList();
                        MessageBox.Show("Supplier Updated Sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("Supplier Doesn`t Exists");
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
            if (supp_id.Text != ""
               && supp_name.Text != ""
                )
            {
                var tempname = Form1.ent.Suppliers.
                    Where(name => name.name == supp_name.Text).FirstOrDefault();
                if (tempname != null)
                {
                    Form1.ent.Suppliers.Remove(tempname);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Supplier Removed Sucessfully");
                }
                else
                {
                    MessageBox.Show("Supplier Not Found");
                }

            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }
    }
}
