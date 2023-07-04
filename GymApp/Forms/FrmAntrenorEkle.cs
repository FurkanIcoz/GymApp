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
using System.Text.RegularExpressions;

namespace GymApp.Forms
{
    public partial class FrmAntrenorEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmAntrenorEkle()
        {
            InitializeComponent();
        }
        GymDBEntities dbAntrenorKayıt = new GymDBEntities();

        private void FrmAntrenorEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnDonAntrenorler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtTelAntrenorKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        private string firstName;
        private string lastName;

        private void btnAntrenorKayit_Click(object sender, EventArgs e)
        {
            string antrenorAd = txtAdAntrenorKaydi.Text;
            string antrenorSoyAd = txtSoyAdAntrenorKaydi.Text;
            string antrenorTel = txtTelAntrenorKaydi.Text;
            string antrenorAdres = txtAdresAntrenorKaydi.Text;
            string antrenorMail = txtMailAntrenorKaydi.Text;
            string antrenorDTarih = txtDTarihiAntrenorKaydi.Text;
            string antrenorFoto = txtFotoAntrenorKaydi.Text;

            DateTime dateValue;
            try
            {
                if (string.IsNullOrWhiteSpace(antrenorAd) || string.IsNullOrWhiteSpace(antrenorSoyAd) || string.IsNullOrWhiteSpace(antrenorTel) || string.IsNullOrWhiteSpace(antrenorAdres) ||
                string.IsNullOrWhiteSpace(antrenorMail) || string.IsNullOrWhiteSpace(antrenorDTarih) || string.IsNullOrWhiteSpace(antrenorFoto))
                {
                    XtraMessageBox.Show("Bos Alan Birakmayin", "HATA", MessageBoxButtons.OK);
                }
                else if (!rEMail.IsMatch(txtMailAntrenorKaydi.Text))

                {
                    XtraMessageBox.Show("Gecerli Bir Mail Adresi Giriniz", "HATA", MessageBoxButtons.OK);

                }
                else if (txtTelAntrenorKaydi.Text.Length != 11)
                {
                    XtraMessageBox.Show("Gecerli Bir Telefon Numarasi Giriniz", "HATA", MessageBoxButtons.OK);

                }
                else if (!DateTime.TryParse(txtDTarihiAntrenorKaydi.Text, out dateValue))
                {
                    MessageBox.Show("Geçersiz bir tarih değeri girdiniz.");
                }
                else
                {

                    string tamIsim = antrenorAd + " " + antrenorSoyAd;
                    Regex tamIsimKont = new Regex(@"(?<firstName>.+)\s+(?<lastName>.+)");
                    if (tamIsim.Contains(" "))
                    {
                        var spaceCount = tamIsim.Count(c => c == ' ');

                        if (spaceCount > 1)
                        {
                            tamIsim = string.Join(" ", tamIsim.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        }
                    }
                    Match match = tamIsimKont.Match(tamIsim);
                    if (match.Success)
                    {
                        firstName = match.Groups["firstName"].Value;
                        lastName = match.Groups["lastName"].Value;


                        var yeniAntrenor = new TBLANTRENORLER
                        {
                            antrenor_ad = firstName,
                            antrenor_soyad = lastName,
                            antrenor_telefon = antrenorTel,
                            antrenor_email = antrenorMail,
                            antrenor_adres = antrenorAdres,
                            antrenor_dogumTarihi = DateTime.Parse(antrenorDTarih),
                            antrenor_baslangicTarihi = DateTime.Today,
                            antrenor_foto = antrenorFoto,
                            antrenor_aktif = "1"
                        };

                        yeniAntrenor.antrenor_dogumTarihi = yeniAntrenor.antrenor_dogumTarihi.Date;
                        yeniAntrenor.antrenor_baslangicTarihi = DateTime.Today.Date;

                        dbAntrenorKayıt.TBLANTRENORLER.Add(yeniAntrenor);
                        dbAntrenorKayıt.SaveChanges();

                        XtraMessageBox.Show("Antrenor Eklendi", "OK", MessageBoxButtons.OK);

                    }
                    else
                    {
                        XtraMessageBox.Show("Hata Oluştu", "HATA", MessageBoxButtons.OK);

                    }


                }
                foreach (Control control in this.Controls)
                {
                    if (control is TextEdit)
                    {
                        ((TextEdit)control).Text = string.Empty;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
                throw;
            }


        }

        private void txtAdAntrenorKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoyAdAntrenorKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}