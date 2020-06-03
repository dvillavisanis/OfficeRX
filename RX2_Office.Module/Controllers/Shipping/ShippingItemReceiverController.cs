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
    public partial class ShippingItemReceiverController : ViewController
    {


        public ShippingItemReceiverController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

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
            View.ObjectSpace.Refresh();
            View.Refresh();

        }

        private void ItemReceiver_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();
            View.ObjectSpace.Refresh();
            View.Refresh();
        }

        private void ItemReceiver_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemReceiver_ReceiptofGoods";
        
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemReceiver IR = objectSpace.CreateObject<ItemReceiver>();
            Shippers SE = SE = objectSpace.FindObject<Shippers>(new BinaryOperator("ShipperId", SecuritySystem.CurrentUserName));
            if (SE != null)
            {
                IR.DistributionCenterWhse = SE.DefaultWhse;
            }
        
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, IR);

            // e.View.Caption = e.View.Caption + " - " + IR.ItemNumber;
            //e.Size = new Size(1000, 1000);

        }

        private void ReceiverPutaway_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemReceiver IR = objectSpace.GetObject<ItemReceiver>((ItemReceiver)View.CurrentObject);
            IR.ReceiverStatus = ItemReceiverStatus.Completed;
            IR.Save();
            objectSpace.CommitChanges();
           
            View.ObjectSpace.Refresh();
            View.Refresh();
        }

        private void ReceiverPutaway_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemReceiver_ReceiptofGoods_PutAway";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            //ItemReceiver IR = objectSpace.CreateObject<ItemReceiver>();
            ItemReceiver IR = objectSpace.GetObject<ItemReceiver>((ItemReceiver)View.CurrentObject);
            //   IObjectSpace objectSpace = Application.CreateObjectSpace();

            // ItemReceiver note = objectSpace.CreateObject<ItemReceiver>();

            IR.PutAwayBy = SecuritySystem.CurrentUserName;
            IR.PutawayDateTime = DateTime.Now;


            //e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, note);
            //e.View.Caption = e.View.Caption + " - " + note.Customers.CustomerName;

            //Shippers SE = SE = objectSpace.FindObject<Shippers>(new BinaryOperator("ShipperId", SecuritySystem.CurrentUserName));
            //if (SE != null)
            //{
            //    IR.DistributionCenterWhse = SE.DefaultWhse;
            //           }


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, IR);
            //// e.View.Caption = e.View.Caption + " - " + IR.ItemNumber;
            ////e.Size = new Size(1000, 1000);
        }

        private void ReceiptofWO_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void ReceiptofWO_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

        }
    }
}
