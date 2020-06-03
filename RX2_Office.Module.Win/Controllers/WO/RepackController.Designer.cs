namespace RX2_Office.Module.Controllers.WO
{
    partial class RepackController
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
            this.GenSerialNo = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.GenShipSerialNo = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.GenPalletLabel = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.RepackLabel = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // GenSerialNo
            // 
            this.GenSerialNo.AcceptButtonCaption = null;
            this.GenSerialNo.CancelButtonCaption = null;
            this.GenSerialNo.Caption = "Gen Serial No";
            this.GenSerialNo.Category = "Edit";
            this.GenSerialNo.ConfirmationMessage = null;
            this.GenSerialNo.Id = "GenSerialNo";
            this.GenSerialNo.ImageName = "SerialNumberGen";
            this.GenSerialNo.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.GenSerialNo.TargetObjectsCriteria = "!(LotId is null) && !(RepackItem is null)";
            this.GenSerialNo.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.GenSerialNo.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);
            this.GenSerialNo.ToolTip = null;
            this.GenSerialNo.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.GenSerialNo_CustomizePopupWindowParams);
            this.GenSerialNo.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.GenSerialNo_Execute);
            // 
            // GenShipSerialNo
            // 
            this.GenShipSerialNo.AcceptButtonCaption = null;
            this.GenShipSerialNo.CancelButtonCaption = null;
            this.GenShipSerialNo.Caption = "Gen  Ship Serial No";
            this.GenShipSerialNo.Category = "Edit";
            this.GenShipSerialNo.ConfirmationMessage = null;
            this.GenShipSerialNo.Id = "GenShipSerialNo";
            this.GenShipSerialNo.ImageName = "SerialNumberGen";
            this.GenShipSerialNo.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.GenShipSerialNo.TargetObjectsCriteria = "!(LotId is null) && !(RepackItem is null)";
            this.GenShipSerialNo.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.GenShipSerialNo.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);
            this.GenShipSerialNo.ToolTip = null;
            this.GenShipSerialNo.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.GenSerialNo_CustomizePopupWindowParams);
            this.GenShipSerialNo.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.GenShipSerialNo_Execute);
            // 
            // GenPalletLabel
            // 
            this.GenPalletLabel.AcceptButtonCaption = null;
            this.GenPalletLabel.CancelButtonCaption = null;
            this.GenPalletLabel.Caption = "Gen Pallet Label";
            this.GenPalletLabel.Category = "Edit";
            this.GenPalletLabel.ConfirmationMessage = null;
            this.GenPalletLabel.Id = "GenPalletLabel";
            this.GenPalletLabel.ImageName = "SerialNumberGen";
            this.GenPalletLabel.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);
            this.GenPalletLabel.ToolTip = null;
            this.GenPalletLabel.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.GenPalletLabel_CustomizePopupWindowParams);
            this.GenPalletLabel.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.GenPalletLabel_Execute);
            // 
            // RepackLabel
            // 
            this.RepackLabel.AcceptButtonCaption = null;
            this.RepackLabel.CancelButtonCaption = null;
            this.RepackLabel.Caption = "334639ab-75ed-4080-91c9-3883b1b8f001";
            this.RepackLabel.ConfirmationMessage = null;
            this.RepackLabel.Id = "334639ab-75ed-4080-91c9-3883b1b8f001";
            this.RepackLabel.ToolTip = null;
            this.RepackLabel.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.RepackLabel_Execute);
            // 
            // RepackController
            // 
            this.Actions.Add(this.GenSerialNo);
            this.Actions.Add(this.GenShipSerialNo);
            this.Actions.Add(this.GenPalletLabel);
            this.Actions.Add(this.RepackLabel);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.RepackLots);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction GenSerialNo;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction GenShipSerialNo;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction GenPalletLabel;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction RepackLabel;
    }
}
