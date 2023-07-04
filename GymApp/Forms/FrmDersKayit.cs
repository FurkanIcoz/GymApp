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
using System.Data.Entity;
using GymApp.Entity;
using System.Text.RegularExpressions;

namespace GymApp
{
    public partial class FrmDersKayit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmDersKayit()
        {
            InitializeComponent();
        }
        GymDBEntities dbDersKayit = new GymDBEntities();
        Regex nameRegex = new Regex(@"(?<firstName>.+)\s+(?<lastName>.+)");

        private void btnGrupDersEkle_Click(object sender, EventArgs e)
        {
            string gdAd = txtGrupDersEkleAd.Text;
            string gdTarih = txtGrupDersEkleTarih.Text;
            string gdSaat = txtGrupDersEkleSaat.Text;
            string gdKapasite = txtGrupDersEkleKapasite.Text;

            int rowIndex = grCntGrupDersleri.FocusedView.RowCount;
            var rowinfo = grCntGrupDersleri.FocusedView.GetRow(rowIndex);

            var antrenorlerAdSoyad = (from pt in dbDersKayit.TBLANTRENORLER
                                 select new
                                 {
                                     pt.antrenor_aktif,
                                     adSoyadPT = pt.antrenor_ad + " " + pt.antrenor_soyad
                                 }).Where(pt => pt.antrenor_aktif == "1").ToList();
            string[] adSoyadArray = antrenorlerAdSoyad.Select(x => x.adSoyadPT).ToArray();
            
            DateTime dateValue;
            try
            {
                if (string.IsNullOrWhiteSpace(gdAd) || string.IsNullOrWhiteSpace(gdTarih) || string.IsNullOrWhiteSpace(gdSaat) || string.IsNullOrWhiteSpace(txtGrupDersEkleKapasite.Text))
                {
                    XtraMessageBox.Show("Bos Alan Birakmayin", "HATA", MessageBoxButtons.OK);
                }
                else if (cboxAntrenorSecGD == null)
                {
                    MessageBox.Show("Antrenor Seciniz");
                }
                else if (gdKapasite.Length>=3)
                {
                    MessageBox.Show("Kapasite Alanina Fazla Deger Girildi");
                }
                else if (!adSoyadArray.Contains(cboxAntrenorSecGD.Text))
                {
                    MessageBox.Show("Secilen Antrenor Aktif değil veya Yok");
                }
                else if (!DateTime.TryParse(txtGrupDersEkleTarih.Text, out dateValue))
                {
                    MessageBox.Show("Geçersiz bir tarih değeri girdiniz.");
                }
                else
                {
                    MessageBox.Show(cboxAntrenorSecGD.SelectedItem.ToString());

                    if (cboxAntrenorSecGD.SelectedItem is Persons selectedPt)
                    {
                        MessageBox.Show("Test");

                        int selectedPtID = selectedPt.Id;

                        var grupDersSaat = dbDersKayit.TBLGRUPDERSLER
                      .Where(gl => gl.grupders_tarih == DateTime.Parse(txtGrupDersEkleTarih.Text).Date &&
                                  gl.grupders_saat <= TimeSpan.Parse(txtGrupDersEkleSaat.Text) &&
                                  gl.grupders_antrenorID == selectedPtID)
                      .ToList();

                        var ozelDersSaat = dbDersKayit.TBLOZELDERSLER
                                                     .Where(ol => ol.ozelders_tarih == DateTime.Parse(txtGrupDersEkleTarih.Text).Date &&
                                                                 ol.ozelders_saat <= TimeSpan.Parse(txtGrupDersEkleSaat.Text) &&
                                                                 ol.ozelders_antrenorID == selectedPtID)
                                                     .ToList();


                        if (grupDersSaat.Any() || ozelDersSaat.Any())
                        {
                            MessageBox.Show("Test");

                            XtraMessageBox.Show("Antrenor Musait Degil", "HATA", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Test");

                            var yeniGrupDers = new TBLGRUPDERSLER
                            {
                                grupders_ad = gdAd,
                                grupders_kapasite = int.Parse(gdKapasite),
                                grupders_tarih = DateTime.Parse(gdTarih),
                                grupders_saat = TimeSpan.Parse(gdSaat),
                                grupders_aktif = "1",
                                grupders_antrenorID = selectedPtID
                            };
                            MessageBox.Show("Test");

                            yeniGrupDers.grupders_tarih = yeniGrupDers.grupders_tarih.Date;


                            MessageBox.Show("Test");

                            dbDersKayit.TBLGRUPDERSLER.Add(yeniGrupDers);
                            dbDersKayit.SaveChanges();
                            GDListele();

                            XtraMessageBox.Show("Grup Ders Eklendi", "OK", MessageBoxButtons.OK);


                        }
                        foreach (Control control in this.Controls)
                        {
                            if (control is TextEdit)
                            {
                                ((TextEdit)control).Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Hata Oluştu", "HATA", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
                throw;
            }
        }

        void GDListele()
        {
            var degerler = (from x in dbDersKayit.TBLGRUPDERSLER
                            join y in dbDersKayit.TBLANTRENORLER
on x.grupders_antrenorID equals y.antrenor_id
                            select new
                            {
                                x.grupders_id,
                                AD = x.grupders_ad,
                                TARIH = x.grupders_tarih,
                                SAAT = x.grupders_saat,
                                KAPASITE = x.grupders_kapasite,
                                MEVCUT = x.grupders_mevcut,
                                x.grupders_aktif,
                                ANTRENOR = y.antrenor_ad,
                                ANTRENORS = y.antrenor_soyad
                            }).Where(x => x.KAPASITE != x.MEVCUT && x.grupders_aktif == "1").ToList();
            grCntGrupDersleri.DataSource = degerler;

        }

        void ODListele()
        {
            var degerler = (from x in dbDersKayit.TBLOZELDERSLER
                            join y in dbDersKayit.TBLANTRENORLER on x.ozelders_antrenorID equals y.antrenor_id
                            join z in dbDersKayit.TBLUYELER on x.ozelders_uyeID equals z.uye_id
                            select new
                            {
                                x.ozelders_id,
                                UyeAdSoyad = z.uye_ad + " " + z.uye_soyad,
                                Tarih = x.ozelders_tarih,
                                Saat = x.ozelders_saat,
                                x.ozelders_aktif,
                                PTAdSoyad = y.antrenor_ad + " " + y.antrenor_soyad,

                            }).Where(x => x.ozelders_aktif == "1").ToList();
            grCntOzelDersler.DataSource = degerler;
        }

        private void FrmDersKayit_Load(object sender, EventArgs e)
        {
            GDListele();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[6].Visible = false;

            ODListele();
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[4].Visible = false;

            var uyeler = dbDersKayit.TBLUYELER.ToList();
            var antrenorler = dbDersKayit.TBLANTRENORLER.ToList();

            foreach (var uye in uyeler)
            {
                if (uye.uye_aktif == "1")
                {
                    cBoxUyeSecGrupDers.Properties.Items.Add(uye.uye_ad + " " + uye.uye_soyad);
                    cBoxUyeSecOzelDers.Properties.Items.Add(uye.uye_ad + " " + uye.uye_soyad);


                }
            }
            foreach (var antrenor in antrenorler)
            {
                if (antrenor.antrenor_aktif == "1")
                {
                    cboxAntrenorSecGD.Properties.Items.Add(antrenor.antrenor_ad + " " + antrenor.antrenor_soyad);
                    cBoxAntrenorSecOzelDers.Properties.Items.Add(antrenor.antrenor_ad + " " + antrenor.antrenor_soyad);

                }
            }




        }

        private void btnGrupDersSil_Click(object sender, EventArgs e)
        {
            if (!grCntGrupDersleri.Focused)
            {
                MessageBox.Show("Ders Seciniz");
            }
            else
            {
                int uyeGrupDersleriIdD = int.Parse(gridView1.GetFocusedRowCellValue("grupders_id").ToString());

                //var uyeGrupDersleri = dbDersKayit.TBLUYEGRUPDERSLERI.Find(grupDersID);
                var satir = dbDersKayit.TBLUYEGRUPDERSLERI.FirstOrDefault(x => x.uyegrupdersler_grupdersID == uyeGrupDersleriIdD);
                dbDersKayit.TBLUYEGRUPDERSLERI.Remove(satir);
                dbDersKayit.SaveChanges();

                var satir2 = dbDersKayit.TBLGRUPDERSLER.FirstOrDefault(x => x.grupders_id == uyeGrupDersleriIdD);
                dbDersKayit.TBLGRUPDERSLER.Remove(satir2);
                dbDersKayit.SaveChanges();

            }
        }

        private void btnGrupDersUyeEkle_Click(object sender, EventArgs e)
        {

            var uyelerAdSoyad = (from pt in dbDersKayit.TBLUYELER
                                      select new
                                      {
                                          pt.uye_aktif,
                                          adSoyadPT = pt.uye_ad + " " + pt.uye_soyad
                                      }).Where(pt => pt.uye_aktif == "1").ToList();
            string[] adSoyadArray = uyelerAdSoyad.Select(x => x.adSoyadPT).ToArray();


            if (cBoxUyeSecGrupDers.SelectedItem == null)
            {

                MessageBox.Show("Uye Seciniz");

            }
            else if (!adSoyadArray.Contains(cBoxUyeSecGrupDers.Text))
            {
                MessageBox.Show("Secilen Uye Aktif veya Kayitli Degil");
            }
            else if (!grCntGrupDersleri.Focused)
            {
                MessageBox.Show("Ders Seciniz");
            }

            else
            {

                if (cBoxUyeSecGrupDers.SelectedItem is Persons selectUye)
                {

                    int selectedUyeID = selectUye.Id;
                    int grupDersID = int.Parse(gridView1.GetFocusedRowCellValue("grupders_id").ToString());
                    var yeniUyeGrupDers = new TBLUYEGRUPDERSLERI
                    {
                        uyegrupdersler_uyeID = selectedUyeID,
                        uyegrupdersler_grupdersID = grupDersID,
                    };

                    var gdMevcut = dbDersKayit.TBLGRUPDERSLER.Find(grupDersID);
                    gdMevcut.grupders_mevcut += 1;
                    dbDersKayit.TBLUYEGRUPDERSLERI.Add(yeniUyeGrupDers);
                    dbDersKayit.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Isim Hatali");
                }
            }
        }

        private void btnOzelDersEkle_Click(object sender, EventArgs e)
        {

            var uyelerlerAdSoyad = (from uyekyt in dbDersKayit.TBLUYELER
                                      select new
                                      {
                                          uyekyt.uye_aktif,
                                          adSoyaduye = uyekyt.uye_ad + " " + uyekyt.uye_soyad
                                      }).Where(uyekyt => uyekyt.uye_aktif == "1").ToList();
            string[] adSoyadArrayUye = uyelerlerAdSoyad.Select(x => x.adSoyaduye).ToArray();
            
            var antrenorlerAdSoyad = (from pt in dbDersKayit.TBLANTRENORLER
                                      select new
                                      {
                                          pt.antrenor_aktif,
                                          adSoyadPT = pt.antrenor_ad + " " + pt.antrenor_soyad
                                      }).Where(pt => pt.antrenor_aktif == "1").ToList();
            string[] adSoyadArrayAntr = antrenorlerAdSoyad.Select(x => x.adSoyadPT).ToArray();
           
            DateTime dateValue;
            if (cBoxUyeSecOzelDers.SelectedItem == null)
            {

                MessageBox.Show("Uye Seciniz");

            }
            else if (cBoxAntrenorSecOzelDers.SelectedItem == null)
            {
                MessageBox.Show("Antrenor Seciniz");
            }
            else if (!adSoyadArrayUye.Contains(cBoxUyeSecOzelDers.Text))
            {
                MessageBox.Show("Secilen Uye Aktif değil veya Yok");
            }
            else if (!adSoyadArrayAntr.Contains(cBoxAntrenorSecOzelDers.Text))
            {
                MessageBox.Show("Secilen Antrenor Aktif değil veya Yok");
            }
            else if (!DateTime.TryParse(txtTarihOzelDers.Text, out dateValue))
            {
                MessageBox.Show("Geçersiz bir tarih değeri girdiniz.");
            }
            else
            {
                if(cBoxAntrenorSecOzelDers.SelectedItem is Persons selectPt  && cBoxUyeSecOzelDers.SelectedItem is Persons selectUye)
                {
                    int selectedUyeID = selectUye.Id;
                    int selectedPtID = selectPt.Id;

                    MessageBox.Show(selectedPtID.ToString());

                    var yeniUyeOzelDers = new TBLOZELDERSLER
                    {
                        ozelders_antrenorID = selectedPtID,
                        ozelders_uyeID = selectedUyeID,
                        ozelders_tarih = DateTime.Parse(txtTarihOzelDers.Text).Date,
                        ozelders_saat = TimeSpan.Parse(txtSaatOzelDers.Text),
                        ozelders_aktif = "1"
                    };

                    dbDersKayit.TBLOZELDERSLER.Add(yeniUyeOzelDers);
                    dbDersKayit.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Isim Hatali");
                }

            }
        }

        private void btnOzelDersSil_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                MessageBox.Show("Ozel Ders Yok");
            }
            else if (!grCntOzelDersler.Focused)
            {
                MessageBox.Show("Silmek Istediginiz Dersi Secin");
            }
            else
            {
                int ozelDersId = int.Parse(gridView2.GetFocusedRowCellValue("ozelders_id").ToString());
                var satir = dbDersKayit.TBLOZELDERSLER.FirstOrDefault(x => x.ozelders_id == ozelDersId);

                if (satir != null)
                {
                    dbDersKayit.TBLOZELDERSLER.Remove(satir);

                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }


        }

        private void txtGrupDersEkleKapasite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabFormContentContainer2_Click(object sender, EventArgs e)
        {

        }

        private void tabFormContentContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}