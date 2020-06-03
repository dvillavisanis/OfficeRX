using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using RX2_Office.Module.BusinessObjects;
using Seagull.BarTender.Print;
using Seagull.BarTender.Print.Database;
namespace RX2_Office.Module.Win.Controllers.WO
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class repackItemsController : ViewController
    {

        private Engine engine = null; // The BarTender Print Engine
        private LabelFormatDocument format = null; // The currently open Format
        public repackItemsController()
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

        private void UpdateImage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            if (e.SelectedObjects.Count > 0) // test
            {
                foreach (RepackItems item in e.SelectedObjects)
                {
                    string path = @"c:\BTData";
                    string xlsfilename = path + @"\btdata.xls";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (File.Exists(xlsfilename))
                    {
                        File.Delete(xlsfilename);
                    }

                    int ret = CreateLabelSpreadsheet(e, xlsfilename);
                    if (ret == 1)
                    {
                        PrintBTLabels(item, xlsfilename);


                    }


                }


            }
            //if (e.SelectedObjects.Count > 0) // test
            //{
            //    string path = @"c:\BTData";
            //    string xlsfilename = path + @"\btdata.xls";
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }
            //    if (File.Exists(xlsfilename))
            //    {
            //        File.Delete(xlsfilename);
            //    }

            //    int ret = CreateLabelSpreadsheet(e, xlsfilename);
            //    if (ret == 1)
            //    {
            //        PrintBTLabels(e, xlsfilename);


            //    }

            //}
        }

        private int PrintBTLabels(RepackItems e, string filename)
        {
            // string[] browsingFormats;
            // npRepackLabelParm lotGenSerial = (npRepackLabelParm)e.PopupWindowView.CurrentObject;
            string LabFilename;
            RepackItems Ritem = e;
            try
            {
                engine = new Engine(true);
            }
            catch (PrintEngineException exception)
            {
                // If the engine is unable to start, a PrintEngineException will be thrown.
                //MessageBox.Show(this, exception.Message, appName);
                //this.Close(); // Close this app. We cannot run without connection to an engine.
                throw new ArgumentNullException(exception.Message + " unable to start Bartender Try installing BARTENDER Label Software");

            }
            //string PrinterName = lotGenSerial.PrinterName;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (format != null)
                {
                    format.Close(SaveOptions.DoNotSaveChanges);
                }
                format = engine.Documents.Open(Ritem.BTDefualtTemplate);
                TextFile xfile = new TextFile("test");


                xfile.FileName = filename; // @"c:\BTData\btdata.xls";
                object test = xfile.GetType();


                // format.DatabaseConnections.SetDatabaseConnection(xfile);
                //format.PrintSetup.PrinterName = PrinterName;

                // format.Print("Lot Label print");
                //Resolution res = new Resolution(300, 700);

                Resolution res = new Resolution(ImageResolution.Screen);
                Messages messages = new Messages();
                LabFilename = Ritem.ItemNumber.ToString() + "-SampleLabel";

                format.ExportPrintPreviewToFile(@"c:\BTData", LabFilename, ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, res, System.Drawing.Color.White, OverwriteOptions.Overwrite, true, true, out messages);
                engine.Documents.Close(Ritem.BTDefualtTemplate, SaveOptions.DoNotSaveChanges);
                // format.Close(SaveOptions.DoNotSaveChanges);
                engine.Dispose();
                engine = null;

                // 
                //if (messages.HasError)
                // {
                //     throw new Exception("error creating labels") ;
                // }

                Messages rMessages;

                rMessages = new Messages();

                Resolution iResolution;
                iResolution = new Resolution(ImageResolution.Printer);

                //format.ExportPrintPreviewToFile("c:\\temp", "testJpeg.jpg", ImageType.JPEG, 
                //    Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, iResolution                     ,  
                //    System.Drawing.Color.White, 
                //    OverwriteOptions.Overwrite, true, true, out rMessages);
                // format.Close(SaveOptions.DoNotSaveChanges);
                format = null;
            }

            catch (System.Runtime.InteropServices.COMException comException)
            {
                //     errorMessage = String.Format("Unable to open format: {0}\nReason: {1}", browsingFormats[index], comException.Message);
                format = null;
                throw new ArgumentNullException(comException.Message + " Error in Repack Label print");
            }

            if (File.Exists(@"c:\BTData\" + LabFilename + "1"))
            {

                Ritem.LabelImage = DownloadFile(@"c:\BTData\" + LabFilename + "1");
                Ritem.Save();
                Ritem.Session.CommitTransaction();

            }

            // engine.Documents.CloseAll(SaveOptions.DoNotSaveChanges);

            return 1;

        }

        //private int PrintBTLabels(SimpleActionExecuteEventArgs e, string filename)
        //{
        //    // string[] browsingFormats;
        //    // npRepackLabelParm lotGenSerial = (npRepackLabelParm)e.PopupWindowView.CurrentObject;
        //    string LabFilename;
        //    RepackItems Ritem = (RepackItems)e.CurrentObject;
        //    try
        //    {
        //        engine = new Engine(true);
        //    }
        //    catch (PrintEngineException exception)
        //    {
        //        // If the engine is unable to start, a PrintEngineException will be thrown.
        //        //MessageBox.Show(this, exception.Message, appName);
        //        //this.Close(); // Close this app. We cannot run without connection to an engine.
        //        throw new ArgumentNullException(exception.Message + " unable to start Bartender Try installing BARTENDER Label Software");

        //    }
        //    //string PrinterName = lotGenSerial.PrinterName;
        //    Cursor.Current = Cursors.WaitCursor;
        //    try
        //    {
        //        if (format != null)
        //        {
        //            format.Close(SaveOptions.DoNotSaveChanges);
        //        }
        //        format = engine.Documents.Open(Ritem.BTDefualtTemplate);
        //        TextFile xfile = new TextFile("test");


        //        xfile.FileName = filename; // @"c:\BTData\btdata.xls";
        //        object test = xfile.GetType();


        //        // format.DatabaseConnections.SetDatabaseConnection(xfile);
        //        //format.PrintSetup.PrinterName = PrinterName;

        //        // format.Print("Lot Label print");
        //        //Resolution res = new Resolution(300, 700);

        //        Resolution res = new Resolution(ImageResolution.Screen);
        //        Messages messages = new Messages();
        //        LabFilename = Ritem.ItemNumber.ToString() + "-SampleLabel";

        //        format.ExportPrintPreviewToFile(@"c:\BTData", LabFilename, ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, res, System.Drawing.Color.White, OverwriteOptions.Overwrite, true, true, out messages);
        //        engine.Documents.Close(Ritem.BTDefualtTemplate, SaveOptions.DoNotSaveChanges);
        //       // format.Close(SaveOptions.DoNotSaveChanges);
        //        engine.Dispose();
        //        engine = null;

        //        // 
        //        //if (messages.HasError)
        //        // {
        //        //     throw new Exception("error creating labels") ;
        //        // }

        //        Messages rMessages;

        //        rMessages = new Messages();

        //        Resolution iResolution;
        //        iResolution = new Resolution(ImageResolution.Printer);

        //        //format.ExportPrintPreviewToFile("c:\\temp", "testJpeg.jpg", ImageType.JPEG, 
        //        //    Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, iResolution                     ,  
        //        //    System.Drawing.Color.White, 
        //        //    OverwriteOptions.Overwrite, true, true, out rMessages);
        //       // format.Close(SaveOptions.DoNotSaveChanges);
        //        format = null;
        //    }

        //    catch (System.Runtime.InteropServices.COMException comException)
        //    {
        //        //     errorMessage = String.Format("Unable to open format: {0}\nReason: {1}", browsingFormats[index], comException.Message);
        //        format = null;
        //        throw new ArgumentNullException(comException.Message + " Error in Repack Label print");
        //    }

        //    if (File.Exists(@"c:\BTData\" + LabFilename+"1"))
        //    {

        //        Ritem.LabelImage = DownloadFile(@"c:\BTData\" + LabFilename+"1");
        //        Ritem.Save();
        //        Ritem.Session.CommitTransaction();

        //    }

        //  // engine.Documents.CloseAll(SaveOptions.DoNotSaveChanges);

        //    return 1;

        //}




        private static byte[] DownloadFile(string url)
        {
            byte[] result = null;

            using (WebClient webClient = new WebClient())
            {
                result = webClient.DownloadData(url);
            }

            return result;
        }

        private int CreateLabelSpreadsheet(SimpleActionExecuteEventArgs e, string filename)
        {

            RepackItems Ritem = (RepackItems)e.CurrentObject;

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
            col8.DataType = Type.GetType("System.String");
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
            DataColumn col37 = new DataColumn("EprDateYYMMDD");
            col37.Caption = "EprDateYYMMDD";
            col37.DataType = Type.GetType("System.String");
            _datatable.Columns.Add(col37);


            if (e.SelectedObjects.Count > 0)
            {
                // if (lotGenSerial.Dupqty == 1) { }
                //  foreach (RepackItems ritem in e.SelectedObjects)
                //  {
                ////      for (int dup = 0; dup < lotGenSerial.Dupqty; dup++)
                ////      {

                DataRow row = _datatable.NewRow();
                row["ItemNumber"] = Ritem.NDC.ItemNumber.Trim();
                row["ItemNumberWithDashes"] = Ritem.NDC.NDCWithDashes;

                row["NDCDescription"] = Ritem.NDCLabelDescription;
                row["NDCLabelContains"] = Ritem.NDCLabelContains;
                row["LabelStorageInfo"] = Ritem.NDCLabelStorage;
                row["NDClot"] = "LotABC123";
                row["SerialNumber"] = "Ser123456789ABC";
                row["ExpirationDate"] = DateTime.Now.ToString("mm/dd/yy");
                row["PackageQty"] = Ritem.LabelCaseQty.ToString();
                //if (Ritem.Manufacturer != null)
                //{
                //    row["ManufactureName"] = Ritem.Manufacturer.ManufacturerName;
                //    row["ManufactureAddress"] = Ritem.Manufacturer.CityStateZip;
                //}
                row["RepackagedBy"] = Ritem.DefaultRepackager.PackagerName;
                row["RepackagedByAddress"] = Ritem.DefaultRepackager.CityStateZip;
                if (Ritem.RepackDistributor != null)
                {
                    row["DistributedBy"] = Ritem.RepackDistributor.RepackDistributorName;
                    row["DistributedByAddress"] = Ritem.RepackDistributor.CityStateZip;
                    row["DistributedByPhone"] = Ritem.RepackDistributor.Phone;
                }
                row["NdcSizeStrength"] = Ritem.LabelSizeStrength;
                row["NdcGTIN"] = Ritem.Gtin.Trim();
                row["DeaClass"] = Ritem.DEACLASS;
                row["NDC"] = Ritem.NDC.BarCode;
                row["CaseQty"] = Ritem.LabelCaseQty;
                row["NDCNAME"] = Ritem.NDCLabelName;
                row["ShippingGTIN"] = Ritem.ShipperGtin;
                row["PalletFullSSCC"] = Ritem.LabelFullSSCC;
                row["PalletPartialSSCC"] = Ritem.LabelPartialSSCC;
                row["PalletQty"] = 0.ToString();
                row["PalletShipToLine1"] = " ";
                row["PalletShipToLine2"] = " ";
                row["IsPartial"] = 0.ToString();
                row["PartialQty"] = 0.ToString();
                row["SCCExt"] = 0.ToString();
                row["Hazardous"] = Ritem.Hazardous;
                row["BarCode"] = Ritem.NDC;
                row["FullPalletSSCC"] = Ritem.LabelFullSSCC + "Ser123456789ABC";
                row["UnitSize"] = Ritem.LabelSizeStrength;
                row["RepakUnitSize"] = Ritem.NDCLabelSize;
                row["EprDateYYMMDD"] = DateTime.Now.ToString("yyMMdd");
                _datatable.Rows.Add(row);
                //   }
                //// }

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
                gridview.Dispose();
                gridview = null;

            }
            return 1;
        }
    }
}
