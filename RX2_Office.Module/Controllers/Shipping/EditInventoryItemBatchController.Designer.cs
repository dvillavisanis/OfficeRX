namespace RX2_Office.Module.Controllers.Shipping
{
    partial class EditInventoryItemBatchController
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
            this.EditInventoryItemBatch = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // EditInventoryItemBatch
            // 
            this.EditInventoryItemBatch.Caption = null;
            this.EditInventoryItemBatch.ConfirmationMessage = null;
            this.EditInventoryItemBatch.Id = "a3c04108-d097-4cd6-98f2-a011ceb47d5b";
            this.EditInventoryItemBatch.ToolTip = null;
            this.EditInventoryItemBatch.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.EditInventoryItemBatch_Execute);
            // 
            // EditInventoryItemBatchController
            // 
            this.Actions.Add(this.EditInventoryItemBatch);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction EditInventoryItemBatch;
    }
}
