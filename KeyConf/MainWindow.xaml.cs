using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyConf
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtHist.Text = "";
            txtHist.Text += "Ver 1.0.1 ELECOM Bluetooth Keyboard という名前のデバイスが接続されている時だけキーの入れ換えを行うようにした。\n";
            txtHist.Text += "Ver 1.0.0 新規\n";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    }
}
