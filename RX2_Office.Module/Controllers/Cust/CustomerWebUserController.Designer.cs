namespace RX2_Office.Module.Controllers
{
    partial class CustomerWebUserController
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
            this.WebUser = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // WebUser
            // 
            this.WebUser.AcceptButtonCaption = null;
            this.WebUser.CancelButtonCaption = null;
            this.WebUser.Caption = "Web User";
            this.WebUser.Category = "Edit";
            this.WebUser.ConfirmationMessage = null;
            this.WebUser.Id = "WebUser";
            this.WebUser.ImageName = "WebUser";
            this.WebUser.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WebUser.TargetObjectsCriteria = "1=0";
            this.WebUser.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            this.WebUser.ToolTip = null;
            this.WebUser.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.WebUser_Execute);
            // 
            // CustomerWebUserController
            // 
            this.Actions.Add(this.WebUser);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction WebUser;
    }
}
