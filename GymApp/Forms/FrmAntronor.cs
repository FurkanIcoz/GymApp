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
namespace GymApp
{
    public partial class FrmAntronor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int AntrenorId;
        GymDBEntities dbAntrenor = new GymDBEntities();

        public FrmAntronor(int AntrenorId)
        {
            InitializeComponent();
            this.AntrenorId = AntrenorId;
        }

        private void FrmAntronor_Load(object sender, EventArgs e)
        {

            var AntrenorBilgileri = dbAntrenor.TBLANTRENORLER.Find(AntrenorId);

            txtAntrenorBilgiAd.Text = AntrenorBilgileri.antrenor_ad;
            txtAntrenorBilgiSoyad.Text = AntrenorBilgileri.antrenor_soyad;
            txtAntrenorBilgiAdres.Text = AntrenorBilgileri.antrenor_adres;
            txtAntrenorBilgiDTarihi.Text = AntrenorBilgileri.antrenor_dogumTarihi.ToString();
            txtAntrenorBilgiMail.Text = AntrenorBilgileri.antrenor_email;
            txtAntrenorBilgiTel.Text = AntrenorBilgileri.antrenor_telefon;
            txtAntrenorBilgiBTarihi.Text = AntrenorBilgileri.antrenor_baslangicTarihi.ToString();

        }

        private void btnDonAntrenorler_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

        private void btnGuncelleAntrenor_Click(object sender, EventArgs e)
        {

            var antrenorBilgileri = dbAntrenor.TBLANTRENORLER.Find(AntrenorId);
            if (string.IsNullOrWhiteSpace(txtAntrenorBilgiTel.Text) ||
                string.IsNullOrWhiteSpace(txtAntrenorBilgiMail.Text) || string.IsNullOrWhiteSpace(txtAntrenorBilgiAdres.Text))
            {
                XtraMessageBox.Show("Bos Alan Birakmayin", "HATA", MessageBoxButtons.OK);
            }
            else if (!rEMail.IsMatch(txtAntrenorBilgiMail.Text))

            {
                XtraMessageBox.Show("Gecerli Bir Mail Adresi Giriniz", "HATA", MessageBoxButtons.OK);

            }
            else if (txtAntrenorBilgiTel.Text.Length != 11)
            {
                XtraMessageBox.Show("Gecerli Bir Telefon Numarasi Giriniz", "HATA", MessageBoxButtons.OK);

            }
            //var uye = dbUye.TBLUYELER.SingleOrDefault(x => x.uye_id== UyeId);
            else
            {
                antrenorBilgileri.antrenor_telefon = txtAntrenorBilgiTel.Text;
                antrenorBilgileri.antrenor_email= txtAntrenorBilgiMail.Text;
                antrenorBilgileri.antrenor_adres= txtAntrenorBilgiAdres.Text;

                dbAntrenor.SaveChanges();

                XtraMessageBox.Show("Uye Basariyla Guncellendi", "OK", MessageBoxButtons.OK);

            }
        }
        private void txtAntrenorBilgiTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}