namespace RX2_Office.Module.Win.Controllers.Shipping
{
    partial class ReceiptPackageItems
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
            this.ReceiptPackageItem = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ReceiptPackageItem
            // 
            this.ReceiptPackageItem.Caption = "Receipt Item";
            this.ReceiptPackageItem.Category = "Edit";
            this.ReceiptPackageItem.ConfirmationMessage = null;
            this.ReceiptPackageItem.Id = "ReceiptItem";
            this.ReceiptPackageItem.ImageName = "unboxing";
            this.ReceiptPackageItem.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ReceiptPackageItem.QuickAccess = true;
            this.ReceiptPackageItem.ToolTip = null;
            this.ReceiptPackageItem.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ReceiptPackageItem_Execute);
            // 
            // ReceiptPackageItems
            // 
            this.Actions.Add(this.ReceiptPackageItem);
            this.TargetObjectType = typeof(RX2_Office.Module.ReceiverPackage);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ReceiptPackageItem;
    }
}
