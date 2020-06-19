namespace RX2_Office.Module.Controllers.PO
{
    partial class VendorNotesController
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
            this.VendorNoteAction = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // VendorNoteAction
            // 
            this.VendorNoteAction.AcceptButtonCaption = null;
            this.VendorNoteAction.CancelButtonCaption = null;
            this.VendorNoteAction.Caption = "Note";
            this.VendorNoteAction.Category = "Edit";
            this.VendorNoteAction.ConfirmationMessage = null;
            this.VendorNoteAction.Id = "e507bb7e-c202-44fd-97a9-e57e1ec4be36";
            this.VendorNoteAction.ImageName = "note-Customer";
            this.VendorNoteAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.VendorNoteAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.VendorNoteAction.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Vendor);
            this.VendorNoteAction.ToolTip = null;
            this.VendorNoteAction.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.VendorNoteAction_CustomizePopupWindowParams);
            this.VendorNoteAction.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.VendorNoteAction_Execute);
            // 
            // VendorNotesController
            // 
            this.Actions.Add(this.VendorNoteAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction VendorNoteAction;
    }
}
