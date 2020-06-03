namespace RX2_Office.Module.Controllers
{
    partial class ItemLookup
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
            this.ItemF12 = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ItemF12
            // 
            this.ItemF12.AcceptButtonCaption = null;
            this.ItemF12.CancelButtonCaption = null;
            this.ItemF12.Caption = "Item F12";
            this.ItemF12.Category = "Edit";
            this.ItemF12.ConfirmationMessage = null;
            this.ItemF12.Id = "ItemF12";
            this.ItemF12.ImageName = "F12";
            this.ItemF12.IsSizeable = false;
            this.ItemF12.QuickAccess = true;
            this.ItemF12.Shortcut = "F12";
            this.ItemF12.ToolTip = "Inventory Look up";
            this.ItemF12.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ItemF12_CustomizePopupWindowParams);
            this.ItemF12.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.popupWindowShowAction1_Execute);
            // 
            // ItemLookup
            // 
            this.Actions.Add(this.ItemF12);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ItemF12;
    }
}
