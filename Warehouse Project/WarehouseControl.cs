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
        public WarehouseControl()
        {
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = Form1.ent.Warehouses.Select(m => new { W=m.ware_id, S=m.ware_name });
            dataGridView1.DataSource = x.ToList();
        }
    }
}
