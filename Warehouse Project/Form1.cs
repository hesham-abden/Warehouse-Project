using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Warehouse_Project
{
    public partial class Form1 : Form
    {
        

        static public WarehouseProjectEntities ent=new WarehouseProjectEntities();

        List<Control> CustomControls;
        public Form1()
        {
            InitializeComponent();
            CustomControls = new List<Control>(new Control[] { warehouseControl1,
                supplierInvoicesControl1,
                customerInvoicesControl1,
                suppliersControl1,
                itemsControl1,
                customersControl1,reportsControl1});
            this.WindowState = FormWindowState.Maximized;

            ShowControl(this.warehouseControl1);
       

        }
        public  void ShowControl(Control control)
        {
            CustomControls.ForEach(c => c.Hide());
            control.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.warehouseControl1);


        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.itemsControl1);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.suppliersControl1);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.customersControl1);

        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.supplierInvoicesControl1);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.customerInvoicesControl1);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            ShowControl(this.reportsControl1);
            reportsControl1.UpdateWare();
        }

        
    }
}
