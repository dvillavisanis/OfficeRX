using DevExpress.ExpressApp;

using DevExpress.ExpressApp.Actions;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using Seagull.BarTender.Print;
using Seagull.BarTender.Print.Database;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

using System.Windows.Forms;
using static RX2_Office.Module.BusinessObjects.BusinessLogic.RFEXCEL;

namespace RX2_Office.Module.Controllers.WO
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class RepackLabelPrint : ViewController
    {
        private eRFXLImpType impType = eRFXLImpType.Production;
        private Engine engine = null; // The BarTender Print Engine
        private LabelFormatDocument format = null; // The currently open Format
        public RepackLabelPrint()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void RepackPrintLabel_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            if (e.SelectedObjects.Count > 0) // test
            {
                string path = @"c:\BTData";
                string xlsfilename = path + @"\btdata.xls";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                int ret = CreateLabelSpreadsheet(e, xlsfilename);
                if (ret == 1)
                {
                    PrintBTLabels(e, xlsfilename);
                    MarkAsPrinted(e);

                }
                View.ObjectSpace.CommitChanges();
                View.ObjectSpace.Refresh();
            }
        }

        private void MarkAsPrinted(PopupWindowShowActionExecuteEventArgs e)
        {
            foreach (RepackLotSerialNo rlsn in e.SelectedObjects)
            {
                rlsn.Isprinted = true;
                rlsn.Save();
                
            }


        }

        private int CreateLabelSpreadsheet(PopupWindowShowActionExecuteEventArgs e, string filename)
        {

            npRepackLabelParm lotGenSerial = (npRepackLabelParm)e.PopupWindowView.CurrentObject;

            DataTable _datatable = new DataTable("NDCLabels");

            DataColumn col1 = new DataColumn("ItemNumber");
            col1.Caption = "ItemNumber";
            col1.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col1);

            DataColumn col2 = new DataColumn("NDCDescription");
            col2.Caption = "NDC Description";
            col2.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col2);

            DataColumn col3 = new DataColumn("NDCLabelContains");
            col3.Caption = "NDC Labelcontains";
            col3.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col3);

            DataColumn col4 = new DataColumn("LabelStorageInfo");
            col4.Caption = "Ndc Storage Info";
            col4.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col4);

            DataColumn col5 = new DataColumn("NDCLot");
            col5.Caption = "NDC Lot";
            col5.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col5);

            DataColumn col6 = new DataColumn("SerialNumber");
            col6.Caption = "Serial Number";
            col6.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col6);

            DataColumn col7 = new DataColumn("ExpirationDate");
            col7.Caption = "Expiration Date";
            col7.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col7);

            DataColumn col8 = new DataColumn("PackageQty");
            col8.Caption = "Package Qty";
            col8.DataType = Type.GetType("System.Int32");
            _datatable.Columns.Add(col8);

            DataColumn col9 = new DataColumn("ManufactureName");
            col9.Caption = "ManufactureName";
            col9.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col9);

            DataColumn col10 = new DataColumn("ManufactureAddress");
            col10.Caption = "Manufacture Address";
            col10.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col10);


            DataColumn col11 = new DataColumn("RepackagedBy");
            col11.Caption = "RepackagedBy";
            col11.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col11);

            DataColumn col12 = new DataColumn("RepackagedByAddress");
            col12.Caption = "RepackagedByAddress";
            col12.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col12);


            DataColumn col13 = new DataColumn("DistributedBy");
            col13.Caption = "DistributedBy";
            col13.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col13);

            DataColumn col14 = new DataColumn("DistributedByAddress");
            col14.Caption = "DistributedByAddress";
            col14.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col14);

            DataColumn col15 = new DataColumn("DistributedByPhone");
            col15.Caption = "DistributedByPhone";
            col15.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col15);

            DataColumn col16 = new DataColumn("NdcSizeStrength");
            col16.Caption = "NdcSizeStrength";
            col16.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col16);

            DataColumn col17 = new DataColumn("NdcGTIN");
            col17.Caption = "NdcGtin";
            col17.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col17);

            DataColumn col18 = new DataColumn("DeaClass");
            col18.Caption = "DeaClass";
            col18.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col18);

            DataColumn col19 = new DataColumn("CaseQty");
            col19.Caption = "CaseQty";
            col19.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col19);

            DataColumn col20 = new DataColumn("NDC");
            col20.Caption = "NDC";
            col20.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col20);

            DataColumn col21 = new DataColumn("NDCName");
            col21.Caption = "NDCName";
            col21.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col21);

            DataColumn col22 = new DataColumn("ShippingGTIN");
            col22.Caption = "ShippingGTIN";
            col22.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col22);

            DataColumn col23 = new DataColumn("PalletFullSSCC");
            col23.Caption = "PalletFullSSCC";
            col23.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col23);

            DataColumn col24 = new DataColumn("PalletPartialSSCC");
            col24.Caption = "PalletPartialSSCC";
            col24.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col24);

            DataColumn col25 = new DataColumn("PalletQty");
            col25.Caption = "PalletQty";
            col25.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col25);

            DataColumn col26 = new DataColumn("PalletShipToLine1");
            col26.Caption = "PalletShipToLine1";
            col26.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col26);

            DataColumn col27 = new DataColumn("PalletShipToLine2");
            col27.Caption = "PalletShipToLine2";
            col27.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col27);

            DataColumn col28 = new DataColumn("IsPartial");
            col28.Caption = "IsPartial";
            col28.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col28);


            DataColumn col29 = new DataColumn("PartialQty");
            col29.Caption = "PartialQty";
            col29.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col29);

            DataColumn col30 = new DataColumn("SCCExt");
            col30.Caption = "SCCExt";
            col30.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col30);

            DataColumn col31 = new DataColumn("Hazardous");
            col31.Caption = "Hazardous";
            col31.DataType = Type.GetType("System.Boolean");
            _datatable.Columns.Add(col31);

            DataColumn col32 = new DataColumn("ItemNumberWithDashes");
            col32.Caption = "ItemNumberWithDashes";
            col32.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col32);

            DataColumn col33 = new DataColumn("BarCode");
            col33.Caption = "Barcode";
            col33.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col33);

            DataColumn col34 = new DataColumn("FullPalletSSCC");
            col34.Caption = "FullPalletSSCC";
            col34.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col34);

            DataColumn col35 = new DataColumn("UnitSize");
            col35.Caption = "UnitSize";
            col35.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col35);


            DataColumn col36 = new DataColumn("RepakUnitSize");
            col36.Caption = "RepakUnitSize";
            col36.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col36);

            DataColumn col37 = new DataColumn("ExpDateYYMMDD");
            col37.Caption = "ExpDateYYMMDD";
            col37.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col37);

            DataColumn col38 = new DataColumn("SSCCSerialNumber");
            col38.Caption = "SSCCSerialNumber";
            col38.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col38);

            if (e.SelectedObjects.Count > 0)
            {
                //if (lotGenSerial.Dupqty == 1)
                // {
                foreach (RepackLotSerialNo rlsn in e.SelectedObjects)
                {
                    //for (int dup = 0; dup < lotGenSerial.Dupqty; dup++)
                    //{

                    DataRow row = _datatable.NewRow();
                    row["ItemNumber"] = rlsn.RepackLot.RepackItem.NDC.ItemNumber.Trim();
                    row["ItemNumberWithDashes"] = rlsn.RepackLot.RepackItem.NDC.AccountingNumber;

                    row["NDCDescription"] = rlsn.RepackLot.RepackItem.NDCLabelDescription;
                    row["NDCLabelContains"] = rlsn.RepackLot.RepackItem.NDCLabelContains;
                    row["LabelStorageInfo"] = rlsn.RepackLot.RepackItem.NDCLabelStorage;
                    row["NDClot"] = rlsn.RepackLot.LotId;
                    row["SerialNumber"] = rlsn.SerialNo;
                    row["ExpirationDate"] = rlsn.RepackLot.LotExpirationDt.ToString("MM/dd/yy");
                    row["PackageQty"] = rlsn.RepackLot.PackageQty;
                    if (rlsn.RepackLot.RepackItem.Manufacturer != null)
                    {
                        row["ManufactureName"] = rlsn.RepackLot.RepackItem.Manufacturer.ManufacturerName;
                        row["ManufactureAddress"] = rlsn.RepackLot.RepackItem.Manufacturer.CityStateZip;
                    }
                    row["RepackagedBy"] = rlsn.RepackLot.RepackPackager.PackagerName;
                    row["RepackagedByAddress"] = rlsn.RepackLot.RepackPackager.CityStateZip;
                    if (rlsn.RepackLot.RepackItem.RepackDistributor != null)
                    {
                        row["DistributedBy"] = rlsn.RepackLot.RepackItem.RepackDistributor.RepackDistributorName;
                        row["DistributedByAddress"] = rlsn.RepackLot.RepackItem.RepackDistributor.CityStateZip;
                        row["DistributedByPhone"] = rlsn.RepackLot.RepackItem.RepackDistributor.Phone;
                    }
                    row["NdcSizeStrength"] = rlsn.RepackLot.RepackItem.LabelSizeStrength;
                    row["NdcGTIN"] = rlsn.RepackLot.RepackItem.Gtin.Trim();
                    row["DeaClass"] = rlsn.RepackLot.RepackItem.DEACLASS;
                    row["NDC"] = rlsn.RepackLot.NDC;
                    row["CaseQty"] = rlsn.RepackLot.LabelCaseQty;
                    row["NDCNAME"] = rlsn.RepackLot.RepackItem.NDCLabelName;
                    row["ShippingGTIN"] = rlsn.RepackLot.RepackItem.ShipperGtin;
                    row["PalletFullSSCC"] = rlsn.RepackLot.RepackItem.LabelFullSSCC;
                    row["PalletPartialSSCC"] = rlsn.RepackLot.RepackItem.LabelPartialSSCC;
                    row["PalletQty"] = rlsn.RepackLot.RepackItem.LabelPalletCaseQty.ToString();
                    row["PalletShipToLine1"] = rlsn.RepackLot.RepackItem.LabelShipToLine1;
                    row["PalletShipToLine2"] = rlsn.RepackLot.RepackItem.LabelShipToLine2;
                    row["IsPartial"] = rlsn.isPartial.ToString();
                    row["PartialQty"] = rlsn.PartialQty.ToString();
                    row["SCCExt"] = 0.ToString();
                    row["Hazardous"] = rlsn.RepackLot.RepackItem.Hazardous;
                    row["BarCode"] = rlsn.RepackLot.Barcode;
                    row["FullPalletSSCC"] = rlsn.RepackLot.RepackItem.LabelFullSSCC + rlsn.SerialNo;
                    row["UnitSize"] = rlsn.RepackLot.UnitSize;
                    row["RepakUnitSize"] = rlsn.RepackLot.RepakUnitSize;
                    row["ExpDateYYMMDD"] = rlsn.RepackLot.LotExpirationDt.ToString("yyMMdd");
                    if (rlsn.sGTIN != null)
                    {
                        row["SSCCSerialNumber"] = rlsn.sGTIN.Substring(rlsn.sGTIN.LastIndexOf(".") + 2);
                    }
                    _datatable.Rows.Add(row);

                }
                int rcount = _datatable.Rows.Count;

                GridControl grid = new GridControl();
                grid.BindingContext = new System.Windows.Forms.BindingContext();
                GridView gridview = new GridView();
                grid.MainView = gridview;
                gridview.GridControl = grid;
                grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridview});

                grid.DataSource = _datatable;
                grid.ForceInitialize();
                gridview.PopulateColumns();
                gridview.ExportToXls(filename);

            }
            //}



            return 1;
        }

        private void RepackPrintLabel_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "npRepackLabelParm_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            npRepackLabelParm lparm = new npRepackLabelParm();

            RepackLotSerialNo rls = objectSpace.GetObject<RepackLotSerialNo>((RepackLotSerialNo)View.CurrentObject);
            if (rls.LabelType == eLabelType.InnerCarton)
            {
                lparm.LabelFile = rls.RepackLot.RepackItem.BTDefualtTemplate;
            }
            else if (rls.LabelType == eLabelType.Pallet)
            {
                lparm.LabelFile = rls.RepackLot.RepackItem.BTPalletLabelTemplate;
            }
            else //shipping label
            {
                lparm.LabelFile = rls.RepackLot.RepackItem.BTShippingLabelTemplate;
            }
            PrinterSettings printerName = new PrinterSettings();



            lparm.PrinterName = printerName.PrinterName;
            // objectSpace.GetObject<RepackLotSerial>((Vendor)View.CurrentObject);
            // e.View = Application.CreateDetailView(Application.CreateObjectSpace(), lparm);
            e.DialogController.SaveOnAccept = false;
            //  npRepackLabelParm  lparm = objectSpace.CreateObject<npRepackLabelParm>();
            //

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, lparm);
            // e.View.Caption = e.View.Caption + " - " + lotSerial.LotId.NDC.ToString();
        }

        private void CommissionSerialNo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            int resaults = CreateCommissioningEvent(e);
            if (resaults == 1)
            {
                View.ObjectSpace.Refresh();
                return;
            }



            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("Commissioning of Serial number not fully tested Implemented yet");
            options.Type = InformationType.Warning;
            options.Web.Position = InformationPosition.Top;
            options.Win.Caption = "Failure";
            options.Win.Type = WinMessageType.Alert;

            Application.ShowViewStrategy.ShowMessage(options);

        }

        private int CreateCommissioningEvent(SimpleActionExecuteEventArgs e)
        {
           
            if (e.SelectedObjects.Count > 0)
            {
                using (IObjectSpace os = Application.CreateObjectSpace())
                {
                    RepackLotSerialNo selectedSerialNo = (RepackLotSerialNo)e.SelectedObjects[0];

                    eSerialTypes stype;

                    stype = eSerialTypes.sequential;
                    stype = selectedSerialNo.RepackLot.RepackItem.SerialType;
                    string strGtin = selectedSerialNo.RepackLot.RepackItem.Gtin;

                    switch (stype)
                    {
                        case eSerialTypes.sequential:

                            throw new NotImplementedException();


                        case eSerialTypes.RFXcel:

                            RFEXCEL rfc = new RFEXCEL(strGtin, 0, Application, impType);
                            rfc.PostRxCommissioningEvent(e);
                            break;

                        default:

                            break;
                    }

                }
                MessageOptions options = new MessageOptions();
                options.Duration = 20000;
                options.Message = string.Format("Commissioning of Serial");
                options.Type = InformationType.Info;
                options.Web.Position = InformationPosition.Top;
                options.Win.Caption = "Succeeded";
                options.Win.Type = WinMessageType.Alert;
                View.ObjectSpace.Refresh();

                Application.ShowViewStrategy.ShowMessage(options);


            }
            //throw new NotImplementedException();
            return 1;
        }



        private int PrintBTLabels(PopupWindowShowActionExecuteEventArgs e, string filename)
        {
            // string[] browsingFormats;
            npRepackLabelParm lotGenSerial = (npRepackLabelParm)e.PopupWindowView.CurrentObject;
            TextFile xfile;
            try
            {
                engine = new Engine(true);
            }
            catch (PrintEngineException exception)
            {
                // If the engine is unable to start, a PrintEngineException will be thrown.
                //MessageBox.Show(this, exception.Message, appName);
                //this.Close(); // Close this app. We cannot run without connection to an engine.
                throw new ArgumentNullException(exception.Message + " unable to start Bartender");

            }
            string PrinterName = lotGenSerial.PrinterName;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (format != null)
                {
                    format.Close(SaveOptions.DoNotSaveChanges);
                }
                format = engine.Documents.Open(lotGenSerial.LabelFile);
                xfile = new TextFile("test");


                xfile.FileName = @"c:\BTData\test2.xls";
                object test = xfile.GetType();


                //format.DatabaseConnections.SetDatabaseConnection(xfile);
                format.PrintSetup.PrinterName = PrinterName;

                format.Print("Lot Label print");
                
                Messages rMessages;

                rMessages = new Messages();

                Resolution iResolution;
                iResolution = new Resolution(ImageResolution.Printer);

                //format.ExportPrintPreviewToFile("c:\\temp", "testJpeg.jpg", ImageType.JPEG, 
                //    Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, iResolution                     ,  
                //    System.Drawing.Color.White, 
                //    OverwriteOptions.Overwrite, true, true, out rMessages);

            }

            catch (System.Runtime.InteropServices.COMException comException)
            {
                //     errorMessage = String.Format("Unable to open format: {0}\nReason: {1}", browsingFormats[index], comException.Message);
                format = null;
                throw new ArgumentNullException(comException.Message + " Error in Repack Label print");
            }
            //View.ObjectSpace.Refresh();
            //engine.Documents.Close(xfile.FileName, SaveOptions.DoNotSaveChanges);
            engine.Dispose();
            format = null;
            engine = null;
            return 1;


        }

        private void ShipEvent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            int resaults = CreateShippingEvent(e);
            if (resaults == 1)
            {
                return;
            }

            View.ObjectSpace.Refresh();


        }

        private int CreateShippingEvent(SimpleActionExecuteEventArgs e)
        {
            //eRFXLImpType impType = eRFXLImpType.QA;
            if (e.SelectedObjects.Count > 0)
            {
                using (IObjectSpace os = Application.CreateObjectSpace())
                {
                    RepackLotSerialNo selectedSerialNo = (RepackLotSerialNo)e.SelectedObjects[0];

                    eSerialTypes stype;

                    stype = eSerialTypes.sequential;
                    stype = selectedSerialNo.RepackLot.RepackItem.SerialType;
                    string strGtin = selectedSerialNo.RepackLot.RepackItem.Gtin;

                    switch (stype)
                    {
                        case eSerialTypes.sequential:

                            throw new NotImplementedException();


                        case eSerialTypes.RFXcel:

                            RFEXCEL rfc = new RFEXCEL(strGtin, 0, Application, impType);
                            rfc.PostShipEvent(e);
                            break;

                        default:

                            break;
                    }

                }
                View.ObjectSpace.Refresh();
                MessageOptions options = new MessageOptions();
                options.Duration = 20000;
                options.Message = string.Format("Ship event");
                options.Type = InformationType.Info;
                options.Web.Position = InformationPosition.Top;
                options.Win.Caption = "Succeeded";
                options.Win.Type = WinMessageType.Alert;

                Application.ShowViewStrategy.ShowMessage(options);


            }
            //throw new NotImplementedException();
            return 1;
        }

        private void AggEvent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
           // eRFXLImpType impType = eRFXLImpType.QA;

            if (e.SelectedObjects.Count > 0)
            {
                using (IObjectSpace os = Application.CreateObjectSpace())
                {
                    RepackLotSerialNo selectedSerialNo = (RepackLotSerialNo)e.SelectedObjects[0];

                    eSerialTypes stype;

                    stype = eSerialTypes.sequential;
                    stype = selectedSerialNo.RepackLot.RepackItem.SerialType;
                    string strGtin = selectedSerialNo.RepackLot.RepackItem.Gtin;

                    switch (stype)
                    {
                        case eSerialTypes.sequential:

                            throw new NotImplementedException();


                        case eSerialTypes.RFXcel:

                            RFEXCEL rfc = new RFEXCEL(strGtin, 0, Application, impType);
                            rfc.PostAggEvent(e);
                            
                            break;

                        default:

                            break;
                    }

                }
                View.ObjectSpace.Refresh();

                MessageOptions options = new MessageOptions();
                options.Duration = 20000;
                options.Message = string.Format("Agg event");
                options.Type = InformationType.Info;
                options.Web.Position = InformationPosition.Top;
                options.Win.Caption = "Succeeded";
                options.Win.Type = WinMessageType.Alert;

                Application.ShowViewStrategy.ShowMessage(options);


            }
            //throw new NotImplementedException();


        }
    }
}
