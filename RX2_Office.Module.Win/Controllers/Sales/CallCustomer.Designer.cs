namespace RX2_Office.Win.Controllers
{
    partial class CallCustomer
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
            this.CustomerCallAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // CustomerCallAction
            // 
            this.CustomerCallAction.Caption = "Call";
            this.CustomerCallAction.Category = "RecordEdit";
            this.CustomerCallAction.ConfirmationMessage = null;
            this.CustomerCallAction.Id = "CustomerCallAction";
            this.CustomerCallAction.ImageName = "CallPhone";
            this.CustomerCallAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.CustomerCallAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.CustomerCallAction.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.CustomerCallAction.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            this.CustomerCallAction.ToolTip = null;
            this.CustomerCallAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CustomerCallAction_Execute);
            // 
            // CallCustomer
            // 
            this.Actions.Add(this.CustomerCallAction);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction CustomerCallAction;
    }
}
