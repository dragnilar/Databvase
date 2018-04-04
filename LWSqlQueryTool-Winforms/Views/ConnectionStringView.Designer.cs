using LWSqlQueryTool_Winforms.View_Models;

namespace LWSqlQueryTool_Winforms.Views
{
    partial class ConnectionStringView
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
            this.mvvmContextConnectionStringView = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContextConnectionStringView
            // 
            this.mvvmContextConnectionStringView.ContainerControl = this;
            this.mvvmContextConnectionStringView.ViewModelType = typeof(ConnectionStringViewModel);
            // 
            // ConnectionStringView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ConnectionStringView";
            this.Text = "ConnectionStringView";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContextConnectionStringView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContextConnectionStringView;
    }
}