namespace RX2_Office.Module.Controllers
{
    partial class SwitchAction
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
            this.SwitchActiondetail = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.SplitlayoutDirection = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // SwitchActiondetail
            // 
            this.SwitchActiondetail.Caption = "Switch  Detail View";
            this.SwitchActiondetail.Category = "View";
            this.SwitchActiondetail.ConfirmationMessage = null;
            this.SwitchActiondetail.Id = "SwitchActionDetailView";
            this.SwitchActiondetail.ImageName = "window_arrange_horizontal";
            this.SwitchActiondetail.ToolTip = "Detail or list view switching";
            this.SwitchActiondetail.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SwitchAction_Execute);
            // 
            // SplitlayoutDirection
            // 
            this.SplitlayoutDirection.Caption = "Side Or Bottom";
            this.SplitlayoutDirection.Category = "View";
            this.SplitlayoutDirection.ConfirmationMessage = null;
            this.SplitlayoutDirection.Id = "ORX-SplitLayoutDirectionController";
            this.SplitlayoutDirection.ImageName = "window_panel_bottom";
            this.SplitlayoutDirection.ToolTip = "Detail info bottom or right side";
            this.SplitlayoutDirection.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SplitLayoutDirection_Execute);
            // 
            // SwitchAction
            // 
            this.Actions.Add(this.SwitchActiondetail);
            this.Actions.Add(this.SplitlayoutDirection);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction SwitchActiondetail;
        private DevExpress.ExpressApp.Actions.SimpleAction SplitlayoutDirection;
    }
}
