namespace RX2_Office.Module.Controllers.IM
{
    partial class ItemInventoryBatchController
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
            this.InventoryItemBatchScan = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // InventoryItemBatchScan
            // 
            this.InventoryItemBatchScan.Caption = "Item Scan";
            this.InventoryItemBatchScan.Category = "Edit";
            this.InventoryItemBatchScan.ConfirmationMessage = null;
            this.InventoryItemBatchScan.Id = "InventoryItemBatchItemScan";
            this.InventoryItemBatchScan.ImageName = "Itemscan";
            this.InventoryItemBatchScan.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.InventoryItemBatchScan.TargetObjectsCriteria = "";
            this.InventoryItemBatchScan.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.InventoryItemBatchScan.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventoryBatch);
            this.InventoryItemBatchScan.ToolTip = null;
            this.InventoryItemBatchScan.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.InventoryItemBatchScan_Execute);
            // 
            // ItemInventoryBatchController
            // 
            this.Actions.Add(this.InventoryItemBatchScan);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventoryBatch);
            this.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction InventoryItemBatchScan;
    }
}
