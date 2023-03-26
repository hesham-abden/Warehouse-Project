using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Project
{
    public partial class SupplierInvoicesControl : UserControl
    {
       
        Supplier_invoice supplier_Invoice = new Supplier_invoice();
        List<TextBox> textBoxes = new List<TextBox>();
        List<ComboBox> comboBoxes = new List<ComboBox>();
        
        public SupplierInvoicesControl()
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
            var list = Form1.ent.Supplier_invoice.Select(m => new
            {
                InvoiceId = m.invoice_id,
                Supplier = m.Supplier.name,
                Warehouse = m.Warehouse.ware_name,
                Item = m.Item.name,
                Quantity = m.item_quantity,
                InvoiceDate = m.invoice_date,
                ManufDate = m.manufacture_date,
                DurationinMonths = m.duration_month
            });

            dataGridView1.DataSource = list.ToList();
        }
        public void UpdateWareItemSupp()
        {
            Inv_ware.Items.Clear();
            Inv_supp.Items.Clear();
            Inv_Item.Items.Clear();
            foreach (var item in Form1.ent.Warehouses)
            {
                Inv_ware.Items.Add(item.ware_name);
            }
            foreach (var item in Form1.ent.Items)
            {
                Inv_Item.Items.Add(item.name);
            }
            foreach (var item in Form1.ent.Suppliers)
            {
                Inv_supp.Items.Add(item.name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            UpdateList();
            UpdateWareItemSupp();
            UpdateQuantity();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int InvoiceId = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            Inv_Id.Text = InvoiceId.ToString();
            supplier_Invoice = Form1.ent.Supplier_invoice.Find(InvoiceId);
            Inv_supp.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            Inv_ware.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            Inv_Item.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            Inv_quant.Text = dataGridView1.Rows[RowIndex].Cells[4].Value.ToString();
            Inv_date.Text = dataGridView1.Rows[RowIndex].Cells[5].Value.ToString();
            Inv_manu_date.Text = dataGridView1.Rows[RowIndex].Cells[6].Value.ToString();
            Inv_exp_dur.Text = dataGridView1.Rows[RowIndex].Cells[7].Value.ToString();
            UpdateQuantity();


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
                var tempsupp = Form1.ent.Suppliers.Where(supp => supp.name == Inv_supp.SelectedItem.ToString()).FirstOrDefault();
                if (Form1.ent.Supplier_invoice.Find(tempid) == null && tempware != null
                    && tempitem != null && tempsupp != null)
                {
                    Supplier_invoice newSupplierInvoice = new Supplier_invoice();
                    newSupplierInvoice.invoice_id = tempid;
                    newSupplierInvoice.ware_id = Form1.ent.Warehouses.Where(ware => ware.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault().ware_id;
                    newSupplierInvoice.item_id = Form1.ent.Items.Where(item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault().code;
                    
                    newSupplierInvoice.supplier_id = Form1.ent.Suppliers.Where(supp => supp.name == Inv_supp.SelectedItem.ToString()).FirstOrDefault().id;
                    newSupplierInvoice.manufacture_date = Inv_manu_date.Value.Date;
                    newSupplierInvoice.invoice_date = Inv_date.Value.Date;
                    if (!int.TryParse(Inv_exp_dur.Text, out int y))
                    { MessageBox.Show("Duration is not in the correct form"); return; }
                    else { newSupplierInvoice.duration_month = y; }
                    if(!int.TryParse(Inv_quant.Text, out int x))
                    { MessageBox.Show("Quantity is not in the correct form"); return; }
                    else { newSupplierInvoice.item_quantity = x; }
                    newSupplierInvoice.invoice_date = Inv_date.Value.Date;
                    var availitem = Form1.ent.Warehouse_Items.Where
                    (item => item.ware_id == tempware.ware_id && item.item_id == tempitem.code).FirstOrDefault();
                    if (availitem == null)
                    { 
                    Warehouse_Items warehouse_Items = new Warehouse_Items();
                    warehouse_Items.ware_id = newSupplierInvoice.ware_id;
                    warehouse_Items.item_id = newSupplierInvoice.item_id;
                    warehouse_Items.quantity = newSupplierInvoice.item_quantity;
                    Form1.ent.Warehouse_Items.Add(warehouse_Items);
                    }
                    else
                    {
                        availitem.quantity += newSupplierInvoice.item_quantity;
                    }
                    Form1.ent.Supplier_invoice.Add(newSupplierInvoice);
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

        



        private void button5_Click(object sender, EventArgs e)
        {
            if (Inv_supp.SelectedItem != null)
            {
                int tempsuppid = Form1.ent.Suppliers.Where(supp => supp.name == Inv_supp.SelectedItem.ToString()).FirstOrDefault().id;
                var tempsupp = Form1.ent.Supplier_invoice.Where(s => s.supplier_id == tempsuppid).Select(m => new
                {
                    InvoiceId = m.invoice_id,
                    Supplier = m.Supplier.name,
                    Warehouse = m.Warehouse.ware_name,
                    Item = m.Item.name,
                    Quantity = m.item_quantity,
                    InvoiceDate = m.invoice_date,
                    ManufDate = m.manufacture_date,
                    Duration = m.duration_month
                });
                if (tempsupp.Count() != 0)
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
            int tempid;
            if (int.TryParse(Inv_Id.Text, out tempid)
                && textBoxes.TrueForAll(m => m.Text != "")
                && comboBoxes.TrueForAll(m => m.SelectedItem != null)
                )
            {
                var _Invoice = Form1.ent.Supplier_invoice.Where(name => name.invoice_id == tempid).FirstOrDefault();
                if (_Invoice != null)
                {
                    _Invoice.ware_id = Form1.ent.Warehouses.Where
                        (ware => ware.ware_name == Inv_ware.SelectedItem.ToString()).FirstOrDefault().ware_id;
                    _Invoice.item_id = Form1.ent.Items.Where
                        (item => item.name == Inv_Item.SelectedItem.ToString()).FirstOrDefault().code;
                    _Invoice.supplier_id = Form1.ent.Suppliers.Where
                        (supp => supp.name == Inv_supp.SelectedItem.ToString()).FirstOrDefault().id;
                    var availitem = Form1.ent.Warehouse_Items.Where
                   (item => item.ware_id == _Invoice.ware_id && item.item_id == _Invoice.item_id).FirstOrDefault();
                    if (!int.TryParse(Inv_quant.Text, out int x)&&availitem!=null)
                    { MessageBox.Show("Quantity is not in the correct form"); return; }
                    else {
                        availitem.quantity += (x - _Invoice.item_quantity);
                        _Invoice.item_quantity = x;

                    }
                    _Invoice.invoice_date = Inv_date.Value.Date;
                    _Invoice.manufacture_date = Inv_manu_date.Value.Date;
                    if (!int.TryParse(Inv_exp_dur.Text, out int y))
                    { MessageBox.Show("Duration is not in the correct form"); return; }
                    else { _Invoice.duration_month = y; }
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
                var _invoice = Form1.ent.Supplier_invoice.
                    Where(inv => inv.invoice_id == tempid).FirstOrDefault();
                if (_invoice != null)
                {
                    Form1.ent.Supplier_invoice.Remove(_invoice);
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
    }
}

