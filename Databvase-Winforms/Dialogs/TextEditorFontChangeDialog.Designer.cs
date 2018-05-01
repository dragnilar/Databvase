using System.Windows.Forms;
using Databvase_Winforms.Modules;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit.Design;

namespace Databvase_Winforms.Dialogs
{
    partial class TextEditorFontChangeDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditorFontChangeDialog));
            this.lcFontDialog = new DevExpress.XtraLayout.LayoutControl();
            this.textEditorFontEdit = new Databvase_Winforms.Modules.TextEditorFontEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.lcgFontDialog = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciOKButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcFontDialog)).BeginInit();
            this.lcFontDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcFontDialog
            // 
            this.lcFontDialog.Controls.Add(this.textEditorFontEdit);
            this.lcFontDialog.Controls.Add(this.simpleButtonCancel);
            this.lcFontDialog.Controls.Add(this.simpleButtonOK);
            this.lcFontDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcFontDialog.Location = new System.Drawing.Point(0, 0);
            this.lcFontDialog.Name = "lcFontDialog";
            this.lcFontDialog.Root = this.lcgFontDialog;
            this.lcFontDialog.Size = new System.Drawing.Size(485, 221);
            this.lcFontDialog.TabIndex = 1;
            this.lcFontDialog.Text = "layoutControl1";
            // 
            // textEditorFontEdit
            // 
            this.textEditorFontEdit.Location = new System.Drawing.Point(12, 12);
            this.textEditorFontEdit.Name = "textEditorFontEdit";
            this.textEditorFontEdit.Size = new System.Drawing.Size(461, 171);
            this.textEditorFontEdit.TabIndex = 6;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.ImageOptions.Image")));
            this.simpleButtonCancel.Location = new System.Drawing.Point(376, 187);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(97, 22);
            this.simpleButtonCancel.StyleController = this.lcFontDialog;
            this.simpleButtonCancel.TabIndex = 5;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.ImageOptions.Image")));
            this.simpleButtonOK.Location = new System.Drawing.Point(233, 187);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(117, 22);
            this.simpleButtonOK.StyleController = this.lcFontDialog;
            this.simpleButtonOK.TabIndex = 4;
            this.simpleButtonOK.Text = "OK";
            // 
            // lcgFontDialog
            // 
            this.lcgFontDialog.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgFontDialog.GroupBordersVisible = false;
            this.lcgFontDialog.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciOKButton,
            this.lciCancel,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1});
            this.lcgFontDialog.Name = "lcgFontDialog";
            this.lcgFontDialog.Size = new System.Drawing.Size(485, 221);
            this.lcgFontDialog.TextVisible = false;
            // 
            // lciOKButton
            // 
            this.lciOKButton.Control = this.simpleButtonOK;
            this.lciOKButton.Location = new System.Drawing.Point(221, 175);
            this.lciOKButton.Name = "lciOKButton";
            this.lciOKButton.Size = new System.Drawing.Size(121, 26);
            this.lciOKButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciOKButton.TextVisible = false;
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.simpleButtonCancel;
            this.lciCancel.Location = new System.Drawing.Point(364, 175);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(101, 26);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 175);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(221, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(342, 175);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(22, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditorFontEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(465, 175);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // TextEditorFontChangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 221);
            this.Controls.Add(this.lcFontDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextEditorFontChangeDialog";
            this.ShowIcon = false;
            this.Text = "Font";
            ((System.ComponentModel.ISupportInitialize)(this.lcFontDialog)).EndInit();
            this.lcFontDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion
        private DevExpress.XtraLayout.LayoutControl lcFontDialog;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFontDialog;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraLayout.LayoutControlItem lciOKButton;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private TextEditorFontEdit textEditorFontEdit;
        private LayoutControlItem layoutControlItem1;
    }
}