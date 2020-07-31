namespace RX2_Office.Module.Controllers
{
    partial class SalesInvoiceController
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
            this.DeliverInvoice = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // DeliverInvoice
            // 
            this.DeliverInvoice.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.DeliverInvoice.Caption = "Deliver Inv";
            this.DeliverInvoice.Category = "RecordEdit";
            this.DeliverInvoice.ConfirmationMessage = null;
            this.DeliverInvoice.Id = "SO-DeliverInvoiceController";
            this.DeliverInvoice.ImageName = "invoice-to-mail";
            this.DeliverInvoice.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.DeliverInvoice.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.CustomerInvoiceHistory);
            this.DeliverInvoice.ToolTip = "Deliver Invoices";
            this.DeliverInvoice.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.DeliverInvoice_Execute);
            // 
            // SalesInvoiceController
            // 
            this.Actions.Add(this.DeliverInvoice);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.CustomerInvoiceHistory);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction DeliverInvoice;
    }
}
