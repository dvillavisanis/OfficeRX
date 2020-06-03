using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Module.Win.Windows.IM
{
    public partial class UserControl1 : UserControl, IComplexControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private IObjectSpace objectSpace;
        void IComplexControl.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            gridControl1.DataSource = objectSpace.GetObjects<ItemInventoryBatchSerialNo>();
            this.objectSpace = objectSpace;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
