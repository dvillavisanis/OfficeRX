using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
namespace RX2_Office.Win.Windows
{
    partial class testcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testcs));
            DevExpress.ExpressApp.Win.Layout.XafLayoutConstants xafLayoutConstants1 = new DevExpress.ExpressApp.Win.Layout.XafLayoutConstants();
            this.xafBarManager = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cObjectsCreation = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cRecordEdit = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cView = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cPrint = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cEdit = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cOpenObject = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cUndoRedo = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.cExport = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem();
            this.actionContainersManager = new DevExpress.ExpressApp.Win.Templates.ActionContainersManager(this.components);
            this.diagnosticContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.diagnosticContainerLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.buttonsContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.buttonsContainerLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.viewSitePanel = new DevExpress.XtraEditors.PanelControl();
            this.bottomPanel = new DevExpress.ExpressApp.Win.Layout.XafLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.diagnosticContainerLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonsContainerLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.formStateModelSynchronizer = new DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer(this.components);
            this.viewSiteManager = new DevExpress.ExpressApp.Win.Templates.ViewSiteManager(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.xafLayoutControlItem1 = new DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem();
            this.button2 = new System.Windows.Forms.Button();
            this.xafLayoutControlItem2 = new DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem();
            this.Lotid = new System.Windows.Forms.TextBox();
            this.txLotid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).BeginInit();
            this.viewSitePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xafLayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xafLayoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // xafBarManager
            // 
            this.xafBarManager.DockControls.Add(this.barDockControlTop);
            this.xafBarManager.DockControls.Add(this.barDockControlBottom);
            this.xafBarManager.DockControls.Add(this.barDockControlLeft);
            this.xafBarManager.DockControls.Add(this.barDockControlRight);
            this.xafBarManager.Form = this;
            this.xafBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cObjectsCreation,
            this.cRecordEdit,
            this.cView,
            this.cPrint,
            this.cEdit,
            this.cOpenObject,
            this.cUndoRedo,
            this.cExport});
            this.xafBarManager.MaxItemId = 8;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Manager = this.xafBarManager;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Manager = this.xafBarManager;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Manager = this.xafBarManager;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Manager = this.xafBarManager;
            // 
            // cObjectsCreation
            // 
            resources.ApplyResources(this.cObjectsCreation, "cObjectsCreation");
            this.cObjectsCreation.ContainerId = "ObjectsCreation";
            this.cObjectsCreation.Id = 0;
            this.cObjectsCreation.Name = "cObjectsCreation";
            this.cObjectsCreation.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cRecordEdit
            // 
            resources.ApplyResources(this.cRecordEdit, "cRecordEdit");
            this.cRecordEdit.ContainerId = "RecordEdit";
            this.cRecordEdit.Id = 1;
            this.cRecordEdit.Name = "cRecordEdit";
            this.cRecordEdit.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cView
            // 
            resources.ApplyResources(this.cView, "cView");
            this.cView.ContainerId = "View";
            this.cView.Id = 2;
            this.cView.Name = "cView";
            this.cView.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cPrint
            // 
            resources.ApplyResources(this.cPrint, "cPrint");
            this.cPrint.ContainerId = "Print";
            this.cPrint.Id = 3;
            this.cPrint.Name = "cPrint";
            this.cPrint.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cEdit
            // 
            resources.ApplyResources(this.cEdit, "cEdit");
            this.cEdit.ContainerId = "Edit";
            this.cEdit.Id = 4;
            this.cEdit.Name = "cEdit";
            this.cEdit.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cOpenObject
            // 
            resources.ApplyResources(this.cOpenObject, "cOpenObject");
            this.cOpenObject.ContainerId = "OpenObject";
            this.cOpenObject.Id = 5;
            this.cOpenObject.Name = "cOpenObject";
            this.cOpenObject.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cUndoRedo
            // 
            resources.ApplyResources(this.cUndoRedo, "cUndoRedo");
            this.cUndoRedo.ContainerId = "UndoRedo";
            this.cUndoRedo.Id = 6;
            this.cUndoRedo.Name = "cUndoRedo";
            this.cUndoRedo.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // cExport
            // 
            resources.ApplyResources(this.cExport, "cExport");
            this.cExport.ContainerId = "Export";
            this.cExport.Id = 7;
            this.cExport.Name = "cExport";
            this.cExport.TargetPageCategoryColor = System.Drawing.Color.Empty;
            // 
            // actionContainersManager
            // 
            this.actionContainersManager.ActionContainerComponents.Add(this.cObjectsCreation);
            this.actionContainersManager.ActionContainerComponents.Add(this.cRecordEdit);
            this.actionContainersManager.ActionContainerComponents.Add(this.cView);
            this.actionContainersManager.ActionContainerComponents.Add(this.cPrint);
            this.actionContainersManager.ActionContainerComponents.Add(this.cEdit);
            this.actionContainersManager.ActionContainerComponents.Add(this.cOpenObject);
            this.actionContainersManager.ActionContainerComponents.Add(this.cUndoRedo);
            this.actionContainersManager.ActionContainerComponents.Add(this.cExport);
            this.actionContainersManager.ActionContainerComponents.Add(this.diagnosticContainer);
            this.actionContainersManager.ActionContainerComponents.Add(this.buttonsContainer);
            this.actionContainersManager.ContextMenuContainers.Add(this.cObjectsCreation);
            this.actionContainersManager.ContextMenuContainers.Add(this.cEdit);
            this.actionContainersManager.ContextMenuContainers.Add(this.cRecordEdit);
            this.actionContainersManager.ContextMenuContainers.Add(this.cUndoRedo);
            this.actionContainersManager.ContextMenuContainers.Add(this.cOpenObject);
            this.actionContainersManager.ContextMenuContainers.Add(this.cView);
            this.actionContainersManager.ContextMenuContainers.Add(this.cExport);
            this.actionContainersManager.ContextMenuContainers.Add(this.cPrint);
            this.actionContainersManager.DefaultContainer = this.cObjectsCreation;
            this.actionContainersManager.Template = this;
            // 
            // diagnosticContainer
            // 
            this.diagnosticContainer.ActionId = null;
            this.diagnosticContainer.AllowCustomization = false;
            resources.ApplyResources(this.diagnosticContainer, "diagnosticContainer");
            this.diagnosticContainer.BackColor = System.Drawing.Color.Transparent;
            this.diagnosticContainer.ContainerId = "Diagnostic";
            this.diagnosticContainer.HideItemsCompletely = true;
            this.diagnosticContainer.Name = "diagnosticContainer";
            this.diagnosticContainer.OptionsView.UseSkinIndents = false;
            this.diagnosticContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.diagnosticContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.diagnosticContainer.Root = this.diagnosticContainerLayoutGroup;
            this.diagnosticContainer.TabStop = false;
            // 
            // diagnosticContainerLayoutGroup
            // 
            this.diagnosticContainerLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.diagnosticContainerLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.diagnosticContainerLayoutGroup.GroupBordersVisible = false;
            this.diagnosticContainerLayoutGroup.Name = "diagnosticContainerLayoutGroup";
            this.diagnosticContainerLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 7, 2, 0);
            this.diagnosticContainerLayoutGroup.Size = new System.Drawing.Size(7, 24);
            this.diagnosticContainerLayoutGroup.TextVisible = false;
            // 
            // buttonsContainer
            // 
            this.buttonsContainer.ActionId = null;
            this.buttonsContainer.AllowCustomization = false;
            resources.ApplyResources(this.buttonsContainer, "buttonsContainer");
            this.buttonsContainer.BackColor = System.Drawing.Color.Transparent;
            this.buttonsContainer.ContainerId = "PopupActions";
            this.buttonsContainer.HideItemsCompletely = false;
            this.buttonsContainer.Name = "buttonsContainer";
            this.buttonsContainer.OptionsView.UseSkinIndents = false;
            this.buttonsContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.buttonsContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.buttonsContainer.Root = this.buttonsContainerLayoutGroup;
            this.buttonsContainer.TabStop = false;
            // 
            // buttonsContainerLayoutGroup
            // 
            this.buttonsContainerLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.buttonsContainerLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.buttonsContainerLayoutGroup.GroupBordersVisible = false;
            this.buttonsContainerLayoutGroup.Name = "buttonsContainerLayoutGroup";
            this.buttonsContainerLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 7, 2, 0);
            this.buttonsContainerLayoutGroup.Size = new System.Drawing.Size(7, 24);
            this.buttonsContainerLayoutGroup.TextVisible = false;
            // 
            // viewSitePanel
            // 
            this.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewSitePanel.Controls.Add(this.txLotid);
            this.viewSitePanel.Controls.Add(this.Lotid);
            resources.ApplyResources(this.viewSitePanel, "viewSitePanel");
            this.viewSitePanel.Name = "viewSitePanel";
            // 
            // bottomPanel
            // 
            this.bottomPanel.AllowCustomization = false;
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.button2);
            this.bottomPanel.Controls.Add(this.button1);
            this.bottomPanel.Controls.Add(this.diagnosticContainer);
            this.bottomPanel.Controls.Add(this.buttonsContainer);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.OptionsCustomizationForm.ShowLoadButton = false;
            this.bottomPanel.OptionsCustomizationForm.ShowSaveButton = false;
            this.bottomPanel.OptionsView.AllowItemSkinning = false;
            this.bottomPanel.OptionsView.EnableIndentsInGroupsWithoutBorders = true;
            this.bottomPanel.OptionsView.UseSkinIndents = false;
            this.bottomPanel.Root = this.Root;
            xafLayoutConstants1.InvisibleGroupVerticalDistance = 10;
            xafLayoutConstants1.ItemToBorderHorizontalDistance = 10;
            xafLayoutConstants1.ItemToBorderVerticalDistance = 10;
            xafLayoutConstants1.ItemToItemHorizontalDistance = 10;
            xafLayoutConstants1.ItemToItemVerticalDistance = 4;
            xafLayoutConstants1.ItemToTabBorderDistance = 2;
            this.bottomPanel.XafLayoutConstants = xafLayoutConstants1;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleSeparator,
            this.emptySpaceItem,
            this.diagnosticContainerLayoutItem,
            this.buttonsContainerLayoutItem,
            this.xafLayoutControlItem1,
            this.xafLayoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(552, 36);
            this.Root.TextVisible = false;
            // 
            // simpleSeparator
            // 
            this.simpleSeparator.AllowHotTrack = false;
            this.simpleSeparator.Location = new System.Drawing.Point(0, 0);
            this.simpleSeparator.Name = "simpleSeparator";
            this.simpleSeparator.Size = new System.Drawing.Size(552, 2);
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 2);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(259, 34);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // diagnosticContainerLayoutItem
            // 
            this.diagnosticContainerLayoutItem.Control = this.diagnosticContainer;
            this.diagnosticContainerLayoutItem.Location = new System.Drawing.Point(518, 2);
            this.diagnosticContainerLayoutItem.Name = "diagnosticContainerLayoutItem";
            this.diagnosticContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.diagnosticContainerLayoutItem.Size = new System.Drawing.Size(17, 34);
            this.diagnosticContainerLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.diagnosticContainerLayoutItem.TextVisible = false;
            // 
            // buttonsContainerLayoutItem
            // 
            this.buttonsContainerLayoutItem.Control = this.buttonsContainer;
            this.buttonsContainerLayoutItem.Location = new System.Drawing.Point(535, 2);
            this.buttonsContainerLayoutItem.Name = "buttonsContainerLayoutItem";
            this.buttonsContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.buttonsContainerLayoutItem.Size = new System.Drawing.Size(17, 34);
            this.buttonsContainerLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.buttonsContainerLayoutItem.TextVisible = false;
            // 
            // formStateModelSynchronizer
            // 
            this.formStateModelSynchronizer.Form = this;
            // 
            // viewSiteManager
            // 
            this.viewSiteManager.ViewSiteControl = this.viewSitePanel;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // xafLayoutControlItem1
            // 
            this.xafLayoutControlItem1.Control = this.button1;
            this.xafLayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xafLayoutControlItem1.Location = new System.Drawing.Point(259, 2);
            this.xafLayoutControlItem1.Name = "xafLayoutControlItem1";
            this.xafLayoutControlItem1.Size = new System.Drawing.Size(128, 34);
            this.xafLayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.xafLayoutControlItem1.TextVisible = false;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xafLayoutControlItem2
            // 
            this.xafLayoutControlItem2.Control = this.button2;
            this.xafLayoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xafLayoutControlItem2.Location = new System.Drawing.Point(387, 2);
            this.xafLayoutControlItem2.Name = "xafLayoutControlItem2";
            this.xafLayoutControlItem2.Size = new System.Drawing.Size(131, 34);
            this.xafLayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.xafLayoutControlItem2.TextVisible = false;
            // 
            // Lotid
            // 
            resources.ApplyResources(this.Lotid, "Lotid");
            this.Lotid.Name = "Lotid";
            this.Lotid.TabStop = false;
            // 
            // txLotid
            // 
            resources.ApplyResources(this.txLotid, "txLotid");
            this.txLotid.Name = "txLotid";
            // 
            // testcs
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.viewSitePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "testcs";
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).EndInit();
            this.viewSitePanel.ResumeLayout(false);
            this.viewSitePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xafLayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xafLayoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager xafBarManager;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cObjectsCreation;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cRecordEdit;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cView;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cPrint;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cEdit;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cOpenObject;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private ActionContainersManager actionContainersManager;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cUndoRedo;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem cExport;
        private DevExpress.XtraEditors.PanelControl viewSitePanel;
        private DevExpress.ExpressApp.Win.Layout.XafLayoutControl bottomPanel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer diagnosticContainer;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer buttonsContainer;
        private DevExpress.XtraLayout.LayoutControlGroup diagnosticContainerLayoutGroup;
        private DevExpress.XtraLayout.LayoutControlGroup buttonsContainerLayoutGroup;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem;
        private DevExpress.XtraLayout.LayoutControlItem diagnosticContainerLayoutItem;
        private DevExpress.XtraLayout.LayoutControlItem buttonsContainerLayoutItem;
        private DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer formStateModelSynchronizer;
        private ViewSiteManager viewSiteManager;
        private System.Windows.Forms.Label txLotid;
        private System.Windows.Forms.TextBox Lotid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem xafLayoutControlItem1;
        private DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem xafLayoutControlItem2;
    }
}