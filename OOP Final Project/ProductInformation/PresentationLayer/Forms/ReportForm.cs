using BusinessLayer.UnitOfWork.Business;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class ReportForm : Form
    {


        public ReportForm()
        {
            InitializeComponent();


            BusinessProduct prodBus = new BusinessProduct();
            BusinessModel modelBus = new BusinessModel();


            pieChtProdByType.InnerRadius = 100;
            pieChtProdByType.LegendLocation = LiveCharts.LegendLocation.Right;
            SeriesCollection series = new SeriesCollection();
            foreach (var p in prodBus.ProductsStockByCategory())
            {
                series.Add(new PieSeries
                {
                    Title = p.ProductType,
                    Values = new ChartValues<int> { (int)p.Stock },
                    DataLabels = true
                });
            }
            pieChtProdByType.Series = series;




            pieChtBrandMyModel.InnerRadius = 100;
            pieChtBrandMyModel.LegendLocation = LiveCharts.LegendLocation.Right;
            SeriesCollection seri = new SeriesCollection();
            foreach (var m in modelBus.ModelByBrand())
            {
                seri.Add(new PieSeries
                {
                    Title = m.Model,
                    Values = new ChartValues<int> { (int)m.Brand },
                    DataLabels = true
                });
            }

            pieChtBrandMyModel.Series = seri;

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Programdan çıkmak istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnComeBack_Click(object sender, EventArgs e)
        {
            MainFromAdmin mfa = new MainFromAdmin();
            mfa.Show();
            this.Hide();
        }
    }
}
