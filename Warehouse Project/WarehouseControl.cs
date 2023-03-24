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
    public partial class WarehouseControl : UserControl
    {
        public Warehouse warehouse=new Warehouse();
        public WarehouseControl()
        {
            InitializeComponent();
        }
        public void UpdateList()
        {
            var x = Form1.ent.Warehouses.Select(m => new {
                ID = m.ware_id,
                Name = m.ware_name,
                Manager = m.manager_name,
                Address = m.ware_address
            });

            dataGridView1.DataSource = x.ToList();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int WarehouseID = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            wh_id.Text = WarehouseID.ToString();
            warehouse = Form1.ent.Warehouses.Find(WarehouseID);
            wh_name.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            wh_manager.Text =dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            wh_address.Text= dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            var values = warehouse.Warehouse_Items.Select(i => new
            {
                Item = i.Item.name,
                Unit = i.Item.Units.FirstOrDefault().unit_type,
                Quantity = i.quantity

            }) ;
            dataGridView2.DataSource = values.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tempid;
            if(int.TryParse(wh_id.Text,out tempid)
                &&wh_name.Text!=""
                &&wh_address.Text!=""
                &wh_manager.Text !="")
            {
                var tempname=Form1.ent.Warehouses.Where(name=>name.ware_name==wh_name.Text).FirstOrDefault();
                if (Form1.ent.Warehouses.Find(tempid) == null &&tempname==null)
                {
                    Warehouse newWarehouse = new Warehouse();
                    newWarehouse.ware_id = tempid;
                    newWarehouse.ware_name = wh_name.Text;
                    newWarehouse.ware_address = wh_address.Text;
                    newWarehouse.manager_name = wh_manager.Text;
                    Form1.ent.Warehouses.Add(newWarehouse);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Warehouse Added Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Warehouse Id/Name");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (wh_name.Text!="")
            {
                var tempware = Form1.ent.Warehouses.Where(s => s.ware_name== wh_name.Text).Select(m => new
                {
                    ID = m.ware_id,
                    Name = m.ware_name,
                    Manager = m.manager_name,
                    Address = m.ware_address
                });
                if (tempware!=null)
                {
                    dataGridView1.DataSource = tempware.ToList();
                }
                else
                {
                    MessageBox.Show("Not Found!");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(wh_address.Text!=""
                &&wh_manager.Text!=""
                &&wh_name.Text !="") 
            {
                var tempname = Form1.ent.Warehouses.Where(name => name.ware_name == wh_name.Text).FirstOrDefault();
                if (tempname == null)
                {
                    warehouse.ware_name = wh_name.Text;
                    warehouse.ware_address = wh_address.Text;
                    warehouse.manager_name = wh_manager.Text;
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Warehouse Updated Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Warehouse name");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (wh_id.Text!=""
                &&wh_address.Text != ""
                 && wh_manager.Text != ""
                 && wh_name.Text != "")
            {
                var tempname = Form1.ent.Warehouses.
                    Where(name => name.ware_name == wh_name.Text).FirstOrDefault();
                if(tempname != null)
                {
                    Form1.ent.Warehouses.Remove(tempname);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Warehouse Removed Sucessfully");
                }
                else
                {
                    MessageBox.Show("Warehouse Not Found");
                }

            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }
    }
}
