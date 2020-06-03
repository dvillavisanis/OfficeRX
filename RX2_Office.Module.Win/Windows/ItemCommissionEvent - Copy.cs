using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Templates;
using System.Collections.Generic;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using DevExpress.Data.Filtering;
using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Win.Windows
{

    public partial class ItemCommissionEvent : PopupFormBase

    {
        public XafApplication application;
        public List<InnerBarcode> INBCList = new List<InnerBarcode>();
        public int innercount = 0;
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


        public ItemCommissionEvent(XafApplication appl)
        {
            application = appl;
            InitializeComponent();


        }




        private void txtOuterScan_Leave(object sender, System.EventArgs e)
        {
            string scan = txtOuterScan.Text;
            GS1DataUtil gdu = new GS1DataUtil();
            if (scan.Length < 30)
            {
                string message = "You did not scan a GS1 2d barcode.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                txtOuterScan.Text = string.Empty;

                txtOuterScan.Focus();
                return;
            }
            gdu.GS1DataConvert(scan);

            string pstring;
            gdu.BarcodeDecodeDictionary.TryGetValue("01", out pstring);
            txtGTIN.Text = pstring;
            gdu.BarcodeDecodeDictionary.TryGetValue("17", out pstring);
            txtExpDt.Text = pstring;

            gdu.BarcodeDecodeDictionary.TryGetValue("10", out pstring);
            txtLot.Text = pstring;
            gdu.BarcodeDecodeDictionary.TryGetValue("21", out pstring);
            txtSerial.Text = pstring;

            txtInnerscan.Focus();
        }



        private void txtInnerscan_Leave(object sender, System.EventArgs e)
        {

            string scan = txtInnerscan.Text;
            if (scan == string.Empty)
            {
                return;
            }
            GS1DataUtil gdu = new GS1DataUtil();
            if (scan.Length < 30)
            {
                string message = "You did not scan a GS1 2d barcode.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                txtInnerscan.Text = string.Empty;
                txtInnerscan.Focus();

            }
            gdu.GS1DataConvert(scan);

            string pgtin;
            string pexpdate;
            string plot;
            string pserial;
            gdu.BarcodeDecodeDictionary.TryGetValue("01", out pgtin);
            gdu.BarcodeDecodeDictionary.TryGetValue("17", out pexpdate);
            gdu.BarcodeDecodeDictionary.TryGetValue("10", out plot);
            gdu.BarcodeDecodeDictionary.TryGetValue("21", out pserial);
            if (plot != txtLot.Text)
            {
                string message = "Inner Lot does not match Outer Lot.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                txtInnerscan.Text = string.Empty;
                txtInnerscan.Focus();
                return;
            }

            if (INBCList.Exists(x => x.serial == pserial))
            {
                string message = string.Format("Duplicate Serial Number {0} found.", pserial);
                string caption = "Error Duplicate Scan";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                txtInnerscan.Text = string.Empty;
                txtInnerscan.Focus();
                return;
            }

            INBCList.Add(new InnerBarcode(pgtin, plot, pserial, pexpdate));
            txtInnerscan.Text = string.Empty;
            txtInnerscan.Focus();
            lbInnerscanns.Items.Add(pgtin + ", " + plot + ", " + pserial);
            innercount++;
        }

        private void Clear_Click(object sender, System.EventArgs e)
        {
            Clearinfo();

        }
        private void Clearinfo()
        {
            // clear out the commission
            txtSerial.Text = string.Empty;
            txtOuterScan.Text = string.Empty;
            txtInnerscan.Text = string.Empty;
            txtGTIN.Text = string.Empty;
            txtLot.Text = string.Empty;
            txtExpDt.Text = string.Empty;
            lbInnerscanns.Items.Clear();
            INBCList.Clear();
            txtOuterScan.Focus();
        }

        private void btnCommission_Click(object sender, System.EventArgs e)
        {
            //       IObjectSpace objectSpace = XafApplication.cre;

            IObjectSpace objectSpace = this.application.CreateObjectSpace();

            CriteriaOperator op = CriteriaOperator.Parse("RepackLot.LotId = ? AND SerialNo = ? AND GTIN = ?", txtLot.Text, txtSerial.Text,txtGTIN.Text);
            RepackLotSerialNo lsnOutside = objectSpace.FindObject<RepackLotSerialNo>(op);
            if (lsnOutside == null) return;

            lsnOutside.IsCommission = true;
            lsnOutside.Save();
            objectSpace.CommitChanges();
            // scroll through the list and find the serial number in the system
            //  IObjectSpace objectSpace = Application.ObjectSpaceProvider.CreateObjectSpace()
            //ObjectSpace os = new ObjectSpace(new UnitOfWork(Session.DataLayer), XafTypesInfo.Instance);
            RepackLotSerialNo lsna;
            foreach (var barcode in INBCList)
            {
                eLabelType aLabelType;
                op = CriteriaOperator.Parse("RepackLot.LotId = ? AND LabelType = ? AND SerialNo = ?", barcode.lot, 0 ,barcode.serial);
                lsna = objectSpace.FindObject<RepackLotSerialNo>(op);
                if (lsna == null) return;
                lsna.ParentSerialNo = txtSerial.Text;
                lsna.IsCommission = true;
                lsna.Save();
                objectSpace.CommitChanges();
            }

            Clearinfo();

        }

        private void txtOuterScan_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
    public class InnerBarcode
        {
            public InnerBarcode(string pgtin, string plot, string pserial, string pexdate)
            {
                gtin = pgtin;
                lot = plot;
                serial = pserial;
                expdate = pexdate;
            }
            public string gtin { get; set; }
            public string lot { get; set; }
            public string serial { get; set; }
            public string expdate { get; set; }

        }
    }
