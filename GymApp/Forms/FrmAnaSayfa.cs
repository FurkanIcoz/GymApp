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
using System.Text.RegularExpressions;
using GymApp.Entity;

namespace GymApp
{
    public partial class FrmAnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        GymDBEntities dbAnasayfa = new GymDBEntities();

        static string ozel_ant_ad, ozel_ant_soyad, grup_ant_ad, grup_ant_soyad, uyelik_adi;


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            var enCokOzelDersVerenAntrenor = (from ozelDers in dbAnasayfa.TBLOZELDERSLER
                                              group ozelDers by ozelDers.ozelders_antrenorID into antrenor
                                              orderby antrenor.Count() descending
                                              select new
                                              {
                                                  AntrenorID = antrenor.Key,
                                                  ToplamOzelDersSayisi = antrenor.Count()
                                              }).FirstOrDefault();

            if (enCokOzelDersVerenAntrenor != null)
            {
                var ozel_antrenor = dbAnasayfa.TBLANTRENORLER.FirstOrDefault(a => a.antrenor_id == enCokOzelDersVerenAntrenor.AntrenorID);
                if (ozel_antrenor != null)
                {
                    ozel_ant_ad = ozel_antrenor.antrenor_ad;
                    ozel_ant_soyad = ozel_antrenor.antrenor_soyad;
                }
            }

            var enCokGrupDersVerenAntrenor = (from grupDers in dbAnasayfa.TBLGRUPDERSLER
                                              group grupDers by grupDers.grupders_antrenorID into antrenor
                                              orderby antrenor.Count() descending
                                              select new
                                              {
                                                  AntrenorID = antrenor.Key,
                                                  ToplamGrupDersSayisi = antrenor.Count()
                                              }).FirstOrDefault();


            if (enCokGrupDersVerenAntrenor != null)
            {
                var grup_antrenor = dbAnasayfa.TBLANTRENORLER.FirstOrDefault(a => a.antrenor_id == enCokGrupDersVerenAntrenor.AntrenorID);
                if (grup_antrenor != null)
                {
                    grup_ant_ad = grup_antrenor.antrenor_ad;
                    grup_ant_soyad = grup_antrenor.antrenor_soyad;
                }
            }

            var enCokTercihEdilenUyelikTipi = (from uye in dbAnasayfa.TBLUYELER
                                               join uyelikTipi in dbAnasayfa.TBLUYELIKTIPI
                                               on uye.uye_uyelikTipi equals uyelikTipi.uyeliktipi_id
                                               group uyelikTipi by uyelikTipi.uyeliktipi_id into uyelik_tipi
                                               orderby uyelik_tipi.Count() descending
                                               select new
                                               {
                                                   UyelikTipiID = uyelik_tipi.Key,
                                                   ToplamTercihSayisi = uyelik_tipi.Count()
                                               }).FirstOrDefault();

            if (enCokTercihEdilenUyelikTipi != null)
            {
                var encokUyelikTipi = dbAnasayfa.TBLUYELIKTIPI.FirstOrDefault(a => a.uyeliktipi_id== enCokTercihEdilenUyelikTipi.UyelikTipiID);
                if (encokUyelikTipi != null)
                {
                    uyelik_adi = encokUyelikTipi.uyeliktipi_ad;
                }
            }

            var toplamAntrenorSayisi = dbAnasayfa.TBLANTRENORLER.Count();

            var toplamUyeSayisi = dbAnasayfa.TBLUYELER.Count();

            var aktifUyeSayisi = dbAnasayfa.TBLUYELER.Count(uye => uye.uye_aktif == "1");


            lblAktifUyeSayisi.Text = aktifUyeSayisi.ToString();

            lblToplamAntrenorSayısı.Text = toplamAntrenorSayisi.ToString();

            lblToplamUyeSayısı.Text = toplamUyeSayisi.ToString();

            if (enCokGrupDersVerenAntrenor!=null)
            {
                lblGrupDersAntr.Text = grup_ant_ad + " " + grup_ant_soyad;
            }
            else
            {
                lblGrupDersAntr.Text = "Antrenor Bulunamadı";

            }


            if (enCokOzelDersVerenAntrenor != null)
            {
                lblOzelDersAntr.Text = ozel_ant_ad + " " + ozel_ant_soyad;
            }
            else
            {
                lblGrupDersAntr.Text = "Antrenor Bulunamadı";
            }



            if (enCokTercihEdilenUyelikTipi != null)
            {
                lblUyelikTipi.Text = uyelik_adi;
            }
            else
            {
                lblUyelikTipi.Text = "0";
            }
        }
    }
}