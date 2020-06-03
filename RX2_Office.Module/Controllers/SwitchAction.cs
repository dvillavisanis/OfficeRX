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
using DevExpress.ExpressApp.Model;

namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SwitchAction : ViewController
    {
        public SwitchAction()
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



        private void SwitchAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IModelListView model = ((ListView)View).Model;
            ViewShortcut shortcut = Frame.View.CreateShortcut();
            Frame.SetView(null);
            if (model.MasterDetailMode == MasterDetailMode.ListViewAndDetailView)
            {
                model.MasterDetailMode = MasterDetailMode.ListViewOnly;
            }
            else
            {
                model.MasterDetailMode = MasterDetailMode.ListViewAndDetailView;
            }
            Frame.SetView(Application.ProcessShortcut(shortcut), true, Frame);


        }

        private void SplitLayoutDirection_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IModelListViewSplitLayout SplitLayout = ((ListView)View).Model.SplitLayout;
            ViewShortcut shortcut = Frame.View.CreateShortcut();
            Frame.SetView(null);
            if (SplitLayout.Direction == FlowDirection.Horizontal )
            {
                SplitLayout.Direction = FlowDirection.Vertical;
            }
            else
            {
                SplitLayout.Direction = FlowDirection.Horizontal;
            }
            Frame.SetView(Application.ProcessShortcut(shortcut), true, Frame);



        }
    }
}
