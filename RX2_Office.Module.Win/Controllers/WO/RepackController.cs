using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using static RX2_Office.Module.BusinessObjects.BusinessLogic.RFEXCEL;

namespace RX2_Office.Module.Controllers.WO
{

    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class RepackController : ViewController
    {
       eRFXLImpType impType = eRFXLImpType.Production;
        public RepackController()
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

        private void GenSerialNo_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
           // eRFXLImpType impType = eRFXLImpType.Production;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            // IObjectSpace objectSpace = ObjectSpace.CreateNestedObjectSpace();


            RepackLotGenerate lotGenSerial = (RepackLotGenerate)e.PopupWindowView.CurrentObject;
            RepackLots lsg = lotGenSerial.LotId;

            RepackLots RL = (RepackLots)objectSpace.GetObjectByKey(typeof(RepackLots), lsg.Oid);
            eSerialTypes stype;
            int snumber = 1965;
            if (lsg == null)
            {
                stype = eSerialTypes.sequential;
            }
            stype = RL.RepackItem.SerialType;

            //lsg.RepackItem.SerialType;
            switch (stype)
            {
                case eSerialTypes.sequential:
                    {
                        int lastSerialNumber = 0;
                        lastSerialNumber = RL.LastSerialNumber;
                        //Generates Partials
                        for (int i = 1; i < lotGenSerial.QtyOfPartial + 1; i++)
                        {
                            lastSerialNumber++;
                            string snum = lastSerialNumber.ToString().PadLeft(2, '0');
                            RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                            LotSerial.RepackLot = RL;
                            LotSerial.LabelType = eLabelType.InnerCarton;
                            LotSerial.GTIN = RL.RepackItem.Gtin;
                            LotSerial.isPartial = true;
                            LotSerial.GTIN = RL.RepackItem.Gtin;
                            LotSerial.SerialNo = RL.LotId.PadRight(2, '0') + snum;
                            LotSerial.Save();
                        }
                        //Generates non partials
                        for (int i = 1; i < lotGenSerial.QtyToGenerate + 1; i++)
                        {
                            lastSerialNumber++;
                            string snum = lastSerialNumber.ToString().PadLeft(2, '0');
                            RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                            LotSerial.RepackLot = RL;
                            LotSerial.LabelType = eLabelType.InnerCarton;
                            LotSerial.GTIN = RL.RepackItem.Gtin;

                            LotSerial.GTIN = RL.RepackItem.Gtin;
                            LotSerial.SerialNo = RL.LotId.PadRight(2, '0') + snum;
                            LotSerial.Save();
                        }


                        RL.LastSerialNumber = lastSerialNumber;
                        RL.Save();
                        break;
                    }
                case eSerialTypes.Random:
                    Random getRandom = new Random();

                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {
                        IObjectSpace objectSpace2 = Application.CreateObjectSpace();
                        RepackLotSerialNo LotSerial = objectSpace2.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.InnerCarton;
                        LotSerial.GTIN = RL.RepackItem.Gtin;
                        LotSerial.SerialNo = lotGenSerial.LotId.ToString() + snumber.ToString("000000") + getRandom.Next(3, 999999).ToString("000000");
                        LotSerial.Save();
                    }
                    break;
                case eSerialTypes.RFXcel:
                    string gtin = RL.RepackItem.Gtin;
                    RFEXCEL rfc = new RFEXCEL(gtin, lotGenSerial.QtyToGenerate, Application, impType);
                    //************************************************
                    //
                    // Go Get  Serial Number from RXexcel
                    //
                    //***********************************************
                    rfc.PostRequest(gtin, lotGenSerial.QtyToGenerate, e);

                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {

                        // string is1 = "12345.6789.1111111111";

                        //int lastdot = is1.LastIndexOf(".");
                        //string is2 = is1.Substring(lastdot +1 );
                        RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.InnerCarton;
                        LotSerial.SerialNo = rfc.SerialList[i];
                        LotSerial.sGTIN = rfc.sGTIN[i];
                        LotSerial.GTIN = RL.RepackItem.Gtin;


                        //LotSerial.SerialNo = RL.LotId.ToString() + snumber.ToString("000000") + i + 1.ToString("000000");
                        LotSerial.Save();
                    }
                    break;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("{0} Serial Number for Lot {1} has been entered", lotGenSerial.QtyToGenerate, lotGenSerial.LotId.LotId.ToString());
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            Application.ShowViewStrategy.ShowMessage(options);
        }

        private void GenSerialNo_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "RepackLotGenerate_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();

            RepackLotGenerate lotSerial = objectSpace.CreateObject<RepackLotGenerate>();
            lotSerial.LotId = objectSpace.GetObject<RepackLots>((RepackLots)View.CurrentObject);

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, lotSerial);
            e.View.Caption = e.View.Caption + " - ";//+ lotSerial.LotId.NDC.ToString();
        }

        private void GenShipSerialNo_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            
           // eRFXLImpType impType = eRFXLImpType.Production;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            // IObjectSpace objectSpace = ObjectSpace.CreateNestedObjectSpace();


            RepackLotGenerate lotGenSerial = (RepackLotGenerate)e.PopupWindowView.CurrentObject;
            RepackLots lsg = lotGenSerial.LotId;

            RepackLots RL = (RepackLots)objectSpace.GetObjectByKey(typeof(RepackLots), lsg.Oid);
            eSerialTypes stype;
            int snumber = 1965;
            if (lsg == null)
            {
                stype = eSerialTypes.sequential;
            }
            stype = RL.RepackItem.SerialType;

            //lsg.RepackItem.SerialType;
            switch (stype)
            {
                case eSerialTypes.sequential:
                    {
                        int lastSerialNumber = 0;
                        lastSerialNumber = RL.LastSerialNumber;

                        for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                        {
                            lastSerialNumber++;
                            RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                            LotSerial.RepackLot = RL;
                            LotSerial.LabelType = eLabelType.Shipping;
                            LotSerial.SerialNo = RL.LotId.ToString() + snumber.ToString("000000") + lastSerialNumber + 1.ToString("000000");
                            LotSerial.GTIN = RL.RepackItem.ShipperGtin;
                            LotSerial.Save();
                        }
                        RL.LastSerialNumber = lastSerialNumber;
                        RL.Save();


                        break;
                    }

                case eSerialTypes.Random:
                    Random getRandom = new Random();

                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {
                        IObjectSpace objectSpace2 = Application.CreateObjectSpace();

                        RepackLotSerialNo LotSerial = objectSpace2.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.Shipping;
                        LotSerial.GTIN = RL.RepackItem.ShipperGtin;
                        LotSerial.SerialNo = lotGenSerial.LotId.ToString() + snumber.ToString("000000") + getRandom.Next(3, 999999).ToString("000000");
                        LotSerial.Save();
                    }
                    break;
                case eSerialTypes.RFXcel:
                    string gtin = RL.RepackItem.ShipperGtin;
                    RFEXCEL rfc = new RFEXCEL(gtin, lotGenSerial.QtyToGenerate, Application, impType);
                    rfc.PostRequest(gtin, lotGenSerial.QtyToGenerate, e);

                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {

                        // string is1 = "12345.6789.1111111111";

                        //int lastdot = is1.LastIndexOf(".");
                        //string is2 = is1.Substring(lastdot +1 );
                        RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.Shipping;
                        LotSerial.SerialNo = rfc.SerialList[i];
                        LotSerial.sGTIN = rfc.sGTIN[i];
                        LotSerial.GTIN = RL.RepackItem.ShipperGtin;

                        //LotSerial.SerialNo = RL.LotId.ToString() + snumber.ToString("000000") + i + 1.ToString("000000");
                        LotSerial.Save();
                    }
                    break;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("{0} Serial Number for Lot {1} has been entered", lotGenSerial.QtyToGenerate, lotGenSerial.LotId.LotId.ToString());
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            Application.ShowViewStrategy.ShowMessage(options);

        }

        private void GenPalletLabel_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            //eRFXLImpType impType = eRFXLImpType.Production;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            // IObjectSpace objectSpace = ObjectSpace.CreateNestedObjectSpace();


            RepackLotGenerate lotGenSerial = (RepackLotGenerate)e.PopupWindowView.CurrentObject;
            RepackLots lsg = lotGenSerial.LotId;

            RepackLots RL = (RepackLots)objectSpace.GetObjectByKey(typeof(RepackLots), lsg.Oid);
            eSerialTypes stype;
            int snumber = 1965;
            if (lsg == null)
            {
                stype = eSerialTypes.sequential;
            }
            stype = RL.RepackItem.SerialType;

            //lsg.RepackItem.SerialType;
            switch (stype)
            {
                case eSerialTypes.sequential:
                    {
                        for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                        {
                            RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                            LotSerial.RepackLot = RL;
                            LotSerial.LabelType = eLabelType.Shipping;
                            LotSerial.GTIN = RL.RepackItem.PalletSSCC;
                            LotSerial.SerialNo = RL.LotId.ToString() + snumber.ToString("000000") + i + 1.ToString("000000");
                            LotSerial.Save();
                        }
                        break;
                    }
                case eSerialTypes.Random:
                    Random getRandom = new Random();

                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {
                        IObjectSpace objectSpace2 = Application.CreateObjectSpace();

                        RepackLotSerialNo LotSerial = objectSpace2.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.Shipping;
                        LotSerial.GTIN = RL.RepackItem.PalletSSCC;
                        LotSerial.SerialNo = lotGenSerial.LotId.ToString() + snumber.ToString("000000") + getRandom.Next(3, 999999).ToString("000000");
                        LotSerial.Save();
                    }
                    break;
                case eSerialTypes.RFXcel:
                    string gtin = RL.RepackItem.ShipperGtin;
                    RFEXCEL rfc = new RFEXCEL(gtin, lotGenSerial.QtyToGenerate, Application, impType);
                    //rfc.PostRequest(gtin, lotGenSerial.QtyToGenerate, e);
                    rfc.PostPalletRequest(gtin, lotGenSerial.QtyToGenerate, e);
                    for (int i = 0; i < lotGenSerial.QtyToGenerate; i++)
                    {

                        // string is1 = "12345.6789.1111111111";

                        //int lastdot = is1.LastIndexOf(".");
                        //string is2 = is1.Substring(lastdot +1 );
                        RepackLotSerialNo LotSerial = objectSpace.CreateObject<RepackLotSerialNo>();
                        LotSerial.RepackLot = RL;
                        LotSerial.LabelType = eLabelType.Pallet;
                        LotSerial.SerialNo = rfc.SerialList[i];
                        LotSerial.sGTIN = rfc.sGTIN[i];
                        LotSerial.GTIN = rfc.sGTIN[i];
                        LotSerial.SsccSerialNumber = rfc.sGTIN[i].Substring(rfc.sGTIN[i].LastIndexOf(".") + 1);

                        //LotSerial.SerialNo = RL.LotId.ToString() + snumber.ToString("000000") + i + 1.ToString("000000");
                        LotSerial.Save();
                    }
                    break;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("{0} Serial Number for Lot {1} has been entered", lotGenSerial.QtyToGenerate, lotGenSerial.LotId.LotId.ToString());
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            Application.ShowViewStrategy.ShowMessage(options);

        }

        private void GenPalletLabel_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "RepackLotGenerate_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();

            RepackLotGenerate lotSerial = objectSpace.CreateObject<RepackLotGenerate>();
            lotSerial.LotId = objectSpace.GetObject<RepackLots>((RepackLots)View.CurrentObject);

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, lotSerial);
            e.View.Caption = "Pallet Serial Number gen- ";//+ lotSerial.LotId.NDC.ToString();
        }

        private void RepackLabel_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }
    }
}
