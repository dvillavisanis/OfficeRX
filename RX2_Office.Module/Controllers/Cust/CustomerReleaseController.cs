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
    public partial class CustomerReleaseController : ViewController
    {
        public CustomerReleaseController()
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

        private void GrabCustomer_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (e.SelectedObjects.Count > 0)
            {
                if (this.GetAvailableSnatchLimit(SecuritySystem.CurrentUserName) >= e.SelectedObjects.Count)
                {

                    using (IObjectSpace os = Application.CreateObjectSpace())
                    {
                        SalesRep SR = os.FindObject<SalesRep>(new BinaryOperator("SalesRepCode", SecuritySystem.CurrentUserName.ToUpper()));
                        if (SR == null  )
                        {
                            SR = os.CreateObject<SalesRep>();
                            SR.SalesRepCode = SecuritySystem.CurrentUserName;
                            os.CommitChanges();

                        }

                        foreach (CustomerRelease selectedCustomer in e.SelectedObjects)
                        {
                            CustomerRelease custr = os.GetObject<CustomerRelease>(selectedCustomer);
                            custr.AquiredBy = SecuritySystem.CurrentUserName.ToUpper();
                            custr.AquiredDate = DateTime.Now;
                            Customer cust = os.FindObject<Customer>(new BinaryOperator("Oid", custr.Customer ) );

                            cust.SalesRep = SR;
                            cust.SalesRepAssignedDt = DateTime.Now;

                        }
                        os.CommitChanges();
                        ((ListView)View).CollectionSource.Reload();
                    }
               
                }
            }

        }

        private int GetAvailableSnatchLimit(string aSalesRepName)
        {
            // a sales rep can only grab X customer in a rolling 30 day period
            using (IObjectSpace os = Application.CreateObjectSpace())
            {
                int apid = 1;
                ApplicationOptions ao = os.FindObject<ApplicationOptions>(new BinaryOperator("Ref", apid, BinaryOperatorType.Equal));

                DateTime startdate = DateTime.Today.AddDays(-30);
                Object count = os.Evaluate(typeof(CustomerRelease), CriteriaOperator.Parse("Count()"),
                        CriteriaOperator.Parse("[AquiredBy]=? and [AquiredDate] >= ?", aSalesRepName, startdate));

                if (count != null)
                {
                    return ao.ThrityDayCustomerSnatchLimit - Convert.ToInt32(count);
                }
            }


            return 0;

        }



    }




}
