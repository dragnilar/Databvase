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
    public class XtraFontDialog : XtraForm
    {
        private ComboBoxEdit cbeFont;
        private CheckedListBoxControl clbStyle;
        private Container components;
        private Font fCurrentFont;
        private Font fResultFont;
        private ImageListBoxControl ilbcFont;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private ListBoxControl lbcFontSize;
        private LabelControl lcPreview;
        private SimpleButton sbCancel;
        private SimpleButton sbOk;
        private SpinEdit seFontSize;
        private TextEdit teFontStyle;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage2;

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
            xtraTabControl1 = new XtraTabControl();
            xtraTabPage2 = new XtraTabPage();
            lcPreview = new LabelControl();
            labelControl4 = new LabelControl();
            lbcFontSize = new ListBoxControl();
            labelControl3 = new LabelControl();
            seFontSize = new SpinEdit();
            labelControl2 = new LabelControl();
            teFontStyle = new TextEdit();
            clbStyle = new CheckedListBoxControl();
            labelControl1 = new LabelControl();
            ilbcFont = new ImageListBoxControl();
            cbeFont = new ComboBoxEdit();
            sbCancel = new SimpleButton();
            sbOk = new SimpleButton();
            xtraTabControl1.BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage2.SuspendLayout();
            ((ISupportInitialize) lbcFontSize).BeginInit();
            seFontSize.Properties.BeginInit();
            teFontStyle.Properties.BeginInit();
            ((ISupportInitialize) clbStyle).BeginInit();
            ((ISupportInitialize) ilbcFont).BeginInit();
            cbeFont.Properties.BeginInit();
            SuspendLayout();
            xtraTabControl1.Location = new Point(8, 9);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            xtraTabControl1.Size = new Size(376, 303);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new XtraTabPage[1]
            {
                xtraTabPage2
            });
            xtraTabControl1.TabStop = false;
            xtraTabControl1.Text = "xtcFont";
            xtraTabPage2.Controls.AddRange(new Control[11]
            {
                lcPreview,
                labelControl4,
                lbcFontSize,
                labelControl3,
                seFontSize,
                labelControl2,
                teFontStyle,
                clbStyle,
                labelControl1,
                ilbcFont,
                cbeFont
            });
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(367, 273);
            xtraTabPage2.Text = "Font";
            lcPreview.Appearance.BackColor = Color.White;
            lcPreview.Appearance.Options.UseBackColor = true;
            lcPreview.Appearance.Options.UseTextOptions = true;
            lcPreview.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            lcPreview.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            lcPreview.BorderStyle = BorderStyles.Simple;
            lcPreview.LineLocation = LineLocation.Center;
            lcPreview.LineVisible = true;
            lcPreview.Location = new Point(8, 216);
            lcPreview.Name = "lcPreview";
            lcPreview.AutoSizeMode = LabelAutoSizeMode.None;
            lcPreview.Size = new Size(352, 40);
            lcPreview.TabIndex = 25;
            lcPreview.Text = "Font Preview Text";
            labelControl4.LineVisible = true;
            labelControl4.Location = new Point(10, 192);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new Size(350, 13);
            labelControl4.TabIndex = 24;
            labelControl4.Text = "Preview";
            lbcFontSize.Location = new Point(280, 46);
            lbcFontSize.Name = "lbcFontSize";
            lbcFontSize.Size = new Size(80, 130);
            lbcFontSize.TabIndex = 5;
            lbcFontSize.SelectedIndexChanged += lbcFontSize_SelectedIndexChanged;
            labelControl3.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            labelControl3.Location = new Point(282, 8);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new Size(48, 13);
            labelControl3.TabIndex = 22;
            labelControl3.Text = "Font Size:";
            seFontSize.EditValue = new decimal(new int[4]
            {
                8,
                0,
                0,
                0
            });
            seFontSize.Location = new Point(280, 24);
            seFontSize.Name = "seFontSize";
            seFontSize.Properties.Buttons.AddRange(new EditorButton[1]
            {
                new EditorButton()
            });
            seFontSize.Properties.IsFloatValue = false;
            seFontSize.Properties.Mask.EditMask = "N00";
            seFontSize.Properties.MaxValue = new decimal(new int[4]
            {
                100,
                0,
                0,
                0
            });
            seFontSize.Properties.MinValue = new decimal(new int[4]
            {
                6,
                0,
                0,
                0
            });
            seFontSize.Size = new Size(80, 20);
            seFontSize.TabIndex = 4;
            seFontSize.EditValueChanged += seFontSize_EditValueChanged;
            labelControl2.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            labelControl2.Location = new Point(170, 8);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(53, 13);
            labelControl2.TabIndex = 20;
            labelControl2.Text = "Font Style:";
            teFontStyle.Location = new Point(168, 24);
            teFontStyle.Name = "teFontStyle";
            teFontStyle.Properties.ReadOnly = true;
            teFontStyle.Size = new Size(104, 20);
            teFontStyle.TabIndex = 2;
            teFontStyle.TabStop = false;
            clbStyle.CheckOnClick = true;
            clbStyle.Items.AddRange(new CheckedListBoxItem[4]
            {
                new CheckedListBoxItem("Bold"),
                new CheckedListBoxItem("Italic"),
                new CheckedListBoxItem("Strikeout"),
                new CheckedListBoxItem("Underline")
            });
            clbStyle.Location = new Point(168, 46);
            clbStyle.Name = "clbStyle";
            clbStyle.Size = new Size(104, 130);
            clbStyle.TabIndex = 3;
            clbStyle.ItemCheck += clbStyle_ItemCheck;
            labelControl1.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            labelControl1.Location = new Point(10, 8);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(26, 13);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Font:";
            ilbcFont.Location = new Point(8, 46);
            ilbcFont.Name = "ilbcFont";
            ilbcFont.Size = new Size(152, 130);
            ilbcFont.TabIndex = 1;
            ilbcFont.SelectedIndexChanged += ilbcFont_SelectedIndexChanged;
            cbeFont.Location = new Point(8, 24);
            cbeFont.Name = "cbeFont";
            cbeFont.Properties.ShowDropDown = ShowDropDown.Never;
            cbeFont.Size = new Size(152, 20);
            cbeFont.TabIndex = 0;
            cbeFont.SelectedValueChanged += cbeFont_SelectedValueChanged;
            sbCancel.DialogResult = DialogResult.Cancel;
            sbCancel.Location = new Point(296, 320);
            sbCancel.Name = "sbCancel";
            sbCancel.Size = new Size(88, 24);
            sbCancel.TabIndex = 2;
            sbCancel.Text = "&Cancel";
            sbOk.DialogResult = DialogResult.OK;
            sbOk.Location = new Point(200, 320);
            sbOk.Name = "sbOk";
            sbOk.Size = new Size(88, 24);
            sbOk.TabIndex = 1;
            sbOk.Text = "&OK";
            AcceptButton = sbOk;
            AutoScaleMode = AutoScaleMode.Font;
            AutoScaleDimensions = new SizeF(6f, 13f);
            CancelButton = sbCancel;
            ClientSize = new Size(394, 352);
            Controls.AddRange(new Control[3]
            {
                sbOk,
                sbCancel,
                xtraTabControl1
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFontDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Font";
            xtraTabControl1.EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage2.ResumeLayout(false);
            ((ISupportInitialize) lbcFontSize).EndInit();
            seFontSize.Properties.EndInit();
            teFontStyle.Properties.EndInit();
            ((ISupportInitialize) clbStyle).EndInit();
            ((ISupportInitialize) ilbcFont).EndInit();
            cbeFont.Properties.EndInit();
            ResumeLayout(false);
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
            lcPreview.Font = ResultFont;
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