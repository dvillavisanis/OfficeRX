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
    public partial class CustomerCustomRequestController : ViewController
    {
        public CustomerCustomRequestController()
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

        private void CustomRequest_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            ItemRequest ccr = (ItemRequest)e.PopupWindowViewCurrentObject;
          //  string x = "1";
           // ccr.Customer.AddNote(ccr.Customer, string.Format("Item Request has been sent for Item: {0} {1} for Customer {2}", ccr.ItemNumber.AccountingNumber, ccr.ItemNumber.ItemDescription, ccr.Customer.CustomerName));

            e.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();
            View.ObjectSpace.Refresh();
     
            MessageOptions options = new MessageOptions();
            options.Message = string.Format("Item Request has been sent for Item: {0} {1} for Customer {2}", 
                                  ccr.ItemNumber.AccountingNumber, 
                                  ccr.ItemNumber.ItemDescription,
                                  ccr.Customer.CustomerName);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            options.Duration = 1000;
            Application.ShowViewStrategy.ShowMessage(options);

            View.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomRequest_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemRequest_DetailView_SalesRepRequest";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemRequest newRequest = objectSpace.CreateObject<ItemRequest>();
            newRequest.Customer = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            newRequest.RequestBy = SecuritySystem.CurrentUserName;
            newRequest.SearchUntil = DateTime.Today.AddDays(4);
            newRequest.SubsOkay = false;
            

            //newRequest.Customer.SalesRep;
            newRequest.RequestDt = DateTime.Now;
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newRequest);
            e.View.Caption = e.View.Caption + " - " + newRequest.Customer.CustomerName;
                                 
        }
    }
}
