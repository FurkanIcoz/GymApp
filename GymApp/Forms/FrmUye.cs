using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using GymApp.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Columns;

namespace GymApp
{
    public partial class FrmUye : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int UyeId;

        public FrmUye(int uyeId)
        {
            InitializeComponent();
            this.UyeId = uyeId;
            
        }
        GymDBEntities dbUye = new GymDBEntities();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UyeId.ToString());
        }

        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");


        private void btnGuncelleUye_Click(object sender, EventArgs e)
        {
            var uyeBilgileri = dbUye.TBLUYELER.Find(UyeId);
            if (string.IsNullOrWhiteSpace(txtUyeBilgiTel.Text) ||
                string.IsNullOrWhiteSpace(txtUyeBilgiMail.Text) || string.IsNullOrWhiteSpace(txtUyeBilgiAdres.Text))
            {
                XtraMessageBox.Show("Bos Alan Birakmayin", "HATA", MessageBoxButtons.OK);
            }
            else if (!rEMail.IsMatch(txtUyeBilgiMail.Text))

            {
                XtraMessageBox.Show("Gecerli Bir Mail Adresi Giriniz", "HATA", MessageBoxButtons.OK);

            }
            else if (txtUyeBilgiTel.Text.Length != 11)
            {
                XtraMessageBox.Show("Gecerli Bir Telefon Numarasi Giriniz", "HATA", MessageBoxButtons.OK);

            }
            //var uye = dbUye.TBLUYELER.SingleOrDefault(x => x.uye_id== UyeId);
            else
            {
                uyeBilgileri.uye_telefon = txtUyeBilgiTel.Text;
                uyeBilgileri.uye_email = txtUyeBilgiMail.Text;
                uyeBilgileri.uye_adres = txtUyeBilgiAdres.Text;

                dbUye.SaveChanges();

                XtraMessageBox.Show("Uye Basariyla Guncellendi", "OK", MessageBoxButtons.OK);

            }

        }

        private void btnDonUyeler_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        void GDAListele()
        {
            var degerler = (from x in dbUye.TBLGRUPDERSLER
                            join y in dbUye.TBLANTRENORLER
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
            grdContUyeAktifGrupDersListesi.DataSource = degerler;

        }
        //void GDPListele()
        //{
        //    var degerler = (from x in dbUye.TBLUYEGRUPDERSLERI
        //                    join y in dbUye.TBLUYELER
        //                    on x.id equals y.antrenor_id
        //                    select new
        //                    {
        //                        x.grupders_id,
        //                        AD = x.grupders_ad,
        //                        TARIH = x.grupders_tarih,
        //                        SAAT = x.grupders_saat,
        //                        KAPASITE = x.grupders_kapasite,
        //                        MEVCUT = x.grupders_mevcut,
        //                        x.grupders_aktif,
        //                        ANTRENOR = y.antrenor_ad,
        //                        ANTRENORS = y.antrenor_soyad
        //                    }).Where(x => x.KAPASITE != x.MEVCUT && x.grupders_aktif == "1").ToList();
        //    grdContUyeEskiGrupDersListesi.DataSource = degerler;

        //}

        //void ODListele()
        //{
        //    var degerler = (from x in dbUye.TBLOZELDERSLER
        //                    join y in dbUye.TBLANTRENORLER on x.ozelders_antrenorID equals y.antrenor_id
        //                    join z in dbUye.TBLUYELER on x.ozelders_uyeID equals z.uye_id
        //                    select new
        //                    {
        //                        x.ozelders_id,
        //                        UyeAdSoyad = z.uye_ad + " " + z.uye_soyad,
        //                        Tarih = x.ozelders_tarih,
        //                        Saat = x.ozelders_saat,
        //                        x.ozelders_aktif,
        //                        PTAdSoyad = y.antrenor_ad + " " + y.antrenor_soyad,

        //                    }).Where(x => x.ozelders_aktif == "1").ToList();
        //    grCntOzelDersler.DataSource = degerler;
        //}
        private void FrmUye_Load(object sender, EventArgs e)
        {
            var bedenler = (from beden in dbUye.TBLBEDENBILGILERI
                            select new
                            {
                                beden.beden_id,
                                beden.beden_uyeID,
                                Bel = beden.bel,
                                Boy = beden.boy,
                                Kilo = beden.kilo,
                                Yag = beden.yagOrani,
                                Gogus = beden.gogus,
                                Kol = beden.kol,
                                Kalca = beden.kalca
                            }).Where(beden => beden.beden_uyeID == UyeId).ToList();
            cBoxUyeBedenBilgileri.Properties.Items.Add("Boy");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Kilo");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Yag");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Bel");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Kalca");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Gogus");
            cBoxUyeBedenBilgileri.Properties.Items.Add("Kol");



            var uyeBilgileri = dbUye.TBLUYELER.Find(UyeId);
            var uyeUyelikTipi = dbUye.TBLUYELIKTIPI.Find(uyeBilgileri.uye_uyelikTipi);

            txtUyeBilgiAd.Text = uyeBilgileri.uye_ad;
            txtUyeBilgiSoyad.Text = uyeBilgileri.uye_soyad;
            txtUyeBilgiAdres.Text = uyeBilgileri.uye_adres;
            txtUyeBilgiDTarihi.Text = uyeBilgileri.uye_dogumTarihi.ToString();
            txtUyeBilgiMail.Text = uyeBilgileri.uye_email;
            txtUyeBilgiTel.Text = uyeBilgileri.uye_telefon;
            txtUyeBilgiUyelikTipi.Text = uyeUyelikTipi.uyeliktipi_ad;
            txtUyeBilgiKTarihi.Text = uyeBilgileri.uye_kayitTarihi.ToString();
            txtUyeBilgiBTarihi.Text = uyeBilgileri.uye_bitisTarihi.ToString();

        }

        private void txtUyeBilgiTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        Forms.FrmBedenBilgisiEkle frmBedenBilgisiEkle;
        private void btnBedenBilgisiEkle_Click(object sender, EventArgs e)
        {
            frmBedenBilgisiEkle = new Forms.FrmBedenBilgisiEkle(UyeId);
            frmBedenBilgisiEkle.TopLevel = false;
            frmBedenBilgisiEkle.FormBorderStyle = FormBorderStyle.None;
            frmBedenBilgisiEkle.Dock = DockStyle.Fill;
            this.Controls.Add(frmBedenBilgisiEkle);
            frmBedenBilgisiEkle.BringToFront();
            frmBedenBilgisiEkle.Show();
            this.Text = "UYELER";
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void tabFormContentContainer1_Click(object sender, EventArgs e)
        {

        }


        private void cBoxUyeBedenBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {



            string secilenKolon = cBoxUyeBedenBilgileri.EditValue.ToString();

            var bedenler = (from beden in dbUye.TBLBEDENBILGILERI
                            where beden.beden_uyeID == UyeId
                            select new
                            {
                                Tarih = beden.beden_tarih,
                                Boy = secilenKolon == "Boy" ? beden.boy : 0, 
                                Kilo = secilenKolon == "Kilo" ? beden.kilo : 0,
                                Yag = secilenKolon == "Yag" ? beden.yagOrani : 0, 
                                Gogus = secilenKolon == "Gogus" ? beden.gogus : 0,
                                Kol = secilenKolon == "Kol" ? beden.kol : 0, 
                                Kalca = secilenKolon == "Kalca" ? beden.kalca : 0,
                                Bel = secilenKolon == "Bel" ? beden.bel : 0, 

                            }).ToList();

            grdContBedenBilgileri.DataSource = bedenler;

            foreach (GridColumn column in gridView1.Columns)
            {
                column.Visible = false;
            }
            gridView1.Columns[0].Visible = true;
            switch (secilenKolon)
            {
                case "Boy":
                    gridView1.Columns[1].Visible = true;
                    break;
                case "Kilo":
                    gridView1.Columns[2].Visible = true;
                    break;
                case "Yag":
                    gridView1.Columns[3].Visible = true;
                    break;
                case "Gogus":
                    gridView1.Columns[4].Visible = true;
                    break;
                case "Kol":
                    gridView1.Columns[5].Visible = true;
                    break;
                case "Kalca":
                    gridView1.Columns[6].Visible = true;
                    break;
                case "Bel":
                    gridView1.Columns[7].Visible = true;
                    break;
                default:
                    foreach (GridColumn column in gridView1.Columns)
                    {
                        column.Visible = true;
                    }
                    break;
            }


            chrtContBedenBilgileri.Series.Clear();
            List<DateTime> tarihler = new List<DateTime>();
            Series series = new Series(secilenKolon, ViewType.Line);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DateTime date = (DateTime)gridView1.GetRowCellValue(i, "Tarih");
                tarihler.Add(date);
                double value = Convert.ToDouble(gridView1.GetRowCellValue(i, secilenKolon));
                

                series.Points.Add(new SeriesPoint(date, value));
            }



            chrtContBedenBilgileri.Series.Add(series);

            tarihler.RemoveAll(tarih=> tarih!=null);




        }

        private void tabFormContentContainer3_Click(object sender, EventArgs e)
        {

        }
    }
}
