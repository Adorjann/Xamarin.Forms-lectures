using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SubscribeNumberAndBracketButtons();
            SubscibeOperandButtons();

        }

        private void SubscibeOperandButtons()
        {
            List<Button> allOperands = new List<Button>()
            {
                Division,Multiplication,Substraction,Addition,Dot
            };
            allOperands.ForEach(button => button.Clicked += OperandsAndDotClicked);
        }

        private void OperandsAndDotClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if ( !IsLastInputOperand() )
            {
                CheckLabelLenght();
                Display.Text += button.Text;

            }else if(button.Text == "-")
            {
                Display.Text += "(-";
            }
            
        }

        private bool IsLastInputOperand()
        {
            string lastInput;
            if (Display.Text.Length > 1)
            {
                lastInput = Display.Text.Substring(Display.Text.Length - 1, 1);
            }
            else
            {
                lastInput = Display.Text;
            }

            if(!isOperand(lastInput))
            {
                return false; 
            }
            return true;
        }
        private bool isOperand(string charToCheck)
        {
            if (charToCheck == Division.Text ||
                charToCheck == Multiplication.Text ||
                charToCheck == Substraction.Text ||
                charToCheck == Addition.Text ||
                charToCheck == Dot.Text)
            {
                return true;
            }
            return false;
        }
        private void CheckLabelLenght()
        {
            if (Display.Text.Length > 10)
            {
                Display.FontSize = 50;
            }
            else
            {
                Display.FontSize = 85;
            }
        }

        private void SubscribeNumberAndBracketButtons()
        {
            List<Button> allNumbers = new List<Button>()
            {
                Num0,Num1,Num2,Num3,Num4,Num5,Num6,Num7,Num8,Num9,OpenBracket,ClosedBracket
            };
            allNumbers.ForEach(button => button.Clicked += NumberClicked);
        }

        private void NumberClicked(object sender, EventArgs e)
        {
            CheckLabelLenght();
            Button button = (Button)sender;
            Display.Text = Display.Text == "0" ? button.Text : Display.Text += button.Text;
            
            if(button.Text == ")")
            {
                EmptyBracketChecker();
                OpenBracketPresentChecker();
            }else if(button.Text == "(")
            {
                OperandBeforeBracketChecker();
            }
            
        }

        private void OpenBracketPresentChecker()
        {
           
            if (Display.Text.Length > 1 && !Display.Text.Contains("("))
            {
               
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                
            }
        }

        private void OperandBeforeBracketChecker()
        {
             
            if (Display.Text.Length > 1)
            {
                string lastInput = Display.Text.Substring(Display.Text.Length - 2, 1);
                if (!isOperand(lastInput))
                {
                    Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                }
            }
        }

        private void EmptyBracketChecker()
        {
            string lastInput;
            if (Display.Text.Length > 1)
            {
                lastInput = Display.Text.Substring(Display.Text.Length - 2, 2);
                if(lastInput == "()")
                {
                    Display.Text = Display.Text.Substring(0, Display.Text.Length - 2);
                }
            }
            else
            {
                Display.Text = "0";

            }

        }

        private void C_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            CheckLabelLenght();
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
            }
            CheckLabelLenght();
        }



        private void Equals_Clicked(object sender, EventArgs e)
        {
            Display.Text = Evaluate(Display.Text).ToString();
        }
        private double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
    }

    
}
