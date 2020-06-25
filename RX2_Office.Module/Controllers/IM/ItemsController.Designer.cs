namespace RX2_Office.Module.Controllers
{
    partial class ItemsController
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
            DevExpress.ExpressApp.Actions.PopupWindowShowAction MinMaint;
            this.ItemPTBMaint = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.Newpo = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            MinMaint = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // MinMaint
            // 
            MinMaint.AcceptButtonCaption = null;
            MinMaint.CancelButtonCaption = null;
            MinMaint.Caption = "Min";
            MinMaint.Category = "RecordEdit";
            MinMaint.ConfirmationMessage = null;
            MinMaint.Id = "ItemMinMaint";
            MinMaint.ImageName = "MinPrice";
            MinMaint.TargetObjectsCriteria = " IsCurrentUserInRole(\'Item Min Maintenance\')";
            MinMaint.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Items);
            MinMaint.ToolTip = null;
            MinMaint.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ItemMinMaint_Execute);
            MinMaint.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.MinMaint_Execute);
            // 
            // ItemPTBMaint
            // 
            this.ItemPTBMaint.AcceptButtonCaption = null;
            this.ItemPTBMaint.CancelButtonCaption = null;
            this.ItemPTBMaint.Caption = "PTB";
            this.ItemPTBMaint.Category = "RecordEdit";
            this.ItemPTBMaint.ConfirmationMessage = null;
            this.ItemPTBMaint.Id = "ItemPTBMaint";
            this.ItemPTBMaint.ImageName = "Pricetobeat";
            this.ItemPTBMaint.TargetObjectsCriteria = " IsCurrentUserInRole(\'Item PTB Maintenance\')";
            this.ItemPTBMaint.ToolTip = null;
            this.ItemPTBMaint.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.Ptb_popWindowParms_execute);
            this.ItemPTBMaint.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.PTB_Execute);
            // 
            // Newpo
            // 
            this.Newpo.AcceptButtonCaption = null;
            this.Newpo.CancelButtonCaption = null;
            this.Newpo.Caption = "New PO";
            this.Newpo.Category = "RecordEdit";
            this.Newpo.ConfirmationMessage = null;
            this.Newpo.Id = "NewPO";
            this.Newpo.ImageName = "PurchaseOrder";
            this.Newpo.TargetObjectsCriteria = " IsCurrentUserInRole(\'Purchasing\')";
            this.Newpo.ToolTip = null;
            this.Newpo.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.NewPO_popwindowParm);
            this.Newpo.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.Newpo_Execute);
            // 
            // ItemsController
            // 
            this.Actions.Add(MinMaint);
            this.Actions.Add(this.ItemPTBMaint);
            this.Actions.Add(this.Newpo);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Items);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ItemPTBMaint;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction Newpo;
    }
}
