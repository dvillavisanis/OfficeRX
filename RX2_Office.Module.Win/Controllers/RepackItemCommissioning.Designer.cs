namespace RX2_Office.Win.Controllers
{
    partial class RepackItemCommissioning
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
            this.RepackItemComEvent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.PalletCommissionEvent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // RepackItemComEvent
            // 
            this.RepackItemComEvent.Caption = "RpkItem Com ";
            this.RepackItemComEvent.Category = "Edit";
            this.RepackItemComEvent.ConfirmationMessage = null;
            this.RepackItemComEvent.Id = "RepackItemComEvent";
            this.RepackItemComEvent.ImageName = "repackComm";
            this.RepackItemComEvent.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.RepackItemComEvent.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);
            this.RepackItemComEvent.ToolTip = "Commission lots and serial numbers";
            this.RepackItemComEvent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.RepackItemComEvent_Execute);
            // 
            // PalletCommissionEvent
            // 
            this.PalletCommissionEvent.Caption = "Pallet Comm";
            this.PalletCommissionEvent.Category = "Edit";
            this.PalletCommissionEvent.ConfirmationMessage = null;
            this.PalletCommissionEvent.Id = "45cdf997-910b-43c7-a27d-96db6da8ee38";
            this.PalletCommissionEvent.ImageName = "WO\\Palletcomm";
            this.PalletCommissionEvent.ToolTip = null;
            this.PalletCommissionEvent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PalletCommissionEvent_Execute);
            // 
            // RepackItemCommissioning
            // 
            this.Actions.Add(this.RepackItemComEvent);
            this.Actions.Add(this.PalletCommissionEvent);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction RepackItemComEvent;
        private DevExpress.ExpressApp.Actions.SimpleAction PalletCommissionEvent;
    }
}
