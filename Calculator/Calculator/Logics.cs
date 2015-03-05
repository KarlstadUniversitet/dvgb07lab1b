using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Logics
    {
        List<double> number = new List<double>();
        List<char> op = new List<char>();
        double result;

        public Logics()
        {

        }

        public string calculate(string input)
        {
            if (!parse(input))
            {
                return "ERROR: incorrect input";
            }
            result = number.ElementAt(0);
            string return_string = ""+number.ElementAt(0);
            for (int i = 0; i < op.Count(); i++)
            {
                if (op.ElementAt(i) == '/') result = result / number.ElementAt(i+1);
                if (op.ElementAt(i) == '*') result = result * number.ElementAt(i+1);
                if (op.ElementAt(i) == '+') result = result + number.ElementAt(i+1);
                if (op.ElementAt(i) == '-') result = result - number.ElementAt(i+1);
                return_string = return_string + " " + op.ElementAt(i) + " " + number.ElementAt(i + 1);
            }
            return_string = return_string + " = " + result;
            return return_string;
        }

        private bool parse(string input)
        {
            string number = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '/' || input[i] == '*' || input[i] == '+' || input[i] == '-')
                {
                    if (!parseStringNum(number)) return false;
                    op.Add(input[i++]);
                    number = "";
                }
                number += input[i];
            }
            if (!parseStringNum(number)) return false;
            return true;
        }

        private bool parseStringNum(string string_number)
        {
            try
            {
                number.Add(double.Parse(string_number));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
