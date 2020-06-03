namespace RX2_Office.Module.Controllers
{
    partial class PurchaseOrderLineController
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
            this.AddLine = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // AddLine
            // 
            this.AddLine.AcceptButtonCaption = null;
            this.AddLine.CancelButtonCaption = null;
            this.AddLine.Caption = "Add Line";
            this.AddLine.Category = "Edit";
            this.AddLine.ConfirmationMessage = null;
            this.AddLine.Id = "POAddLine";
            this.AddLine.ImageName = "list-add";
            this.AddLine.Shortcut = "Ctrl + i";
            this.AddLine.TargetObjectsCriteria = "[PoStatus] = 1";
            this.AddLine.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemPurchaseOrder);
            this.AddLine.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.AddLine.ToolTip = "Add Line Item";
            this.AddLine.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.AddLine.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.AddLine_CustomizePopupWindowParams);
            this.AddLine.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.AddLine_Execute);
            // 
            // PurchaseOrderLineController
            // 
            this.Actions.Add(this.AddLine);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction AddLine;
    }
}
