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
        }


    }
}
