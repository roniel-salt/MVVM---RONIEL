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
        int questionsRemaining = 10;

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

            var (newText1, newText2, newMathSign, newRemaining,real, questions) = GameLogic.GenerateQuestion(Age,questionsRemaining);

            text1.Text = newText1;
            text2.Text = newText2;
            mathSign.Text = newMathSign;
            remaining.Text = newRemaining;
            real_answer = int.Parse(real);
            questionsRemaining = int.Parse(questions)-1;
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

                var (newText1, newText2, newMathSign, newRemaining,real, questions) = GameLogic.GenerateQuestion(Age,questionsRemaining);
                if(questionsRemaining==0)
                {
                    MessageBox.Show($"Exam completed! You scored {points} points.");
                    this.Close();
                }

                text1.Text = newText1;
                text2.Text = newText2;
                mathSign.Text = newMathSign;
                remaining.Text = newRemaining;
                real_answer = int.Parse(real);
                questionsRemaining = int.Parse(questions)-1;
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

        private void answerTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
