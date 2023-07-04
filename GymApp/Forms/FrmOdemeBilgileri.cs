using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GymApp.Entity;
using System.Data.Entity;

namespace GymApp.Forms
{
    public partial class FrmOdemeBilgileri : DevExpress.XtraEditors.XtraForm
    {
        public FrmOdemeBilgileri()
        {
            InitializeComponent();
        }
        GymDBEntities dbOdemeTipi = new GymDBEntities();

        void OTListele()
        {
            var degerler = (from x in dbOdemeTipi.TBLUYELIKTIPI
                            select new
                            {
                                x.uyeliktipi_id,
                                x.uyeliktipi_ad,
                                x.uyeliktipi_sure,
                                x.uyeliktipi_fiyat
                            }).ToList();
            grdCntrOdemeBilgileri.DataSource = degerler;

        }

        private void FrmOdemeBilgileri_Load(object sender, EventArgs e)
        {
            OTListele();
            gridView1.Columns[0].Visible = false;

        }
        static string id0 = "0";
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtOdemeUyelikAdi.Text = gridView1.GetFocusedRowCellValue("uyeliktipi_ad").ToString();
            txtOdemeUyelikSuresi.Text = gridView1.GetFocusedRowCellValue("uyeliktipi_sure").ToString();
            txtOdemeUcret.Text = gridView1.GetFocusedRowCellValue("uyeliktipi_fiyat").ToString();

            id0 = gridView1.GetFocusedRowCellValue("uyeliktipi_id").ToString();        
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(id0);
            var deger = dbOdemeTipi.TBLUYELIKTIPI.Find(id);
            deger.uyeliktipi_fiyat = int.Parse(txtOdemeUcret.Text);
            dbOdemeTipi.SaveChanges();
            OTListele();

        }
    }
}