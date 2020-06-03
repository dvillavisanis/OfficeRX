namespace RX2_Office.Module.Controllers
{
    partial class ItemInventorycs
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
            this.Quanatine = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // Quanatine
            // 
            this.Quanatine.AcceptButtonCaption = null;
            this.Quanatine.CancelButtonCaption = null;
            this.Quanatine.Caption = "Quarantine";
            this.Quanatine.Category = "RecordEdit";
            this.Quanatine.ConfirmationMessage = null;
            this.Quanatine.Id = "ItemQuarentine";
            this.Quanatine.ImageName = "Quarantine";
            this.Quanatine.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.Quanatine.TargetObjectsCriteria = "QtyOnHand > 0 ";
            this.Quanatine.ToolTip = "Quarantine this item";
            // 
            // ItemInventorycs
            // 
            this.Actions.Add(this.Quanatine);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventory);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction Quanatine;
    }
}
