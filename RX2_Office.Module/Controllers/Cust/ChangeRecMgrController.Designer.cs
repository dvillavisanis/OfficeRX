namespace RX2_Office.Module.Controllers
{
    partial class ChangeRecMgrController
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
            this.ChangeRecMgr = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // ChangeRecMgr
            // 
            this.ChangeRecMgr.Caption = "Change Rec Mgr";
            this.ChangeRecMgr.Category = "RecordEdit";
            this.ChangeRecMgr.ConfirmationMessage = null;
            this.ChangeRecMgr.Id = "ChangeRecMgr";
            this.ChangeRecMgr.ImageName = "ChangeRecordMgr";
            this.ChangeRecMgr.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.ChangeRecMgr.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ChangeRecMgr.ShowItemsOnClick = true;
            this.ChangeRecMgr.TargetObjectsCriteria = " IsCurrentUserInRole(\'SalesLicenseVer\')";
            this.ChangeRecMgr.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            this.ChangeRecMgr.ToolTip = null;
            this.ChangeRecMgr.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ChangeRecMgr_Execute);
            this.ChangeRecMgr.CustomGetFormattedConfirmationMessage += new System.EventHandler<DevExpress.ExpressApp.Actions.CustomGetFormattedConfirmationMessageEventArgs>(this.ChangeSalesRep_CustomGetFormattedConfirmationMessage);
            // 
            // ChangeRecMgrController
            // 
            this.Actions.Add(this.ChangeRecMgr);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction ChangeRecMgr;
    }
}
