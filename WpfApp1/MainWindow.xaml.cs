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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftop = "";
        string operation = "";
        string rightop = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (string)((Button)e.OriginalSource).Content;
            textBlock.Text = buttonText;

            double num;

            bool result = double.TryParse(buttonText, out num);

            if (result)
            {
                if (operation == "")
                    leftop += buttonText;
                else
                    rightop += buttonText;
            }
            else
            {
                if (buttonText == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                }
                else
                    if (buttonText == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = buttonText;
                }
            }
        }

        private void Update_RightOp()
        {
            double num1 = double.Parse(leftop);
            double num2 = double.Parse(rightop);

            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
    }
}