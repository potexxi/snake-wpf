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

namespace Snake.Pages
{
    /// <summary>
    /// Interaktionslogik für PageSettings.xaml
    /// </summary>
    public partial class PageSettings : Page
    {
        public PageSettings()
        {
            InitializeComponent();
            SliderSpeed.Value = -500;
        }

        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(LabelSpeed != null)
                LabelSpeed.Content = Convert.ToInt32(SliderSpeed.Value * -1);
        }

        private void SliderFieldWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(LabelWidth != null)
                LabelWidth.Content = Convert.ToInt32(SliderFieldWidth.Value);
        }

        private void SliderFieldHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(LabelHeight != null)
                LabelHeight.Content = Convert.ToInt32(SliderFieldHeight.Value);
        }

        private void ButtonApply_Click(object sender, RoutedEventArgs e)
        {
            SnakeLogger.logger.Information($"Applied settings: {SliderSpeed.Value};{SliderFieldWidth.Value};{SliderFieldHeight.Value}");
            int difficulty = 1;
            if(RadioButtonMedium.IsChecked == true)
            {
                difficulty = 2;
            }
            else if (RadioButtonExtreme.IsChecked == true)
            {
                difficulty = 3;
            }
            GameSettings.Apply(Convert.ToInt32(SliderSpeed.Value), Convert.ToInt32(SliderFieldWidth.Value), Convert.ToInt32(SliderFieldHeight.Value), difficulty);
            MainWindow.frame.Navigate(MainWindow.pages["menu"]);
        }

        public void Set()
        {
            SliderSpeed.Value = GameSettings.Speed * -1;
            SliderFieldHeight.Value = GameSettings.FieldHeight;
            SliderFieldWidth.Value = GameSettings.FieldWith;
            if (GameSettings.Difficulty == 1)
            {
                RadioButtonEasy.IsChecked = true;
            }
            else if (GameSettings.Difficulty == 2)
            {
                RadioButtonMedium.IsChecked = true;
            }
            else if (GameSettings.Difficulty == 3)
            {
                RadioButtonExtreme.IsChecked = true;
            }
        }
    }
}
