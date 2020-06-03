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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.ExpressApp.Win.Editors;
using System.Drawing;
using RX2_Office.Module.BusinessObjects;
namespace RX2_Office.Win
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class Replacklistchangeheader : ViewController
    {
        public Replacklistchangeheader()
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
            GridListEditor listEditor = ((ListView)View).Editor as GridListEditor;
            if (listEditor != null)
            {
                GridView gridView = listEditor.GridView;
                gridView.OptionsView.EnableAppearanceOddRow = true;
                gridView.Appearance.OddRow.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }
        protected void UpdateCaptions()
        {
            string caption = DateTime.Now.Year.ToString();    //((RepackItems)View.CurrentObject).CurrentMonth.ToString();
         //   PropertyEditor propertyEditor = (PropertyEditor)View.FindItem("CurrentMonth");
         //   SetPropertyEditorCaption(propertyEditor, caption);
        }
        protected virtual void SetPropertyEditorCaption(PropertyEditor propertyEditor, string caption)
        {
            propertyEditor.Caption = caption;
        }
        
        

    }
}
