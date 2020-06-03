using System;
using System.Collections;
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
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.BusinessObjects.BusinessLogic;
using RX2_Office.Module.Reports;

namespace RX2_Office.Module.Controllers.Shipping
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ShippingController : ViewController
    {
        public ShippingController()
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

        private void PickingSheetPrint_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ArrayList SelectedSo = new ArrayList();
            if ((e.SelectedObjects.Count > 0) &&
                ((e.SelectedObjects[0] is XafDataViewRecord) ||
                 (e.SelectedObjects[0] is XafInstantFeedbackRecord)))
            {
                foreach (var selectedObject in e.SelectedObjects)
                {
                    SelectedSo.Add((SOHeader)ObjectSpace.GetObject(selectedObject));
                }
            }
            else
            {
                SelectedSo = (ArrayList)e.SelectedObjects;
            }
            foreach (SOHeader selectedContact in SelectedSo)
            {
                XtraReport myReport = new rptShippingPickSht();
                myReport.DataSource = SelectedSo;


                //selectedContact.Street1 
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

        private void PickSht2_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            XtraReport myReport = new rptShippingPickSht();

            ArrayList SelectedSo = new ArrayList();
            if ((e.SelectedObjects.Count > 0) &&
                ((e.SelectedObjects[0] is XafDataViewRecord) ||
                 (e.SelectedObjects[0] is XafInstantFeedbackRecord)))
            {
                foreach (var selectedObject in e.SelectedObjects)
                {
                    SelectedSo.Add((SOHeader)ObjectSpace.GetObject(selectedObject));
                }
            }
            else
            {
                SelectedSo = (ArrayList)e.SelectedObjects;
            }

            myReport.DataSource = SelectedSo;
            foreach (SOHeader selectedSOi in SelectedSo)
            {

                selectedSOi.PickingsheetPrinted = true;


                //selectedContact.Street1 
            }
            myReport.PrintDialog();

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

        }

        private void SOPack_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void CompChk_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            string erromsg = "";
            ComplianceBL CBL = new ComplianceBL(Application);
            MessageOptions options = new MessageOptions();
            foreach (SOHeader so in e.SelectedObjects)
            {

                if (CBL.SoComplianceCheck(so, out erromsg) == 0)
                {
                    options.Duration = 20000;
                    options.Message = string.Format("Sales Order for {0} has been entered", so.CustomerNumber.CustomerName);
                    options.Type = InformationType.Success;
                    options.Web.Position = InformationPosition.Right;
                    options.Win.Caption = "Success";
                    options.Win.Type = WinMessageType.Alert;
                }
                else
                {
                    erromsg = Environment.NewLine + erromsg;
                    options.Duration = 20000;
                    options.Message = string.Format("Sales Order for {0} has been entered is in Compliance due to the following:{1}" , so.CustomerNumber.CustomerName, erromsg);
                    options.Type = InformationType.Warning;
                    options.Web.Position = InformationPosition.Right;
                    options.Win.Caption = "Needs Compliance Attention";
                    options.Win.Type = WinMessageType.Flyout;
                }
                Application.ShowViewStrategy.ShowMessage(options);
            }
        }
    }
}
