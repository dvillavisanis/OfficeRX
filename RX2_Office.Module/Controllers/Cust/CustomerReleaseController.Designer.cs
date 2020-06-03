namespace RX2_Office.Module.Controllers
{
    partial class CustomerReleaseController
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
            this.GrabCustomer = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // GrabCustomer
            // 
            this.GrabCustomer.Caption = "Grab Customer";
            this.GrabCustomer.Category = "Edit";
            this.GrabCustomer.ConfirmationMessage = null;
            this.GrabCustomer.Id = "GrabCustomer";
            this.GrabCustomer.ImageName = "snatch-customer";
            this.GrabCustomer.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.GrabCustomer.TargetObjectsCriteria = "[AquiredBy] is null";
            this.GrabCustomer.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.GrabCustomer.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.CustomerRelease);
            this.GrabCustomer.ToolTip = null;
            this.GrabCustomer.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.GrabCustomer_Execute);
            // 
            // CustomerReleaseController
            // 
            this.Actions.Add(this.GrabCustomer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction GrabCustomer;
    }
}
