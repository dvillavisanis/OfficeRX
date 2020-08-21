namespace RX2_Office.Module.Controllers.PO
{
    partial class POItemResearch
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
            this.POItemRequestResearch = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // POItemRequestResearch
            // 
            this.POItemRequestResearch.AcceptButtonCaption = null;
            this.POItemRequestResearch.CancelButtonCaption = null;
            this.POItemRequestResearch.Caption = "Research";
            this.POItemRequestResearch.Category = "Edit";
            this.POItemRequestResearch.ConfirmationMessage = null;
            this.POItemRequestResearch.Id = "POItemRequestResearch";
            this.POItemRequestResearch.ImageName = "PO\\Po-ItemRequestResearch";
            this.POItemRequestResearch.ToolTip = null;
            // 
            // POItemResearch
            // 
            this.Actions.Add(this.POItemRequestResearch);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemRequestSummary);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction POItemRequestResearch;
    }
}
