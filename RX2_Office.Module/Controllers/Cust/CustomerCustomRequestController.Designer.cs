namespace RX2_Office.Module.Controllers
{
    partial class CustomerCustomRequestController
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
            this.CustomRequest = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // CustomRequest
            // 
            this.CustomRequest.AcceptButtonCaption = null;
            this.CustomRequest.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.CustomRequest.CancelButtonCaption = null;
            this.CustomRequest.Caption = "Sales Customer Custom Request";
            this.CustomRequest.Category = "Edit";
            this.CustomRequest.ConfirmationMessage = "Would you like to Submit to Purchasing?";
            this.CustomRequest.Id = "SalesCustomerCustomRequest";
            this.CustomRequest.ImageName = "CustomerRequest";
            this.CustomRequest.ToolTip = null;
            this.CustomRequest.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CustomRequest_CustomizePopupWindowParams);
            this.CustomRequest.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CustomRequest_Execute);
            // 
            // CustomerCustomRequestController
            // 
            this.Actions.Add(this.CustomRequest);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CustomRequest;
    }
}
