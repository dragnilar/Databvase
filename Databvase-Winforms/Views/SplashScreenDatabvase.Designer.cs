namespace Databvase_Winforms.Views
{
    partial class SplashScreenDatabvase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenDatabvase));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControlTitle = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditLogo = new DevExpress.XtraEditors.PictureEdit();
            this.separatorControlSplash = new DevExpress.XtraEditors.SeparatorControl();
            this.defaultLookAndFeelSplashy = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.labelControlDescription = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControlSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(23, 286);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(173, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "No Copyright, this Jank Is Freeware";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(278, 266);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new System.Drawing.Size(160, 48);
            this.pictureEdit1.TabIndex = 8;
            // 
            // labelControlTitle
            // 
            this.labelControlTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlTitle.Appearance.Options.UseFont = true;
            this.labelControlTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControlTitle.Location = new System.Drawing.Point(118, 78);
            this.labelControlTitle.Name = "labelControlTitle";
            this.labelControlTitle.Size = new System.Drawing.Size(269, 58);
            this.labelControlTitle.TabIndex = 6;
            this.labelControlTitle.Text = "Databvase!!!";
            // 
            // pictureEditLogo
            // 
            this.pictureEditLogo.EditValue = ((object)(resources.GetObject("pictureEditLogo.EditValue")));
            this.pictureEditLogo.Location = new System.Drawing.Point(45, 78);
            this.pictureEditLogo.Name = "pictureEditLogo";
            this.pictureEditLogo.Properties.AllowFocused = false;
            this.pictureEditLogo.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEditLogo.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEditLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditLogo.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.pictureEditLogo.Properties.ReadOnly = true;
            this.pictureEditLogo.Properties.ShowMenu = false;
            this.pictureEditLogo.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEditLogo.Size = new System.Drawing.Size(67, 52);
            this.pictureEditLogo.TabIndex = 11;
            // 
            // separatorControlSplash
            // 
            this.separatorControlSplash.BackColor = System.Drawing.Color.Transparent;
            this.separatorControlSplash.Location = new System.Drawing.Point(23, 136);
            this.separatorControlSplash.Name = "separatorControlSplash";
            this.separatorControlSplash.Size = new System.Drawing.Size(401, 23);
            this.separatorControlSplash.TabIndex = 12;
            // 
            // defaultLookAndFeelSplashy
            // 
            this.defaultLookAndFeelSplashy.LookAndFeel.SkinName = "The Bezier";
            // 
            // labelControlDescription
            // 
            this.labelControlDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlDescription.Appearance.Options.UseFont = true;
            this.labelControlDescription.Location = new System.Drawing.Point(34, 165);
            this.labelControlDescription.Name = "labelControlDescription";
            this.labelControlDescription.Size = new System.Drawing.Size(369, 16);
            this.labelControlDescription.TabIndex = 13;
            this.labelControlDescription.Text = "A Lightweight MS SQL Server Database Management Application";
            // 
            // SplashScreenDatabvase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.labelControlDescription);
            this.Controls.Add(this.separatorControlSplash);
            this.Controls.Add(this.pictureEditLogo);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControlTitle);
            this.Controls.Add(this.labelControl1);
            this.ForeColor = System.Drawing.Color.DarkGreen;
            this.Name = "SplashScreenDatabvase";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControlSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControlTitle;
        private DevExpress.XtraEditors.PictureEdit pictureEditLogo;
        private DevExpress.XtraEditors.SeparatorControl separatorControlSplash;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeelSplashy;
        private DevExpress.XtraEditors.LabelControl labelControlDescription;
    }
}
