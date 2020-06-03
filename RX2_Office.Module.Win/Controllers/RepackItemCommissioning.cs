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
using RX2_Office.Module.Win;
using RX2_Office.Win.Windows;

namespace RX2_Office.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class RepackItemCommissioning : ViewController
    {
        public RepackItemCommissioning()
        {
            
                SimpleAction showWindowAction = new SimpleAction(this, "RepackItemCommissioning",
        DevExpress.Persistent.Base.PredefinedCategory.View);
                showWindowAction.ImageName = "ModelEditor_Views";
                showWindowAction.Execute +=
        new SimpleActionExecuteEventHandler(RepackItemComEvent_Execute);
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

        private void RepackItemComEvent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            ItemCommissionEvent form = new ItemCommissionEvent(Application);
            //... 
           
            form.ShowDialog();
            View.ObjectSpace.Refresh();
            View.Refresh();


        }

        private void PalletCommissionEvent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            PalletCommissionEvent form = new PalletCommissionEvent(Application);
            //... 

            form.ShowDialog();
            View.ObjectSpace.Refresh();
            View.Refresh();

        }
    }
}
