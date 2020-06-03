using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
namespace RX2_Office.Module.Win.Windows.ItemInventoryScan
{
    partial class InventoryItemScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryItemScanForm));
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
            this.DXGridSerialNoList = new DevExpress.XtraGrid.GridControl();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemSummaryList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordgridList = new System.Windows.Forms.DataGridView();
            this.Gtin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirtationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblExpDt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpDt = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.txtItemNumber = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.DXGridSerialNoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSummaryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordgridList)).BeginInit();
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
            this.diagnosticContainerLayoutGroup.Size = new System.Drawing.Size(19, 25);
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
            this.buttonsContainerLayoutGroup.Size = new System.Drawing.Size(20, 25);
            this.buttonsContainerLayoutGroup.TextVisible = false;
            // 
            // viewSitePanel
            // 
            this.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewSitePanel.Controls.Add(this.DXGridSerialNoList);
            this.viewSitePanel.Controls.Add(this.itemSummaryList);
            this.viewSitePanel.Controls.Add(this.RecordgridList);
            this.viewSitePanel.Controls.Add(this.btnClose);
            this.viewSitePanel.Controls.Add(this.btnSubmit);
            this.viewSitePanel.Controls.Add(this.lblExpDt);
            this.viewSitePanel.Controls.Add(this.label4);
            this.viewSitePanel.Controls.Add(this.label3);
            this.viewSitePanel.Controls.Add(this.label2);
            this.viewSitePanel.Controls.Add(this.label1);
            this.viewSitePanel.Controls.Add(this.txtExpDt);
            this.viewSitePanel.Controls.Add(this.txtSerialNumber);
            this.viewSitePanel.Controls.Add(this.txtLot);
            this.viewSitePanel.Controls.Add(this.txtItemNumber);
            this.viewSitePanel.Controls.Add(this.txtBarcode);
            resources.ApplyResources(this.viewSitePanel, "viewSitePanel");
            this.viewSitePanel.Name = "viewSitePanel";
            this.viewSitePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.viewSitePanel_Paint);
            // 
            // DXGridSerialNoList
            // 
            this.DXGridSerialNoList.DataSource = this.xpCollection1;
            resources.ApplyResources(this.DXGridSerialNoList, "DXGridSerialNoList");
            this.DXGridSerialNoList.MainView = this.gridView1;
            this.DXGridSerialNoList.MenuManager = this.xafBarManager;
            this.DXGridSerialNoList.Name = "DXGridSerialNoList";
            this.DXGridSerialNoList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xpCollection1
            // 
            this.xpCollection1.DisplayableProperties = "ItemInventoryBatch;Barcode;NDC;Lot;SerialNumber;ExpDate";
            this.xpCollection1.ObjectType = typeof(RX2_Office.Module.BusinessObjects.ItemInventoryBatchSerialNo);
            this.xpCollection1.Session = this.unitOfWork1;
            this.xpCollection1.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[NDC]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.GridControl = this.DXGridSerialNoList;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.Name = "gridColumn1";
            // 
            // itemSummaryList
            // 
            resources.ApplyResources(this.itemSummaryList, "itemSummaryList");
            this.itemSummaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemSummaryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Qty});
            this.itemSummaryList.Name = "itemSummaryList";
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Qty
            // 
            resources.ApplyResources(this.Qty, "Qty");
            this.Qty.Name = "Qty";
            // 
            // RecordgridList
            // 
            resources.ApplyResources(this.RecordgridList, "RecordgridList");
            this.RecordgridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordgridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gtin,
            this.NDC,
            this.SerialNumber,
            this.ExpirtationDate,
            this.Lot,
            this.Barcode});
            this.RecordgridList.Name = "RecordgridList";
            // 
            // Gtin
            // 
            resources.ApplyResources(this.Gtin, "Gtin");
            this.Gtin.Name = "Gtin";
            // 
            // NDC
            // 
            resources.ApplyResources(this.NDC, "NDC");
            this.NDC.Name = "NDC";
            // 
            // SerialNumber
            // 
            resources.ApplyResources(this.SerialNumber, "SerialNumber");
            this.SerialNumber.Name = "SerialNumber";
            // 
            // ExpirtationDate
            // 
            resources.ApplyResources(this.ExpirtationDate, "ExpirtationDate");
            this.ExpirtationDate.Name = "ExpirtationDate";
            // 
            // Lot
            // 
            resources.ApplyResources(this.Lot, "Lot");
            this.Lot.Name = "Lot";
            // 
            // Barcode
            // 
            resources.ApplyResources(this.Barcode, "Barcode");
            this.Barcode.MaxInputLength = 255;
            this.Barcode.Name = "Barcode";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblExpDt
            // 
            resources.ApplyResources(this.lblExpDt, "lblExpDt");
            this.lblExpDt.Name = "lblExpDt";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtExpDt
            // 
            resources.ApplyResources(this.txtExpDt, "txtExpDt");
            this.txtExpDt.Name = "txtExpDt";
            // 
            // txtSerialNumber
            // 
            resources.ApplyResources(this.txtSerialNumber, "txtSerialNumber");
            this.txtSerialNumber.Name = "txtSerialNumber";
            // 
            // txtLot
            // 
            resources.ApplyResources(this.txtLot, "txtLot");
            this.txtLot.Name = "txtLot";
            // 
            // txtItemNumber
            // 
            resources.ApplyResources(this.txtItemNumber, "txtItemNumber");
            this.txtItemNumber.Name = "txtItemNumber";
            this.txtItemNumber.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.SizeAll;
            resources.ApplyResources(this.txtBarcode, "txtBarcode");
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
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
            this.buttonsContainerLayoutItem});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(961, 36);
            this.Root.TextVisible = false;
            // 
            // simpleSeparator
            // 
            this.simpleSeparator.AllowHotTrack = false;
            this.simpleSeparator.Location = new System.Drawing.Point(0, 0);
            this.simpleSeparator.Name = "simpleSeparator";
            this.simpleSeparator.Size = new System.Drawing.Size(961, 1);
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 1);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(902, 35);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // diagnosticContainerLayoutItem
            // 
            this.diagnosticContainerLayoutItem.Control = this.diagnosticContainer;
            this.diagnosticContainerLayoutItem.Location = new System.Drawing.Point(902, 1);
            this.diagnosticContainerLayoutItem.Name = "diagnosticContainerLayoutItem";
            this.diagnosticContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.diagnosticContainerLayoutItem.Size = new System.Drawing.Size(29, 35);
            this.diagnosticContainerLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.diagnosticContainerLayoutItem.TextVisible = false;
            // 
            // buttonsContainerLayoutItem
            // 
            this.buttonsContainerLayoutItem.Control = this.buttonsContainer;
            this.buttonsContainerLayoutItem.Location = new System.Drawing.Point(931, 1);
            this.buttonsContainerLayoutItem.Name = "buttonsContainerLayoutItem";
            this.buttonsContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 10, 0);
            this.buttonsContainerLayoutItem.Size = new System.Drawing.Size(30, 35);
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
            // InventoryItemScanForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.viewSitePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("InventoryItemScanForm.IconOptions.Icon")));
            this.Name = "InventoryItemScanForm";
            ((System.ComponentModel.ISupportInitialize)(this.xafBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainerLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).EndInit();
            this.viewSitePanel.ResumeLayout(false);
            this.viewSitePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DXGridSerialNoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemSummaryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecordgridList)).EndInit();
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
        private System.Windows.Forms.DataGridView itemSummaryList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridView RecordgridList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gtin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirtationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblExpDt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpDt;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.TextBox txtItemNumber;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraGrid.GridControl DXGridSerialNoList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
    }
}