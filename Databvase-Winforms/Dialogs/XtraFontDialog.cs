using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using ItemCheckEventArgs = DevExpress.XtraEditors.Controls.ItemCheckEventArgs;

namespace Databvase_Winforms.Controls
{
    /// <summary>
    /// This is an "unofficial" DevExpress control that was taken from their RichEdit demo. It provides a rich experience for a user to select a font.
    /// </summary>
    public class XtraFontDialog : XtraForm
    {
        private ComboBoxEdit cbeFont;
        private CheckedListBoxControl clbStyle;
        private Container components;
        private Font fCurrentFont;
        private Font fResultFont;
        private ImageListBoxControl ilbcFont;
        private LabelControl labelControlFontName;
        private LabelControl labelControlFontStyle;
        private LabelControl labelControlFontSize;
        private LabelControl labelControlPreview;
        private ListBoxControl lbcFontSize;
        private LabelControl lcFontPreviewText;
        private SimpleButton sbCancel;
        private SimpleButton sbOk;
        private SpinEdit seFontSize;
        private TextEdit teFontStyle;
        private XtraTabControl xtraTabControlXtraFontDialog;
        private XtraTabPage xtraTabPageFontSetup;

        public XtraFontDialog(Font font)
        {
            InitializeComponent();
            InitFont();
            InitSize();
            if (LookAndFeel.GetTouchUI())
                Scale(new SizeF((float) (1.39999997615814 + LookAndFeel.GetTouchScaleFactor() / 10.0),
                    (float) (1.39999997615814 + LookAndFeel.GetTouchScaleFactor() / 10.0)));
            ilbcFont.SelectedIndex = -1;
            CurrentFont = font;
            UpdatePreview();
            cbeFont.GotFocus += cbeFont_GotFocus;
        }

        private Font CurrentFont
        {
            get => fCurrentFont;
            set
            {
                fCurrentFont = value;
                InitFontValues();
            }
        }

        private string ResultFontName
        {
            get
            {
                if (ilbcFont.SelectedItem != null)
                    return ilbcFont.SelectedItem.ToString();
                return AppearanceObject.DefaultFont.Name;
            }
        }

