namespace GymApp.Forms
{
    partial class FrmOdemeBilgileri
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
            this.grdCntrOdemeBilgileri = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.txtOdemeUcret = new DevExpress.XtraEditors.TextEdit();
            this.txtOdemeUyelikSuresi = new DevExpress.XtraEditors.TextEdit();
            this.txtOdemeUyelikAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblUyelikUcret = new DevExpress.XtraEditors.LabelControl();
            this.lblUyelikSuresi = new DevExpress.XtraEditors.LabelControl();
            this.lblUyelikAdi = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrOdemeBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUcret.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUyelikSuresi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUyelikAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCntrOdemeBilgileri
            // 
            this.grdCntrOdemeBilgileri.Location = new System.Drawing.Point(-2, 0);
            this.grdCntrOdemeBilgileri.MainView = this.gridView1;
            this.grdCntrOdemeBilgileri.Name = "grdCntrOdemeBilgileri";
            this.grdCntrOdemeBilgileri.Size = new System.Drawing.Size(593, 399);
            this.grdCntrOdemeBilgileri.TabIndex = 0;
            this.grdCntrOdemeBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCntrOdemeBilgileri;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnGuncelle);
            this.groupControl1.Controls.Add(this.txtOdemeUcret);
            this.groupControl1.Controls.Add(this.txtOdemeUyelikSuresi);
            this.groupControl1.Controls.Add(this.txtOdemeUyelikAdi);
            this.groupControl1.Controls.Add(this.lblUyelikUcret);
            this.groupControl1.Controls.Add(this.lblUyelikSuresi);
            this.groupControl1.Controls.Add(this.lblUyelikAdi);
            this.groupControl1.Location = new System.Drawing.Point(590, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(258, 399);
            this.groupControl1.TabIndex = 1;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.ImageOptions.Image = global::GymApp.Properties.Resources.refreshallpivottable_32x32;
            this.btnGuncelle.Location = new System.Drawing.Point(122, 198);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGuncelle.Size = new System.Drawing.Size(112, 51);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "GUNCELLE";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // txtOdemeUcret
            // 
            this.txtOdemeUcret.Location = new System.Drawing.Point(121, 138);
            this.txtOdemeUcret.Name = "txtOdemeUcret";
            this.txtOdemeUcret.Size = new System.Drawing.Size(112, 20);
            this.txtOdemeUcret.TabIndex = 5;
            // 
            // txtOdemeUyelikSuresi
            // 
            this.txtOdemeUyelikSuresi.Location = new System.Drawing.Point(121, 93);
            this.txtOdemeUyelikSuresi.Name = "txtOdemeUyelikSuresi";
            this.txtOdemeUyelikSuresi.Size = new System.Drawing.Size(112, 20);
            this.txtOdemeUyelikSuresi.TabIndex = 4;
            // 
            // txtOdemeUyelikAdi
            // 
            this.txtOdemeUyelikAdi.Location = new System.Drawing.Point(121, 48);
            this.txtOdemeUyelikAdi.Name = "txtOdemeUyelikAdi";
            this.txtOdemeUyelikAdi.Size = new System.Drawing.Size(112, 20);
            this.txtOdemeUyelikAdi.TabIndex = 3;
            // 
            // lblUyelikUcret
            // 
            this.lblUyelikUcret.Appearance.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyelikUcret.Appearance.Options.UseFont = true;
            this.lblUyelikUcret.Location = new System.Drawing.Point(68, 137);
            this.lblUyelikUcret.Name = "lblUyelikUcret";
            this.lblUyelikUcret.Size = new System.Drawing.Size(47, 18);
            this.lblUyelikUcret.TabIndex = 2;
            this.lblUyelikUcret.Text = "Ucret:";
            // 
            // lblUyelikSuresi
            // 
            this.lblUyelikSuresi.Appearance.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyelikSuresi.Appearance.Options.UseFont = true;
            this.lblUyelikSuresi.Location = new System.Drawing.Point(14, 92);
            this.lblUyelikSuresi.Name = "lblUyelikSuresi";
            this.lblUyelikSuresi.Size = new System.Drawing.Size(101, 18);
            this.lblUyelikSuresi.TabIndex = 1;
            this.lblUyelikSuresi.Text = "Uyelik Suresi:";
            // 
            // lblUyelikAdi
            // 
            this.lblUyelikAdi.Appearance.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUyelikAdi.Appearance.Options.UseFont = true;
            this.lblUyelikAdi.Location = new System.Drawing.Point(37, 47);
            this.lblUyelikAdi.Name = "lblUyelikAdi";
            this.lblUyelikAdi.Size = new System.Drawing.Size(78, 18);
            this.lblUyelikAdi.TabIndex = 0;
            this.lblUyelikAdi.Text = "Uyelik Adi:";
            // 
            // FrmOdemeBilgileri
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 398);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdCntrOdemeBilgileri);
            this.Name = "FrmOdemeBilgileri";
            this.Text = "Ödeme Bilgileri";
            this.Load += new System.EventHandler(this.FrmOdemeBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCntrOdemeBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUcret.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUyelikSuresi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeUyelikAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCntrOdemeBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.TextEdit txtOdemeUcret;
        private DevExpress.XtraEditors.TextEdit txtOdemeUyelikSuresi;
        private DevExpress.XtraEditors.TextEdit txtOdemeUyelikAdi;
        private DevExpress.XtraEditors.LabelControl lblUyelikUcret;
        private DevExpress.XtraEditors.LabelControl lblUyelikSuresi;
        private DevExpress.XtraEditors.LabelControl lblUyelikAdi;
    }
}