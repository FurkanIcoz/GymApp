namespace GymApp
{
    partial class FrmAntronorler
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
            this.btnAntrenorSec = new DevExpress.XtraEditors.SimpleButton();
            this.lblAntrenorEkle = new DevExpress.XtraEditors.LabelControl();
            this.lblAntrenorSec = new DevExpress.XtraEditors.LabelControl();
            this.btnAntrenorEkle = new DevExpress.XtraEditors.SimpleButton();
            this.cboxAntrenorSec = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxAntrenorSec.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAntrenorSec
            // 
            this.btnAntrenorSec.Appearance.BackColor = System.Drawing.Color.Turquoise;
            this.btnAntrenorSec.Appearance.Options.UseBackColor = true;
            this.btnAntrenorSec.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAntrenorSec.ImageOptions.SvgImage = global::GymApp.Properties.Resources.doublenext;
            this.btnAntrenorSec.Location = new System.Drawing.Point(275, 221);
            this.btnAntrenorSec.Name = "btnAntrenorSec";
            this.btnAntrenorSec.Size = new System.Drawing.Size(99, 76);
            this.btnAntrenorSec.TabIndex = 9;
            this.btnAntrenorSec.Click += new System.EventHandler(this.btnAntrenorSec_Click);
            // 
            // lblAntrenorEkle
            // 
            this.lblAntrenorEkle.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntrenorEkle.Appearance.Options.UseFont = true;
            this.lblAntrenorEkle.Location = new System.Drawing.Point(530, 124);
            this.lblAntrenorEkle.Name = "lblAntrenorEkle";
            this.lblAntrenorEkle.Size = new System.Drawing.Size(117, 17);
            this.lblAntrenorEkle.TabIndex = 7;
            this.lblAntrenorEkle.Text = "ANTRENOR EKLE";
            // 
            // lblAntrenorSec
            // 
            this.lblAntrenorSec.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntrenorSec.Appearance.Options.UseFont = true;
            this.lblAntrenorSec.Location = new System.Drawing.Point(258, 124);
            this.lblAntrenorSec.Name = "lblAntrenorSec";
            this.lblAntrenorSec.Size = new System.Drawing.Size(109, 17);
            this.lblAntrenorSec.TabIndex = 6;
            this.lblAntrenorSec.Text = "ANTRENOR SEC";
            // 
            // btnAntrenorEkle
            // 
            this.btnAntrenorEkle.Appearance.BackColor = System.Drawing.Color.Turquoise;
            this.btnAntrenorEkle.Appearance.Options.UseBackColor = true;
            this.btnAntrenorEkle.ImageOptions.Image = global::GymApp.Properties.Resources.add_32x322;
            this.btnAntrenorEkle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAntrenorEkle.Location = new System.Drawing.Point(543, 221);
            this.btnAntrenorEkle.Name = "btnAntrenorEkle";
            this.btnAntrenorEkle.Size = new System.Drawing.Size(97, 76);
            this.btnAntrenorEkle.TabIndex = 8;
            this.btnAntrenorEkle.Click += new System.EventHandler(this.btnAntrenorEkle_Click);
            // 
            // cboxAntrenorSec
            // 
            this.cboxAntrenorSec.Location = new System.Drawing.Point(213, 184);
            this.cboxAntrenorSec.Name = "cboxAntrenorSec";
            this.cboxAntrenorSec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxAntrenorSec.Size = new System.Drawing.Size(224, 20);
            this.cboxAntrenorSec.TabIndex = 5;
            // 
            // FrmAntronorler
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 398);
            this.Controls.Add(this.btnAntrenorSec);
            this.Controls.Add(this.lblAntrenorEkle);
            this.Controls.Add(this.btnAntrenorEkle);
            this.Controls.Add(this.lblAntrenorSec);
            this.Controls.Add(this.cboxAntrenorSec);
            this.Name = "FrmAntronorler";
            this.Text = "Antrenörler";
            this.Load += new System.EventHandler(this.FrmAntronorler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboxAntrenorSec.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAntrenorSec;
        private DevExpress.XtraEditors.LabelControl lblAntrenorEkle;
        private DevExpress.XtraEditors.SimpleButton btnAntrenorEkle;
        private DevExpress.XtraEditors.LabelControl lblAntrenorSec;
        private DevExpress.XtraEditors.ComboBoxEdit cboxAntrenorSec;
    }
}