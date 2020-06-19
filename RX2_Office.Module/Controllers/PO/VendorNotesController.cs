using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Module.Controllers.PO
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VendorNotesController : ViewController
    {
        public VendorNotesController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void VendorNoteAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {


        }

        private void VendorNoteAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "VendorNotePopup_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            VendorNote note = objectSpace.CreateObject<VendorNote>();
            
            note.Vendors = objectSpace.GetObject<Vendor>((Vendor)View.CurrentObject);
            note.Text = "test";


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, note);


            e.View.Caption = e.View.Caption + " - " + note.Vendors.VendorName;



        }
    }

}
