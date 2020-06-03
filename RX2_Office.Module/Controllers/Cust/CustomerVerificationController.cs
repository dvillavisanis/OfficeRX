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

namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerVerificationController : ViewController
    {
        public CustomerVerificationController()
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

        private void CustomerLicVerification_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();

            IObjectSpace objectSpace = Application.CreateObjectSpace();
            CustomerLicenseVerifications clr = objectSpace.CreateObject<CustomerLicenseVerifications>();

            MessageOptions options = new MessageOptions();

            options.Duration = 3000;
            options.Message = string.Format("{0} Varified Dea Number of {1} with the Exp date of: {2}  updated!","" , clr.LicenseNumber, clr.LicenseExpirationDate);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;

            Application.ShowViewStrategy.ShowMessage(options);

            View.ObjectSpace.Refresh();
            View.Refresh();
        }

        private void CustomerLicVerification_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "CustomerLicenseVerifications_DetailViewEntry";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            CustomerLicenseVerifications clr = objectSpace.CreateObject<CustomerLicenseVerifications>();

            clr.Customer = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            clr.LicenseNumber = clr.Customer.DeaNo;
            clr.LicenseExpirationDate = clr.Customer.DeaExpDate;


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, clr);
            e.View.Caption = e.View.Caption + " - " + clr.Customer.CustomerName;
            //e.Size = new Size(1000, 1000);

        }
    }
}
