using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace project_machshevon
{
    public partial class Window1 : Window
    {
        private int points, real_answer = 0;
        private int Age;
        private bool isDarkMode = false;

        public Window1(string name, string age, bool darkMode)
        {
            InitializeComponent();
            isDarkMode = darkMode;
            
            
            if (isDarkMode)
            {
                SetDarkMode();
            }

            you.Text = $" Good luck {name}";

            if (int.TryParse(age, out int parsedAge))
            {
                Age = parsedAge;
            }
            else
            {
                MessageBox.Show("Invalid age format");
                this.Close();
            }

            GenerateQuestion();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "answer")
            {
                textBox.Text = string.Empty;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                
                if (userAnswer == real_answer)
                {

                    answerTextBox.Clear();
                    sound_right.Visibility = Visibility.Visible;
                    sound_right.Position = TimeSpan.Zero;
                    sound_right.Play();

                    MessageBox.Show("Correct!");
                    points++;
                }
                else
                {
                    answerTextBox.Clear();
                    sound_wrong.Visibility = Visibility.Visible;
                    sound_wrong.Position = TimeSpan.Zero;
                    sound_wrong.Play();
                    MessageBox.Show("Incorrect");
                }

                
                GenerateQuestion();
            }
            else
            {
                
                MessageBox.Show("Invalid answer format. Please enter a number.");
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
            
            grid1.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF39494C"));
            text1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            mathSign.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            text3.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            text2.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            you.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            remaining.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            darkModeToggle.Content = "Light mode";
            
        }

        private void SetLightMode()
        {
          
            grid1.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBECAB8"));
            text1.Foreground = System.Windows.Media.Brushes.Black;
            mathSign.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF000000"));
            text3.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF000000"));
            text2.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF000000"));
            you.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF000000"));
            remaining.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF000000"));
            darkModeToggle.Content = "Dark mode";
            
        }

        private int questionsRemaining = 10; 

        private void answerTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void GenerateQuestion()
        {
            if (questionsRemaining <= 0)
            {
                
                MessageBox.Show($"Exam completed! You scored {points} points.");
                this.Close();
                return;
            }

            Random random = new Random();
            int num1 = random.Next(1, 11); 
            int num2 = random.Next(1, 11); 

            
            if (Age >= 8) 
            {
                int operation;
                if (questionsRemaining >= 6) 
                {
                    operation = random.Next(3, 5); 
                }
                else
                {
                    operation = random.Next(1, 3); 
                }

                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "-";
                        real_answer = num1 - num2;
                        break;
                    case 3:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "*";
                        real_answer = num1 * num2;
                        break;
                    case 4:
                        text1.Text = (num1 * num2).ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "/";
                        real_answer = num1;
                        break;
                }
            }
            else if (Age >= 6) 
            {
                int operation;
                if (questionsRemaining <= 3) 
                {
                    operation = 2; 
                }
                else
                {
                    operation = random.Next(1, 3); 
                }

                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "-";
                        real_answer = num1 - num2;
                        break;
                    case 3:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "*";
                        real_answer = num1 * num2;
                        break;
                }
            }
            else 
            {
                int operation = random.Next(1, 2); 
                Console.WriteLine($"Selected operation: {operation}");

                switch (operation)
                {
                    case 1:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "+";
                        real_answer = num1 + num2;
                        break;
                    case 2:
                        text1.Text = num1.ToString();
                        text2.Text = num2.ToString();
                        mathSign.Text = "-";
                        real_answer = num1 - num2;
                        break;
                }
            }

            questionsRemaining--;
            remaining.Text = $"Qustions remaining: {questionsRemaining+1}";
        }
    }
}
