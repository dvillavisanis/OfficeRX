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
    public partial class PurchasingController : ViewController
    {
        public PurchasingController()
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

        private void parametrizedAction1_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemPurchaseOrder_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemPurchaseOrder newOrder = objectSpace.CreateObject<ItemPurchaseOrder>();
            newOrder.Vendor = objectSpace.GetObject<Vendor>((Vendor)View.CurrentObject);
            newOrder.PODate = DateTime.Now;
            newOrder.PoStatus = PoStatus.New;

       


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newOrder);
            e.View.Caption = e.View.Caption + " - " + newOrder.Vendor.VendorName;

        }

        private void newpo_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ItemPurchaseOrder po = (ItemPurchaseOrder)e.PopupWindowViewCurrentObject;

            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("Purchase Order for {0} has been entered", po.Vendor.VendorName  );
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            Application.ShowViewStrategy.ShowMessage(options);



        }
    }
}
