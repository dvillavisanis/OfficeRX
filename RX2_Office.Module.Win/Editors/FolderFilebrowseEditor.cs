using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace RX2_Office.Module.Win.Editors
{
    [PropertyEditor(typeof(string), "FolderBrowserEditor",false)]
    public class FolderBrowseEditor : DXPropertyEditor
    {
        public FolderBrowseEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select folder...";
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    ((ButtonEdit)sender).Text = dialog.SelectedPath;
                }
            }
        }
        protected override object CreateControlCore()
        {
            return new ButtonEdit();
        }
        protected override RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemButtonEdit();
        }
        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            ((RepositoryItemButtonEdit)item).ButtonClick += buttonEdit_ButtonClick;
        }
        protected override void SetRepositoryItemReadOnly(RepositoryItem item, bool readOnly)
        {
            base.SetRepositoryItemReadOnly(item, readOnly);
            ((RepositoryItemButtonEdit)item).Buttons[0].Enabled = !readOnly;
        }
    }

    [PropertyEditor(typeof(string), "FileBrowserEditor",false)]
    public class FileBrowseEditor : DXPropertyEditor
    {
        public FileBrowseEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select file...";
              
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    ((ButtonEdit)sender).Text = dialog.FileName;
                }
            }
        }
        protected override object CreateControlCore()
        {
            return new ButtonEdit();
        }
        protected override RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemButtonEdit();
        }
        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            ((RepositoryItemButtonEdit)item).ButtonClick += buttonEdit_ButtonClick;
        }
        protected override void SetRepositoryItemReadOnly(RepositoryItem item, bool readOnly)
        {
            base.SetRepositoryItemReadOnly(item, readOnly);
            ((RepositoryItemButtonEdit)item).Buttons[0].Enabled = !readOnly;
        }
    }
    [PropertyEditor(typeof(string), "PrinterBrowserEditor", false)]
    public class PrinterBrowseEditor : DXPropertyEditor
    {
        public PrinterBrowseEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }
        private void buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.ShowDialog();
            ((ButtonEdit)sender).Text = PrintDialog1.PrinterSettings.PrinterName;

        }
        protected override object CreateControlCore()
        {
            return new ButtonEdit();
        }
        protected override RepositoryItem CreateRepositoryItem()
        {
            return new RepositoryItemButtonEdit();
        }
        protected override void SetupRepositoryItem(RepositoryItem item)
        {
            base.SetupRepositoryItem(item);
            ((RepositoryItemButtonEdit)item).ButtonClick += buttonEdit_ButtonClick;
        }
        protected override void SetRepositoryItemReadOnly(RepositoryItem item, bool readOnly)
        {
            base.SetRepositoryItemReadOnly(item, readOnly);
            ((RepositoryItemButtonEdit)item).Buttons[0].Enabled = !readOnly;
        }
    }
}


