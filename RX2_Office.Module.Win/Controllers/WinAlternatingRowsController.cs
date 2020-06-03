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
using System.Drawing;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Skins;
using DevExpress.ExpressApp.Win.SystemModule;

namespace RX2_Office.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WinAlternatingRowsController : ViewController
    {
        public WinAlternatingRowsController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            ChooseSkinController chooseSkinController = Application.MainWindow.GetController<ChooseSkinController>();
            if (chooseSkinController != null)
            {
                chooseSkinController.ChooseSkinAction.Executed += ChooseSkinAction_Executed;
            }
            ConfigureSkinController configureSkinController = Application.MainWindow.GetController<ConfigureSkinController>();
            if (configureSkinController != null)
            {
                configureSkinController.ConfigureSkinAction.Executed += ConfigureSkinAction_Executed;
            }
        }

        private void ConfigureSkinAction_Executed(object sender, DevExpress.ExpressApp.Actions.ActionBaseEventArgs e)
        {
            SetGridAppearance();
        }


        
        private void ChooseSkinAction_Executed(object sender, DevExpress.ExpressApp.Actions.ActionBaseEventArgs e)
        {
            SetGridAppearance();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            SetGridAppearance();
        }

        private void SetGridAppearance()
        {
            GridListEditor listEditor = ((ListView)View).Editor as GridListEditor;
            if (listEditor != null)
            {
                GridView gridView = listEditor.GridView;
                gridView.OptionsView.EnableAppearanceOddRow = true;
                Skin currentSkin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                Color c = currentSkin.TranslateColor(SystemColors.Control);
                gridView.Appearance.OddRow.BackColor = c;
                gridView.Appearance.SelectedRow.BackColor = c;
            }
        }
        protected override void OnDeactivated()
        {
            ConfigureSkinController configureSkinController = Application.MainWindow.GetController<ConfigureSkinController>();
            if (configureSkinController != null)
            {
                configureSkinController.ConfigureSkinAction.Executed -= ConfigureSkinAction_Executed;
            }
            ChooseSkinController chooseSkinController = Application.MainWindow.GetController<ChooseSkinController>();
            if (chooseSkinController != null)
            {
                chooseSkinController.ChooseSkinAction.Executed -= ChooseSkinAction_Executed;
            }
            base.OnDeactivated();
        }

    
    // Perform various tasks depending on the target View.


    
        private void WinAlternatingRowsController_ViewControlsCreated(object sender, EventArgs e)
        {
            GridListEditor listEditor = ((ListView)View).Editor as GridListEditor;
            if (listEditor != null)
            {
                GridView gridView = listEditor.GridView;
                gridView.OptionsView.EnableAppearanceOddRow = true;
                Skin currentSkin = CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                Color c = currentSkin.TranslateColor(SystemColors.Control);
                gridView.Appearance.OddRow.BackColor = c;
            }

        }
       
    }
}
