using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color highlightcolor = Color.FromArgb(255, 255, 0, 0);
        private Color normalcolor = Color.FromArgb(255, 255, 255, 255);

        public MainWindow()
        {
            InitializeComponent();
            hellotext.MouseEnter += TextBlock_MouseEnter;
            hellotext.MouseLeave += TextBlock_MouseLeave;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            hellotext.Background = new SolidColorBrush(normalcolor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hellotext.Text = "world";
            //MessageBox.Show("You clicked me!");
            highlightcolor = Color.FromArgb(255,0,255,0);
            normalcolor = Color.FromArgb(255, 0, 255, 255);
            hellotext.Background = new SolidColorBrush(normalcolor);
            button1.Click += fun;
            button1.Click -= Button_Click;
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            hellotext.Background = new SolidColorBrush(highlightcolor);
        }

        private void fun(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("You clicked fun!");
            highlightcolor = Color.FromArgb(255, 0, 0, 255);
            button1.Click -= fun;
            button1.Click += Button_Click;

        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock)
            {
                TextBlock tb = sender as TextBlock;
                hellotext.Foreground = tb.Foreground;
            }
        }
    }
}
