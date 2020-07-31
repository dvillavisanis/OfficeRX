using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

using RX2_Office.Module.BusinessObjects;

namespace RX2_Office.Module.Controllers.IM
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class FirstDataUpdate : ViewController
    {
        public FirstDataUpdate()
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

        private async void FDBUpdate_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            //// ...
            //FDBConnector fdbConnector = new FDBConnector();
            //string ItemNoToCheck;


            //foreach (Items item in e.SelectedObjects)
            //{

            //    ItemNoToCheck = item.ItemNumber.Replace("-", string.Empty);
            //    FDBResult result = await fdbConnector.GetFDBDataByNDC(ItemNoToCheck);
            //    if (result.ErrorCode == 0)
            //    {

            //        if (string.IsNullOrEmpty(item.ItemNumber)) item.ItemNumber = result.fdbRootObject.PackagedDrug.NDC;
            //        if (item.FDAFormat == null) item.FDAFormat = ((eNDCFormatCode)Enum.Parse(typeof(eNDCFormatCode), result.fdbRootObject.PackagedDrug.NDCFormatCode));
            //        if (string.IsNullOrEmpty(item.AccountingNumber)) item.AccountingNumber = result.fdbRootObject.PackagedDrug.NDCFormatted;
            //        if (string.IsNullOrEmpty(item.ItemDescription)) item.ItemDescription = result.fdbRootObject.PackagedDrug.DrugNameDesc;
            //        if (string.IsNullOrEmpty(item.Strength)) item.Strength = result.fdbRootObject.PackagedDrug.MedStrength.ToString();
            //        if (string.IsNullOrEmpty(item.StrengthUnit)) item.StrengthUnit = result.fdbRootObject.PackagedDrug.MedStrengthUnit;
            //        if (string.IsNullOrEmpty(item.GenericName)) item.GenericName = result.fdbRootObject.PackagedDrug.GenericMedIDDesc;
            //        if (string.IsNullOrEmpty(item.GenericKey)) item.GenericKey = result.fdbRootObject.PackagedDrug.GenericDrugNameID;
            //        if (string.IsNullOrEmpty(item.LabelName30)) item.LabelName30 = result.fdbRootObject.PackagedDrug.LabelName30;
            //        if (string.IsNullOrEmpty(item.FormCode)) item.FormCode = result.fdbRootObject.PackagedDrug.CMSUnitTypeCode;
            //        if (string.IsNullOrEmpty(item.NDC)) item.NDC = result.fdbRootObject.PackagedDrug.NDC.Replace("-", string.Empty);
            //        if (string.IsNullOrEmpty(item.GtnId)) item.GtnId = result.fdbRootObject.PackagedDrug.NDC.Replace("-", string.Empty);
            //        if (item.PackageSize == 0) item.PackageSize = Decimal.Parse(result.fdbRootObject.PackagedDrug.CMSUnitsPerPackage);
            //        // if (string.IsNullOrEmpty(StandardUnitOfMeasure)) StandardUnitOfMeasure = result.fdbRootObject.PackagedDrug.PackageSizeUnitsCodeDesc;
            //        if (!item.AppearsOnDailyMed) item.AppearsOnDailyMed = true;
            //        string storagecondition = result.fdbRootObject.PackagedDrug.StorageConditionInfo.StorageConditionCode;
            //        if (!item.IsActive) item.IsActive = true;
            //        item.Save();


            //    }


          //  }
            // ...


            

            //View.ObjectSpace.CommitChanges();
            //View.ObjectSpace.Refresh();
            //View.Refresh();

        }

        //public async void GetDataFromFDB(SimpleActionExecuteEventArgs e)
        //{
          
        //}
    }
}
