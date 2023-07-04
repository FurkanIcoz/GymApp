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
using System.Data.Entity.Validation;
using DevExpress.Utils.OAuth.Provider;

namespace GymApp
{
    public partial class FrmUyeKayit : DevExpress.XtraEditors.XtraForm
    {

        public FrmUyeKayit()
        {
            InitializeComponent();

        }
        GymDBEntities dbUyeKaydı = new GymDBEntities();

        private void FrmUyeKayit_Load(object sender, EventArgs e)
        {
            cBoxUyelikTipiUyeKaydi.Properties.Items.AddRange(dbUyeKaydı.TBLUYELIKTIPI
            .Select(x => x.uyeliktipi_ad)
            .ToArray());


        }
        private void btnDonUyeler_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtTelUyeKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        private string firstName;
        private string lastName;

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string uyeAd = txtAdUyeKaydi.Text;
            string uyeSoyAd = txtSoyAdUyeKaydi.Text;
            string uyeTel = txtTelUyeKaydi.Text;
            string uyeAdres = txtAdresUyeKaydi.Text;
            string uyeMail = txtMailUyeKaydi.Text;
            string uyeDTarih = txtDTarihiUyeKaydi.Text;
            string uyeFoto = txtFotoUyeKaydi.Text;

            int id = 0;

            if (cBoxUyelikTipiUyeKaydi.SelectedItem != null)
            {
                id = dbUyeKaydı.TBLUYELIKTIPI
                   .Where(x => x.uyeliktipi_ad == cBoxUyelikTipiUyeKaydi.SelectedItem.ToString())
                   .Select(x => x.uyeliktipi_id)
                   .FirstOrDefault();
            }

            string sure = dbUyeKaydı.TBLUYELIKTIPI
                   .Where(x => x.uyeliktipi_id == id)
                   .Select(x => x.uyeliktipi_sure)
                   .FirstOrDefault();

            
            

            // MessageBox.Show(id.ToString());
            //string[] tarih = txtDTarihiUyeKaydi.Text.ToString().Split();
            //var dTarih = DateTime.Parse(tarih[0]);

            //MessageBox.Show(tarih[0]);
            DateTime dateValue;
            try
            {
                if (string.IsNullOrWhiteSpace(uyeAd) || string.IsNullOrWhiteSpace(uyeSoyAd) || string.IsNullOrWhiteSpace(uyeTel) || string.IsNullOrWhiteSpace(uyeAdres) ||
                string.IsNullOrWhiteSpace(uyeMail) || string.IsNullOrWhiteSpace(uyeDTarih) || string.IsNullOrWhiteSpace(uyeFoto) || id == 0)
                {
                    XtraMessageBox.Show("Bos Alan Birakmayin", "HATA", MessageBoxButtons.OK);
                }
                else if (!rEMail.IsMatch(txtMailUyeKaydi.Text))

                {
                    XtraMessageBox.Show("Gecerli Bir Mail Adresi Giriniz", "HATA", MessageBoxButtons.OK);

                }
                else if (txtTelUyeKaydi.Text.Length != 11)
                {
                    XtraMessageBox.Show("Gecerli Bir Telefon Numarasi Giriniz", "HATA", MessageBoxButtons.OK);

                }
                else if (!DateTime.TryParse(txtDTarihiUyeKaydi.Text, out dateValue))
                {
                    MessageBox.Show("Geçersiz bir tarih değeri girdiniz.");
                }
                else
                {

                    string tamIsim = uyeAd + " " + uyeSoyAd;
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

                        DateTime bitisTarihi = DateTime.Today.AddMonths(int.Parse(sure));
                        var yeniUye = new TBLUYELER
                        {
                            uye_dogumTarihi = DateTime.Parse(uyeDTarih),
                            uye_ad = firstName,
                            uye_soyad = lastName,
                            uye_telefon = uyeTel,
                            uye_email = uyeMail,
                            uye_adres = uyeAdres,
                            uye_foto = uyeFoto,
                            uye_uyelikTipi = id,
                            uye_kayitTarihi = DateTime.Today,
                            uye_bitisTarihi = bitisTarihi,
                            uye_aktif = "1",
                            uye_salonda = "0",


                        };

                        yeniUye.uye_dogumTarihi = yeniUye.uye_dogumTarihi.Date;
                        yeniUye.uye_kayitTarihi = DateTime.Today.Date;
                        yeniUye.uye_bitisTarihi = bitisTarihi.Date;


                        dbUyeKaydı.TBLUYELER.Add(yeniUye);
                        dbUyeKaydı.SaveChanges();

                        XtraMessageBox.Show("Uye Eklendi", "OK", MessageBoxButtons.OK);
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

        private void txtAdUyeKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoyAdUyeKaydi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
