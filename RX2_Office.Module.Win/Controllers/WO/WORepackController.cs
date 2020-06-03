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

namespace RX2_Office.Module.Controllers.Work_Orders
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WORepackController : ViewController
    {
        public WORepackController()
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

        private void popupWindowShowAction1_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        //private void SalesOrderPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        //{
        //    SOHeader so = (SOHeader)e.PopupWindowViewCurrentObject;

        //    MessageOptions options = new MessageOptions();
        //    options.Duration = 20000;
        //    options.Message = string.Format("Sales Order for {0} has been entered", so.CustomerNumber.CustomerName);
        //    options.Type = InformationType.Success;
        //    options.Web.Position = InformationPosition.Right;
        //    options.Win.Caption = "Success";
        //    options.Win.Type = WinMessageType.Alert;
        //    //options.OkDelegate = () => {
        //    //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
        //    // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
        //    // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
        //    //};
        //    Application.ShowViewStrategy.ShowMessage(options);


        //}



        private void AddWO_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
           // RepackItems RepackItem = (RepackItems)e.PopupWindowViewCurrentObject;
        }

        private void AddWO_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "WorkOrders_New";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            WorkOrders newWO = objectSpace.CreateObject<WorkOrders>();
            RepackItems cRepack = objectSpace.GetObject<RepackItems>((RepackItems)View.CurrentObject);
            newWO.OriginalNDC = cRepack.OriginalNDC;
            newWO.NewNdc = cRepack.NDC;
            newWO.CreatedBy = SecuritySystem.CurrentUserName;
            newWO.WoStatus = WorkOrderStatus.New;
            newWO.ExpectedDate = DateTime.Now.AddDays(4);
            newWO.Repackager = cRepack.DefaultRepackager;
            //CustomerNumber = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
           // newWO.CreatedBy = newWO.CustomerNumber.SalesRep;
            newWO.CreatedDate = DateTime.Now;
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newWO);
            e.View.Caption = e.View.Caption + " - " + newWO.NewNdc.ItemDescription;

        }
    }
}
