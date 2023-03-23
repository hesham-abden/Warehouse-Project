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
    public partial class ItemsControl : UserControl
    {
        Item item=new Item();
        public ItemsControl()
        {
            InitializeComponent();
        }
        public void UpdateList()
        {
            var list = Form1.ent.Items.Select(m => new
            {
                ID = m.code,
                Name = m.name,
                unit = m.Units.FirstOrDefault().unit_type,
                value = m.Units.FirstOrDefault().unit_value

            });

            dataGridView1.DataSource = list.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox1.Items.Clear();
                int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int ItemId = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
                item_code.Text = ItemId.ToString();
                item = Form1.ent.Items.Find(ItemId);
                item_name.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                item_unit.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
                item_unitval.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            foreach (var unit in item.Units)
            {
                listBox1.Items.Add($"Unit : {unit.unit_type}  Value : {unit.unit_value}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tempid;
            if (int.TryParse(item_code.Text, out tempid)
                && item_name.Text != "")
            {
                var tempname = Form1.ent.Items.Where(name => name.name == item_name.Text).FirstOrDefault();
                if (Form1.ent.Items.Find(tempid) == null && tempname == null)
                {
                    Item newItem = new Item();
                    newItem.code = tempid;
                    newItem.name = item_name.Text;
                    Unit unit = new Unit();
                    unit.item_code= tempid;
                    unit.unit_type = item_unit.Text;
                    int tempunitvalue =1;
                    if( int.TryParse(item_unitval.Text,out tempunitvalue))
                    { unit.unit_value = tempunitvalue; }
                    newItem.Units.Add(unit);
                    Form1.ent.Items.Add(newItem);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Item Added Sucessfully");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (item_name.Text != ""
                && item_unit.Text != ""
                && item_unitval.Text != "")
            {
                var tempname = Form1.ent.Items.Where(name => name.name == item_name.Text).FirstOrDefault();
                if (tempname == null)
                {
                    item.name = item_name.Text;
                    item.Units.FirstOrDefault().unit_type = item_unit.Text;
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Item Updated Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Item name");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (item_name.Text != "")
            {
                var tempitem = Form1.ent.Items.Where(s => s.name == item_name.Text).Select(m => new
                {
                    Code = m.code,
                    Name = m.name,
                    unit = m.Units.FirstOrDefault().unit_type,
                    value = m.Units.FirstOrDefault().unit_value
                });
                if (tempitem.Count()!=0)
                {
                    dataGridView1.DataSource = tempitem.ToList();
                }
                else
                {
                    MessageBox.Show("Not Found!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (item_name.Text != ""
                && item_unit.Text != ""
                 && item_unitval.Text != ""
                 )
            {
                var tempname = Form1.ent.Items.
                    Where(name => name.name == item_name.Text).FirstOrDefault();
                if (tempname != null)
                {
                    Form1.ent.Items.Remove(tempname);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    MessageBox.Show("Item Removed Sucessfully");
                }
                else
                {
                    MessageBox.Show("Item Not Found");
                }

            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }
    }
}
