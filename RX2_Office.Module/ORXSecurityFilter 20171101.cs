using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ReportsV2;
using RX2_Office.Module.BusinessObjects;
using RX2_Office.Module.Reports;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;



namespace RX2_Office.Module
{
    public class ORXSecurityFilter : ModelNodesGeneratorUpdater<ModelListViewFiltersGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            IModelListViewFilters filtersNode = (IModelListViewFilters)node;
            #region CustomerFilters
            if (((IModelListView)filtersNode.Parent).ModelClass.TypeInfo.Type ==
                typeof(Customer))
            {

                bool flag = ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("SalesMGR") || ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Administrators");
                if (flag)
                {
                    IModelListViewFilterItem myFilter = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter");
                    myFilter.Criteria = "";
                    myFilter.Index = 99;
                    myFilter.ToolTip = "All Customers will take longer";
                    myFilter.Caption = "All";
                    myFilter.Description = "All";
                    IModelListViewFilterItem myFilter1 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter1");

                    myFilter1.Criteria = "[LastInvoiceDate] >=  ADDDAYS(LocalDateTimeToday(), -30) ";
                    myFilter1.Index = 98;
                    myFilter1.ToolTip = "All Customers who Purchase In 30 Days  will take longer";
                    myFilter1.Caption = "All Customers who Purchase In 30 Days ";
                    myFilter1.Description = "All Customers who Purchase In 30 Days ";

                    IModelListViewFilterItem myFilter2 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter2");
                    myFilter2.Criteria = "[LastInvoiceDate] >=  ADDDAYS(LocalDateTimeToday(), -60) ";
                    myFilter2.Index = 98;
                    myFilter2.ToolTip = "All Customers who Purchase In 60 Days  will take longer";
                    myFilter2.Caption = "All Customers who Purchase In 60 Days ";
                    myFilter2.Description = "All Customers who Purchase In 60 Days ";

                    //filtersNode.CurrentFilter = myFilter;
                }
            }
            #endregion
            #region Customer Notes
            if (((IModelListView)filtersNode.Parent).ModelClass.TypeInfo.Type == typeof(CustomerNote))
            {

                bool flag = ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("SalesMGR") || ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Administrators");
                if (flag)
                {
                    IModelListViewFilterItem myFilter = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter");
                    myFilter.Criteria = "";
                    myFilter.Index = 99;
                    myFilter.ToolTip = "All Notes will take longer";
                    myFilter.Caption = "All";
                    myFilter.Description = "All";

                    IModelListViewFilterItem myFilter1 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter1");
                    myFilter1.Criteria = "[NoteDate] >  ADDDAYS(LocalDateTimeToday(), -365)  ";
                    myFilter1.Index = 98;
                    myFilter1.ToolTip = "All Notes for the past 365 days";
                    myFilter1.Caption = "All Notes for the past 365 days";
                    myFilter1.Description = "All Notes for the past 365 days";
                    //filtersNode.CurrentFilter = myFilter;
                }
            }
            #endregion
            #region Customer cdr


            if (((IModelListView)filtersNode.Parent).ModelClass.TypeInfo.Type == typeof(CustomerCDR))
            {

                bool flag = ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("CDRMgr") || ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Administrators");
                if (flag)
                {
                    IModelListViewFilterItem myFilter = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter");
                    myFilter.Criteria = "";
                    myFilter.Index = 99;
                    myFilter.ToolTip = "All Notes will take longer";
                    myFilter.Caption = "All";
                    myFilter.Description = "All";

                    IModelListViewFilterItem myFilter1 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter1");
                    myFilter1.Criteria = "[CallDate] = LocalDateTimeThisWeek() ";
                    myFilter1.Index = 98;
                    myFilter1.ToolTip = "All This Weeks Calls";
                    myFilter1.Caption = "All This Weeks Calls";
                    myFilter1.Description = "All This Weeks Calls";


                    IModelListViewFilterItem myFilter2 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter2");
                    myFilter2.Criteria = "[CallDate] = LocalDateTimeToday()";
                    myFilter2.Index = 97;
                    myFilter2.ToolTip = "All Today's Calls";
                    myFilter2.Caption = "All Today's Calls";
                    myFilter2.Description = "All Today's Calls";
                    //filtersNode.CurrentFilter = myFilter;

                }
            }
            #endregion

