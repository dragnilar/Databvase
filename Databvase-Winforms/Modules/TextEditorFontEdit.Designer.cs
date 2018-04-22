namespace Databvase_Winforms.Modules
{
    partial class TextEditorFontEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditorFontEdit));
            this.lcFontDialog = new DevExpress.XtraLayout.LayoutControl();
            this.colorPickEditStringColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEditKeywordColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.colorPickEditDefaultTextColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.fontEditDefaultFont = new DevExpress.XtraEditors.FontEdit();
            this.lcgFontDialog = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgFontOptions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciFontPicker = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStringColor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKeywordsColor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDefaultTextColor = new DevExpress.XtraLayout.LayoutControlItem();
            this.colorPickEditCommentsColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.lciColorPickComments = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcFontDialog)).BeginInit();
            this.lcFontDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditStringColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditKeywordColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditDefaultTextColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEditDefaultFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFontPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStringColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKeywordsColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDefaultTextColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditCommentsColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciColorPickComments)).BeginInit();
            this.SuspendLayout();
            // 
            // lcFontDialog
            // 
            this.lcFontDialog.Controls.Add(this.colorPickEditCommentsColor);
            this.lcFontDialog.Controls.Add(this.colorPickEditStringColor);
            this.lcFontDialog.Controls.Add(this.colorPickEditKeywordColor);
            this.lcFontDialog.Controls.Add(this.colorPickEditDefaultTextColor);
            this.lcFontDialog.Controls.Add(this.fontEditDefaultFont);
            this.lcFontDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcFontDialog.Location = new System.Drawing.Point(0, 0);
            this.lcFontDialog.Margin = new System.Windows.Forms.Padding(0);
            this.lcFontDialog.Name = "lcFontDialog";
            this.lcFontDialog.Root = this.lcgFontDialog;
            this.lcFontDialog.Size = new System.Drawing.Size(475, 172);
            this.lcFontDialog.TabIndex = 2;
            this.lcFontDialog.Text = "layoutControl1";
            // 
            // colorPickEditStringColor
            // 
            this.colorPickEditStringColor.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditStringColor.Location = new System.Drawing.Point(151, 135);
            this.colorPickEditStringColor.Name = "colorPickEditStringColor";
            this.colorPickEditStringColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditStringColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditStringColor.Size = new System.Drawing.Size(310, 20);
            this.colorPickEditStringColor.StyleController = this.lcFontDialog;
            this.colorPickEditStringColor.TabIndex = 9;
            // 
            // colorPickEditKeywordColor
            // 
            this.colorPickEditKeywordColor.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditKeywordColor.Location = new System.Drawing.Point(151, 87);
            this.colorPickEditKeywordColor.Name = "colorPickEditKeywordColor";
            this.colorPickEditKeywordColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditKeywordColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditKeywordColor.Size = new System.Drawing.Size(310, 20);
            this.colorPickEditKeywordColor.StyleController = this.lcFontDialog;
            this.colorPickEditKeywordColor.TabIndex = 8;
            // 
            // colorPickEditDefaultTextColor
            // 
            this.colorPickEditDefaultTextColor.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditDefaultTextColor.Location = new System.Drawing.Point(151, 63);
            this.colorPickEditDefaultTextColor.Name = "colorPickEditDefaultTextColor";
            this.colorPickEditDefaultTextColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditDefaultTextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditDefaultTextColor.Size = new System.Drawing.Size(310, 20);
            this.colorPickEditDefaultTextColor.StyleController = this.lcFontDialog;
            this.colorPickEditDefaultTextColor.TabIndex = 7;
            // 
            // fontEditDefaultFont
            // 
            this.fontEditDefaultFont.Location = new System.Drawing.Point(151, 39);
            this.fontEditDefaultFont.Name = "fontEditDefaultFont";
            this.fontEditDefaultFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fontEditDefaultFont.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.fontEditDefaultFont.Size = new System.Drawing.Size(310, 20);
            this.fontEditDefaultFont.StyleController = this.lcFontDialog;
            this.fontEditDefaultFont.TabIndex = 6;
            // 
            // lcgFontDialog
            // 
            this.lcgFontDialog.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgFontDialog.GroupBordersVisible = false;
            this.lcgFontDialog.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgFontOptions});
            this.lcgFontDialog.Name = "lcgFontDialog";
            this.lcgFontDialog.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgFontDialog.Size = new System.Drawing.Size(475, 172);
            this.lcgFontDialog.TextVisible = false;
            // 
            // lcgFontOptions
            // 
            this.lcgFontOptions.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lcgFontOptions.CaptionImageOptions.SvgImage")));
            this.lcgFontOptions.CaptionImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.lcgFontOptions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciFontPicker,
            this.lciKeywordsColor,
            this.lciDefaultTextColor,
            this.lciColorPickComments,
            this.lciStringColor});
            this.lcgFontOptions.Location = new System.Drawing.Point(0, 0);
            this.lcgFontOptions.Name = "lcgFontOptions";
            this.lcgFontOptions.Size = new System.Drawing.Size(475, 172);
            this.lcgFontOptions.Text = "Text Editor Font Options";
            // 
            // lciFontPicker
            // 
            this.lciFontPicker.Control = this.fontEditDefaultFont;
            this.lciFontPicker.Location = new System.Drawing.Point(0, 0);
            this.lciFontPicker.Name = "lciFontPicker";
            this.lciFontPicker.Size = new System.Drawing.Size(451, 24);
            this.lciFontPicker.Text = "Text Editor Font";
            this.lciFontPicker.TextSize = new System.Drawing.Size(134, 13);
            // 
            // lciStringColor
            // 
            this.lciStringColor.Control = this.colorPickEditStringColor;
            this.lciStringColor.Location = new System.Drawing.Point(0, 96);
            this.lciStringColor.Name = "lciStringColor";
            this.lciStringColor.Size = new System.Drawing.Size(451, 27);
            this.lciStringColor.Text = "Text Editor String Color";
            this.lciStringColor.TextSize = new System.Drawing.Size(134, 13);
            // 
            // lciKeywordsColor
            // 
            this.lciKeywordsColor.Control = this.colorPickEditKeywordColor;
            this.lciKeywordsColor.Location = new System.Drawing.Point(0, 48);
            this.lciKeywordsColor.Name = "lciKeywordsColor";
            this.lciKeywordsColor.Size = new System.Drawing.Size(451, 24);
            this.lciKeywordsColor.Text = "Text Editor Keywords Color";
            this.lciKeywordsColor.TextSize = new System.Drawing.Size(134, 13);
            // 
            // lciDefaultTextColor
            // 
            this.lciDefaultTextColor.Control = this.colorPickEditDefaultTextColor;
            this.lciDefaultTextColor.Location = new System.Drawing.Point(0, 24);
            this.lciDefaultTextColor.Name = "lciDefaultTextColor";
            this.lciDefaultTextColor.Size = new System.Drawing.Size(451, 24);
            this.lciDefaultTextColor.Text = "Text Editor Default Font";
            this.lciDefaultTextColor.TextSize = new System.Drawing.Size(134, 13);
            // 
            // colorPickEditCommentsColor
            // 
            this.colorPickEditCommentsColor.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditCommentsColor.Location = new System.Drawing.Point(151, 111);
            this.colorPickEditCommentsColor.Name = "colorPickEditCommentsColor";
            this.colorPickEditCommentsColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditCommentsColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditCommentsColor.Size = new System.Drawing.Size(310, 20);
            this.colorPickEditCommentsColor.StyleController = this.lcFontDialog;
            this.colorPickEditCommentsColor.TabIndex = 10;
            // 
            // lciColorPickComments
            // 
            this.lciColorPickComments.Control = this.colorPickEditCommentsColor;
            this.lciColorPickComments.Location = new System.Drawing.Point(0, 72);
            this.lciColorPickComments.Name = "lciColorPickComments";
            this.lciColorPickComments.Size = new System.Drawing.Size(451, 24);
            this.lciColorPickComments.Text = "Text Editor Comments Color";
            this.lciColorPickComments.TextSize = new System.Drawing.Size(134, 13);
            // 
            // TextEditorFontEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcFontDialog);
            this.Name = "TextEditorFontEdit";
            this.Size = new System.Drawing.Size(475, 172);
            ((System.ComponentModel.ISupportInitialize)(this.lcFontDialog)).EndInit();
            this.lcFontDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditStringColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditKeywordColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditDefaultTextColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontEditDefaultFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFontOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFontPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStringColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKeywordsColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDefaultTextColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditCommentsColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciColorPickComments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcFontDialog;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFontDialog;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFontOptions;
        private DevExpress.XtraLayout.LayoutControlItem lciFontPicker;
        private DevExpress.XtraLayout.LayoutControlItem lciStringColor;
        private DevExpress.XtraLayout.LayoutControlItem lciKeywordsColor;
        private DevExpress.XtraLayout.LayoutControlItem lciDefaultTextColor;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditStringColor;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditKeywordColor;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditDefaultTextColor;
        private DevExpress.XtraEditors.FontEdit fontEditDefaultFont;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditCommentsColor;
        private DevExpress.XtraLayout.LayoutControlItem lciColorPickComments;
    }
}
