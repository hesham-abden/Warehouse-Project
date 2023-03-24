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
    public partial class CustomerInvoicesControl : UserControl
    {
        Customer_invoice customer_Invoice = new Customer_invoice();
        List<TextBox> textBoxes = new List<TextBox>();
        List<ComboBox> comboBoxes = new List<ComboBox>();
        public CustomerInvoicesControl()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                    textBoxes.Add(item as TextBox);
                if (item is ComboBox)
                    comboBoxes.Add(item as ComboBox);
            }

           
        }
        public void UpdateList()
        {
            var list = Form1.ent.Customer_invoice.Select(m => new
            {
                InvoiceId = m.invoice_id,
                Customer = m.Customer.name,
                Warehouse = m.Warehouse.ware_name,
                Item = m.Item.name,
                Quantity = m.item_quantity,
                InvoiceDate = m.invoice_date,
            });

            dataGridView1.DataSource = list.ToList();
        }
        public void UpdateWareItemCust()
        {
            Inv_ware.Items.Clear();
            Inv_cust.Items.Clear();
            Inv_Item.Items.Clear();
            foreach (var item in Form1.ent.Warehouses)
            {
                Inv_ware.Items.Add(item.ware_name);
            }
            foreach (var item in Form1.ent.Items)
            {
                Inv_Item.Items.Add(item.name);
            }
            foreach (var item in Form1.ent.Customers)
            {
                Inv_cust.Items.Add(item.name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
            UpdateWareItemCust();
            UpdateQuantity();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int InvoiceId = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            Inv_Id.Text = InvoiceId.ToString();
            customer_Invoice = Form1.ent.Customer_invoice.Find(InvoiceId);
            Inv_cust.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            Inv_ware.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            Inv_Item.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            Inv_quant.Text = dataGridView1.Rows[RowIndex].Cells[4].Value.ToString();
            Inv_date.Text = dataGridView1.Rows[RowIndex].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tempid;
            if (int.TryParse(Inv_Id.Text, out tempid)
                && textBoxes.TrueForAll(m => m.Text != "")
                && comboBoxes.TrueForAll(m => m.SelectedItem != null)
                )
            {
                var tempware = Form1.ent.Warehouses.Where(item => item.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault();
                var tempitem = Form1.ent.Items.Where(item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault();
                var tempcust = Form1.ent.Customers.Where(supp => supp.name == Inv_cust.SelectedItem.ToString()).FirstOrDefault();
                if (Form1.ent.Customer_invoice.Find(tempid) == null && tempware != null
                    && tempitem != null && tempcust != null)
                {
                    Customer_invoice newInvoice = new Customer_invoice();
                    newInvoice.invoice_id = tempid;
                    newInvoice.ware_id = Form1.ent.Warehouses.Where(ware => ware.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault().ware_id;
                    newInvoice.item_id = Form1.ent.Items.Where(item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault().code;
                    newInvoice.customer_id = Form1.ent.Customers.Where(cust => cust.name == Inv_cust.SelectedItem.ToString()).FirstOrDefault().id;
                    if (!int.TryParse(Inv_quant.Text, out int x))
                    { MessageBox.Show("Quantity is not in the correct form"); return; }
                    else { newInvoice.item_quantity = x; }
                    newInvoice.invoice_date = Inv_date.Value.Date;
                    var availitem = Form1.ent.Warehouse_Items.Where
                   (item => item.ware_id == tempware.ware_id && item.item_id == tempitem.code).FirstOrDefault();
                    if (availitem == null)
                    {
                        MessageBox.Show("Not Available Quantity");
                        return;
                    }
                    else
                    {
                        if (x <= int.Parse(Avil_quant.Text))
                        availitem.quantity -= newInvoice.item_quantity; 
                        else
                        { MessageBox.Show("Not Available Quantity"); return; }
                    }
                    Form1.ent.Customer_invoice.Add(newInvoice);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    UpdateQuantity();
                    MessageBox.Show("Invoice Added Sucessfully");
                }
                else
                {
                    MessageBox.Show("Duplicated Invoice Id");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tempid;
            int newquant=0;
            if (int.TryParse(Inv_Id.Text, out tempid)
                && textBoxes.TrueForAll(m => m.Text != "")
                && comboBoxes.TrueForAll(m => m.SelectedItem != null
                && int.TryParse(Inv_quant.Text, out newquant))
                )
            {
                var _Invoice = Form1.ent.Customer_invoice.Where(name => name.invoice_id == tempid).FirstOrDefault();
                if (_Invoice != null)
                {
                    _Invoice.ware_id = Form1.ent.Warehouses.Where
                        (ware => ware.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault().ware_id;
                    _Invoice.item_id = Form1.ent.Items.Where
                        (item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault().code;
                    _Invoice.customer_id = Form1.ent.Customers.Where
                        (supp => supp.name == Inv_cust.SelectedItem.ToString()).FirstOrDefault().id;
                    _Invoice.invoice_date = Inv_date.Value.Date;

                    var availitem = Form1.ent.Warehouse_Items.Where
                   (item => item.ware_id == _Invoice.ware_id && item.item_id == _Invoice.item_id).FirstOrDefault();
                    if (availitem == null||
                        availitem.quantity-(newquant-_Invoice.item_quantity)<0)
                    {
                        MessageBox.Show("Not Available Quantity");
                        return;
                    }
                    else
                    {
                        availitem.quantity += (_Invoice.item_quantity - newquant);
                        _Invoice.item_quantity = newquant;
                    }







                    Form1.ent.SaveChanges();
                    UpdateList();
                    UpdateQuantity();
                    MessageBox.Show("Invoice Updated Sucessfully");
                }
                else
                {
                    MessageBox.Show("Invoice Doesn`t Exists");
                }
            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int tempid;
            if (int.TryParse(Inv_Id.Text, out tempid))
            {
                var _invoice = Form1.ent.Customer_invoice.
                    Where(inv => inv.invoice_id == tempid).FirstOrDefault();
                if (_invoice != null)
                {
                    Form1.ent.Customer_invoice.Remove(_invoice);
                    Form1.ent.SaveChanges();
                    UpdateList();
                    UpdateQuantity();
                    MessageBox.Show("Invoice Removed Sucessfully");
                }
                else
                {
                    MessageBox.Show("Invoice Not Found");
                }

            }
            else
            {
                MessageBox.Show("Invalid Input Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Inv_cust.SelectedItem != null)
            {
                int tempcustid = Form1.ent.Customers.Where(supp => supp.name == Inv_cust.SelectedItem.ToString()).FirstOrDefault().id;
                var tempcust = Form1.ent.Customer_invoice.Where(s => s.customer_id == tempcustid).Select(m => new
                {
                    InvoiceId = m.invoice_id,
                    Supplier = m.Customer.name,
                    Warehouse = m.Warehouse.ware_name,
                    Item = m.Item.name,
                    Quantity = m.item_quantity,
                    InvoiceDate = m.invoice_date,
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

        private void Inv_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuantity();
        }
        public void UpdateQuantity()
        {
            if (Inv_ware.SelectedItem != null &&
                Inv_Item.SelectedItem != null)
            {
                Avil_quant.Text = "0";
                var tempware = Form1.ent.Warehouses.Where
                    (ware => ware.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault();

                var tempitem = Form1.ent.Items.Where
                    (item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault();

                if (tempware != null && tempitem != null)
                {

                    var availitem = Form1.ent.Warehouse_Items.Where
                        (item => item.ware_id == tempware.ware_id && item.item_id == tempitem.code).FirstOrDefault();
                    if (availitem != null)
                        Avil_quant.Text = availitem.quantity.ToString();
                }
            }
        }

        private void Inv_ware_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuantity();
        }
    }
}
