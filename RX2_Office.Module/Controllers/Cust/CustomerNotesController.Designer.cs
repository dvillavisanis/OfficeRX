namespace RX2_Office.Module.Controllers
{
    partial class CustomerNotesController
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
            this.Note = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.SalesOrderPopup = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CustomerRequestPopup = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.ReleaseCustomer = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.NewCustomerContact = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.actionpopupCustomerMeeting = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // Note
            // 
            this.Note.AcceptButtonCaption = null;
            this.Note.CancelButtonCaption = null;
            this.Note.Caption = "Note";
            this.Note.Category = "Edit";
            this.Note.ConfirmationMessage = null;
            this.Note.Id = "S0-CustomNotePUController";
            this.Note.ImageName = "note-Customer";
            this.Note.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.Note.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.Note.TargetObjectsCriteria = "";
            this.Note.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            this.Note.ToolTip = "Add Note to Current Customer";
            this.Note.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.Note_CustomizePopupWindowParams);
            this.Note.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.Note_Execute);
            // 
            // SalesOrderPopup
            // 
            this.SalesOrderPopup.AcceptButtonCaption = null;
            this.SalesOrderPopup.CancelButtonCaption = null;
            this.SalesOrderPopup.Caption = "Sales Order ";
            this.SalesOrderPopup.Category = "Edit";
            this.SalesOrderPopup.ConfirmationMessage = null;
            this.SalesOrderPopup.Id = "SO-SalesOrderPopupController";
            this.SalesOrderPopup.ImageName = "order-add";
            this.SalesOrderPopup.QuickAccess = true;
            this.SalesOrderPopup.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.SalesOrderPopup.TargetObjectsCriteria = " DeaExpDate > Today()";
            this.SalesOrderPopup.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.SalesOrderPopup.ToolTip = "Add Sales Order";
            this.SalesOrderPopup.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SalesOrderPopup_CustomizePopupWindowParams);
            this.SalesOrderPopup.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SalesOrderPopup_Execute);
            // 
            // CustomerRequestPopup
            // 
            this.CustomerRequestPopup.AcceptButtonCaption = null;
            this.CustomerRequestPopup.CancelButtonCaption = null;
            this.CustomerRequestPopup.Caption = "Item Request";
            this.CustomerRequestPopup.Category = "Edit";
            this.CustomerRequestPopup.ConfirmationMessage = null;
            this.CustomerRequestPopup.Id = "CustomerRequestPopup";
            this.CustomerRequestPopup.ImageName = "Request";
            this.CustomerRequestPopup.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.CustomerRequestPopup.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.CustomerRequestPopup.ToolTip = "Item Request ";
            this.CustomerRequestPopup.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CustomerRequestPopup_CustomizePopupWindowParams);
            this.CustomerRequestPopup.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CustomerRequestPopup_Execute);
            // 
            // ReleaseCustomer
            // 
            this.ReleaseCustomer.Caption = "SO-ReleaseCustomerController";
            this.ReleaseCustomer.Category = "Edit";
            this.ReleaseCustomer.ConfirmationMessage = "Release all Selected Customers to Goldmine";
            this.ReleaseCustomer.Id = "SO-ReleaseCustomerController";
            this.ReleaseCustomer.ImageName = "burn";
            this.ReleaseCustomer.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.ReleaseCustomer.TargetObjectsCriteria = "[SalesRep.SalesRepCode] = UserCurrent";
            this.ReleaseCustomer.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.ReleaseCustomer.ToolTip = null;
            this.ReleaseCustomer.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ReleaseCustomer_Execute);
            this.ReleaseCustomer.CustomGetFormattedConfirmationMessage += new System.EventHandler<DevExpress.ExpressApp.Actions.CustomGetFormattedConfirmationMessageEventArgs>(this.ReleaseCustomer_CustomGetFormattedConfirmationMessage);
            // 
            // NewCustomerContact
            // 
            this.NewCustomerContact.AcceptButtonCaption = null;
            this.NewCustomerContact.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Cancel;
            this.NewCustomerContact.CancelButtonCaption = null;
            this.NewCustomerContact.Caption = "New Contact";
            this.NewCustomerContact.Category = "Edit";
            this.NewCustomerContact.ConfirmationMessage = null;
            this.NewCustomerContact.Id = "S0-NewContactController";
            this.NewCustomerContact.ImageName = "BO_Contact";
            this.NewCustomerContact.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.NewCustomerContact.ToolTip = "Add new Contact";
            this.NewCustomerContact.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.newContact_Parm);
            this.NewCustomerContact.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.NewContact_Execute);
            // 
            // actionpopupCustomerMeeting
            // 
            this.actionpopupCustomerMeeting.AcceptButtonCaption = null;
            this.actionpopupCustomerMeeting.CancelButtonCaption = null;
            this.actionpopupCustomerMeeting.Caption = "Customer Meeting";
            this.actionpopupCustomerMeeting.Category = "Edit";
            this.actionpopupCustomerMeeting.ConfirmationMessage = null;
            this.actionpopupCustomerMeeting.Id = "SO-actionpopupCustomerMeeting";
            this.actionpopupCustomerMeeting.ImageName = "BO_Scheduler";
            this.actionpopupCustomerMeeting.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.actionpopupCustomerMeeting.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);
            this.actionpopupCustomerMeeting.ToolTip = null;
            this.actionpopupCustomerMeeting.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.actionpopupCustomerMeeting_CustomizePopupWindowParams);
            this.actionpopupCustomerMeeting.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.actionpopupCustomerMeeting_Execute);
            // 
            // CustomerNotesController
            // 
            this.Actions.Add(this.Note);
            this.Actions.Add(this.SalesOrderPopup);
            this.Actions.Add(this.CustomerRequestPopup);
            this.Actions.Add(this.ReleaseCustomer);
            this.Actions.Add(this.NewCustomerContact);
            this.Actions.Add(this.actionpopupCustomerMeeting);
            this.TargetObjectType = typeof(RX2_Office.Module.BusinessObjects.Customer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction Note;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SalesOrderPopup;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CustomerRequestPopup;
        private DevExpress.ExpressApp.Actions.SimpleAction ReleaseCustomer;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction NewCustomerContact;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction actionpopupCustomerMeeting;
    }
}
