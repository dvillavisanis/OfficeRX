namespace RX2_Office.Module.Controllers
{
    partial class CustomerVerificationController
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
            DevExpress.ExpressApp.Actions.PopupWindowShowAction CustomerLicVerification;
            CustomerLicVerification = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // CustomerLicVerification
            // 
            CustomerLicVerification.AcceptButtonCaption = null;
            CustomerLicVerification.CancelButtonCaption = null;
            CustomerLicVerification.Caption = "Lic Verification";
            CustomerLicVerification.Category = "RecordEdit";
            CustomerLicVerification.ConfirmationMessage = null;
            CustomerLicVerification.Id = "CustomerLicVerificationID";
            CustomerLicVerification.ImageName = "LicenseVerification";
            CustomerLicVerification.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
            CustomerLicVerification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            CustomerLicVerification.TargetObjectsCriteria = " IsCurrentUserInRole(\'SalesMgrRole\')";
            CustomerLicVerification.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            CustomerLicVerification.ToolTip = null;
            CustomerLicVerification.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CustomerLicVerification_CustomizePopupWindowParams);
            CustomerLicVerification.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CustomerLicVerification_Execute);
            // 
            // CustomerVerificationController
            // 
            this.Actions.Add(CustomerLicVerification);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);

        }

        #endregion


    }
}
