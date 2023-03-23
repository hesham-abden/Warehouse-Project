using System.Windows.Forms;

namespace Warehouse_Project
{
    public partial class Form1 : Form
    {
        public int x = 0;

        static public WarehouseProjectEntities1 ent=new WarehouseProjectEntities1();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.warehouseControl1.Hide();
            this.userControl11.Hide();
            this.suppliersControl1.Hide();
            this.customersControl1.Hide();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.warehouseControl1.Show();
            this.userControl11.Hide();
            this.suppliersControl1.Hide();
            this.customersControl1.Hide();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.warehouseControl1.Hide();
            this.userControl11.Show();
            this.suppliersControl1.Hide();
            this.customersControl1.Hide();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.suppliersControl1.Show();
            this.userControl11.Hide();
            this.warehouseControl1.Hide();
            this.customersControl1.Hide();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.suppliersControl1.Hide();
            this.userControl11.Hide();
            this.warehouseControl1.Hide();
            this.customersControl1.Show();
        }
    }
}
