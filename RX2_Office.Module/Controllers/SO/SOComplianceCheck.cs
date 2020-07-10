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
using RX2_Office.Module.BusinessObjects.BusinessLogic;

namespace RX2_Office.Module.Controllers.SO
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SOComplianceCheck : ViewController
    {
        public SOComplianceCheck()
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
                    options.Message = string.Format("Sales Order for {0} has been Checked and is OKAY", so.CustomerNumber.CustomerName);
                    options.Type = InformationType.Success;
                    options.Web.Position = InformationPosition.Right;
                    options.Win.Caption = "Success";
                    options.Win.Type = WinMessageType.Alert;
                    so.SOStatus = SalesOrderStatus.Picking;
                    so.CustomerNumber.AddNote(so.CustomerNumber, String.Format("Sales Order: {0} Has been Move out of Compliance.", so.SalesOrderNumber));
                    so.Save();
                    ObjectSpace.CommitChanges();
                    View.Refresh();
                }
                else
                {
                    erromsg = Environment.NewLine + erromsg;
                    options.Duration = 20000;
                    options.Message = string.Format("Sales Order for {0} has been Checked will be entered into compliance due to the following:{1}", so.CustomerNumber.CustomerName, erromsg);
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
