namespace RX2_Office.Module.Controllers.Shipping
{
    partial class ShippingController
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
            this.PickSht2 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.SOPack = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // PickSht2
            // 
            this.PickSht2.Caption = "pickSht2";
            this.PickSht2.Category = "Edit";
            this.PickSht2.ConfirmationMessage = null;
            this.PickSht2.Id = "bPickSht";
            this.PickSht2.ImageName = "Shipping\\PickSht";
            this.PickSht2.TargetObjectsCriteria = "PickingsheetPrinted == False";
            this.PickSht2.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.PickSht2.ToolTip = null;
            this.PickSht2.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PickSht2_Execute);
            // 
            // SOPack
            // 
            this.SOPack.AcceptButtonCaption = "Ship";
            this.SOPack.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.SOPack.CancelButtonCaption = null;
            this.SOPack.Caption = "Pack Ship";
            this.SOPack.Category = "Edit";
            this.SOPack.ConfirmationMessage = null;
            this.SOPack.Id = "soPackController";
            this.SOPack.ImageName = "Shipping\\pakship";
            this.SOPack.TargetObjectsCriteria = "PickingsheetPrinted == True";
            this.SOPack.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.SOPack.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SOHeader);
            this.SOPack.ToolTip = "Pack and Ship";
            this.SOPack.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SOPack_Execute);
            // 
            // ShippingController
            // 
            this.Actions.Add(this.PickSht2);
            this.Actions.Add(this.SOPack);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SOHeader);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction PickSht2;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SOPack;
    }
}
