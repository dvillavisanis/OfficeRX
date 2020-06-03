namespace RX2_Office.Module.Controllers.IM
{
    partial class FirstDataUpdate
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
            this.FDBUpdate = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // FDBUpdate
            // 
            this.FDBUpdate.Caption = "FirstData Update";
            this.FDBUpdate.Category = "RecordEdit";
            this.FDBUpdate.ConfirmationMessage = null;
            this.FDBUpdate.Id = "FDBUpdateAction";
            this.FDBUpdate.ImageName = "fdbpCheck";
            this.FDBUpdate.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.FDBUpdate.TargetObjectsCriteria = "ItemNumber is not null";
            this.FDBUpdate.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.FDBUpdate.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Items);
            this.FDBUpdate.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.FDBUpdate.ToolTip = "Set FirstData Data into the Item";
            this.FDBUpdate.TypeOfView = typeof(DevExpress.ExpressApp.View);
            this.FDBUpdate.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.FDBUpdate_Execute);
            // 
            // FirstDataUpdate
            // 
            this.Actions.Add(this.FDBUpdate);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction FDBUpdate;
    }
}
