namespace RX2_Office.Module.Controllers.Work_Orders
{
    partial class WORepackController
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
            this.History = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // History
            // 
            this.History.AcceptButtonCaption = null;
            this.History.CancelButtonCaption = null;
            this.History.Caption = "Item History";
            this.History.Category = "View";
            this.History.ConfirmationMessage = null;
            this.History.Id = "WoRepackItemhistory";
            this.History.ImageName = "ItemHistory";
            this.History.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.History.Shortcut = "ALT+h";
            this.History.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackItems);
            this.History.ToolTip = "ItemHistory";
            this.History.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.History.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.popupWindowShowAction1_Execute);
            // 
            // WORepackController
            // 
            this.Actions.Add(this.History);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackItems);
            this.TypeOfView = typeof(DevExpress.ExpressApp.View);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction History;
    }
}
