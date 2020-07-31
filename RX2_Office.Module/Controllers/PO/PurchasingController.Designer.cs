namespace RX2_Office.Module.Controllers.PO
{
    partial class PurchasingController
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
            this.newpo = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // newpo
            // 
            this.newpo.AcceptButtonCaption = null;
            this.newpo.CancelButtonCaption = null;
            this.newpo.Caption = "New PO";
            this.newpo.Category = "Edit";
            this.newpo.ConfirmationMessage = null;
            this.newpo.Id = "PO-NewPOController";
            this.newpo.ImageName = "order-add";
            this.newpo.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.newpo.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Vendor);
            this.newpo.ToolTip = "Create New Purchase Order";
            this.newpo.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.parametrizedAction1_Execute);
            this.newpo.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.newpo_Execute);
            // 
            // PurchasingController
            // 
            this.Actions.Add(this.newpo);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Vendor);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction newpo;
    }
}
