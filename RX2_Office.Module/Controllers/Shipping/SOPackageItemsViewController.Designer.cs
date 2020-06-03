namespace RX2_Office.Module.Controllers.Shipping
{
    partial class SOPackageItemsViewController
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
            this.ScanRecieveItems = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ScanRecieveItems
            // 
            this.ScanRecieveItems.AcceptButtonCaption = null;
            this.ScanRecieveItems.CancelButtonCaption = null;
            this.ScanRecieveItems.Caption = "Scan Items";
            this.ScanRecieveItems.ConfirmationMessage = null;
            this.ScanRecieveItems.Id = "5bcb32fd-fc35-4bd1-abe1-0a573ea845c1";
            this.ScanRecieveItems.TargetObjectType = typeof(RX2_Office.Module.ReceiverPackage);
            this.ScanRecieveItems.ToolTip = null;
            this.ScanRecieveItems.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ScanRecieveItems_CustomizePopupWindowParams);
            this.ScanRecieveItems.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ScanRecieveItems_Execute);
            // 
            // SOPackageItemsViewController
            // 
            this.Actions.Add(this.ScanRecieveItems);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ScanRecieveItems;
    }
}
