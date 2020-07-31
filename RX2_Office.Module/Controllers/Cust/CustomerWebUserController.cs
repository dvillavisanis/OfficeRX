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

namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerWebUserController : ViewController
    {
        public CustomerWebUserController()
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

        private void WebUser_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            {
                //TargetViewId = "CustomerWebUsers_DetailView";
                //IObjectSpace objectSpace = Application.CreateObjectSpace();
                //CustomerWebUserController clr = objectSpace.CreateObject<CustomerWebUserController>();

                //clr.Customer = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
              

                //e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, clr);
                //e.View.Caption = e.View.Caption + " - " + clr.Customer.CustomerName;
                ////e.Size = new Size(1000, 1000);

            }
        }
    }
}
