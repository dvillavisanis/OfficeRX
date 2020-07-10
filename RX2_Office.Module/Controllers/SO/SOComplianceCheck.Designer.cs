namespace RX2_Office.Module.Controllers.SO
{
    partial class SOComplianceCheck
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
            this.CompChk = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // CompChk
            // 
            this.CompChk.Caption = "CompChk";
            this.CompChk.Category = "Edit";
            this.CompChk.ConfirmationMessage = "Run this order through Compliance Check?";
            this.CompChk.Id = "SOComplianceCheck";
            this.CompChk.ImageName = "SO\\complianceCheck";
            this.CompChk.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SOHeader);
            this.CompChk.TargetViewId = "SOHeader_ListView_ComplianceCheck";
            this.CompChk.ToolTip = null;
            this.CompChk.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CompChk_Execute);
            // 
            // SOComplianceCheck
            // 
            this.Actions.Add(this.CompChk);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.SOHeader);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction CompChk;
    }
}