        public Font ResultFont
        {
            get
            {
                if (fResultFont == null)
                    fResultFont = new Font(ResultFontName, (int) seFontSize.Value, GetFontStyleByValues(clbStyle));
                return fResultFont;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                ResultFontDispose();
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitFontValues()
        {
            ilbcFont.Enabled = cbeFont.Enabled = teFontStyle.Enabled =
                clbStyle.Enabled = seFontSize.Enabled = lbcFontSize.Enabled = CurrentFont != null;
            if (CurrentFont == null)
                return;
            ilbcFont.SelectedValue = CurrentFont.Name;
            foreach (CheckedListBoxItem checkedListBoxItem in clbStyle.Items)
                checkedListBoxItem.CheckState =
                    CurrentFont.Style.ToString().IndexOf(checkedListBoxItem.Value.ToString()) > -1
                        ? CheckState.Checked
                        : CheckState.Unchecked;
            InitStyleString();
            seFontSize.Value = Convert.ToInt32(CurrentFont.Size);
        }

        private void InitializeComponent()
        {
            this.xtraTabControlXtraFontDialog = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageFontSetup = new DevExpress.XtraTab.XtraTabPage();
            this.lcFontPreviewText = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPreview = new DevExpress.XtraEditors.LabelControl();
            this.lbcFontSize = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControlFontSize = new DevExpress.XtraEditors.LabelControl();
            this.seFontSize = new DevExpress.XtraEditors.SpinEdit();
            this.labelControlFontStyle = new DevExpress.XtraEditors.LabelControl();
            this.teFontStyle = new DevExpress.XtraEditors.TextEdit();
            this.clbStyle = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControlFontName = new DevExpress.XtraEditors.LabelControl();
            this.ilbcFont = new DevExpress.XtraEditors.ImageListBoxControl();
            this.cbeFont = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlXtraFontDialog)).BeginInit();
            this.xtraTabControlXtraFontDialog.SuspendLayout();
            this.xtraTabPageFontSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbcFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFontSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFontStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilbcFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeFont.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlXtraFontDialog
            // 
            this.xtraTabControlXtraFontDialog.Location = new System.Drawing.Point(8, 9);
            this.xtraTabControlXtraFontDialog.Name = "xtraTabControlXtraFontDialog";
            this.xtraTabControlXtraFontDialog.SelectedTabPage = this.xtraTabPageFontSetup;
            this.xtraTabControlXtraFontDialog.Size = new System.Drawing.Size(376, 303);
            this.xtraTabControlXtraFontDialog.TabIndex = 0;
            this.xtraTabControlXtraFontDialog.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageFontSetup});
            this.xtraTabControlXtraFontDialog.TabStop = false;
            // 
            // xtraTabPageFontSetup
            // 
            this.xtraTabPageFontSetup.Controls.Add(this.lcFontPreviewText);
            this.xtraTabPageFontSetup.Controls.Add(this.labelControlPreview);
            this.xtraTabPageFontSetup.Controls.Add(this.lbcFontSize);
            this.xtraTabPageFontSetup.Controls.Add(this.labelControlFontSize);
            this.xtraTabPageFontSetup.Controls.Add(this.seFontSize);
            this.xtraTabPageFontSetup.Controls.Add(this.labelControlFontStyle);
            this.xtraTabPageFontSetup.Controls.Add(this.teFontStyle);
            this.xtraTabPageFontSetup.Controls.Add(this.clbStyle);
            this.xtraTabPageFontSetup.Controls.Add(this.labelControlFontName);
            this.xtraTabPageFontSetup.Controls.Add(this.ilbcFont);
            this.xtraTabPageFontSetup.Controls.Add(this.cbeFont);
            this.xtraTabPageFontSetup.Name = "xtraTabPageFontSetup";
            this.xtraTabPageFontSetup.Size = new System.Drawing.Size(370, 275);
            this.xtraTabPageFontSetup.Text = "Font";
            // 
            // lcFontPreviewText
            // 
            this.lcFontPreviewText.Appearance.BackColor = System.Drawing.Color.White;
            this.lcFontPreviewText.Appearance.Options.UseBackColor = true;
            this.lcFontPreviewText.Appearance.Options.UseTextOptions = true;
            this.lcFontPreviewText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcFontPreviewText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcFontPreviewText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcFontPreviewText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lcFontPreviewText.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lcFontPreviewText.LineVisible = true;
            this.lcFontPreviewText.Location = new System.Drawing.Point(8, 216);
            this.lcFontPreviewText.Name = "lcFontPreviewText";
            this.lcFontPreviewText.Size = new System.Drawing.Size(352, 40);
            this.lcFontPreviewText.TabIndex = 25;
            this.lcFontPreviewText.Text = "Font Preview Text";
            // 
            // labelControlPreview
            // 
            this.labelControlPreview.LineVisible = true;
            this.labelControlPreview.Location = new System.Drawing.Point(10, 192);
            this.labelControlPreview.Name = "labelControlPreview";
            this.labelControlPreview.Size = new System.Drawing.Size(38, 13);
            this.labelControlPreview.TabIndex = 24;
            this.labelControlPreview.Text = "Preview";
            // 
            // lbcFontSize
            // 
            this.lbcFontSize.Location = new System.Drawing.Point(280, 46);
            this.lbcFontSize.Name = "lbcFontSize";
            this.lbcFontSize.Size = new System.Drawing.Size(80, 130);
            this.lbcFontSize.TabIndex = 5;
            // 
            // labelControlFontSize
            // 
            this.labelControlFontSize.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControlFontSize.Location = new System.Drawing.Point(282, 8);
            this.labelControlFontSize.Name = "labelControlFontSize";
            this.labelControlFontSize.Size = new System.Drawing.Size(48, 13);
            this.labelControlFontSize.TabIndex = 22;
            this.labelControlFontSize.Text = "Font Size:";
            // 
            // seFontSize
            // 
            this.seFontSize.EditValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.seFontSize.Location = new System.Drawing.Point(280, 24);
            this.seFontSize.Name = "seFontSize";
            this.seFontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seFontSize.Properties.IsFloatValue = false;
            this.seFontSize.Properties.Mask.EditMask = "N00";
            this.seFontSize.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seFontSize.Properties.MinValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.seFontSize.Size = new System.Drawing.Size(80, 20);
            this.seFontSize.TabIndex = 4;
            // 
            // labelControlFontStyle
            // 
            this.labelControlFontStyle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControlFontStyle.Location = new System.Drawing.Point(170, 8);
            this.labelControlFontStyle.Name = "labelControlFontStyle";
            this.labelControlFontStyle.Size = new System.Drawing.Size(53, 13);
            this.labelControlFontStyle.TabIndex = 20;
            this.labelControlFontStyle.Text = "Font Style:";
            // 
            // teFontStyle
            // 
            this.teFontStyle.Location = new System.Drawing.Point(168, 24);
            this.teFontStyle.Name = "teFontStyle";
            this.teFontStyle.Properties.ReadOnly = true;
            this.teFontStyle.Size = new System.Drawing.Size(104, 20);
            this.teFontStyle.TabIndex = 2;
            this.teFontStyle.TabStop = false;
            // 
            // clbStyle
            // 
            this.clbStyle.CheckOnClick = true;
            this.clbStyle.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Bold"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Italic"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Strikeout"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Underline")});
            this.clbStyle.Location = new System.Drawing.Point(168, 46);
            this.clbStyle.Name = "clbStyle";
            this.clbStyle.Size = new System.Drawing.Size(104, 130);
            this.clbStyle.TabIndex = 3;
            // 
            // labelControlFontName
            // 
            this.labelControlFontName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControlFontName.Location = new System.Drawing.Point(10, 8);
            this.labelControlFontName.Name = "labelControlFontName";
            this.labelControlFontName.Size = new System.Drawing.Size(26, 13);
            this.labelControlFontName.TabIndex = 2;
            this.labelControlFontName.Text = "Font:";
            // 
            // ilbcFont
            // 
            this.ilbcFont.Location = new System.Drawing.Point(8, 46);
            this.ilbcFont.Name = "ilbcFont";
            this.ilbcFont.Size = new System.Drawing.Size(152, 130);
            this.ilbcFont.TabIndex = 1;
            // 
            // cbeFont
            // 
            this.cbeFont.Location = new System.Drawing.Point(8, 24);
            this.cbeFont.Name = "cbeFont";
            this.cbeFont.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.cbeFont.Size = new System.Drawing.Size(152, 20);
            this.cbeFont.TabIndex = 0;
            // 
            // sbCancel
            // 
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(296, 320);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(88, 24);
            this.sbCancel.TabIndex = 2;
            this.sbCancel.Text = "&Cancel";
            // 
            // sbOk
            // 
            this.sbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbOk.Location = new System.Drawing.Point(200, 320);
            this.sbOk.Name = "sbOk";
            this.sbOk.Size = new System.Drawing.Size(88, 24);
            this.sbOk.TabIndex = 1;
            this.sbOk.Text = "&OK";
            // 
            // XtraFontDialog
            // 
            this.AcceptButton = this.sbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbCancel;
            this.ClientSize = new System.Drawing.Size(394, 352);
            this.Controls.Add(this.sbOk);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.xtraTabControlXtraFontDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFontDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlXtraFontDialog)).EndInit();
            this.xtraTabControlXtraFontDialog.ResumeLayout(false);
            this.xtraTabPageFontSetup.ResumeLayout(false);
            this.xtraTabPageFontSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbcFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFontStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilbcFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeFont.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitStyleString()
        {
            teFontStyle.Text = GetFontStyleByValues(clbStyle).ToString();
            UpdatePreview();
        }

        private FontStyle GetFontStyleByValues(CheckedListBoxControl clb)
        {
            var fontStyle = FontStyle.Regular;
            if (clb.GetItemChecked(0))
                fontStyle |= FontStyle.Bold;
            if (clb.GetItemChecked(1))
                fontStyle |= FontStyle.Italic;
            if (clb.GetItemChecked(2))
                fontStyle |= FontStyle.Strikeout;
            if (clb.GetItemChecked(3))
                fontStyle |= FontStyle.Underline;
            return fontStyle;
        }

        private void InitFont()
        {
            FontInitializer(ilbcFont, new Size(20, 16));
            cbeFont.Properties.Items.AddRange(ilbcFont.Items);
        }

        private void InitSize()
        {
            var num = 8;
            while (num < 30)
            {
                lbcFontSize.Items.Add(num);
                num += 2;
            }

            lbcFontSize.Items.Add(36);
            lbcFontSize.Items.Add(48);
            lbcFontSize.Items.Add(72);
        }

        private void ilbcFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ilbcFont.SelectedItem == null)
                return;
            cbeFont.SelectedItem = ilbcFont.SelectedItem;
            UpdatePreview();
        }

        private void cbeFont_SelectedValueChanged(object sender, EventArgs e)
        {
            ilbcFont.SelectedItem = cbeFont.SelectedItem;
        }

        private void cbeFont_GotFocus(object sender, EventArgs e)
        {
            cbeFont.SelectAll();
        }

        private void clbStyle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            InitStyleString();
        }

        private void seFontSize_EditValueChanged(object sender, EventArgs e)
        {
            var num = (int) seFontSize.Value;
            if (lbcFontSize.Items.IndexOf(num) < 0)
                lbcFontSize.SelectedIndex = -1;
            else
                lbcFontSize.SelectedValue = num;
            UpdatePreview();
        }

        private void lbcFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbcFontSize.SelectedIndex == -1)
                return;
            seFontSize.Value = (int) lbcFontSize.SelectedItem;
        }

        private void UpdatePreview()
        {
            ResultFontDispose();
            lcFontPreviewText.Font = ResultFont;
        }

        private void ResultFontDispose()
        {
            if (fResultFont == null)
                return;
            fResultFont.Dispose();
            fResultFont = null;
        }


        public static void FontInitializer(ImageListBoxControl ilb, Size imageSize)
        {
            var width = imageSize.Width;
            var height = imageSize.Height;
            var num1 = 1;
            var imageList = new ImageList();
            imageList.ImageSize = new Size(width, height);
            var rect = new Rectangle(num1, num1, width - num1 * 2, height - num1 * 2);
            ilb.BeginUpdate();
            try
            {
                ilb.Items.Clear();
                ilb.ImageList = imageList;
                var num2 = 0;
                for (var index = 0; index < FontFamily.Families.Length; ++index)
                    try
                    {
                        var font = new Font(FontFamily.Families[index].Name, 8f);
                        var name = FontFamily.Families[index].Name;
                        var image = (Image) new Bitmap(width, height);
                        using (var graphics = Graphics.FromImage(image))
                        {
                            graphics.FillRectangle(Brushes.White, rect);
                            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                            graphics.DrawString("abc", font, Brushes.Black, num1, num1);
                            graphics.DrawRectangle(Pens.Black, rect);
                        }

                        imageList.Images.Add(image);
                        ilb.Items.Add(name, num2++);
                    }
                    catch
                    {
                    }
            }
            finally
            {
                ilb.CancelUpdate();
            }
        }
    }
}