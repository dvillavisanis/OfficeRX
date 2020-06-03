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
using DevExpress.XtraReports.UI;
using RX2_Office.Module.Reports;
using DevExpress.ExpressApp.Reports;
using DevExpress.ExpressApp.ReportsV2;

namespace RX2_Office.Module.BusinessObjects.BOCustomers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerInvoiceController : ViewController
    {
        public CustomerInvoiceController()
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

        private void InvoicePrint_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

        }

        // private void InvoicePrint_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)


        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            XtraReport report = new rptSalesInvoice();
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
           

            if (e.SelectedObjects.Count > 0) // Multi invoice selected
            {
                string[] multiparm = new string[e.SelectedObjects.Count];
                int i = 0;
                foreach (CustomerInvoiceHistory selectedinv in e.SelectedObjects)
                {
                    multiparm[i] = selectedinv.InvoiceNumber;
                    i++;

                }


                report.Parameters["InvoiceNumber"].Value = multiparm;
                report.Parameters["InvoiceNumber"].Visible = false;


            }
            else
            {
                report.Parameters["InvoiceNumber"].Visible = true;
            }
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);

            }
            report.Name = "Invoice Print";
           // report.PrintDialog();
            report.ShowPreview();
          


        }

    }
}
