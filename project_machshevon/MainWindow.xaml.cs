using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace project_machshevon
{
    public partial class MainWindow : Window
    {
        private bool isDarkMode = false; 
        private string age = "";
        private string name = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtAge_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "age")
            {
                textBox.Text = string.Empty;
            }
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "name")
            {
                textBox.Text = string.Empty;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            name = name_box.Text;
            age = age_box.Text.Trim();
            Window1 window1 = new Window1(name, age, isDarkMode);
            ui_click.Visibility = Visibility.Visible;
            ui_click.Play();
            window1.Show();
            this.Close();
        }

        private void age_box_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                submitButton_Click(sender, e);
            }
        }

        private void darkModeToggle_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;

            if (toggleButton.IsChecked == true)
            {
               
                SetDarkMode();
                ui_click.Visibility = Visibility.Visible;
                ui_click.Position = TimeSpan.Zero;
                ui_click.Play();

            }
            else
            {
               
                SetLightMode();
                ui_click.Visibility = Visibility.Visible;
                ui_click.Position = TimeSpan.Zero;
                ui_click.Play();
            }
        }


        private void SetDarkMode()
        {
            
            grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF39494C"));
            text3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF39494C"));

            text1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBECAB8"));
            text3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBECAB8"));
            text5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBECAB8"));

            
            isDarkMode = true; 
            darkModeToggle.Content = "Light mode";
        }

        private void SetLightMode()
        {
           
            grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBECAB8"));
            text3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBECAB8"));

           
            text1.Foreground = Brushes.Black;
            text3.Foreground = Brushes.Black;
            text5.Foreground = Brushes.Black;

            
            isDarkMode = false; 
            darkModeToggle.Content = "Dark mode";
        }
    }
}
