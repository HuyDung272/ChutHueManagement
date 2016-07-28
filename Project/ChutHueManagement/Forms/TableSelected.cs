using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChutHueManagement.ChutHueManagement
{
    public partial class TableSelected : DevComponents.DotNetBar.Metro.MetroForm
    {
        public TableSelected()
        {
            InitializeComponent();
        }

        private void TableSelected_Load(object sender, EventArgs e)
        {
            this.Size = new Size(432, 123);
        }
    }
}
