namespace RX2_Office.Module.Controllers
{
    partial class ShippingItemReceiverController
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
            this.ItemReceiver = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.ReceiverPutaway = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ItemReceiver
            // 
            this.ItemReceiver.AcceptButtonCaption = null;
            this.ItemReceiver.CancelButtonCaption = null;
            this.ItemReceiver.Caption = "Receipt of Goods2";
            this.ItemReceiver.Category = "Edit";
            this.ItemReceiver.ConfirmationMessage = null;
            this.ItemReceiver.Id = "ItemReceiver";
            this.ItemReceiver.ImageName = "Receiver";
            this.ItemReceiver.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemReceiver);
            this.ItemReceiver.ToolTip = null;
            this.ItemReceiver.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ItemReceiver_CustomizePopupWindowParams);
            this.ItemReceiver.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ItemReceiver_Execute);
            // 
            // ReceiverPutaway
            // 
            this.ReceiverPutaway.AcceptButtonCaption = null;
            this.ReceiverPutaway.CancelButtonCaption = null;
            this.ReceiverPutaway.Caption = "Put Away";
            this.ReceiverPutaway.Category = "Edit";
            this.ReceiverPutaway.ConfirmationMessage = null;
            this.ReceiverPutaway.Id = "4557d9c6-1880-4a40-9dd9-80fe0f4b42c3";
            this.ReceiverPutaway.ImageName = "putaway";
            this.ReceiverPutaway.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ReceiverPutaway.TargetObjectsCriteria = "ReceiverStatus = 10";
            this.ReceiverPutaway.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemReceiver);
            this.ReceiverPutaway.ToolTip = "Put Away Item";
            this.ReceiverPutaway.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ReceiverPutaway_CustomizePopupWindowParams);
            this.ReceiverPutaway.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ReceiverPutaway_Execute);
            // 
            // ShippingItemReceiverController
            // 
            this.Actions.Add(this.ItemReceiver);
            this.Actions.Add(this.ReceiverPutaway);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemReceiver);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ItemReceiver;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ReceiverPutaway;
    }
}
