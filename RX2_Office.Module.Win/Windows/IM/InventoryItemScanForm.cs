using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
using System.Collections.Generic;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraEditors;
using RX2_Office.Module.BusinessObjects.BusinessLogic;

using System.Windows.Forms;
using System;
using DevExpress.XtraBars;
using RX2_Office.Module.BusinessObjects;
using DevExpress.Xpo;
using System.Data.SqlClient;
using View = DevExpress.ExpressApp.View;
using DevExpress.CodeParser;
using System.ComponentModel;

namespace RX2_Office.Module.Win.Windows.ItemInventoryScan
{
    public partial class InventoryItemScanForm : PopupFormBase
    {
        BarcodeUtil2 bcutil = new BarcodeUtil2();
        ItemInventoryBatch IIB;
        protected override XafLayoutControl BottomPanel
        {
            get { return bottomPanel; }
        }
        protected override PanelControl ViewSitePanel
        {
            get { return viewSitePanel; }
        }
        protected override ViewSiteManager ViewSiteManager
        {
            get { return viewSiteManager; }
        }
        protected override FormStateModelSynchronizer FormStateModelSynchronizer
        {
            get { return formStateModelSynchronizer; }
        }
        public override ICollection<IActionContainer> GetContainers()
        {
            return actionContainersManager.GetContainers();
        }
        public override IActionContainer DefaultContainer
        {
            get { return actionContainersManager.DefaultContainer; }
        }
        public ButtonsContainer ButtonsContainer
        {
            get { return buttonsContainer; }
        }
        public ButtonsContainer DiagnosticContainer
        {
            get { return diagnosticContainer; }
        }
        public override object ViewSiteControl
        {
            get { return viewSitePanel; }
        }
        public override DevExpress.XtraBars.BarManager BarManager
        {
            get { return xafBarManager; }
        }
        public InventoryItemScanForm(ItemInventoryBatch iib)

        {
           

                IIB = iib;

            InitializeComponent();
            this.Text = "Item Scans for: " + IIB.BatchDiscription;
            
            
            DXGridSerialNoList.DataSource = new XPCollection<ItemInventoryBatchSerialNo>( iib.Session           );
            DXGridSerialNoList.DataSource = SampleDS();
        }
        public BindingList<Entry> SampleDS()
        {
            BindingList<Entry> ds = new BindingList<Entry>();
            ds.Add(new Entry("NDC", 1));
            ds.Add(new Entry("Lot", 2));
            ds.Add(new Entry("QTY", 3));
            ds.AllowNew = true;
            return ds;
        }
        public class Entry
        {
            public Entry() { }
            public Entry(string name, Int32 id)
            {
                Name = name; ID = id;
            }
            public string Name { get; set; }
            public Int32 ID { get; set; }
        }

        private int FindBarcodeInlist(string scan)
        {
            int rec = -1;
            int currentrow = 0;
            if (RecordgridList.RowCount > 1)
            {
                foreach (DataGridViewRow row in RecordgridList.Rows)
                {
                    row.Selected = false;
                    currentrow++;
                    if ((row.Cells[5].Value != null) && (row.Cells[5].Value.ToString().Equals(scan)))
                    {
                        row.Selected = true;

                        rec = currentrow;

                        break;
                    }
                }
            }
            return rec;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NDC"></param>
        /// <param name="Lot"></param>
        /// <param name="Qty"></param>
        private void addItemSummary(string NDC, string Lot, string expDt, int Qty)
        {
            bool found = false;
            if (itemSummaryList.RowCount > 1)
            {

                foreach (DataGridViewRow row in itemSummaryList.Rows)
                {
                    row.Selected = false;

                    if ((row.Cells[0].Value != null) && (row.Cells[0].Value.ToString().Equals(NDC)) && (row.Cells[2].Value.ToString().Equals(Lot)))
                    {
                        found = true;
                        row.Selected = true;
                        Int32 qty = Int32.Parse(row.Cells[3].Value.ToString()) + Qty;
                        //string[] newrow = new string[] { NDC, expDt.ToString(), Lot , qty.ToString() };
                        row.Cells[3].Value = qty.ToString();

                        break;

                        
                    }

                }
                



            }
            if (!found)
            {
                string[] newrow = new string[] { NDC, expDt.ToString(), Lot, Qty.ToString() };
                itemSummaryList.Rows.Add(newrow);

            }

        }



        /// <summary>
        ///Scanning will cause this to trigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_Leave(object sender, System.EventArgs e)
        {
            string scan = txtBarcode.Text;
            BarcodeUtil2 gdu = new BarcodeUtil2();
            if (scan.ToString() == string.Empty)
            {
                return;
            }
            if (scan.Length < 30)
            {
                string message = "You did not scan a GS1 2d barcode.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                txtBarcode.Text = string.Empty;
                txtBarcode.Focus();

                txtBarcode.Clear();
                return;
            }

            Dictionary<string, string> BarcodeDecodeDictionary;
            BarcodeDecodeDictionary = gdu.decodeBarcodeGS1Pharma(scan);
            
            string pstring;

            BarcodeDecodeDictionary.TryGetValue("01", out pstring);

            txtItemNumber.Text = pstring;


            BarcodeDecodeDictionary.TryGetValue("17", out pstring);
            txtExpDt.Text = pstring;

            BarcodeDecodeDictionary.TryGetValue("10", out pstring);
            txtLot.Text = pstring;

            BarcodeDecodeDictionary.TryGetValue("21", out pstring);
            txtSerialNumber.Text = pstring;

            if (FindBarcodeInlist(scan) < 1)
            {
                string[] row = new string[] { txtItemNumber.Text, gdu.GtinToNDC(txtItemNumber.Text), txtSerialNumber.Text, txtExpDt.Text, txtLot.Text, scan };
                RecordgridList.Rows.Add(row);
               


                this.addItemSummary(gdu.GtinToNDC(txtItemNumber.Text), txtLot.Text, txtExpDt.Text, 1);
            }

            txtBarcode.Focus();
            txtBarcode.Clear();


        }

        private void txtBarcode_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void viewSitePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            Session s = new Session();
            ItemInventory itemInv = new ItemInventory(s);

            for (int i = 0; i < itemSummaryList.RowCount; i++)
            {
                
            }



        }

       
    }
}