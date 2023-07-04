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
using GymApp.Forms;
using GymApp.Entity;
using System.Data.Entity;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Controls;

namespace GymApp
{
    public partial class FrmAntronorler : DevExpress.XtraEditors.XtraForm
    {
        public FrmAntronorler()
        {
            InitializeComponent();
        }
        public virtual ComboBoxItemCollection Items { get; }

        FrmAntrenorEkle frmAntrenorEkle;
        GymDBEntities dbAntrenorSec = new GymDBEntities();
        FrmAntronor frmAntrenor;
        private void btnAntrenorEkle_Click(object sender, EventArgs e)
        {

            frmAntrenorEkle = new FrmAntrenorEkle();
            frmAntrenorEkle.TopLevel = false;
            frmAntrenorEkle.FormBorderStyle = FormBorderStyle.None;
            frmAntrenorEkle.Dock = DockStyle.Fill;
            this.Controls.Add(frmAntrenorEkle);
            frmAntrenorEkle.BringToFront();
            frmAntrenorEkle.Show();
            this.Text = "ANTRENORLER";
        }

        private void btnAntrenorSec_Click(object sender, EventArgs e)
        {
            if (cboxAntrenorSec.SelectedItem != null)
            {
                var antrenorlerAdSoyad = (from pt in dbAntrenorSec.TBLANTRENORLER
                                          select new
                                          {
                                              pt.antrenor_aktif,
                                              adSoyadPT = pt.antrenor_ad + " " + pt.antrenor_soyad
                                          }).Where(pt => pt.antrenor_aktif == "1").ToList();
                string[] adSoyadArrayAntr = antrenorlerAdSoyad.Select(x => x.adSoyadPT).ToArray();

                Regex nameRegex = new Regex(@"(?<firstName>.+)\s+(?<lastName>.+)");

                Match match = nameRegex.Match(cboxAntrenorSec.SelectedItem.ToString());
                if (!adSoyadArrayAntr.Contains(cboxAntrenorSec.Text))
                {
                    MessageBox.Show("Secilen Antrenor Aktif değil veya Yok");
                }
                else if (cboxAntrenorSec.SelectedItem is Persons selectUye)
                {


                    int selectedID = selectUye.Id;

                    frmAntrenor = new FrmAntronor(selectedID);
                    frmAntrenor.TopLevel = false;
                    frmAntrenor.FormBorderStyle = FormBorderStyle.None;
                    frmAntrenor.Dock = DockStyle.Fill;
                    this.Controls.Add(frmAntrenor);
                    frmAntrenor.BringToFront();
                    frmAntrenor.Show();
                }
                else
                {
                    MessageBox.Show("Isım Hatalı");
                }
            }
            else
            {
                MessageBox.Show("Antrenor Seciniz");
            }

        }

        private void FrmAntronorler_Load(object sender, EventArgs e)
        {

            var antrenorler = dbAntrenorSec.TBLANTRENORLER.ToList();
            foreach (var antrenor in antrenorler)
            {
                Persons antrenorCb = new Persons
                {
                    Isim = antrenor.antrenor_ad,
                    Soyisim = antrenor.antrenor_soyad,
                    Id = antrenor.antrenor_id
                };
                cboxAntrenorSec.Properties.Items.Add(antrenorCb);
            };
        }
    }
}