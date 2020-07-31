namespace RX2_Office.Module.Controllers.Shipping
{
    partial class SHippingInventoryController
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
            this.ShInventoryController = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ShInventoryController
            // 
            this.ShInventoryController.AcceptButtonCaption = null;
            this.ShInventoryController.CancelButtonCaption = null;
            this.ShInventoryController.Caption = "Inventory";
            this.ShInventoryController.Category = "Edit";
            this.ShInventoryController.ConfirmationMessage = null;
            this.ShInventoryController.Id = "SH-ShippingInventoryController";
            this.ShInventoryController.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventory);
            this.ShInventoryController.ToolTip = null;
            this.ShInventoryController.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ShInventoryController_CustomizePopupWindowParams);
            this.ShInventoryController.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ShInventoryController_Execute);
            // 
            // SHippingInventoryController
            // 
            this.Actions.Add(this.ShInventoryController);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ShInventoryController;
    }
}
