namespace RX2_Office.Module.Controllers.Shipping
{
    partial class UPSLabelPrint
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
            this.SH_UPSLablePrint = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SH_UPSLablePrint
            // 
            this.SH_UPSLablePrint.AcceptButtonCaption = null;
            this.SH_UPSLablePrint.CancelButtonCaption = null;
            this.SH_UPSLablePrint.Caption = "Ups Label";
            this.SH_UPSLablePrint.Category = "Edit";
            this.SH_UPSLablePrint.ConfirmationMessage = null;
            this.SH_UPSLablePrint.Id = "SH_UPSLablePrint";
            this.SH_UPSLablePrint.ImageName = "Shipping\\upslabel";
            this.SH_UPSLablePrint.ToolTip = null;
            // 
            // UPSLabelPrint
            // 
            this.Actions.Add(this.SH_UPSLablePrint);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SOHeader);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SH_UPSLablePrint;
    }
}
