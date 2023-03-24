namespace Warehouse_Project
{
    partial class CustomerInvoicesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.Inv_cust = new System.Windows.Forms.ComboBox();
            this.Inv_Item = new System.Windows.Forms.ComboBox();
            this.Inv_ware = new System.Windows.Forms.ComboBox();
            this.Inv_date = new System.Windows.Forms.DateTimePicker();
            this.sss = new System.Windows.Forms.Label();
            this.d = new System.Windows.Forms.Label();
            this.supp_ida = new System.Windows.Forms.Label();
            this.Inv_Id = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.s = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.Ind_ware = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Inv_quant = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Avil_quant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(534, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 93;
            this.label2.Text = "Available Quantity";
            // 
            // Inv_cust
            // 
            this.Inv_cust.FormattingEnabled = true;
            this.Inv_cust.Location = new System.Drawing.Point(167, 232);
            this.Inv_cust.Name = "Inv_cust";
            this.Inv_cust.Size = new System.Drawing.Size(360, 21);
            this.Inv_cust.TabIndex = 91;
            // 
            // Inv_Item
            // 
            this.Inv_Item.FormattingEnabled = true;
            this.Inv_Item.Location = new System.Drawing.Point(167, 180);
            this.Inv_Item.Name = "Inv_Item";
            this.Inv_Item.Size = new System.Drawing.Size(360, 21);
            this.Inv_Item.TabIndex = 90;
            this.Inv_Item.SelectedIndexChanged += new System.EventHandler(this.Inv_Item_SelectedIndexChanged);
            // 
            // Inv_ware
            // 
            this.Inv_ware.FormattingEnabled = true;
            this.Inv_ware.Location = new System.Drawing.Point(167, 153);
            this.Inv_ware.Name = "Inv_ware";
            this.Inv_ware.Size = new System.Drawing.Size(360, 21);
            this.Inv_ware.TabIndex = 89;
            this.Inv_ware.SelectedIndexChanged += new System.EventHandler(this.Inv_ware_SelectedIndexChanged);
            // 
            // Inv_date
            // 
            this.Inv_date.Location = new System.Drawing.Point(167, 259);
            this.Inv_date.Name = "Inv_date";
            this.Inv_date.Size = new System.Drawing.Size(360, 20);
            this.Inv_date.TabIndex = 87;
            // 
            // sss
            // 
            this.sss.AutoSize = true;
            this.sss.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sss.Location = new System.Drawing.Point(34, 253);
            this.sss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sss.Name = "sss";
            this.sss.Size = new System.Drawing.Size(105, 26);
            this.sss.TabIndex = 86;
            this.sss.Text = "Invoice Date";
            // 
            // d
            // 
            this.d.AutoSize = true;
            this.d.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d.Location = new System.Drawing.Point(52, 227);
            this.d.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(83, 26);
            this.d.TabIndex = 82;
            this.d.Text = "Customer";
            // 
            // supp_ida
            // 
            this.supp_ida.AutoSize = true;
            this.supp_ida.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supp_ida.Location = new System.Drawing.Point(47, 122);
            this.supp_ida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.supp_ida.Name = "supp_ida";
            this.supp_ida.Size = new System.Drawing.Size(84, 26);
            this.supp_ida.TabIndex = 81;
            this.supp_ida.Text = "Invoice Id";
            this.supp_ida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Inv_Id
            // 
            this.Inv_Id.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inv_Id.Location = new System.Drawing.Point(167, 125);
            this.Inv_Id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Inv_Id.Multiline = true;
            this.Inv_Id.Name = "Inv_Id";
            this.Inv_Id.Size = new System.Drawing.Size(360, 21);
            this.Inv_Id.TabIndex = 80;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CadetBlue;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(659, 52);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 47);
            this.button4.TabIndex = 79;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(460, 52);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 47);
            this.button3.TabIndex = 78;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(272, 52);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 47);
            this.button2.TabIndex = 77;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.CadetBlue;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Segoe Print", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button5.Location = new System.Drawing.Point(539, 245);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 34);
            this.button5.TabIndex = 76;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Swis721 BlkEx BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Swis721 BlkEx BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(4, 332);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1076, 294);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.Location = new System.Drawing.Point(71, 175);
            this.s.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(47, 26);
            this.s.TabIndex = 74;
            this.s.Text = "Item";
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a.Location = new System.Drawing.Point(52, 201);
            this.a.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(79, 26);
            this.a.TabIndex = 73;
            this.a.Text = "Quantity";
            // 
            // Ind_ware
            // 
            this.Ind_ware.AutoSize = true;
            this.Ind_ware.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ind_ware.Location = new System.Drawing.Point(52, 147);
            this.Ind_ware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Ind_ware.Name = "Ind_ware";
            this.Ind_ware.Size = new System.Drawing.Size(92, 26);
            this.Ind_ware.TabIndex = 72;
            this.Ind_ware.Text = "Warehouse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swis721 BlkEx BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 32);
            this.label1.TabIndex = 71;
            this.label1.Text = "Customer Invoices";
            // 
            // Inv_quant
            // 
            this.Inv_quant.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inv_quant.Location = new System.Drawing.Point(167, 205);
            this.Inv_quant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Inv_quant.Name = "Inv_quant";
            this.Inv_quant.Size = new System.Drawing.Size(360, 21);
            this.Inv_quant.TabIndex = 70;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCyan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(76, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 47);
            this.button1.TabIndex = 69;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Avil_quant
            // 
            this.Avil_quant.Enabled = false;
            this.Avil_quant.Location = new System.Drawing.Point(693, 186);
            this.Avil_quant.Name = "Avil_quant";
            this.Avil_quant.Size = new System.Drawing.Size(100, 20);
            this.Avil_quant.TabIndex = 94;
            // 
            // CustomerInvoicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.Avil_quant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Inv_cust);
            this.Controls.Add(this.Inv_Item);
            this.Controls.Add(this.Inv_ware);
            this.Controls.Add(this.Inv_date);
            this.Controls.Add(this.sss);
            this.Controls.Add(this.d);
            this.Controls.Add(this.supp_ida);
            this.Controls.Add(this.Inv_Id);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.s);
            this.Controls.Add(this.a);
            this.Controls.Add(this.Ind_ware);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Inv_quant);
            this.Controls.Add(this.button1);
            this.Name = "CustomerInvoicesControl";
            this.Size = new System.Drawing.Size(811, 653);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Inv_cust;
        private System.Windows.Forms.ComboBox Inv_Item;
        private System.Windows.Forms.ComboBox Inv_ware;
        private System.Windows.Forms.DateTimePicker Inv_date;
        private System.Windows.Forms.Label sss;
        private System.Windows.Forms.Label d;
        private System.Windows.Forms.Label supp_ida;
        private System.Windows.Forms.TextBox Inv_Id;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Label Ind_ware;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Inv_quant;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Avil_quant;
    }
}
