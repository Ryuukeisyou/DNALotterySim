using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DNALotterySim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppModel AppModel { get; set; }

        public MainWindow()
        {
            AppModel = new AppModel();

            InitializeComponent();
            this.Closing += new CancelEventHandler(ClosingHandler);
            this.DataContext = AppModel;

            #region CJWJ
            DG_CJWJ.ItemsSource = AppModel.Prizes_CJWJ;
            DG_CJWJ_Temp.ItemsSource = AppModel.CJWJ_Prizes_Temp;
            #endregion

            #region XYBZ2
            DG_XYBZ2.ItemsSource = AppModel.Prizes_XYBZ2;
            DG_XYBZ2_Temp.ItemsSource = AppModel.XYBZ2_Prizes_Temp;
            #endregion
        }

        private void ClosingHandler(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }


        #region CJWJ
        private void BT_CJWJ_Roll1_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Prize prize_new = AppModel.Roll(AppModel.Prizes_CJWJ, random);
            AppModel.CJWJ_Prizes_Temp.Add(prize_new);
            AppModel.CJWJ_Prizes_Temp = AppModel.CJWJ_Prizes_Temp;
        }

        private void BT_CJWJ_Roll10_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for(int i = 0; i < 10; i++)
            {
                Prize prize_new = AppModel.Roll(AppModel.Prizes_CJWJ, random);
                AppModel.CJWJ_Prizes_Temp.Add(prize_new);
                AppModel.CJWJ_Prizes_Temp = AppModel.CJWJ_Prizes_Temp;
            }

        }

        private void BT_CJWJ_Roll100_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Prize prize_new = AppModel.Roll(AppModel.Prizes_CJWJ, random);
                AppModel.CJWJ_Prizes_Temp.Add(prize_new);
                AppModel.CJWJ_Prizes_Temp = AppModel.CJWJ_Prizes_Temp;
            }
        }

        private void BT_CJWJ_Clear_Click(object sender, RoutedEventArgs e)
        {
            AppModel.CJWJ_Prizes_Temp.Clear();
        }
        #endregion

        #region XYBZ2
        private void BT_XYBZ2_Roll1_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Prize prize_new = AppModel.Roll(AppModel.Prizes_XYBZ2, random);
            AppModel.XYBZ2_Prizes_Temp.Add(prize_new);
            AppModel.XYBZ2_Prizes_Temp = AppModel.XYBZ2_Prizes_Temp;
        }

        private void BT_XYBZ2_Roll10_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Prize prize_new = AppModel.Roll(AppModel.Prizes_XYBZ2, random);
                AppModel.XYBZ2_Prizes_Temp.Add(prize_new);
                AppModel.XYBZ2_Prizes_Temp = AppModel.XYBZ2_Prizes_Temp;
            }

        }

        private void BT_XYBZ2_Roll100_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Prize prize_new = AppModel.Roll(AppModel.Prizes_XYBZ2, random);
                AppModel.XYBZ2_Prizes_Temp.Add(prize_new);
                AppModel.XYBZ2_Prizes_Temp = AppModel.XYBZ2_Prizes_Temp;
            }
        }

        private void BT_XYBZ2_Clear_Click(object sender, RoutedEventArgs e)
        {
            AppModel.XYBZ2_Prizes_Temp.Clear();
        }
        #endregion

    }
}
