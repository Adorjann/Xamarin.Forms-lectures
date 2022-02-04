namespace FirstMobileApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        private bool displayingResult = false;

        public MainPage()
        {
            this.InitializeComponent();

            this.SubscribeNumberAndBracketButtons();
            this.SubscibeOperandButtons();
        }

        private void SubscribeNumberAndBracketButtons()
        {
            List<Button> allNumbers = new List<Button>()
            {
                this.Num0, this.Num1, this.Num2, this.Num3, this.Num4,
                this.Num5, this.Num6, this.Num7, this.Num8, this.Num9,
                this.OpenBracket, this.ClosedBracket,
            };
            allNumbers.ForEach(button => button.Clicked += this.Number_Clicked);
        }

        private void Number_Clicked(object sender, EventArgs e)
        {
            this.CheckLabelLenght();
            Button button = (Button)sender;

            // typing numbers after result is displayed
            if (this.displayingResult)
            {
                this.Display.Text = button.Text;
                this.displayingResult = false;
            }
            else
            {
                this.Display.Text = this.Display.Text == "0" ? button.Text : this.Display.Text += button.Text;
            }

            if (button.Text == ")")
            {
                this.EmptyBracketChecker();
                this.OpenBracketPresentChecker();
            }
            else if (button.Text == "(")
            {
                this.OperandBeforeBracketChecker();
            }
        }

        private void SubscibeOperandButtons()
        {
            List<Button> allOperands = new List<Button>()
            {
                this.Division, this.Multiplication, this.Substraction, this.Addition, this.Dot,
            };
            allOperands.ForEach(button => button.Clicked += this.OperandsAndDotClicked);
        }

        private void OperandsAndDotClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!this.IsLastInputOperand())
            {
                this.displayingResult = false;
                this.CheckLabelLenght();
                this.Display.Text += button.Text;
            }
            else if (button.Text == "-")
            {
                this.Display.Text += "(-";
            }
        }

        private bool IsLastInputOperand()
        {
            string lastInput;

            if (this.Display.Text.Length > 1)
            {
                lastInput = this.Display.Text.Substring(this.Display.Text.Length - 1, 1);
            }
            else
            {
                lastInput = this.Display.Text;
            }

            if (!this.IsOperand(lastInput))
            {
                return false;
            }

            return true;
        }

        private bool IsOperand(string charToCheck)
        {
            return charToCheck == this.Division.Text ||
                   charToCheck == this.Multiplication.Text ||
                   charToCheck == this.Substraction.Text ||
                   charToCheck == this.Addition.Text ||
                   charToCheck == this.Dot.Text;
        }

        private void CheckLabelLenght()
        {
            if (this.Display.Text.Length > 10)
            {
                this.Display.FontSize = 50;
            }
            else
            {
                this.Display.FontSize = 85;
            }
        }

        private void OpenBracketPresentChecker()
        {
            if (this.Display.Text.Length > 1 && !this.Display.Text.Contains("("))
            {
                this.Display.Text = this.Display.Text.Substring(0, this.Display.Text.Length - 1);
            }
        }

        private void OperandBeforeBracketChecker()
        {
            if (this.Display.Text.Length > 1)
            {
                string lastInput = this.Display.Text.Substring(this.Display.Text.Length - 2, 1);

                if (!this.IsOperand(lastInput))
                {
                    this.Display.Text = this.Display.Text.Substring(0, this.Display.Text.Length - 1);
                }
            }
        }

        private void EmptyBracketChecker()
        {
            if (this.Display.Text.Length > 1)
            {
                string lastInput = this.Display.Text.Substring(this.Display.Text.Length - 2, 2);

                if (lastInput == "()")
                {
                    this.Display.Text = this.Display.Text.Substring(0, this.Display.Text.Length - 2);
                }
            }
            else
            {
                this.Display.Text = "0";
            }
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            this.Display.Text = "0";
            this.CheckLabelLenght();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Display.Text = this.Display.Text.Length > 1 ?
                this.Display.Text.Substring(0, this.Display.Text.Length - 1) : "0";

            this.CheckLabelLenght();
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            if (this.Display.Text.Contains("(") && !this.Display.Text.Contains(")"))
            {
                return;
            }

            this.Display.Text = this.Evaluate(this.Display.Text).ToString();
            this.displayingResult = true;
        }

        private double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)loDataTable.Rows[0]["Eval"];
        }
    }
}
