using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;
using RX2_Office.Module.BusinessObjects;
using DevExpress.Persistent.Base;
using System;

using System.Linq;

namespace RX2_Office.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

         
            #region Security default  System Users


            Employee sampleUser = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "User"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<Employee>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("");
                sampleUser.FirstName = "Sample";
                sampleUser.LastName = "User";

            }
            EmployeeRole defaultRole = CreateDefaultRole();
            sampleUser.EmployeeRoles.Add(defaultRole);
            #endregion
            #region Administrator

            EmployeeRole adminRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<EmployeeRole>();
                adminRole.Name = "Administrators";

            }
            adminRole.IsAdministrative = true;
            #endregion
            #region admin
            Employee userAdmin = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<Employee>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("fireant");
                userAdmin.FirstName = "Default";
                userAdmin.LastName = "Admin";
                userAdmin.EmployeeRoles.Add(adminRole);
                ObjectSpace.CommitChanges();
            }
            // If a role with the Administrators name doesn't exist in the database, create this role

            userAdmin.EmployeeRoles.Add(adminRole);
            ObjectSpace.CommitChanges();
            #region DefaultAdmin
            // If a role with the Administrators name doesn't exist in the database, create this role
            #region DVill
            Employee userAdmin2 = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "DVillavisanis"));
            if (userAdmin2 == null)
            {
                userAdmin2 = ObjectSpace.CreateObject<Employee>();
                userAdmin2.UserName = "DVILLAVISANIS";
                userAdmin2.FirstName = "Daniel";
                userAdmin2.LastName = "Villavisanis";
                userAdmin2.PhoneExt = "275";
                userAdmin2.MobileNumber = "9542607590";
                userAdmin2.Birthday = Convert.ToDateTime("10/20/1977");
                // Set a password if the standard authentication type is used 
                userAdmin2.SetPassword("fireant7270");
                userAdmin2.EmployeeRoles.Add(adminRole);
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userAdmin2.ComparePassword("fireant7270"))
                {

                    userAdmin2.SetPassword("fireant7270");
                }
                if (!userAdmin2.IsUserInRole(adminRole.Name))
                {
                    userAdmin2.EmployeeRoles.Add(adminRole);
                }
                if (userAdmin2.IsActive == false)
                {
                    userAdmin2.IsActive = true;

                }

                ObjectSpace.CommitChanges();
            }
            #endregion

            #endregion

            #region Sales Users

            Employee userSalesOnly = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "SalesOnly"));
            if (userSalesOnly == null)
            {
                userSalesOnly = ObjectSpace.CreateObject<Employee>();
                userSalesOnly.UserName = "SalesOnly";
                userSalesOnly.FirstName = "Sales";
                userSalesOnly.LastName = "Only";
                // Set a password if the standard authentication type is used 
                userSalesOnly.SetPassword("atlantic21");
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userSalesOnly.ComparePassword("atlantic21"))
                {
                    userSalesOnly.SetPassword("atlantic21");
                }

                if (userSalesOnly.IsActive == false)
                {
                    userSalesOnly.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }

            Employee userSalesRO = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "SalesRO"));
            if (userSalesRO == null)
            {
                userSalesRO = ObjectSpace.CreateObject<Employee>();
                userSalesRO.UserName = "SalesRO";
                userSalesRO.FirstName = "Sales";
                userSalesRO.LastName = "ReadOnly";
                // Set a password if the standard authentication type is used 
                userSalesRO.SetPassword("atlantic21");
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userSalesRO.ComparePassword("atlantic21"))
                {
                    userSalesRO.SetPassword("atlantic21");
                }

                if (userSalesRO.IsActive == false)
                {
                    userSalesRO.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }

            Employee userSalesMgr = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "SalesMGR"));
            if (userSalesMgr == null)
            {
                userSalesMgr = ObjectSpace.CreateObject<Employee>();
                userSalesMgr.UserName = "SalesMGR";
                userSalesMgr.FirstName = "User Sales";
                userSalesMgr.LastName = "MGR";
                // Set a password if the standard authentication type is used 
                userSalesMgr.SetPassword("atlantic21");

                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userSalesMgr.ComparePassword("atlantic21"))
                {
                    userSalesMgr.SetPassword("atlantic21");
                }

                if (userSalesMgr.IsActive == false)
                {
                    userSalesMgr.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }
            #endregion sales user

            #region CustomerCDR

            EmployeeRole CDRMgr = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "CDRMgr"));
            if (CDRMgr == null)
            {
                CDRMgr = ObjectSpace.CreateObject<EmployeeRole>();
                CDRMgr.Name = "CDRMgr";

                //CDRMgr.SetTypePermission(item, "Create;Navigate;Delete", SecurityPermissionState.Allow);
                CDRMgr.SetTypePermission(typeof(CustomerCDR), "Read;Navigate", SecurityPermissionState.Allow);
                ObjectSpace.CommitChanges();
            }
            #endregion

            #region Inventory Users
            Employee userInvMgr = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "InventoryMGR"));
            if (userInvMgr == null)
            {
                userInvMgr = ObjectSpace.CreateObject<Employee>();
                userInvMgr.UserName = "InventoryMGR";
                // Set a password if the standard authentication type is used 
                userInvMgr.SetPassword("atlantic21");
                userInvMgr.FirstName = "User Inv";
                userInvMgr.LastName = "Mgr";
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userInvMgr.ComparePassword("atlantic21"))
                {
                    userInvMgr.SetPassword("atlantic21");
                }

                if (userInvMgr.IsActive == false)
                {
                    userInvMgr.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }

            Employee userItemMaintRo = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "ItemMaintRo"));
            if (userItemMaintRo == null)
            {
                userItemMaintRo = ObjectSpace.CreateObject<Employee>();
                userItemMaintRo.UserName = "ItemMaintRo";
                // Set a password if the standard authentication type is used 
                userItemMaintRo.SetPassword("atlantic21");
                userItemMaintRo.FirstName = "User ITem Maint";
                userItemMaintRo.LastName = "Mgr";
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userItemMaintRo.ComparePassword("atlantic21"))
                {
                    userItemMaintRo.SetPassword("atlantic21");
                }

                if (userItemMaintRo.IsActive == false)
                {
                    userItemMaintRo.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }


            Employee userInvRo = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "InventoryRo"));
            if (userInvRo == null)
            {
                userInvRo = ObjectSpace.CreateObject<Employee>();
                userInvRo.UserName = "InventoryRo";
                // Set a password if the standard authentication type is used 
                userInvRo.SetPassword("atlantic21");
                userInvRo.FirstName = "User Inv";
                userInvRo.LastName = "Mgr";
                ObjectSpace.CommitChanges();
            }
            else
            {
                if (!userInvRo.ComparePassword("atlantic21"))
                {
                    userInvRo.SetPassword("atlantic21");
                }

                if (userInvRo.IsActive == false)
                {
                    userInvRo.IsActive = true;

                }
                ObjectSpace.CommitChanges();
            }


            #endregion
            #endregion

            #region Roles

            EmployeeRole CustomerCheckData = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "CustomerCheckData"));
            if (CustomerCheckData == null)
            {
                CustomerCheckData = ObjectSpace.CreateObject<EmployeeRole>();
                CustomerCheckData.Name = "CustomerCheckData";
                ObjectSpace.CommitChanges();
            }

            EmployeeRole CustomContactLock = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "CustomContactLock"));
            if (CustomerCheckData == null)
            {
                CustomContactLock = ObjectSpace.CreateObject<EmployeeRole>();
                CustomContactLock.Name = "CustomContactLock";

                ObjectSpace.CommitChanges();
            }
            //#region Security roles
            #region Lookup
            EmployeeRole LookupRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Lookup"));
            if (LookupRole == null)
            {
                LookupRole = ObjectSpace.CreateObject<EmployeeRole>();
                LookupRole.Name = "Lookup";
                //Role.SetTypePermission(item, "Create;Navigate;Delete", SecurityPermissionState.Allow);

                LookupRole.SetTypePermission(typeof(CustomerClassification), "Read", SecurityPermissionState.Allow);

                LookupRole.SetTypePermission(typeof(CustomerCDR), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(CustomerGPO), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(CustomerIDN), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(CustomerParentSystem), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(CustomerTerritory), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(DistributionCenter), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(DistributionCenterWhse), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ItemProductLine), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(LicenseType), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(Manufacturer), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(MarketingGroup), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(RepackStatus), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ShippingType), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(RX2_Office.Module.BusinessObjects.State), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ZipCodes), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(Items), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ItemInventory), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ItemPricingGroup), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ItemPricingGroupList), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(ItemRequest), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(SalesTeams), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(CustomerInvoicePayments), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(AuditDataItemPersistent), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(Vendor), "Read", SecurityPermissionState.Allow);
                LookupRole.SetTypePermission(typeof(Wholesaler), "Read", SecurityPermissionState.Allow);

                ObjectSpace.CommitChanges();
            }

            #endregion
            #region Sales View All Customers
            EmployeeRole SalesViewAllCustomers = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "SalesViewAllCustomers"));
            if (SalesViewAllCustomers == null)
            {
                SalesViewAllCustomers = ObjectSpace.CreateObject<EmployeeRole>();
                SalesViewAllCustomers.Name = "SalesViewAllCustomers";
                userSalesMgr.EmployeeRoles.Add(SalesViewAllCustomers);
                ObjectSpace.CommitChanges();
            }
            #endregion
            #region Sales
            EmployeeRole SalesRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Sales"));
            if (SalesRole == null)
            {
                SalesRole = ObjectSpace.CreateObject<EmployeeRole>();
                SalesRole.Name = "Sales";
                //Role.SetTypePermission(item, "Create;Navigate;Delete", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(Customer), "Navigate;Write;Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerNote), "Create;Navigate;Write;Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerContact), "Create;Navigate;Write;Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerIDN), "Read;", SecurityPermissionState.Allow);                SalesRole.SetTypePermission(typeof(CustomerInvoiceHistory), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerInvoiceHistoryDetails), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerClassification), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerLicenseVerifications), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerGPO), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerParentSystem), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(ItemPricingGroup), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(SalesRep), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(SOHeader), "Create;Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(SODetails), "Create;Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(Items), "Read;Navigate", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(ItemTransaction), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(ItemRequest), "Read;Create;", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerItemPricing), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerWebUsers), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerCustomUDRequest), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(DistributionCenter), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(DistributionCenterWhse), "Read", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(ShippingType), "Read;", SecurityPermissionState.Allow);

                SalesRole.AddMemberPermission(typeof(Customer), "Write", "CreditLimit", null, SecurityPermissionState.Deny);
                SalesRole.AddMemberPermission(typeof(Customer), "Read", "CreditLimit", null, SecurityPermissionState.Allow);

                userSalesOnly.EmployeeRoles.Add(SalesRole);

                ObjectSpace.CommitChanges();
            }


            EmployeeRole CustomContactLockRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "CustomContactLock"));
            if (CustomContactLockRole == null)
            {
                CustomContactLockRole = ObjectSpace.CreateObject<EmployeeRole>();
                CustomContactLockRole.Name = "CustomContactLock";
                CustomContactLockRole.SetTypePermission(typeof(CustomerContact), "Navigate;Write;Read", SecurityPermissionState.Allow);
                userAdmin.EmployeeRoles.Add(CustomContactLockRole);
                userAdmin2.EmployeeRoles.Add(CustomContactLockRole);
            }


            EmployeeRole SalesLicenseVerRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "SalesLicenseVer"));
            if (SalesLicenseVerRole == null)
            {
                SalesLicenseVerRole = ObjectSpace.CreateObject<EmployeeRole>();
                SalesLicenseVerRole.Name = "SalesLicenseVer";
                //Role.SetTypePermission(item, "Create;Navigate;Delete", SecurityPermissionState.Allow);
                SalesLicenseVerRole.SetTypePermission(typeof(CustomerLicenseVerifications), "Navigate;Write;Read", SecurityPermissionState.Allow);
                userAdmin.EmployeeRoles.Add(SalesLicenseVerRole);
                userAdmin2.EmployeeRoles.Add(SalesLicenseVerRole);
            }



            EmployeeRole AllCustomerInvoices = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "ViewAllCustomerInvoices"));
            if (AllCustomerInvoices == null)
            {
                AllCustomerInvoices = ObjectSpace.CreateObject<EmployeeRole>();
                AllCustomerInvoices.Name = "ViewAllCustomerInvoices";
                //Role.SetTypePermission(item, "Create;Navigate;Delete", SecurityPermissionState.Allow);
                //AllCustomerInvoices.SetTypePermission(typeof(CustomerLicenseVerifications), "Navigate;Write;Read", SecurityPermissionState.Allow);
                userAdmin.EmployeeRoles.Add(AllCustomerInvoices);
                userAdmin2.EmployeeRoles.Add(AllCustomerInvoices);

            }


            EmployeeRole SalesReadOnlyRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "SalesReadOnlyRole"));
            if (SalesReadOnlyRole == null)
            {
                SalesReadOnlyRole = ObjectSpace.CreateObject<EmployeeRole>();
                SalesReadOnlyRole.Name = "SalesReadOnlyRole";
                SalesReadOnlyRole.SetTypePermission(typeof(Customer), "Read;Navigate", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerNote), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerContact), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerIDN), "Read;", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerInvoiceHistory), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerInvoiceHistoryDetails), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerClassification), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerLicenseVerifications), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerGPO), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(CustomerParentSystem), "Read", SecurityPermissionState.Allow);
                SalesReadOnlyRole.SetTypePermission(typeof(ItemPricingGroup), "Read", SecurityPermissionState.Allow);
                userSalesRO.EmployeeRoles.Add(SalesReadOnlyRole);
                ObjectSpace.CommitChanges();
            }


            EmployeeRole SalesMgrRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "SalesMgrRole"));
            if (SalesMgrRole == null)
            {
                SalesMgrRole = ObjectSpace.CreateObject<EmployeeRole>();
                SalesMgrRole.Name = "SalesMgrRole";
                SalesMgrRole.SetTypePermission(typeof(Customer), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerNote), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerContact), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerIDN), "Read;Write;Create;Navigate;", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerInvoiceHistory), "Read;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerInvoiceHistoryDetails), "Read;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerClassification), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerLicenseVerifications), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerGPO), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerParentSystem), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(ItemPricingGroup), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(WebUsers), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerItemPricing), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesMgrRole.SetTypePermission(typeof(CustomerWebUsers), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                SalesRole.SetTypePermission(typeof(CustomerCustomUDRequest), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);

                userSalesMgr.EmployeeRoles.Add(SalesMgrRole);
                userAdmin.EmployeeRoles.Add(SalesMgrRole);
                userAdmin2.EmployeeRoles.Add(SalesMgrRole);


                ObjectSpace.CommitChanges();
            }

            #endregion

            #region Accounting Role
            EmployeeRole AccountingRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Accounting"));
            if (AccountingRole == null)
            {
                AccountingRole = ObjectSpace.CreateObject<EmployeeRole>();
                AccountingRole.Name = "Accounting";


                AccountingRole.SetTypePermission(typeof(Items), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                AccountingRole.SetTypePermission(typeof(ItemProductLine), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                AccountingRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                AccountingRole.SetTypePermission(typeof(ItemInventory), "Read;Navigate", SecurityPermissionState.Allow);


                ObjectSpace.CommitChanges();

            }

            
    


            #region ContactMgr
            // used for locking and unlocking Contacts
            EmployeeRole CustomerContactRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "ContactMgr"));
            if (CustomerContactRole == null)
            {
                CustomerContactRole = ObjectSpace.CreateObject<EmployeeRole>();
                CustomerContactRole.Name = "ContactMgr";
                                ObjectSpace.CommitChanges();
            }

            #endregion



            #region Item
            EmployeeRole ItemMaintenanceRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Item Maintenence"));
            if (ItemMaintenanceRole == null)
            {
                ItemMaintenanceRole = ObjectSpace.CreateObject<EmployeeRole>();
                ItemMaintenanceRole.Name = "Item Maintenence";


                ItemMaintenanceRole.SetTypePermission(typeof(Items), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                ItemMaintenanceRole.SetTypePermission(typeof(ItemProductLine), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                ItemMaintenanceRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                ItemMaintenanceRole.SetTypePermission(typeof(ItemInventory), "Read;Write;Create;Navigate", SecurityPermissionState.Allow);
                userInvMgr.EmployeeRoles.Add(ItemMaintenanceRole);
                userAdmin.EmployeeRoles.Add(ItemMaintenanceRole);
                userAdmin2.EmployeeRoles.Add(ItemMaintenanceRole);
                // userAdmin2.EmployeeRoles.Add(SalesMgrRole);
                ObjectSpace.CommitChanges();

            }
            #endregion

            #region Inventory
            EmployeeRole InventoryMgrRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "InventoryMgr"));
            if (InventoryMgrRole == null)
            {
                InventoryMgrRole = ObjectSpace.CreateObject<EmployeeRole>();
                InventoryMgrRole.Name = "InventoryMgr";


                InventoryMgrRole.SetTypePermission(typeof(Items), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                InventoryMgrRole.SetTypePermission(typeof(ItemProductLine), "Create;Write;Read;Navigate", SecurityPermissionState.Allow);
                InventoryMgrRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                InventoryMgrRole.SetTypePermission(typeof(ItemInventory), "Read;Navigate", SecurityPermissionState.Allow);

                userInvMgr.EmployeeRoles.Add(InventoryMgrRole);
                userAdmin.EmployeeRoles.Add(SalesMgrRole);
                userAdmin2.EmployeeRoles.Add(SalesMgrRole);
                ObjectSpace.CommitChanges();

            }
            #region Item PTB Role
            EmployeeRole ItemPtbMaint = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Item PTB Maintenance"));
            if (ItemPtbMaint == null)
            {
                ItemPtbMaint = ObjectSpace.CreateObject<EmployeeRole>();
                ItemPtbMaint.Name = "Item PTB Maintenance";
               
                ItemPtbMaint.SetTypePermission(typeof(ItemPTB), "Read;Create;Write;Navigate", SecurityPermissionState.Allow);
                ObjectSpace.CommitChanges();
                userAdmin.EmployeeRoles.Add(ItemPtbMaint);
                userAdmin2.EmployeeRoles.Add(ItemPtbMaint);
            }
            #endregion

            #region Item Min Role
            EmployeeRole ItemMinMaint = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Item Min Maintenance"));
            if (ItemMinMaint == null)
            {
                ItemMinMaint = ObjectSpace.CreateObject<EmployeeRole>();
                ItemMinMaint.Name = "Item Min Maintenance";
                ItemMinMaint.SetTypePermission(typeof(ItemPTB), "Read;Create;Write;Navigate", SecurityPermissionState.Allow);
                ObjectSpace.CommitChanges();
                userAdmin.EmployeeRoles.Add(ItemMinMaint);
                userAdmin2.EmployeeRoles.Add(ItemMinMaint);
            }

            #endregion

            EmployeeRole InventoryRORole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Inventory Read Only"));
            if (InventoryRORole == null)
            {
                InventoryRORole = ObjectSpace.CreateObject<EmployeeRole>();
                InventoryRORole.Name = "Inventory Read Only";

                InventoryRORole.SetTypePermission(typeof(Items), "Read;Navigate", SecurityPermissionState.Allow);
                InventoryRORole.SetTypePermission(typeof(ItemProductLine), "Read", SecurityPermissionState.Allow);
                InventoryRORole.SetTypePermission(typeof(ItemTransaction), "Read", SecurityPermissionState.Allow);
                InventoryMgrRole.SetTypePermission(typeof(ItemInventory), "Read", SecurityPermissionState.Allow);
                userInvRo.EmployeeRoles.Add(InventoryRORole);
                userSalesMgr.EmployeeRoles.Add(InventoryRORole);
                userSalesRO.EmployeeRoles.Add(InventoryRORole);

                ObjectSpace.CommitChanges();

            }

            #endregion

            #region Workorder Roles

            EmployeeRole WorkOrdersRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Work Orders"));
            if (WorkOrdersRole == null)
            {
                WorkOrdersRole = ObjectSpace.CreateObject<EmployeeRole>();
                WorkOrdersRole.Name = "Work Orders";

                WorkOrdersRole.SetTypePermission(typeof(WorkOrders), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                WorkOrdersRole.SetTypePermission(typeof(WorkOrderStatus), "Read;Navigate", SecurityPermissionState.Allow);
                WorkOrdersRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                // WorkOrdersRole.SetTypePermission(typeof(RepackItems), "Read;Write,Create,Navigate", SecurityPermissionState.Allow);

                ObjectSpace.CommitChanges();
            }


            EmployeeRole WorkOrdersRORole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Work Orders Read Only"));
            if (WorkOrdersRORole == null)
            {
                WorkOrdersRORole = ObjectSpace.CreateObject<EmployeeRole>();
                WorkOrdersRORole.Name = "Work Orders Read Only";

                WorkOrdersRORole.SetTypePermission(typeof(WorkOrders), "Read;Write;Navigate", SecurityPermissionState.Allow);
                WorkOrdersRORole.SetTypePermission(typeof(WorkOrderStatus), "Read;Navigate", SecurityPermissionState.Allow);
                WorkOrdersRORole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                ObjectSpace.CommitChanges();
            }

            #endregion

            #region Purchasing Role
            EmployeeRole PurchasingRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Purchasing"));
            if (PurchasingRole == null)
            {
                PurchasingRole = ObjectSpace.CreateObject<EmployeeRole>();
                PurchasingRole.Name = "Purchasing";
                PurchasingRole.SetTypePermission(typeof(ItemPurchaseOrder), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(ItemPurchaseOrderLine), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(ItemReceiver), "Read;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(Vendor), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(VendorNote), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(VendorType), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                PurchasingRole.SetTypePermission(typeof(VendorContact), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                //PurchasingRole.ChildRoles.Add(InventoryMgrRole);

                ObjectSpace.CommitChanges();

            }
            #endregion


            #region Repack Roles
            EmployeeRole RepackItem = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "RepackItemMaint"));
            if (RepackItem == null)
            {
                RepackItem = ObjectSpace.CreateObject<EmployeeRole>();
                RepackItem.Name = "RepackItemMaint";
                RepackItem.SetTypePermission(typeof(RepackItems), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackLots), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackLotSerialNo), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackLotOperations), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackLotStatus), "Read;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackMachines), "Read;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(RepackPackager), "Read;Navigate", SecurityPermissionState.Allow);
                RepackItem.SetTypePermission(typeof(VendorContact), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                //PurchasingRole.ChildRoles.Add(InventoryMgrRole);

                ObjectSpace.CommitChanges();

            }
            EmployeeRole RepackItemAdmin = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "RepackItemLabelAdmin"));
            if (RepackItemAdmin == null)
            {
                RepackItemAdmin = ObjectSpace.CreateObject<EmployeeRole>();
                RepackItemAdmin.Name = "RepackItemLabelAdmin";

                ObjectSpace.CommitChanges();
            }
            #endregion



            #region Shipping Role
            EmployeeRole ShippingRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Shipping"));
            if (ShippingRole == null)
            {
                ShippingRole = ObjectSpace.CreateObject<EmployeeRole>();
                ShippingRole.Name = "Shipping";
                ShippingRole.SetTypePermission(typeof(ItemReceiver), "Create;Read;Write;Navigate", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(Items), "Read;Navigate", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(ItemTransaction), "Read;Navigate", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(ItemUnitOfMeasure), "Read", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(ItemProductLine), "Read", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(DistributionCenterWhse), "Read", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(DistributionCenterWhseBins), "Read", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(DistributionCenter), "Read", SecurityPermissionState.Allow);
                ShippingRole.SetTypePermission(typeof(Shippers), "Read", SecurityPermissionState.Allow);
                ObjectSpace.CommitChanges();

            }
            ObjectSpace.CommitChanges();
            #endregion
            #endregion

            #endregion
            #region Unit of Measures

            ItemUnitOfMeasure UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "EA"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "EA";
                unitOfMeassure.Description = "EACH";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK60"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK60";
                unitOfMeassure.Description = "Package of 60";
                ObjectSpace.CommitChanges();
            }


            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK5"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK5";
                unitOfMeassure.Description = "Package of 5";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK10"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK10";
                unitOfMeassure.Description = "Package of 10";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK14"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK14";
                unitOfMeassure.Description = "Package of 14";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK36"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK36";
                unitOfMeassure.Description = "Package of 36";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK25"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK25";
                unitOfMeassure.Description = "Package of 25";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK12"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK12";
                unitOfMeassure.Description = "Package of 12";
                ObjectSpace.CommitChanges();
            }
            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK4"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK4";
                unitOfMeassure.Description = "Package of 4";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "PK24"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "PK24";
                unitOfMeassure.Description = "Package of 24";
                ObjectSpace.CommitChanges();
            }
            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "CASE"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "CASE";
                unitOfMeassure.Description = "CASE";
                ObjectSpace.CommitChanges();
            }


            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "P100"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "P100";
                unitOfMeassure.Description = "Package of 100";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "KIT"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "KIT";
                unitOfMeassure.Description = "KIT";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "C100"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "C100";
                unitOfMeassure.Description = "Carton of 100";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "C500"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "C500";
                unitOfMeassure.Description = "Carton of 500";
                ObjectSpace.CommitChanges();
            }



            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "BOX"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "BOX";
                unitOfMeassure.Description = "BOX";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "EACH"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "EACH";
                unitOfMeassure.Description = "EACH";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "BAG"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "BAG";
                unitOfMeassure.Description = "BAG";
                ObjectSpace.CommitChanges();
            }

            UOM = ObjectSpace.FindObject<ItemUnitOfMeasure>(new BinaryOperator("UnitOfMeasureCode", "BX50"));
            if (UOM == null)
            {
                ItemUnitOfMeasure unitOfMeassure = ObjectSpace.CreateObject<ItemUnitOfMeasure>();
                unitOfMeassure.UnitOfMeasureCode = "BX50";
                unitOfMeassure.Description = "BX50";
                ObjectSpace.CommitChanges();
            }
            #endregion
            #region Commission formulas
            CommissionFormulas CF;

            CF = ObjectSpace.FindObject<CommissionFormulas>(new BinaryOperator("FormulaCode", "PctOfSales"));
            if (CF == null)
            {
                CommissionFormulas cf = ObjectSpace.CreateObject<CommissionFormulas>();
                cf.OID = 1;
                cf.FormulaCode = "PctOfSales";
                cf.FormulaDescription = "Percentage of Sales";
                cf.Formula = "% of Sales";

                ObjectSpace.CommitChanges();
            }

            CF = ObjectSpace.FindObject<CommissionFormulas>(new BinaryOperator("FormulaCode", "PctOfGP"));
            if (CF == null)
            {

                CommissionFormulas cf = ObjectSpace.CreateObject<CommissionFormulas>();
                cf.OID = 2;
                cf.FormulaCode = "PctOfGP";
                cf.FormulaDescription = " Percentage of Gross Profit";
                cf.Formula = "% of (Sales - COGS)";
                ObjectSpace.CommitChanges();
            }
            CF = ObjectSpace.FindObject<CommissionFormulas>(new BinaryOperator("FormulaCode", "PctOfGP-UAF"));
            //uaf = Unit admin Fee
            if (CF == null)
            {
                CommissionFormulas cf = ObjectSpace.CreateObject<CommissionFormulas>();
                cf.OID = 3;
                cf.FormulaCode = "PctOfGP-UAF";
                cf.FormulaDescription = "Percentage of GP minus a unit admin fee";
                cf.Formula = "% of (Sales - (COGS-(qty * Unit Admin Fee))";
                ObjectSpace.CommitChanges();
            }
            #endregion
            #region Payment Terms
            PaymentTermsCode PTC;
            PTC = ObjectSpace.FindObject<PaymentTermsCode>(new BinaryOperator("PaymentTermCode", "NET30"));
            if (PTC == null)
            {
                PaymentTermsCode ptc = ObjectSpace.CreateObject<PaymentTermsCode>();
                ptc.PaymentTermCode = "NET30";
                ptc.TermCodeDescription = "Net Due in 30 Days";
                ptc.DiscountPercentage = 0;
                ptc.DaysBeforeDue = 30;
                ObjectSpace.CommitChanges();
            }

            PTC = ObjectSpace.FindObject<PaymentTermsCode>(new BinaryOperator("PaymentTermCode", "NET15"));
            if (PTC == null)
            {
                PaymentTermsCode ptc = ObjectSpace.CreateObject<PaymentTermsCode>();
                ptc.PaymentTermCode = "NET15";
                ptc.TermCodeDescription = "Net Due in 15 Days";
                ptc.DiscountPercentage = 0;
                ptc.DaysBeforeDue = 15;
                ObjectSpace.CommitChanges();
            }
            #endregion
            #region Repack status
            //RepackStatus RCKStatus;
            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 1));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 1;
            //    rs.StatusDescription = "Intake";
            //    rs.StatusOrder = 1;
            //    ObjectSpace.CommitChanges();
            //}
            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 2));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 2;
            //    rs.StatusDescription = "Packaging";
            //    rs.StatusOrder = 3;
            //    ObjectSpace.CommitChanges();
            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 3));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 3;
            //    rs.StatusDescription = "Quality Check";
            //    rs.StatusOrder = 4;
            //    ObjectSpace.CommitChanges();
            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 4));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 4;
            //    rs.StatusDescription = "Shipping";
            //    rs.StatusOrder = 6;
            //    ObjectSpace.CommitChanges();

            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 5));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 5;
            //    rs.StatusDescription = "Invoicing";
            //    rs.StatusOrder = 7;
            //    ObjectSpace.CommitChanges();
            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 6));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 6;
            //    rs.StatusDescription = "Completed";
            //    rs.StatusOrder = 8;
            //    ObjectSpace.CommitChanges();
            //}
            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 7));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 7;
            //    rs.StatusDescription = "Pharm Check";
            //    rs.StatusOrder = 5;
            //    ObjectSpace.CommitChanges();
            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 8));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 8;
            //    rs.StatusDescription = "Quarantine";
            //    rs.StatusOrder = 9;
            //    ObjectSpace.CommitChanges();
            //}
            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 9));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 9;
            //    rs.StatusDescription = "Quarantine Returned";
            //    rs.StatusOrder = 10;
            //    ObjectSpace.CommitChanges();
            //}

            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 10));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 10;
            //    rs.StatusDescription = "Intake QC";
            //    rs.StatusOrder = 2;
            //    ObjectSpace.CommitChanges();
            //}
            //RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 11));
            //if (RCKStatus == null)
            //{
            //    RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
            //    rs.RepackStatusId = 11;
            //    rs.StatusDescription = "Deleted";
            //    rs.StatusOrder = 11;
            //    ObjectSpace.CommitChanges();
            //}

            #endregion
            #region License Type
            LicenseType LT;
            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "STAT"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "STAT";
                rs.LicenseDescription = "State";
                ObjectSpace.CommitChanges();
            }

            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "CTRL"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "CTRL";
                rs.LicenseDescription = "Control";
                ObjectSpace.CommitChanges();
            }

            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "DEA"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "DEA";
                rs.LicenseDescription = "DEA-Drug Enforce Adm";
                ObjectSpace.CommitChanges();
            }
            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "COO"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "COO";
                rs.LicenseDescription = "Certificate of Occupancy";
                ObjectSpace.CommitChanges();
            }

            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "GDST"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "GDST";
                rs.LicenseDescription = "Good Standing";
                ObjectSpace.CommitChanges();
            }

            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "VAWD"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "VAWD";
                rs.LicenseDescription = "VAWD";
                ObjectSpace.CommitChanges();
            }
            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "FDL"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "FDL";
                rs.LicenseDescription = "Fire Department";
                ObjectSpace.CommitChanges();
            }
            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "PRVL"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "PRVL";
                rs.LicenseDescription = "Privilege License";
                ObjectSpace.CommitChanges();
            }

            LT = ObjectSpace.FindObject<LicenseType>(new BinaryOperator("LicenseTypeCode", "Cul"));
            if (LT == null)
            {
                LicenseType rs = ObjectSpace.CreateObject<LicenseType>();
                rs.LicenseTypeCode = "CUL";
                rs.LicenseDescription = "Cert. Unico Licitadores";
                ObjectSpace.CommitChanges();
            }
            #endregion

            #region# Defualt Shipper Shipper SE;
            //SE = ObjectSpace.FindObject<Shipper>(new BinaryOperator("Employee.UserName", "DVILLAVISANIS"));

            //if (SE == null)
            //{
            //    Employee userAdminb = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "DVILLAVISANIS"));
            //    SE = ObjectSpace.CreateObject<Shipper>();
            //     // SE.ShipperId = "DVILLAVISANIS";
            //    SE.FirstName = "Daniel";
            //    SE.LastName = "Villavisanis";
            //    ObjectSpace.CommitChanges();
            //}
            #endregion#

            //SE = ObjectSpace.FindObject<Shipper>(new BinaryOperator("UserName", "ADMIN"));
            //if (SE == null)
            //{
            //    Employee userAdmina = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "Admin"));
            //    SE = ObjectSpace.CreateObject<Shipper>();
            //   // SE.Oid = userAdmina.Oid;
            //   // SE.ShipperId = "ADMIN";
            //    SE.FirstName = "ADMIN";
            //    SE.LastName = "Default";
            //    ObjectSpace.CommitChanges();
            //}
            #region CustomerContactType
            CustomerContactType CCT;
            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "AP"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "AP";
                ct.ContactTypeDescription = "Accounts Payable Contact";
                ObjectSpace.CommitChanges();
            }
            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "MAIN"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "MAIN";
                ct.ContactTypeDescription = "Main Number";
                ObjectSpace.CommitChanges();
            }
            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "OTHER"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "OTHER";
                ct.ContactTypeDescription = "Other Contact";
                ObjectSpace.CommitChanges();
            }

            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "PRIMA"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "PRIMA";
                ct.ContactTypeDescription = "Primary Contact";
                ObjectSpace.CommitChanges();
            }

            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "SECON"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "SECON";
                ct.ContactTypeDescription = "Second Contact";
                ObjectSpace.CommitChanges();
            }

            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "RC"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "RC";
                ct.ContactTypeDescription = "Retired Contact";
                ObjectSpace.CommitChanges();
            }

            CCT = ObjectSpace.FindObject<CustomerContactType>(new BinaryOperator("ContactTypeCd", "FC"));
            if (CCT == null)
            {
                CustomerContactType ct = ObjectSpace.CreateObject<CustomerContactType>();
                ct.ContactTypeCd = "FC";
                ct.ContactTypeDescription = "Former Contact";
                ObjectSpace.CommitChanges();
            }





            #endregion

            #region Default Whse Bin
            DistributionCenterWhseBins DCW;
            DCW = ObjectSpace.FindObject<DistributionCenterWhseBins>(new BinaryOperator("BinBarcode", "000"));
            if (DCW == null)
            {
                DistributionCenterWhseBins rs = ObjectSpace.CreateObject<DistributionCenterWhseBins>();
                //rs.OID = "000";
                rs.BinBarcode = "000";
                rs.BinLevel = "00";
                rs.BinRack = "00";
                //rs.Warehouse = "000";

                ObjectSpace.CommitChanges();
            }
            #endregion
            #region RepackDistributors
            RepackDistributor RD;
            RD = ObjectSpace.FindObject<RepackDistributor>(new BinaryOperator("RepackDistributorName", "Atlantic Biologicals Corp"));
            if (RD == null)
            {
                RepackDistributor RD1 = ObjectSpace.CreateObject<RepackDistributor>();
                RD1.RepackDistributorName = "Atlantic Biologicals Corp";
                RD1.RepackDistributorAddress = "20101 NE 16th Pl.";
                RD1.RepackDistributorCity = "Miami";
                RD1.RepackDistributorZipCode = "33179";
                ObjectSpace.CommitChanges();
            }

            RD = ObjectSpace.FindObject<RepackDistributor>(new BinaryOperator("RepackDistributorName", "Arbor Pharmaceuticals, LLC"));
            if (RD == null)
            {
                RepackDistributor RD1 = ObjectSpace.CreateObject<RepackDistributor>();
                RD1.RepackDistributorName = "Arbor Pharmaceuticals, LLC";
                RD1.RepackDistributorAddress = " ";
                RD1.RepackDistributorCity = "Atlanta";
                RD1.RepackDistributorZipCode = "30328";
                ObjectSpace.CommitChanges();
            }

            #endregion


            #region Default CustomerBillingTerms
            CustomerBillingTerms CBT;
            CBT = ObjectSpace.FindObject<CustomerBillingTerms>(new BinaryOperator("TermName", "Net 30"));
            if (CBT == null)
            {
                CustomerBillingTerms rs = ObjectSpace.CreateObject<CustomerBillingTerms>();
                //rs.OID = "000";
                rs.TermName = "Net 30";
                rs.DueinDays = 30;

                ObjectSpace.CommitChanges();
            }
            #endregion

            #region Sales Team
            SalesTeams SlsTeam;

            SlsTeam = ObjectSpace.FindObject<SalesTeams>(new BinaryOperator("TeamCode", "000"));
            if (SlsTeam == null)
            {
                SalesTeams rs = ObjectSpace.CreateObject<SalesTeams>();
                //rs.OID = "000";
                rs.TeamCode = "000";
                rs.TeamDiscription = "Red";
                rs.TeamGoal = 500000;
                //rs.Warehouse = "000";

                ObjectSpace.CommitChanges();
            }
            #endregion

            #region defaultadmin
            // main admin
            userAdmin.EmployeeRoles.Add(CustomContactLockRole);
            userAdmin.EmployeeRoles.Add(CustomerCheckData);
            userAdmin.EmployeeRoles.Add(CustomerContactRole);

                
            userAdmin2.EmployeeRoles.Add(CustomContactLockRole);
            userAdmin2.EmployeeRoles.Add(CustomerCheckData);
            userAdmin2.EmployeeRoles.Add(CustomerContactRole);

            ObjectSpace.CommitChanges();



            # endregion

        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private EmployeeRole CreateDefaultRole()
        {

            EmployeeRole adminEmployeeRole = ObjectSpace.FindObject<EmployeeRole>(
       new BinaryOperator("Name", SecurityStrategy.AdministratorRoleName));
            if (adminEmployeeRole == null)
            {
                adminEmployeeRole = ObjectSpace.CreateObject<EmployeeRole>();
                adminEmployeeRole.Name = SecurityStrategy.AdministratorRoleName;
                adminEmployeeRole.IsAdministrative = true;
                adminEmployeeRole.Save();
            }
            Employee adminEmployee = ObjectSpace.FindObject<Employee>(
                new BinaryOperator("UserName", "Administrator"));
            if (adminEmployee == null)
            {
                adminEmployee = ObjectSpace.CreateObject<Employee>();
                adminEmployee.UserName = "Administrator";
                adminEmployee.FirstName = "Administrator";
                adminEmployee.SetPassword("");
                adminEmployee.EmployeeRoles.Add(adminEmployeeRole);

            }
            ObjectSpace.CommitChanges();

            EmployeeRole defaultRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<EmployeeRole>();
                defaultRole.Name = "Default";

                //defaultRole.AddObjectPermission<Employee>;

                //defaultRole.AddMemberAccessPermission<Employee>("ChangePasswordOnFirstLogon", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                //defaultRole.AddMemberAccessPermission<Employee>("StoredPassword", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                //defaultRole.SetTypePermissionRecursively<EmployeeRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                //defaultRole.SetTypePermissionRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Deny);
                //defaultRole.SetTypePermissionRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Deny);

                //defaultRole.AddObjectAccessPermission<Employee>("[Oid] = CurrentUserId()", SecurityOperations.ReadOnlyAccess);
                //defaultRole.AddMemberAccessPermission<Employee>("ChangePasswordOnFirstLogon", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                //defaultRole.AddMemberAccessPermission<Employee>("StoredPassword", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                //defaultRole.SetTypePermissionRecursively<EmployeeRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                //defaultRole.SetTypePermissionRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Deny);
                //defaultRole.SetTypePermissionRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Deny);

            }
            return defaultRole;
        }



    }
}
