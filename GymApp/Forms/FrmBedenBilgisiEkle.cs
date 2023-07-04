using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymApp.Entity;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace GymApp.Forms
{
    public partial class FrmBedenBilgisiEkle : DevExpress.XtraEditors.XtraForm
    {
        private int UYEID;
        public FrmBedenBilgisiEkle(int UYEID)
        {
            this.UYEID = UYEID;
            InitializeComponent();
        }
        GymDBEntities dbBedenBilgisi = new GymDBEntities();

        void BDListele()
        {
            var degerler = (from x in dbBedenBilgisi.TBLBEDENBILGILERI
                            
                            select new
                            {
                                idBedenBilgisi = x.beden_id,
                                idBedenBilgisiUye =x.beden_uyeID,
                                Tarih = x.beden_tarih,
                                Boy = x.boy,
                                Kilo = x.kilo,
                                YagOrani = x.yagOrani,
                                Bel = x.bel,
                                Kalca = x.kalca,
                                Gogus = x.gogus,
                                Kol = x.kol

                            }).Where(x => x.idBedenBilgisiUye == UYEID).ToList();
            grdContBedenBilgiSil.DataSource = degerler;
        }

        private void FrmBedenBilgisiEkle_Load(object sender, EventArgs e)
        {
            BDListele();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnYeniBedenEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoyBilgisi.Text) || string.IsNullOrWhiteSpace(txtKiloBilgisi.Text) || string.IsNullOrWhiteSpace(txtYagOraniBilgisi.Text) ||
                string.IsNullOrWhiteSpace(txtBelBilgisi.Text) || string.IsNullOrWhiteSpace(txtKalcaBilgisi.Text) || string.IsNullOrWhiteSpace(txtGogusBilgisi.Text) ||
                string.IsNullOrWhiteSpace(txtKolBilgisi.Text))
            {
                if (decimal.TryParse(txtBoyBilgisi.Text, out decimal boy) && decimal.TryParse(txtKiloBilgisi.Text, out decimal kilo) && decimal.TryParse(txtYagOraniBilgisi.Text, out decimal yag) &&
               decimal.TryParse(txtBelBilgisi.Text, out decimal bel) && decimal.TryParse(txtKalcaBilgisi.Text, out decimal kalca) && decimal.TryParse(txtGogusBilgisi.Text, out decimal gogus) &&
               decimal.TryParse(txtKolBilgisi.Text, out decimal kol))
                {
                    var yeniBedenBilgisi = new TBLBEDENBILGILERI
                    {
                        beden_tarih = DateTime.Today,
                        boy = boy,
                        kilo=kilo,
                        yagOrani=yag,
                        bel=bel,
                        kalca=kalca,
                        gogus=gogus,
                        kol=kol
                    };
                    yeniBedenBilgisi.beden_tarih = DateTime.Today.Date;
                    dbBedenBilgisi.TBLBEDENBILGILERI.Add(yeniBedenBilgisi);
                    dbBedenBilgisi.SaveChanges();

                    XtraMessageBox.Show("Beden Bilgisi Eklendi", "OK", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Lutfen Yalnizca Sayisal Degerler Girin");
                }
            }
           
        }

        private void btnBedenBilgiSil_Click(object sender, EventArgs e)
        {
            if (!(gridView1.SelectedRowsCount>0))//!grdContBedenBilgiSil.Focused
            {
                MessageBox.Show("Beden Olcumu Seciniz");
            }
            else
            {
                int bedenBilgisiId = int.Parse(gridView1.GetFocusedRowCellValue("idBedenBilgisi").ToString());

                MessageBox.Show(bedenBilgisiId.ToString());

                var satir = dbBedenBilgisi.TBLBEDENBILGILERI.FirstOrDefault(x => x.beden_id == bedenBilgisiId);
                dbBedenBilgisi.TBLBEDENBILGILERI.Remove(satir);
                dbBedenBilgisi.SaveChanges();

                BDListele();
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[1].Visible = false;

            }
        }
    }
}