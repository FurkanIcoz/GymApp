using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GymApp
{
    public partial class FrmForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmForm()
        {
            InitializeComponent();
        }
        FrmAnaSayfa frmAnaSayfa;
        private void barBtnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frmAnaSayfa== null || frmAnaSayfa.IsDisposed)
            {
                frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.MdiParent = this;
                frmAnaSayfa.Show();

            }
            frmAnaSayfa.BringToFront();

        }
        FrmUyeler frmUyeler;
        private void barBtnUyeler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmUyeler == null || frmUyeler.IsDisposed)
            {
                frmUyeler = new FrmUyeler();
                frmUyeler.MdiParent = this;
                frmUyeler.Show();
            }
            frmUyeler.BringToFront();


        }
        FrmAntronorler frmAntronorler;
        private void barBtnAntrenorler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAntronorler == null || frmAntronorler.IsDisposed)
            {
                frmAntronorler = new FrmAntronorler();
                frmAntronorler.MdiParent = this;
                frmAntronorler.Show();
            }
            frmAntronorler.BringToFront();

        }
        FrmDersKayit frmDersKayit;
        private void barBtnDersKayit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmDersKayit == null || frmDersKayit.IsDisposed)
            {
                frmDersKayit = new FrmDersKayit();
                frmDersKayit.MdiParent = this;
                frmDersKayit.Show();
            }
            frmDersKayit.BringToFront();

        }
        //FrmGirisCikis frmGirisCikis;
        //private void barBtnGirisCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (frmGirisCikis == null || frmGirisCikis.IsDisposed)
        //    {
        //        frmGirisCikis = new FrmGirisCikis();
        //        frmGirisCikis.MdiParent = this;
        //        frmGirisCikis.Show();
        //    }
        //    frmGirisCikis.BringToFront();

        //}

        private void barBtnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        
        private void FrmForm_Load(object sender, EventArgs e)
        {

        }
        Forms.FrmOdemeBilgileri frmOdemeBilgileri;
        private void barBtnOdemeBilgileri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmOdemeBilgileri == null || frmOdemeBilgileri.IsDisposed)
            {
                frmOdemeBilgileri = new Forms.FrmOdemeBilgileri();
                frmOdemeBilgileri.MdiParent = this;
                frmOdemeBilgileri.Show();
            }
            frmOdemeBilgileri.BringToFront();

        }

    }
}
