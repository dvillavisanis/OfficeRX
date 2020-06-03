namespace RX2_Office.Module.Controllers
{
    partial class SalesInvoicePrintAction
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
            this.PrintInvoice = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // PrintInvoice
            // 
            this.PrintInvoice.Caption = null;
            this.PrintInvoice.Category = "Print";
            this.PrintInvoice.ConfirmationMessage = null;
            this.PrintInvoice.Id = "87eb0e8d-cb7b-4614-8adb-5b337ff7bdc9";
            this.PrintInvoice.ToolTip = null;
            this.PrintInvoice.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction1_Execute);
            // 
            // SalesInvoicePrintAction
            // 
            this.Actions.Add(this.PrintInvoice);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction PrintInvoice;
    }
}
