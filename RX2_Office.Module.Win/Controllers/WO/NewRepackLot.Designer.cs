namespace RX2_Office.Module.Controllers.WO
{
    partial class NewRepackLot
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
            this.NewLot = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // NewLot
            // 
            this.NewLot.AcceptButtonCaption = null;
            this.NewLot.CancelButtonCaption = null;
            this.NewLot.Caption = "NewLot";
            this.NewLot.Category = "Edit";
            this.NewLot.ConfirmationMessage = null;
            this.NewLot.Id = "NewRepacklot";
            this.NewLot.ImageName = "repacklotadd";
            this.NewLot.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);
            this.NewLot.ToolTip = "Create new RepackLot";
            this.NewLot.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.NewLot_Execute);
            // 
            // NewRepackLot
            // 
            this.Actions.Add(this.NewLot);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction NewLot;
    }
}
