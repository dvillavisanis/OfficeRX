namespace RX2_Office.Module.Controllers
{
    partial class SalesOrderDetailController
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
            this.SalesOrderLines = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SalesOrderLines
            // 
            this.SalesOrderLines.AcceptButtonCaption = null;
            this.SalesOrderLines.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.SalesOrderLines.CancelButtonCaption = null;
            this.SalesOrderLines.Caption = "New Item";
            this.SalesOrderLines.Category = "Edit";
            this.SalesOrderLines.ConfirmationMessage = null;
            this.SalesOrderLines.Id = "SaleOrdernewline";
            this.SalesOrderLines.ImageName = "SO_NEW";
            this.SalesOrderLines.TargetObjectsCriteria = "";
            this.SalesOrderLines.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.SalesOrderLines.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SODetails);
            this.SalesOrderLines.ToolTip = null;
            this.SalesOrderLines.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.popupWindowShowAction1_CustomizePopupWindowParams);
            this.SalesOrderLines.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SalesOrderLines_Execute);
            // 
            // SalesOrderDetailController
            // 
            this.Actions.Add(this.SalesOrderLines);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SalesOrderLines;

    }
}