            #region Customer InvoiceHistory
            //         [ListViewFilter("Past Year", "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -365)", "Past Year Invoice", "Only invoices in the past year. ", false)]
            // [ListViewFilter("Last Week", "[InvoiceDate] > LocalDateTimeLastWeek() and [InvoiceDate] < LocalDateTimeThisWeek()", "Last Week", "Last Weeks Invoices. ", false)]
            // [ListViewFilter("Last Month", "[InvoiceDate] > LocalDateTimeLastMonth() and [InvoiceDate] < LocalDateTimeThisMonth()", "Last Month", "Last month Invoices. ", false)]
            // [ListViewFilter("This Week", "[InvoiceDate] > LocalDateTimeThisWeek() and [InvoiceDate] <= LocalDateTimeToday()", "This Week", "This Weeks Invoices. ", false)]
            // [ListViewFilter("This Month", "[InvoiceDate] > LocalDateTimeThisMonth() and [InvoiceDate] < LocalDateTimeNextMonth()", "This Month", "Thisd month Invoices. ", false)]

            if (((IModelListView)filtersNode.Parent).ModelClass.TypeInfo.Type == typeof(CustomerInvoiceHistory))
            {

                bool flag = ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("AllCustomerInvoices") || ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Administrators");
                if (flag)
                {
                    IModelListViewFilterItem myFilter = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter");
                    myFilter.Criteria = "";
                    myFilter.Index = 99;
                    myFilter.ToolTip = "All Invoices will take longer";
                    myFilter.Caption = "All Invoices";
                    myFilter.Description = "All";

                    IModelListViewFilterItem myFilter1 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter1");
                    myFilter1.Criteria = "[InvoiceDate] >  ADDDAYS(LocalDateTimeToday(), -365)";
                    myFilter1.Index = 97;
                    myFilter1.ToolTip = "All Past Year";
                    myFilter1.Caption = "All Past Year";
                    myFilter1.Description = "All Past Year Invoices";


                    IModelListViewFilterItem myFilter2 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter2");
                    myFilter1.Criteria = "[InvoiceDate] > LocalDateTimeThisMonth() and [InvoiceDate] < LocalDateTimeNextMonth()";
                    myFilter1.Index = 98;
                    myFilter1.ToolTip = "All Last Month";
                    myFilter1.Caption = "All Last Month";
                    myFilter1.Description = "Last Month Invoices";


                }




            }
            #endregion

            #region Item Request
       // [ListViewFilter(" My Open Last 30 Day Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -30)  ", " My Open last 30 days Request ", "Request I created In the last 30 days", true, Index = 0)]
       // [ListViewFilter(" My Open Last 30 Day Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -90)  ", " My Open last 90 days Request ", "Request I created In the last 90 days", true, Index = 2)]
       // [ListViewFilter(" My ALL Open Request ", "[RequestBy] = CurrentUserName() && [RequestStatus] < 9  ", " My All Open Request ", "All Open Request I created", false, Index = 5)]
       // [ListViewFilter(" All ", "", " All", "All Request", false, Index = 10)]

            if (((IModelListView)filtersNode.Parent).ModelClass.TypeInfo.Type == typeof(ItemRequest))
            {

                bool flag = ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Purchasing") || ((SecuritySystemUser)SecuritySystem.CurrentUser).IsUserInRole("Administrators");
                if (flag)
                {
                    IModelListViewFilterItem myFilter = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter");
                    myFilter.Criteria = "";
                    myFilter.Index = 99;
                    myFilter.ToolTip = "All Request will take longer";
                    myFilter.Caption = "All";
                    myFilter.Description = "All";

                    IModelListViewFilterItem myFilter1 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter1");
                    myFilter1.Criteria = "[RequestStatus] < 9    ";
                    myFilter1.Index = 82;
                    myFilter1.ToolTip = "All open request ";
                    myFilter1.Caption = "All open request";
                    myFilter1.Description = "All open ";


                    IModelListViewFilterItem myFilter2 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter2");
                    myFilter2.Criteria = "[RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -30)  ";
                    myFilter2.Index = 80;
                    myFilter2.ToolTip = "All open request for the past 30 days";
                    myFilter2.Caption = "All 30 day open request";
                    myFilter2.Description = "All open request for the past 30 days";
                    //filtersNode.CurrentFilter = myFilter;

                    IModelListViewFilterItem myFilter3 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter3");
                    myFilter3.Criteria = "[RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -60)  ";
                    myFilter3.Index = 81;
                    myFilter3.ToolTip = "All open request for the past 60 days";
                    myFilter3.Caption = "All 60 day open request";
                    myFilter3.Description = "All open request for the past 60 days";
                    //filtersNode.CurrentFilter = myFilter;

                    IModelListViewFilterItem myFilter4 = filtersNode.AddNode<IModelListViewFilterItem>("MyComplexFilter4");
                    myFilter4.Criteria = "[RequestStatus] < 9  && [RequestDt] >=  ADDDAYS(LocalDateTimeToday(), -90)  ";
                    myFilter4.Index = 82;
                    myFilter4.ToolTip = "All open request for the past 90 days";
                    myFilter4.Caption = "All 90 day open request";
                    myFilter4.Description = "All open request for the past 90 days";

                    //filtersNode.CurrentFilter = myFilter;


                }
            }
            #endregion



        }



    }
}
