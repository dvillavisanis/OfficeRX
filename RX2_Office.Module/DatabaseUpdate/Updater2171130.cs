using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

using RX2_Office.Module.BusinessObjects;

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

            #region admin
            SecuritySystemUser sampleUser = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "User"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<SecuritySystemUser>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("");

            }
            SecuritySystemRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            SecuritySystemRole adminRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;

            SecuritySystemUser userAdmin = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<SecuritySystemUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
                userAdmin.Roles.Add(adminRole);
                ObjectSpace.CommitChanges();
            }
            // If a role with the Administrators name doesn't exist in the database, create this role

            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges();

            // If a role with the Administrators name doesn't exist in the database, create this role
            SecuritySystemUser userAdmin2 = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "DVillavisanis"));
            if (userAdmin2 == null)
            {
                userAdmin2 = ObjectSpace.CreateObject<SecuritySystemUser>();
                userAdmin2.UserName = "DVILLAVISANIS";
                // Set a password if the standard authentication type is used 
                userAdmin2.SetPassword("fireant7270");
                userAdmin2.Roles.Add(adminRole);
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
                    userAdmin2.Roles.Add(adminRole);
                }
                if (userAdmin2.IsActive == false)
                {
                    userAdmin2.IsActive = true;

                }

                ObjectSpace.CommitChanges();
            }
            #endregion
            #region admin2
            Employee esampleUser = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "User"));
            if (esampleUser == null)
            {
                esampleUser = ObjectSpace.CreateObject<Employee>();
                esampleUser.UserName = "User";
                esampleUser.SetPassword("");

            }
            // EmployeeRole edefaultRole = CreateDefaultRole();
            // esampleUser.Roles.Add(edefaultRole);

            EmployeeRole eadminRole = ObjectSpace.FindObject<EmployeeRole>(new BinaryOperator("Name", "Administrators"));
            if (eadminRole == null)
            {
                eadminRole = ObjectSpace.CreateObject<EmployeeRole>();
                eadminRole.Name = "Administrators";
            }
            eadminRole.IsAdministrative = true;

            Employee EAdmin = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "Admin"));
            if (EAdmin == null)
            {
                EAdmin = ObjectSpace.CreateObject<Employee>();
                EAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                EAdmin.SetPassword("");
                // EAdmin.Roles.Add(eadminRole);
                ObjectSpace.CommitChanges();
            }
            // If a role with the Administrators name doesn't exist in the database, create this role

            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges();

            // If a role with the Administrators name doesn't exist in the database, create this role
            SecuritySystemUser userAdmin2 = ObjectSpace.FindObject<Employee>(new BinaryOperator("UserName", "DVillavisanis"));
            if (userAdmin2 == null)
            {
                userAdmin2 = ObjectSpace.CreateObject<Employee>();
                userAdmin2.UserName = "DVILLAVISANIS";
                // Set a password if the standard authentication type is used 
                userAdmin2.SetPassword("fireant7270");
                userAdmin2.Roles.Add(adminRole);
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
                    userAdmin2.Roles.Add(adminRole);
                }
                if (userAdmin2.IsActive == false)
                {
                    userAdmin2.IsActive = true;

                }

                ObjectSpace.CommitChanges();
            }
            #endregion

            #region Sales Users

            SecuritySystemUser userSalesOnly = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "SalesOnly"));
            if (userSalesOnly == null)
            {
                userSalesOnly = ObjectSpace.CreateObject<SecuritySystemUser>();
                userSalesOnly.UserName = "SalesOnly";
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

            SecuritySystemUser userSalesRO = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "SalesRO"));
            if (userSalesRO == null)
            {
                userSalesRO = ObjectSpace.CreateObject<SecuritySystemUser>();
                userSalesRO.UserName = "SalesRO";
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

            SecuritySystemUser userSalesMgr = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "SalesMGR"));
            if (userSalesMgr == null)
            {
                userSalesMgr = ObjectSpace.CreateObject<SecuritySystemUser>();
                userSalesMgr.UserName = "SalesMGR";
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

            SecuritySystemRole CDRMgr = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "CDRMgr"));
            if (CDRMgr == null)
            {
                CDRMgr = ObjectSpace.CreateObject<SecuritySystemRole>();
                CDRMgr.Name = "CDRMgr";
                //Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                CDRMgr.SetTypePermissions(typeof(CustomerCDR), "Read;Navigate", SecuritySystemModifier.Allow);
                ObjectSpace.CommitChanges();
            }
            #endregion



            #region Inventory Users
            SecuritySystemUser userInvMgr = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "InventoryMGR"));
            if (userInvMgr == null)
            {
                userInvMgr = ObjectSpace.CreateObject<SecuritySystemUser>();
                userInvMgr.UserName = "InventoryMGR";
                // Set a password if the standard authentication type is used 
                userInvMgr.SetPassword("atlantic21");
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
            SecuritySystemUser userInvRo = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "InventoryRo"));
            if (userInvRo == null)
            {
                userInvRo = ObjectSpace.CreateObject<SecuritySystemUser>();
                userInvRo.UserName = "InventoryRo";
                // Set a password if the standard authentication type is used 
                userInvRo.SetPassword("atlantic21");
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

            #region Security roles
            #region Lookup
            SecuritySystemRole LookupRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Lookup"));
            if (LookupRole == null)
            {
                LookupRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                LookupRole.Name = "Lookup";
                //Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerClassification), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerCDR), "Read;Navigate", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerGPO), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerIDN), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerParentSystem), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerTerritory), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(DistributionCenter), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(DistributionCenterWhse), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ItemProductLine), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(LicenseType), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(Manufacturer), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(MarketingGroup), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(RepackStatus), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ShippingType), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(RX2_Office.Module.BusinessObjects.State), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ZipCodes), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(Items), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ItemInventory), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ItemPricingGroup), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ItemPricingGroupList), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(ItemRequest), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(SalesRepTeam), "Read", SecuritySystemModifier.Allow);
                LookupRole.SetTypePermissions(typeof(CustomerInvoicePayments), "Read", SecuritySystemModifier.Allow);

                LookupRole.SetTypePermissions(typeof(AuditDataItemPersistent), "Read", SecuritySystemModifier.Allow);


                ObjectSpace.CommitChanges();
            }

            #endregion
            SecuritySystemRole SalesViewAllCustomers = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "SalesViewAllCustomers"));
            if (SalesViewAllCustomers == null)
            {
                SalesViewAllCustomers = ObjectSpace.CreateObject<SecuritySystemRole>();
                SalesViewAllCustomers.Name = "SalesViewAllCustomers";
                userSalesMgr.Roles.Add(SalesViewAllCustomers);

                ObjectSpace.CommitChanges();
            }

            #region Sales
            SecuritySystemRole SalesRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Sales"));
            if (SalesRole == null)
            {
                SalesRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                SalesRole.Name = "Sales";
                //Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(Customer), "Navigate;Write;Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerNote), "Create;Navigate;Write;Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerContact), "Create;Navigate;Write;Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerIDN), "Read;Write;Navigate;", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerInvoiceHistory), "Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerInvoiceHistoryDetails), "Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerClassification), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerLicenseVerifications), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerGPO), "Read;Write;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerParentSystem), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(ItemPricingGroup), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(SalesRep), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(SOHeader), "Create;Navigate;Write;Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(SODetails), "Create;Navigate;Write;Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(Items), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(ItemRequest), "Read;Create;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerItemPricing), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerWebUsers), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerCustomUDRequest), "Read;Write;Create", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(DistributionCenter), "Read", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(DistributionCenterWhse), "Read;Write", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(ShippingType), "Read;Write", SecuritySystemModifier.Allow);


                SalesRole.ChildRoles.Add(LookupRole);

                userSalesOnly.Roles.Add(SalesRole);

                ObjectSpace.CommitChanges();
            }


            SecuritySystemRole SalesLicenseVerRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "SalesLicenseVer"));
            if (SalesLicenseVerRole == null)
            {
                SalesLicenseVerRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                SalesLicenseVerRole.Name = "SalesLicenseVer";
                //Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                SalesLicenseVerRole.SetTypePermissions(typeof(CustomerLicenseVerifications), "Navigate;Write;Read", SecuritySystemModifier.Allow);
                userAdmin.Roles.Add(SalesLicenseVerRole);
                userAdmin2.Roles.Add(SalesLicenseVerRole);
            }



            SecuritySystemRole AllCustomerInvoices = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "ViewAllCustomerInvoices"));
            if (AllCustomerInvoices == null)
            {
                AllCustomerInvoices = ObjectSpace.CreateObject<SecuritySystemRole>();
                AllCustomerInvoices.Name = "ViewAllCustomerInvoices";
                //Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                //AllCustomerInvoices.SetTypePermissions(typeof(CustomerLicenseVerifications), "Navigate;Write;Read", SecuritySystemModifier.Allow);
                userAdmin.Roles.Add(AllCustomerInvoices);
                userAdmin2.Roles.Add(AllCustomerInvoices);
            }


            SecuritySystemRole SalesReadOnlyRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "SalesReadOnlyRole"));
            if (SalesReadOnlyRole == null)
            {
                SalesReadOnlyRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                SalesReadOnlyRole.Name = "SalesReadOnlyRole";
                SalesReadOnlyRole.SetTypePermissions(typeof(Customer), "Read;Navigate", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerNote), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerContact), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerIDN), "Read;", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerInvoiceHistory), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerInvoiceHistoryDetails), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerClassification), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerLicenseVerifications), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerGPO), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(CustomerParentSystem), "Read", SecuritySystemModifier.Allow);
                SalesReadOnlyRole.SetTypePermissions(typeof(ItemPricingGroup), "Read", SecuritySystemModifier.Allow);
                userSalesRO.Roles.Add(SalesReadOnlyRole);
                ObjectSpace.CommitChanges();
            }


            SecuritySystemRole SalesMgrRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "SalesMgrRole"));
            if (SalesMgrRole == null)
            {
                SalesMgrRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                SalesMgrRole.Name = "SalesMgrRole";
                SalesMgrRole.SetTypePermissions(typeof(Customer), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerNote), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerContact), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerIDN), "Read;Write;Create;Navigate;", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerInvoiceHistory), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerInvoiceHistoryDetails), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerClassification), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerLicenseVerifications), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerGPO), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerParentSystem), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(ItemPricingGroup), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(WebUsers), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerItemPricing), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesMgrRole.SetTypePermissions(typeof(CustomerWebUsers), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);
                SalesRole.SetTypePermissions(typeof(CustomerCustomUDRequest), "Read;Write;Create;Navigate", SecuritySystemModifier.Allow);

                userSalesMgr.Roles.Add(SalesMgrRole);
                userAdmin.Roles.Add(SalesMgrRole);
                userAdmin2.Roles.Add(SalesMgrRole);


                ObjectSpace.CommitChanges();
            }




            #endregion

            #region Inventory
            SecuritySystemRole InventoryMgrRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "InventoryMgr"));
            if (InventoryMgrRole == null)
            {
                InventoryMgrRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                InventoryMgrRole.Name = "InventoryMgr";


                InventoryMgrRole.SetTypePermissions(typeof(Items), "Create;Write;Read;Navigate", SecuritySystemModifier.Allow);
                InventoryMgrRole.SetTypePermissions(typeof(ItemProductLine), "Create;Write;Read;Navigate", SecuritySystemModifier.Allow);
                InventoryMgrRole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                InventoryMgrRole.SetTypePermissions(typeof(ItemInventory), "Read;Navigate", SecuritySystemModifier.Allow);

                userInvMgr.Roles.Add(InventoryMgrRole);
                userAdmin.Roles.Add(SalesMgrRole);
                userAdmin2.Roles.Add(SalesMgrRole);
                ObjectSpace.CommitChanges();

            }

            SecuritySystemRole InventoryRORole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Inventory Read Only"));
            if (InventoryRORole == null)
            {
                InventoryRORole = ObjectSpace.CreateObject<SecuritySystemRole>();
                InventoryRORole.Name = "Inventory Read Only";

                InventoryRORole.SetTypePermissions(typeof(Items), "Read;Navigate", SecuritySystemModifier.Allow);
                InventoryRORole.SetTypePermissions(typeof(ItemProductLine), "Read;Navigate", SecuritySystemModifier.Allow);
                InventoryRORole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                InventoryMgrRole.SetTypePermissions(typeof(ItemInventory), "Read;Navigate", SecuritySystemModifier.Allow);
                userInvRo.Roles.Add(InventoryRORole);
                userSalesMgr.Roles.Add(InventoryRORole);
                userSalesRO.Roles.Add(InventoryRORole);

                ObjectSpace.CommitChanges();

            }

            #endregion

            #region Workorder Roles

            SecuritySystemRole WorkOrdersRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Work Orders"));
            if (WorkOrdersRole == null)
            {
                WorkOrdersRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                WorkOrdersRole.Name = "Work Orders";

                WorkOrdersRole.SetTypePermissions(typeof(WorkOrders), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                WorkOrdersRole.SetTypePermissions(typeof(WorkOrderStatus), "Read;Navigate", SecuritySystemModifier.Allow);
                WorkOrdersRole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                ObjectSpace.CommitChanges();
            }


            SecuritySystemRole WorkOrdersRORole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Work Orders Read Only"));
            if (WorkOrdersRORole == null)
            {
                WorkOrdersRORole = ObjectSpace.CreateObject<SecuritySystemRole>();
                WorkOrdersRORole.Name = "Work Orders Read Only";

                WorkOrdersRORole.SetTypePermissions(typeof(WorkOrders), "Read;Write;Navigate", SecuritySystemModifier.Allow);
                WorkOrdersRORole.SetTypePermissions(typeof(WorkOrderStatus), "Read;Navigate", SecuritySystemModifier.Allow);
                WorkOrdersRORole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                ObjectSpace.CommitChanges();
            }

            #endregion

            #region Purchasing Role
            SecuritySystemRole PurchasingRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Purchasing"));
            if (PurchasingRole == null)
            {
                PurchasingRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                PurchasingRole.Name = "Purchasing";
                PurchasingRole.SetTypePermissions(typeof(ItemPurchaseOrder), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(ItemPurchaseOrderLine), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(ItemReceiver), "Read;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(Vendor), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(VendorNote), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(VendorType), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.SetTypePermissions(typeof(VendorContact), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                PurchasingRole.ChildRoles.Add(InventoryMgrRole);

                ObjectSpace.CommitChanges();

            }
            #endregion

            #region Shipping Role
            SecuritySystemRole ShippingRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Shipping"));
            if (ShippingRole == null)
            {
                ShippingRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                ShippingRole.Name = "Shipping";
                ShippingRole.SetTypePermissions(typeof(ItemReceiver), "Create;Read;Write;Navigate", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(Items), "Read;Navigate", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(ItemTransaction), "Read;Navigate", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(ItemUnitOfMeasure), "Read", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(ItemProductLine), "Read", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(DistributionCenterWhse), "Read", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(DistributionCenterWhseBins), "Read", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(DistributionCenter), "Read", SecuritySystemModifier.Allow);
                ShippingRole.SetTypePermissions(typeof(Shippers), "Read", SecuritySystemModifier.Allow);
                ObjectSpace.CommitChanges();

            }
            #endregion



            ObjectSpace.CommitChanges();
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
            RepackStatus RCKStatus;
            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 1));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 1;
                rs.StatusDescription = "Intake";
                rs.StatusOrder = 1;
                ObjectSpace.CommitChanges();
            }
            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 2));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 2;
                rs.StatusDescription = "Packaging";
                rs.StatusOrder = 3;
                ObjectSpace.CommitChanges();
            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 3));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 3;
                rs.StatusDescription = "Quality Check";
                rs.StatusOrder = 4;
                ObjectSpace.CommitChanges();
            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 4));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 4;
                rs.StatusDescription = "Shipping";
                rs.StatusOrder = 6;
                ObjectSpace.CommitChanges();

            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 5));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 5;
                rs.StatusDescription = "Invoicing";
                rs.StatusOrder = 7;
                ObjectSpace.CommitChanges();
            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 6));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 6;
                rs.StatusDescription = "Completed";
                rs.StatusOrder = 8;
                ObjectSpace.CommitChanges();
            }
            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 7));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 7;
                rs.StatusDescription = "Pharm Check";
                rs.StatusOrder = 5;
                ObjectSpace.CommitChanges();
            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 8));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 8;
                rs.StatusDescription = "Quarantine";
                rs.StatusOrder = 9;
                ObjectSpace.CommitChanges();
            }
            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 9));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 9;
                rs.StatusDescription = "Quarantine Returned";
                rs.StatusOrder = 10;
                ObjectSpace.CommitChanges();
            }

            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 10));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 10;
                rs.StatusDescription = "Intake QC";
                rs.StatusOrder = 2;
                ObjectSpace.CommitChanges();
            }
            RCKStatus = ObjectSpace.FindObject<RepackStatus>(new BinaryOperator("RepackStatusId", 11));
            if (RCKStatus == null)
            {
                RepackStatus rs = ObjectSpace.CreateObject<RepackStatus>();
                rs.RepackStatusId = 11;
                rs.StatusDescription = "Deleted";
                rs.StatusOrder = 11;
                ObjectSpace.CommitChanges();
            }

            #endregion

            #region Work Order status
            //WorkOrderStatus WoStatus;
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 10));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 10;
            //    rs.WoStatusDescription = "New";
            //    ObjectSpace.CommitChanges();
            //}
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 20));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 20;
            //    rs.WoStatusDescription = "Submitted";
            //    ObjectSpace.CommitChanges();
            //}
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 30));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 30;
            //    rs.WoStatusDescription = "Shipping";
            //    ObjectSpace.CommitChanges();
            //}
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 35));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 35;
            //    rs.WoStatusDescription = "On Route To Rpk";
            //    ObjectSpace.CommitChanges();
            //}

            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 40));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 40;
            //    rs.WoStatusDescription = "Processing";
            //    ObjectSpace.CommitChanges();
            //}
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 50));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 50;
            //    rs.WoStatusDescription = "Invoicing";
            //    ObjectSpace.CommitChanges();
            //}

            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 55));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 55;
            //    rs.WoStatusDescription = "Quality Check";
            //    ObjectSpace.CommitChanges();
            //}

            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 60));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 60;
            //    rs.WoStatusDescription = "Receiving";
            //    ObjectSpace.CommitChanges();
            //}

            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 70));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 70;
            //    rs.WoStatusDescription = "Completed";
            //    ObjectSpace.CommitChanges();
            //}
            //WoStatus = ObjectSpace.FindObject<WorkOrderStatus>(new BinaryOperator("WoStatusId", 99));
            //if (WoStatus == null)
            //{
            //    WorkOrderStatus rs = ObjectSpace.CreateObject<WorkOrderStatus>();
            //    rs.WoStatusId = 99;
            //    rs.WoStatusDescription = "Deleted";
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
            #region# Defualt Shipper

            //Shipper SE;
            //SE = ObjectSpace.FindObject<Shipper>(new BinaryOperator("SecuritySystemUser.UserName", "DVILLAVISANIS"));

            //if (SE == null)
            //{
            //    SecuritySystemUser userAdminb = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "DVILLAVISANIS"));
            //    SE = ObjectSpace.CreateObject<Shipper>();

            //   // SE.ShipperId = "DVILLAVISANIS";
            //    SE.FirstName = "Daniel";
            //    SE.LastName = "Villavisanis";
            //    ObjectSpace.CommitChanges();
            //}
            #endregion#

            //SE = ObjectSpace.FindObject<Shipper>(new BinaryOperator("UserName", "ADMIN"));
            //if (SE == null)
            //{
            //    SecuritySystemUser userAdmina = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Admin"));
            //    SE = ObjectSpace.CreateObject<Shipper>();
            //   // SE.Oid = userAdmina.Oid;
            //   // SE.ShipperId = "ADMIN";
            //    SE.FirstName = "ADMIN";
            //    SE.LastName = "Default";
            //    ObjectSpace.CommitChanges();
            //}

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

        }

        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private SecuritySystemRole CreateDefaultRole()
        {
            SecuritySystemRole defaultRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectAccessPermission<SecuritySystemUser>("[Oid] = CurrentUserId()", SecurityOperations.ReadOnlyAccess);
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("ChangePasswordOnFirstLogon", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("StoredPassword", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.SetTypePermissionsRecursively<SecuritySystemRole>(SecurityOperations.Read, SecuritySystemModifier.Deny);
                defaultRole.SetTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Deny);
                defaultRole.SetTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Deny);
            }
            return defaultRole;
        }



    }
}
