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
using RX2_Office.Module;
using RX2_Office.Module.BusinessObjects;
using DevExpress.Persistent.BaseImpl;
using System.Drawing;
namespace RX2_Office.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ItemLookup : ViewController
    {
        public ItemLookup()
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

        private void popupWindowShowAction1_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
             
        }

        private void ItemF12_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Items));
            string ItemListviewid  = "Items_ListView_F12";
            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(Items), ItemListviewid);

           // collectionSource.CanApplyCriteria = false;
            collectionSource.Reload();
           

            e.View = Application.CreateListView(ItemListviewid, collectionSource,true );

            //Optionally customize the window display settings. 
               
            e.Maximized = false; 
            e.IsSizeable = true;
          
            


        }
    }
}
