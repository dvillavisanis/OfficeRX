namespace RX2_Office.Module.Win.Controllers.WO
{
    partial class repackItemsController
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
            this.UpdateImage = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // UpdateImage
            // 
            this.UpdateImage.Caption = "Label Image";
            this.UpdateImage.Category = "Edit";
            this.UpdateImage.ConfirmationMessage = null;
            this.UpdateImage.Id = "RepackItemImageupdate";
            this.UpdateImage.ImageName = "labelupdate2ico";
            this.UpdateImage.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.UpdateImage.ToolTip = null;
            this.UpdateImage.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.UpdateImage_Execute);
            // 
            // repackItemsController
            // 
            this.Actions.Add(this.UpdateImage);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackItems);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction UpdateImage;
    }
}
