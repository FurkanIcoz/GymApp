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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace GymApp
{
    
    public partial class FrmUyeler : DevExpress.XtraEditors.XtraForm
    {
        public FrmUyeler()
        {
            InitializeComponent();
        }

        public virtual ComboBoxItemCollection Items { get; }

        FrmUyeKayit frmUyeKayit;
        GymDBEntities dbUyeler = new GymDBEntities();

        private void FrmUyeler_Load(object sender, EventArgs e)
        {

            var uyeler = dbUyeler.TBLUYELER.ToList();
            foreach (var uye in uyeler)
            {
                if (uye.uye_aktif == "1")
                {
                    Persons aktifUye = new Persons
                    {
                        Isim = uye.uye_ad,
                        Soyisim = uye.uye_soyad,
                        Id = uye.uye_id
                    };
                    cboxUyeSec.Properties.Items.Add(aktifUye);

                }
            };

        }
        private void btnUyeEkle_Click_1(object sender, EventArgs e)
        {
            frmUyeKayit = new FrmUyeKayit();
            frmUyeKayit.TopLevel = false;
            frmUyeKayit.FormBorderStyle = FormBorderStyle.None;
            frmUyeKayit.Dock = DockStyle.Fill;
            this.Controls.Add(frmUyeKayit);
            frmUyeKayit.BringToFront();
            frmUyeKayit.Show();
            this.Text = "UYELER";

        }
        FrmUye frmUye;
        private void btnUyeGetir_Click(object sender, EventArgs e)
        {
            if (cboxUyeSec.SelectedItem != null)
            {
                var uyelerlerAdSoyad = (from uye in dbUyeler.TBLUYELER
                                        select new
                                        {
                                            uye.uye_id,
                                            uye.uye_aktif,
                                            adSoyaduye = uye.uye_ad + " " + uye.uye_soyad
                                        }).Where(uye => uye.uye_aktif == "1").ToList();
                string[] adSoyadArrayUye = uyelerlerAdSoyad.Select(x => x.adSoyaduye).ToArray();

                Regex nameRegex = new Regex(@"(?<firstName>.+)\s+(?<lastName>.+)");
                Match match = nameRegex.Match(cboxUyeSec.SelectedItem.ToString());
                if (!adSoyadArrayUye.Contains(cboxUyeSec.Text))
                {
                    MessageBox.Show("Secilen Uye Aktif değil veya Yok");
                }
                //else if (match.Success)
                //{
                

                else if (cboxUyeSec.SelectedItem is Persons selectUye)
                {
                    int selectedID = selectUye.Id;
                    //MessageBox.Show(selectedID.ToString());
                //}

                    //var firstName = match.Groups["firstName"].Value;
                    //var lastName = match.Groups["lastName"].Value;
                    //var uyeId = dbUyeler.TBLUYELER
                    //.Where(m => m.uye_ad == firstName && m.uye_soyad == lastName)
                    //.Select(m => m.uye_id)
                    //.FirstOrDefault();
                    //MessageBox.Show(firstName);
                    //MessageBox.Show(uyeId.ToString());
                    
                    

                    frmUye = new FrmUye(selectedID);
                    frmUye.TopLevel = false;
                    frmUye.FormBorderStyle = FormBorderStyle.None;
                    frmUye.Dock = DockStyle.Fill;
                    this.Controls.Add(frmUye);
                    frmUye.BringToFront();
                    frmUye.Show();
                }
                else
                {
                    MessageBox.Show("Isim Hatali");
                }
            }
            else
            {
                MessageBox.Show("Uye Seciniz");
            }
            //this.Text = "UYELER";


        }

    }
}