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
using System.Collections;
using System.Diagnostics;


namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ChangeRecMgrController : ViewController
    {

        private ChoiceActionItem setSalesRepItem;
        public ChangeRecMgrController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ChangeRecMgr.Items.Clear();
          
            //SalesRep sr = os.CreateObject<SalesRep>();
            setSalesRepItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(SalesRep), "Sales Rep"), null);
            ChangeRecMgr.Items.Add(setSalesRepItem);

            foreach (SalesRep sr in ObjectSpace.GetObjects<SalesRep>())
            {
                ChangeRecMgr.Items.Add(
                    new ChoiceActionItem(sr.SalesRepCode, sr.SalesRepCode));
            }

            // Target required Views (via the TargetXXX properties) and create their Actions.
            //}



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

        private void ChangeRecMgr_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            
            IObjectSpace os = this.ObjectSpace;
            //ArrayList ObjectsToProcess = new ArrayList(e.SelectedObjects);
            if (e.SelectedChoiceActionItem.ParentItem != setSalesRepItem)
            {
                int rc_count = 0;
                foreach (Customer obj in e.SelectedObjects)
                {
                    SalesRep sr = os.FindObject<SalesRep>(new BinaryOperator("SalesRepCode", e.SelectedChoiceActionItem.Data));
                    //Customer objInNewObjectSpace = (Customer)ObjectSpace.GetObject(obj);
                    obj.SalesRep = sr;
                    obj.SalesRepAssignedDt = DateTime.Now;
                    rc_count++;
                                   

                }
                MessageOptions options = new MessageOptions();
                options.Message = string.Format("Record Manager Changed for {0} Customers",
                                      rc_count.ToString("#,###"));
                options.Type = InformationType.Success;
                options.Web.Position = InformationPosition.Right;
                options.Win.Caption = "Success";
                options.Win.Type = WinMessageType.Alert;
                options.Duration = 10000;
                Application.ShowViewStrategy.ShowMessage(options);


            }

        }

        private void ChangeSalesRep_CustomGetFormattedConfirmationMessage(object sender, CustomGetFormattedConfirmationMessageEventArgs e)
        {


            e.ConfirmationMessage = string.Format("You are about to change Record Manager of all the selected customer to {0}", " ");
                ;

        }

    }
}
