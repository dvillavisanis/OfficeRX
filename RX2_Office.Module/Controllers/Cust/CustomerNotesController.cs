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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using RX2_Office.Module.BusinessObjects;
using System.Drawing;
using RX2_Office.Module.rxClasses;
using System.Net.Mail;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.DirectXPaint;
using RX2_Office.Module.BusinessObjects.BusinessLogic;


namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerNotesController : ViewController
    {
        public CustomerNotesController()
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



        private void Note_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "CustomerNotePopup_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            CustomerNote note = objectSpace.CreateObject<CustomerNote>();
            note.Customers = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            note.Text = "test";


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, note);


            e.View.Caption = e.View.Caption + " - " + note.Customers.CustomerName;




            //e.Size = new Size(1000, 1000);




        }

        private void Note_Execute(object sender, PopupWindowShowActionExecuteEventArgs args)
        {
            args.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();


            MessageOptions options = new MessageOptions();

            options.Duration = 3000;
            options.Message = "Note Entered ";
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;

            Application.ShowViewStrategy.ShowMessage(options);

            View.ObjectSpace.Refresh();
            View.Refresh();
            //RxMail newmail = new RxMail();

            //newmail.MailTo = "dan@atlanticbiologicals.com";
            //newmail.MailFrom = "OfficeRx@atlanticbiologicals.com";
            //newmail.Body = "This is a test";
            //newmail.Subject = "test";
            //SmtpException ex = newmail.sendmail();
            //if (ex != null)
            //{
            //    options.Duration = 6000;
            //    options.Message = "No Email sent /r" + ex.Message;
            //    if (ex.InnerException != null)
            //    {
            //        options.Message = options.Message + "/r " + ex.InnerException.Message;
            //        if (ex.InnerException.InnerException != null)
            //        {
            //            options.Message = options.Message + "/r " + ex.InnerException.InnerException.Message;
            //        }
            //        options.Message = options.Message + "/r  TargetSite:" + ex.TargetSite;
            //    }
            //    options.Type = InformationType.Warning;
            //    options.Web.Position = InformationPosition.Right;
            //    options.Win.Caption = "Email Problem";
            //    options.Win.Type = WinMessageType.Alert;

            //    Application.ShowViewStrategy.ShowMessage(options);

        }


        private void SalesOrderPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            SOHeader so = (SOHeader)e.PopupWindowViewCurrentObject;
            string erromsg;
            ComplianceBL CBL = new ComplianceBL(Application);
            MessageOptions options = new MessageOptions();
            if (CBL.SoComplianceCheck(so, out erromsg) == 0)
            {
                options.Duration = 20000;
                options.Message = string.Format("Sales Order for {0} has been entered", so.CustomerNumber.CustomerName);
                options.Type = InformationType.Success;
                options.Web.Position = InformationPosition.Right;
                options.Win.Caption = "Success";
                options.Win.Type = WinMessageType.Alert;
                so.SOStatus = SalesOrderStatus.Submitted;
            }
            else
            {
                options.Duration = 20000;
                options.Message = string.Format("Sales Order for {0} has been entered is in Compliance due to the following {1}", so.CustomerNumber.CustomerName, erromsg);
                options.Type = InformationType.Warning;
                options.Web.Position = InformationPosition.Right;
                options.Win.Caption = "Success Need Compliance";
                options.Win.Type = WinMessageType.Alert;
                so.SOStatus = SalesOrderStatus.ComplianceCheck;

            }
            Application.ShowViewStrategy.ShowMessage(options);
            string msg = string.Format("Sales order: {2} entered by {0} {1} ", SecuritySystem.CurrentUserName, System.Environment.NewLine,so.SalesOrderNumber);
            foreach (SODetails det in so.SODetails)
            {
                msg = msg + string.Format(det.Item.ItemNumber.ToString() + " {0:C2} @ {1} {2} ", det.QtyOrdered, det.UnitPrice, System.Environment.NewLine);
            }
            so.CustomerNumber.AddNote(so.CustomerNumber, msg);

        }

        private void SalesOrderPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "SOHeader_NewSO";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            SOHeader newOrder = objectSpace.CreateObject<SOHeader>();

            newOrder.CustomerNumber = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            newOrder.SalesRep = newOrder.CustomerNumber.SalesRep;
            newOrder.SalesOrderDate = DateTime.Now;
            newOrder.SOStatus = SalesOrderStatus.New;
            newOrder.ShippingType = newOrder.CustomerNumber.ShippingType;
            newOrder.SalesOrderNumber = "test0001";
            if (newOrder.ShippingType == null)
            {
                newOrder.ShippingType = ApplicationOptions.getDefaultShippingType(objectSpace);
            }

            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, newOrder);
            e.View.Caption = e.View.Caption + " - " + newOrder.CustomerNumber.CustomerName;

        }

        private void DrugRequestAction_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            TargetViewId = "ItemRequest_DetailView_SalesRepRequest";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemRequest itemrequest = objectSpace.CreateObject<ItemRequest>();

            itemrequest.Customer = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, itemrequest);
            //e.Size = new Size(1000, 1000);

        }

        private void DrugRequestAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            View.Refresh();
            MessageOptions options = new MessageOptions();
            options.Duration = 20000;
            options.Message = string.Format("{0} Request have been successfully updated!", e.PopupWindow.Application.Title);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Flyout;
            //options.OkDelegate = () => {
            //    IObjectSpace os = Application.CreateObjectSpace(typeof(Customer));
            // DetailView newTaskDetailView = Application.CreateDetailView(os, os.CreateObject<ItemRequest>());
            // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
            //};
            Application.ShowViewStrategy.ShowMessage(options);



        }
        private void sendnewrequestemail(object sender, PopupWindowShowActionExecuteEventArgs args)
        {
            ItemRequest ccr = (ItemRequest)args.PopupWindowViewCurrentObject;
            RxMail newmail = new RxMail();

            MessageOptions options = new MessageOptions();
#if DEBUG
            {
                newmail.MailTo = "dan@atlanticbiologicals.com";
            }

#else
            newmail.MailTo = "sales@atlanticbiologicals.com";
#endif
            newmail.MailFrom = "OfficeRx@atlanticbiologicals.com";

            //   newmail.Body = "This is a test";
            //"        .style2 { width: 189px; background-color: #66FF99; text-align: right;border-style: solid;border-width: 1px;padding: 1px 4px;}" +
            newmail.Body = "<html xmlns=\"http://www.w3.org/1999/xhtml \">" +
                "<head>" +
"    <title>Untitled Page</title>" +
"    <style type=\"text / css\">" +
  "        .style1 { width: 100%; }" +
  "        .style2 { width: 189px; background-color: #66FF99; text-align: right;border-style: solid;border-width: 1px;padding: 1px 4px;}" +
  "        .style3 {text-align: center; background-color: #66FF99 ;border-style: solid;border-width: 1px;padding: 1px 4px;}" +
  "        .style4 {   border-style: solid;border-width: 1px;padding: 1px 4px;}" +
  "    </style>" +
  "</head>" +
  "<body>" +
  "    <table class=\"style1\">" +
  "        <tr>" +
  "            <td class=\"style3\" colspan=\"2\"> Customer Item Request </td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\">Request Id </td>" +
  "            <td class=\"style4\">" + ccr.Oid.ToString() + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\">Request Date</td>" +
                "            <td class=\"style4\"> " + ccr.RequestDt.ToLongTimeString() + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\">NDC</td>" +
  "            <td class=\"style4\"> " + ccr.ItemNumber.AccountingNumber + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\"> NDC Description</td>" +
  "            <td class=\"style4\">" + ccr.ItemNumber.ItemDescription + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\"> PTB</td>" +
  "            <td class=\"style4\"> " + ccr.ItemNumber.CurrentPTB.ToString("c") + "</td>" +
  "        </tr>" +
    "         <tr>" +
  "            <td class=\"style2\"> Min</td>" +
  "            <td class=\"style4\"> " + ccr.ItemNumber.MinPrice.ToString("c") + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\"> Qty Requested</td>" +
  "            <td class=\"style4\">" + ccr.RequestQty.ToString("0,00") + "</td>" +
  "        </tr>" +
  "        <tr>" +
  "            <td class=\"style2\"> Requested By</td>" +
  "            <td class=\"style4\"> " + ccr.RequestBy + "</td>" +
  "        </tr>" +
    "         <tr>" +
  "            <td class=\"style2\"> Requested For</td>" +
  "            <td class=\"style4\"> " + ccr.Customer.CustomerName + "</td>" +
  "        </tr>" +
  "         <tr>" +
  "            <td class=\"style2\"> Wholesaler For</td>" +
  "            <td class=\"style4\"> " + ccr.Customer.Wholesaler.Name + "</td>" +
  "        </tr>" +
  "         <tr>" +
  "            <td class=\"style2\"> In state</td>" +
  "            <td class=\"style4\"> " + ccr.Customer.ShipState + "</td>" +
  "        </tr>" +
  "    </table>" +
  "</body>" +
  "</html>";

            newmail.Subject = "test";
            SmtpException ex = newmail.sendmail();
            if (ex != null)
            {
                options.Duration = 6000;
                options.Message = "No Email sent /r" + ex.Message;
                if (ex.InnerException != null)
                {
                    options.Message = options.Message + "/r " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        options.Message = options.Message + "/r " + ex.InnerException.InnerException.Message;
                    }
                    options.Message = options.Message + "/r  TargetSite:" + ex.TargetSite;
                }
                Application.ShowViewStrategy.ShowMessage(options);
            }
        }


        private void CustomerRequestPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            ItemRequest ccr = (ItemRequest)e.PopupWindowViewCurrentObject;

            ccr.Customer.AddNote(ccr.Customer, string.Format("Item Request has been sent to purchasing \r\n Item: {0} {1} \r\n Customer: {2} \r\n Qty: {3} \r\n Price: {4} ", ccr.ItemNumber.AccountingNumber, ccr.ItemNumber.ItemDescription, ccr.Customer.CustomerName, ccr.RequestQty.ToString(), ccr.UnitPrice.ToString("c")));

            e.PopupWindow.View.ObjectSpace.CommitChanges();
            //  ((ListView)View).CollectionSource.Reload();
            View.ObjectSpace.Refresh();

            MessageOptions options = new MessageOptions();
            options.Message = string.Format("Item Request has been sent for Item: {0} {1} for Customer {2}",
                                  ccr.ItemNumber.AccountingNumber,
                                  ccr.ItemNumber.ItemDescription,
                                  ccr.Customer.CustomerName);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            options.Duration = 10000;
            Application.ShowViewStrategy.ShowMessage(options);

            View.Refresh();
            sendnewrequestemail(sender, e);
        }
        private void CustomerRequestPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TargetViewId = "ItemRequest_DetailView_SalesRepRequest";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            ItemRequest itemreq = objectSpace.CreateObject<ItemRequest>();
            itemreq.Customer = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            itemreq.SearchUntil = DateTime.Today.AddDays(3);
            itemreq.ItemRequestType = ItemRequestType.Search;
            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, itemreq);
            e.View.Caption = e.View.Caption + " - " + itemreq.Customer.CustomerName;
            //e.Size = new Size(1000, 1000);
        }





        private void ReleaseCustomer_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //  IObjectSpace objectSpace = Application.CreateObjectSpace();
            // SalesRep SR = objectSpace.FindObject<SalesRep>(new BinaryOperator("SalesRepCode", "GOLD MINE"));

            //            if (SR != null)
            //          {
            if (e.SelectedObjects.Count > 0)
            {
                using (IObjectSpace os = Application.CreateObjectSpace())
                {
                    SalesRep SR = os.FindObject<SalesRep>(new BinaryOperator("SalesRepCode", "GOLD MINE"));
                    int count = 0;
                    foreach (Customer selectedCustomer in e.SelectedObjects)
                    {
                        Customer cust = os.GetObject<Customer>(selectedCustomer);
                        cust.SalesRep = SR;

                        CustomerRelease custr = os.CreateObject<CustomerRelease>();

                        custr.Customer = cust;
                        custr.ReleasedBy = SecuritySystem.CurrentUserName;
                        custr.ReleasedDate = DateTime.Now;
                        count++;
                    }
                    os.CommitChanges();
                    MessageOptions options = new MessageOptions();
                    options.Duration = 3000;
                    options.Message = string.Format("{0} Customers have been released!", count.ToString());
                    options.Type = InformationType.Success;
                    options.Web.Position = InformationPosition.Right;
                    options.Win.Caption = "Success";
                    options.Win.Type = WinMessageType.Alert;
                    //options.OkDelegate = () => {
                    //    IObjectSpace os1 = Application.CreateObjectSpace(typeof(Customer));
                    // DetailView newTaskDetailView = Application.CreateDetailView(os1, os1.CreateObject<Customer>());
                    // Application.ShowViewStrategy.ShowViewInPopupWindow(newTaskDetailView);
                    //};
                    Application.ShowViewStrategy.ShowMessage(options);
                    View.ObjectSpace.Refresh();
                                        View.Refresh();

                }
            }

        }


        private void ReleaseCustomer_CustomGetFormattedConfirmationMessage(object sender, CustomGetFormattedConfirmationMessageEventArgs e)
        {
            e.ConfirmationMessage = "You are about to Release Customer into Gold Mine. Do you want to proceed?";

        }

        private void NewContact_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            CustomerContact cc = (CustomerContact)e.PopupWindowViewCurrentObject;
            e.PopupWindow.View.ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            MessageOptions options = new MessageOptions();
            options.Message = string.Format("Contact added for :{0}  {1}",
                                  cc.Customers.CustomerName,
                                  cc.FullName);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Success";
            options.Win.Type = WinMessageType.Alert;
            options.Duration = 10000;
            Application.ShowViewStrategy.ShowMessage(options);


        }

        private void newContact_Parm(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            TargetViewId = "CustomerContact_DetailView";
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            CustomerContact CustCont = objectSpace.CreateObject<CustomerContact>();
            CustCont.Customers = objectSpace.GetObject<Customer>((Customer)View.CurrentObject);
            CustCont.State = CustCont.Customers.BillingState;
            CustCont.Phone = CustCont.Customers.Phone;
            CustCont.Address = CustCont.Customers.BillingAddress;
            CustCont.Address2 = CustCont.Customers.BillingAddress2;
            CustCont.City = CustCont.Customers.BillingCity;
            CustCont.Fax = CustCont.Customers.Fax;
            CustCont.ZipCode = CustCont.Customers.BillingZip;


            e.View = Application.CreateDetailView(objectSpace, TargetViewId, true, CustCont);
            e.View.Caption = e.View.Caption + " - " + CustCont.Customers.CustomerName;

        }

        private void actionpopupCustomerMeeting_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }

        private void actionpopupCustomerMeeting_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            Customer customer = (Customer)View.CurrentObject;
            IObjectSpace space = View.ObjectSpace.CreateNestedObjectSpace();

            CustomerEvent meeting = space.CreateObject<CustomerEvent>();
            meeting.Customer = space.GetObject<Customer>(customer);

            e.View = Application.CreateDetailView(space, meeting);
        }
    }
}

