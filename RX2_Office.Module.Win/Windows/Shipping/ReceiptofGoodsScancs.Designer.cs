using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
namespace RX2_Office.Module.Win.Controllers.Shipping
{
    partial class Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt));
            DevExpress.ExpressApp.Win.Layout.XafLayoutConstants xafLayoutConstants2 = new DevExpress.ExpressApp.Win.Layout.XafLayoutConstants();
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtExpDate = new System.Windows.Forms.TextBox();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpireationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceiverDt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceiptID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bottomPanel = new DevExpress.ExpressApp.Win.Layout.XafLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.diagnosticContainerLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonsContainerLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.formStateModelSynchronizer = new DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer(this.components);
            this.viewSiteManager = new DevExpress.ExpressApp.Win.Templates.ViewSiteManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).BeginInit();
            this.viewSitePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutItem)).BeginInit();
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
            this.diagnosticContainerLayoutGroup.Size = new System.Drawing.Size(18, 25);
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
            this.buttonsContainerLayoutGroup.Size = new System.Drawing.Size(19, 25);
            this.buttonsContainerLayoutGroup.TextVisible = false;
            // 
            // viewSitePanel
            // 
            this.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewSitePanel.Controls.Add(this.button2);
            this.viewSitePanel.Controls.Add(this.btnScan);
            this.viewSitePanel.Controls.Add(this.txtSerialNumber);
            this.viewSitePanel.Controls.Add(this.txtExpDate);
            this.viewSitePanel.Controls.Add(this.txtLot);
            this.viewSitePanel.Controls.Add(this.txtItemNumber);
            this.viewSitePanel.Controls.Add(this.label8);
            this.viewSitePanel.Controls.Add(this.label7);
            this.viewSitePanel.Controls.Add(this.label6);
            this.viewSitePanel.Controls.Add(this.label5);
            this.viewSitePanel.Controls.Add(this.label4);
            this.viewSitePanel.Controls.Add(this.txtScan);
            this.viewSitePanel.Controls.Add(this.gridControl1);
            this.viewSitePanel.Controls.Add(this.txtReceivedBy);
            this.viewSitePanel.Controls.Add(this.label3);
            this.viewSitePanel.Controls.Add(this.txtReceiverDt);
            this.viewSitePanel.Controls.Add(this.label2);
            this.viewSitePanel.Controls.Add(this.txtReceiptID);
            this.viewSitePanel.Controls.Add(this.label1);
            resources.ApplyResources(this.viewSitePanel, "viewSitePanel");
            this.viewSitePanel.Name = "viewSitePanel";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            resources.ApplyResources(this.btnScan, "btnScan");
            this.btnScan.Name = "btnScan";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // txtSerialNumber
            // 
            resources.ApplyResources(this.txtSerialNumber, "txtSerialNumber");
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            // 
            // txtExpDate
            // 
            resources.ApplyResources(this.txtExpDate, "txtExpDate");
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.ReadOnly = true;
            // 
            // txtLot
            // 
            resources.ApplyResources(this.txtLot, "txtLot");
            this.txtLot.Name = "txtLot";
            this.txtLot.ReadOnly = true;
            // 
            // txtItemNumber
            // 
            resources.ApplyResources(this.txtItemNumber, "txtItemNumber");
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtScan
            // 
            resources.ApplyResources(this.txtScan, "txtScan");
            this.txtScan.Name = "txtScan";
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.xafBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ItemNumber,
            this.Lot,
            this.ExpireationDate,
            this.SerialNumber});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // ItemNumber
            // 
            resources.ApplyResources(this.ItemNumber, "ItemNumber");
            this.ItemNumber.Name = "ItemNumber";
            // 
            // Lot
            // 
            resources.ApplyResources(this.Lot, "Lot");
            this.Lot.Name = "Lot";
            // 
            // ExpireationDate
            // 
            resources.ApplyResources(this.ExpireationDate, "ExpireationDate");
            this.ExpireationDate.Name = "ExpireationDate";
            // 
            // SerialNumber
            // 
            resources.ApplyResources(this.SerialNumber, "SerialNumber");
            this.SerialNumber.Name = "SerialNumber";
            // 
            // txtReceivedBy
            // 
            resources.ApplyResources(this.txtReceivedBy, "txtReceivedBy");
            this.txtReceivedBy.Name = "txtReceivedBy";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtReceiverDt
            // 
            resources.ApplyResources(this.txtReceiverDt, "txtReceiverDt");
            this.txtReceiverDt.Name = "txtReceiverDt";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtReceiptID
            // 
            resources.ApplyResources(this.txtReceiptID, "txtReceiptID");
            this.txtReceiptID.Name = "txtReceiptID";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bottomPanel
            // 
            this.bottomPanel.AllowCustomization = false;
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.diagnosticContainer);
            this.bottomPanel.Controls.Add(this.buttonsContainer);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.OptionsCustomizationForm.ShowLoadButton = false;
            this.bottomPanel.OptionsCustomizationForm.ShowSaveButton = false;
            this.bottomPanel.OptionsView.AllowItemSkinning = false;
            this.bottomPanel.OptionsView.EnableIndentsInGroupsWithoutBorders = true;
            this.bottomPanel.OptionsView.UseSkinIndents = false;
            this.bottomPanel.Root = this.Root;
            xafLayoutConstants2.InvisibleGroupVerticalDistance = 10;
            xafLayoutConstants2.ItemToBorderHorizontalDistance = 10;
            xafLayoutConstants2.ItemToBorderVerticalDistance = 10;
            xafLayoutConstants2.ItemToItemHorizontalDistance = 10;
            xafLayoutConstants2.ItemToItemVerticalDistance = 4;
            xafLayoutConstants2.ItemToTabBorderDistance = 2;
            this.bottomPanel.XafLayoutConstants = xafLayoutConstants2;
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
            this.buttonsContainerLayoutItem});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(920, 36);
            this.Root.TextVisible = false;
            // 
            // simpleSeparator
            // 
            this.simpleSeparator.AllowHotTrack = false;
            this.simpleSeparator.Location = new System.Drawing.Point(0, 0);
            this.simpleSeparator.Name = "simpleSeparator";
            this.simpleSeparator.Size = new System.Drawing.Size(920, 1);
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 1);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(863, 35);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // diagnosticContainerLayoutItem
            // 
            this.diagnosticContainerLayoutItem.Control = this.diagnosticContainer;
            this.diagnosticContainerLayoutItem.Location = new System.Drawing.Point(863, 1);
            this.diagnosticContainerLayoutItem.Name = "diagnosticContainerLayoutItem";
            this.diagnosticContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.diagnosticContainerLayoutItem.Size = new System.Drawing.Size(28, 35);
            this.diagnosticContainerLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.diagnosticContainerLayoutItem.TextVisible = false;
            // 
            // buttonsContainerLayoutItem
            // 
            this.buttonsContainerLayoutItem.Control = this.buttonsContainer;
            this.buttonsContainerLayoutItem.Location = new System.Drawing.Point(891, 1);
            this.buttonsContainerLayoutItem.Name = "buttonsContainerLayoutItem";
            this.buttonsContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.buttonsContainerLayoutItem.Size = new System.Drawing.Size(29, 35);
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
            // Receipt
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.viewSitePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Receipt.IconOptions.Icon")));
            this.Name = "Receipt";
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).EndInit();
            this.viewSitePanel.ResumeLayout(false);
            this.viewSitePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomPanel)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutItem)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReceiverDt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReceiptID;
        private System.Windows.Forms.TextBox txtScan;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtExpDate;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn ItemNumber;
        private DevExpress.XtraGrid.Columns.GridColumn Lot;
        private DevExpress.XtraGrid.Columns.GridColumn ExpireationDate;
        private DevExpress.XtraGrid.Columns.GridColumn SerialNumber;
    }
}