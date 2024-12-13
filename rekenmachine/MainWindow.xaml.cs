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

namespace rekenmachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double textBoxGetal1;
        double textBoxGetal2;
        char operatorSign;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            ReadNumbers(number1TextBox.Text, number2TextBox.Text);
            Button btn = (Button)sender;

            //Comment gedeelte is hoofdstuk 6 oef 2 van events
            //if (btn.Content.Equals("+"))
            //{
            //    getal1 += getal2;
            //}
            //else if (btn.Content.Equals("-"))
            //{
            //    getal1 -= getal2;
            //}
            //else if (btn.Content.Equals("/"))
            //{
            //    getal1 /= getal2;
            //}
            //else if (btn.Content.Equals("*"))
            //{
            //    getal1 *= getal2;   
            //}
            //double result = getal1;
           
            
            operatorSign = char.Parse(btn.Content.ToString());
            double result = Calculate(textBoxGetal1, textBoxGetal2, operatorSign);          
            resultTextBox.Text = result.ToString(); 
        

        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllButtons();
        }
     
        private void ReadNumbers(string input1, string input2)
        {
            if (!double.TryParse(input1, out textBoxGetal1) || !double.TryParse(input2, out textBoxGetal2))
            {
                MessageBox.Show("Only numbers allowed!", "Foutief", MessageBoxButton.OK);
                ClearAllButtons();
            }
        }
        private double Calculate(double getal1, double getal2, char tekenVanBewerking)
        {
            switch (tekenVanBewerking)
            {
                case '+'  :
                  return  getal1 += getal2;                
                case '-' :
                  return  getal1 -= getal2;                  
                case '/' :
                 return   getal1 /= getal2;
                case '*' :
                 return   getal1 *= getal2;
                default:
                    return 0;
                   
            }
        }
        private void ClearAllButtons()
        {
            number1TextBox.Clear();
            number2TextBox.Clear();
            resultTextBox.Clear();
            number1TextBox.Focus();
        }

        private void Afsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calculateMenuButton(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            

            switch (menuItem.Header)
            {
                case "Optellen":
                    addButton.IsEnabled = true;
                    minusButton.IsEnabled = false;
                    divideButton.IsEnabled = false;
                    multiplyButton.IsEnabled = false;
                    break;
                case "Aftrekken":
                    minusButton.IsEnabled = true;
                    divideButton.IsEnabled = false;
                    multiplyButton.IsEnabled = false;
                    addButton.IsEnabled = false;
                    break ;
                case "Vermenigvuldigen":
                    multiplyButton.IsEnabled = true;
                    divideButton.IsEnabled = false;
                    addButton.IsEnabled=false;
                    minusButton.IsEnabled = false;
                    break ;
                case "Deling":
                    divideButton.IsEnabled = true;
                    addButton.IsEnabled = false;
                    minusButton .IsEnabled = false;
                    multiplyButton .IsEnabled = false;
                    break ;
              
            }
        }
        private void ButtonDisabler()
        { 
        
        }
    }
}