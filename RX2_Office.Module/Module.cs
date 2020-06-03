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
using RX2_Office.Module.Reports.IM;

namespace RX2_Office.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class RX2_OfficeModule : ModuleBase
    {
        public RX2_OfficeModule()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
            CriteriaOperator.RegisterCustomFunction(new CurrentUserNameOperator());
            CriteriaOperator.RegisterCustomFunction(new CurrentShipperDCOperator());
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            PredefinedReportsUpdater predefinedReportsUpdater =
                new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);

            predefinedReportsUpdater.AddPredefinedReport<rptShippingPickSht>("Picking Sheet", typeof(SOHeader), true);
            predefinedReportsUpdater.AddPredefinedReport<rptSalesInvoice>("Sales Invoice", typeof(CustomerInvoiceHistory), true);
            predefinedReportsUpdater.AddPredefinedReport<poPrintRPT>("PO Print", typeof(ItemPurchaseOrder), true);
            predefinedReportsUpdater.AddPredefinedReport<InvItemLabelRpt>("Item Label", typeof(ItemInventory), true);


            return new ModuleUpdater[] { updater, predefinedReportsUpdater };

            //return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
        public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters)
        {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new ORXSecurityFilter());

        }

    }
}


