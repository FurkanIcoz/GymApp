namespace GymApp
{
    partial class FrmUyeler
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
            this.lblUyeSec = new DevExpress.XtraEditors.LabelControl();
            this.lblUyeEkle = new DevExpress.XtraEditors.LabelControl();
            this.btnUyeGetir = new DevExpress.XtraEditors.SimpleButton();
            this.btnUyeEkle = new DevExpress.XtraEditors.SimpleButton();
            this.cboxUyeSec = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxUyeSec.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUyeSec
            // 
            this.lblUyeSec.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUyeSec.Appearance.Options.UseFont = true;
            this.lblUyeSec.Location = new System.Drawing.Point(296, 124);
            this.lblUyeSec.Name = "lblUyeSec";
            this.lblUyeSec.Size = new System.Drawing.Size(60, 17);
            this.lblUyeSec.TabIndex = 1;
            this.lblUyeSec.Text = "UYE SEC";
            // 
            // lblUyeEkle
            // 
            this.lblUyeEkle.Appearance.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUyeEkle.Appearance.Options.UseFont = true;
            this.lblUyeEkle.Location = new System.Drawing.Point(557, 124);
            this.lblUyeEkle.Name = "lblUyeEkle";
            this.lblUyeEkle.Size = new System.Drawing.Size(68, 17);
            this.lblUyeEkle.TabIndex = 2;
            this.lblUyeEkle.Text = "UYE EKLE";
            // 
            // btnUyeGetir
            // 
            this.btnUyeGetir.Appearance.BackColor = System.Drawing.Color.Turquoise;
            this.btnUyeGetir.Appearance.Options.UseBackColor = true;
            this.btnUyeGetir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnUyeGetir.ImageOptions.SvgImage = global::GymApp.Properties.Resources.doublenext;
            this.btnUyeGetir.Location = new System.Drawing.Point(275, 221);
            this.btnUyeGetir.Name = "btnUyeGetir";
            this.btnUyeGetir.Size = new System.Drawing.Size(99, 76);
            this.btnUyeGetir.TabIndex = 4;
            this.btnUyeGetir.Click += new System.EventHandler(this.btnUyeGetir_Click);
            // 
            // btnUyeEkle
            // 
            this.btnUyeEkle.Appearance.BackColor = System.Drawing.Color.Turquoise;
            this.btnUyeEkle.Appearance.Options.UseBackColor = true;
            this.btnUyeEkle.ImageOptions.Image = global::GymApp.Properties.Resources.add_32x322;
            this.btnUyeEkle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnUyeEkle.Location = new System.Drawing.Point(543, 221);
            this.btnUyeEkle.Name = "btnUyeEkle";
            this.btnUyeEkle.Size = new System.Drawing.Size(99, 76);
            this.btnUyeEkle.TabIndex = 3;
            this.btnUyeEkle.Click += new System.EventHandler(this.btnUyeEkle_Click_1);
            // 
            // cboxUyeSec
            // 
            this.cboxUyeSec.Location = new System.Drawing.Point(213, 184);
            this.cboxUyeSec.Name = "cboxUyeSec";
            this.cboxUyeSec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxUyeSec.Size = new System.Drawing.Size(224, 20);
            this.cboxUyeSec.TabIndex = 0;
            // 
            // FrmUyeler
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 398);
            this.Controls.Add(this.btnUyeGetir);
            this.Controls.Add(this.lblUyeEkle);
            this.Controls.Add(this.btnUyeEkle);
            this.Controls.Add(this.lblUyeSec);
            this.Controls.Add(this.cboxUyeSec);
            this.Name = "FrmUyeler";
            this.Text = "Üyeler";
            this.Load += new System.EventHandler(this.FrmUyeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboxUyeSec.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboxUyeSec;
        private DevExpress.XtraEditors.LabelControl lblUyeSec;
        private DevExpress.XtraEditors.LabelControl lblUyeEkle;
        private DevExpress.XtraEditors.SimpleButton btnUyeGetir;
        private DevExpress.XtraEditors.SimpleButton btnUyeEkle;
    }
}