namespace RX2_Office.Module.Controllers.WO
{
    partial class RepackLabelPrint
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
            this.components = new System.ComponentModel.Container();
            this.RepackPrintLabel = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CommissionSerialNo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.ShipEvent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.AggEvent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // RepackPrintLabel
            // 
            this.RepackPrintLabel.AcceptButtonCaption = null;
            this.RepackPrintLabel.CancelButtonCaption = null;
            this.RepackPrintLabel.Caption = "Print Label";
            this.RepackPrintLabel.ConfirmationMessage = null;
            this.RepackPrintLabel.Id = "d6652ec5-7b8d-4d69-a50b-bbdcec692350";
            this.RepackPrintLabel.ImageName = "RepackPrintLabel";
            this.RepackPrintLabel.ToolTip = null;
            this.RepackPrintLabel.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.RepackPrintLabel_CustomizePopupWindowParams);
            this.RepackPrintLabel.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.RepackPrintLabel_Execute);
            // 
            // CommissionSerialNo
            // 
            this.CommissionSerialNo.Caption = "Commission ";
            this.CommissionSerialNo.Category = "Edit";
            this.CommissionSerialNo.ConfirmationMessage = "Do you want to commission selected serial no\'s";
            this.CommissionSerialNo.Id = "CommissionSerialNo";
            this.CommissionSerialNo.ImageName = "";
            this.CommissionSerialNo.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.CommissionSerialNo.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLotSerialNo);
            this.CommissionSerialNo.ToolTip = "Comissioning event for selected serial no";
            this.CommissionSerialNo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CommissionSerialNo_Execute);
            // 
            // ShipEvent
            // 
            this.ShipEvent.Caption = "Ship Event";
            this.ShipEvent.Category = "Edit";
            this.ShipEvent.ConfirmationMessage = null;
            this.ShipEvent.Id = "repackShipEvent";
            this.ShipEvent.TargetObjectsCriteria = "[IsCommission] = True And [CommissionPostedToVendor] = True And [AggPostedToVendo" +
    "r] = True";
            this.ShipEvent.ToolTip = null;
            this.ShipEvent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ShipEvent_Execute);
            // 
            // AggEvent
            // 
            this.AggEvent.Caption = "Agg Event";
            this.AggEvent.Category = "Edit";
            this.AggEvent.ConfirmationMessage = null;
            this.AggEvent.Id = "AggEvent";
            this.AggEvent.TargetObjectsCriteria = "[IsCommission] = True And [CommissionPostedToVendor] = True And [AggPostedToVendo" +
    "r] = False";
            this.AggEvent.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.AggEvent.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLotSerialNo);
            this.AggEvent.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.AggEvent.ToolTip = "Aggregate event after Commissiong Event";
            this.AggEvent.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.AggEvent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.AggEvent_Execute);
            // 
            // RepackLabelPrint
            // 
            this.Actions.Add(this.RepackPrintLabel);
            this.Actions.Add(this.CommissionSerialNo);
            this.Actions.Add(this.ShipEvent);
            this.Actions.Add(this.AggEvent);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLotSerialNo);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction RepackPrintLabel;
        private DevExpress.ExpressApp.Actions.SimpleAction CommissionSerialNo;
        private DevExpress.ExpressApp.Actions.SimpleAction ShipEvent;
        private DevExpress.ExpressApp.Actions.SimpleAction AggEvent;
    }
}
