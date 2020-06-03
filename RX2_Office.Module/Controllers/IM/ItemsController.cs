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
using DevExpress.ExpressApp.Xpo;

namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ItemsController : ViewController
    {
        public ItemsController()
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

        private void PriceToBeat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }

        private void popupWindowShowAction1_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }



        private void ItemMinMaint_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            TargetViewId = "ItemMinChangeHistory_Maint";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemMinChangeHistory newMin = objectSpace.CreateObject<ItemMinChangeHistory>();

            newMin.Item = objectSpace.GetObject<Items>((Items)View.CurrentObject);
            newMin.ChangedBy = SecuritySystem.CurrentUserName;
            newMin.CHangeDate = DateTime.Now;
            newMin.OldMin = newMin.Item.MinPrice;
            newMin.ItemMin = newMin.Item.MinPrice;
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newMin);
            e.View.Caption = e.View.Caption + " - " + newMin.Item.ItemNumber;
            e.Maximized = false;
            e.IsSizeable = true;




        }



        private void MinMaint_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

            e.PopupWindow.View.ObjectSpace.CommitChanges();
            IObjectSpace objectSpace = Application.CreateObjectSpace();

          //  Items item = objectSpace.CreateObject<Items>();
            ItemMinChangeHistory currentMinChange = objectSpace.GetObject<ItemMinChangeHistory>((ItemMinChangeHistory)e.PopupWindowViewCurrentObject);
            //item = objectSpace.GetObject<Items>((Items)View.CurrentObject);
            //item.MinPrice = currentMinChange.ItemMin;
            //item.Save();
            currentMinChange.Item.MinPrice = currentMinChange.ItemMin;
            currentMinChange.Save();
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            View.Refresh();

            // item.MinPrice = e.PopupWindow.View<ItemMinHistory>.CurrentObject.ItemMin;
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("Min has been changed for Item: {0} to {1}", currentMinChange.Item.ItemNumber, currentMinChange.ItemMin.ToString());
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            options.Duration = 10000;
            Application.ShowViewStrategy.ShowMessage(options);
            
        }

        private void Ptb_popWindowParms_execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            TargetViewId = "ItemPTB_Maint";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemPTB newPTB = objectSpace.CreateObject<ItemPTB>();

            newPTB.ItemNumber = objectSpace.GetObject<Items>((Items)View.CurrentObject);
           // newPTB.Employee = Employee.CurrentUserId;
            newPTB.CreatedDate = DateTime.Now;
            newPTB.PTB = newPTB.ItemNumber.CurrentPTB;
            
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newPTB);
            e.View.Caption =  "PTB Maint - " + newPTB.ItemNumber.ItemNumber;
            e.Maximized = false;
            e.IsSizeable = true;

        }

        private void PTB_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            
            ItemPTB currentPTBChange = objectSpace.GetObject<ItemPTB>((ItemPTB)e.PopupWindowViewCurrentObject);

            currentPTBChange.ItemNumber.CurrentPTB = currentPTBChange.PTB;
            currentPTBChange.Save();
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            View.Refresh();

            // item.MinPrice = e.PopupWindow.View<ItemMinHistory>.CurrentObject.ItemMin;
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("PTB has been changed for Item: {0} to {1}", currentPTBChange.ItemNumber.ItemNumber, currentPTBChange.PTB.ToString());
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            options.Duration = 10000;
            Application.ShowViewStrategy.ShowMessage(options);
        }

        private void Newpo_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void NewPO_popwindowParm(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            TargetViewId = "ItemPurchaseOrder_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemPurchaseOrder newPO = objectSpace.CreateObject<ItemPurchaseOrder>();

            //newPO. = objectSpace.GetObject<Items>((Items)View.CurrentObject);
            // newPTB.Employee = Employee.CurrentUserId;
            newPO.PODate = DateTime.Now;
            newPO.PoStatus = PoStatus.New;
            newPO.IsPrinted = false;
       

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newPO);
            
            e.Maximized = false;
            e.IsSizeable = true;
        }
    }

}

