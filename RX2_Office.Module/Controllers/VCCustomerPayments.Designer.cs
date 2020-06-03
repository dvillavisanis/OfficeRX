namespace RX2_Office.Module.Controllers
{
    partial class VCCustomerPayments
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
            this.CustomerPaymentInvoice = new DevExpress.ExpressApp.Actions.PopupWindowShowAction();
            // 
            // CustomerPaymentInvoice
            // 
            this.CustomerPaymentInvoice.AcceptButtonCaption = null;
            this.CustomerPaymentInvoice.CancelButtonCaption = null;
            this.CustomerPaymentInvoice.Caption = "Customer Payments";
            this.CustomerPaymentInvoice.ConfirmationMessage = null;
            this.CustomerPaymentInvoice.Id = "cntCustomerPayments";
            this.CustomerPaymentInvoice.ToolTip = null;
            // 
            // VCCustomerPayments
            // 
            this.Actions.Add(this.CustomerPaymentInvoice);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.CustomerInvoicePayments);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CustomerPaymentInvoice;
    }
}
