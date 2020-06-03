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
    public partial class SalesOrderDetailController : ViewController
    {
        public SalesOrderDetailController()
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

        private void parametrizedAction1_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            View.ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            View.Refresh();

        }

        private void popupWindowShowAction1_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "SODetails_DetailView_NewLine";
            View.ObjectSpace.CommitChanges();




            IObjectSpace objectSpace = Application.CreateObjectSpace();
            SODetails SOD = objectSpace.CreateObject<SODetails>();

            PropertyCollectionSource collectionSource = (PropertyCollectionSource)((ListView)View).CollectionSource;
            SOHeader header = (SOHeader)collectionSource.MasterObject;
            SOD.SalesOrder = objectSpace.GetObject<SOHeader>(header);
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, SOD);

        }

        private void SalesOrderLines_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PropertyCollectionSource collectionSource = (PropertyCollectionSource)((ListView)View).CollectionSource;
            collectionSource.ObjectSpace.CommitChanges();
            collectionSource.ObjectSpace.Refresh();
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();
            View.ObjectSpace.Refresh();
            View.Refresh();
        }
    }
}
