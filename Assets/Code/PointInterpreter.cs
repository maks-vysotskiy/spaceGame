using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal sealed class PointInterpreter
{
    public string Interpreter(int number)
    {
        if(number<0 || number>3999)
        {
            return "MMMM...";
        }
        if (number < 1) return string.Empty;
        if (number >= 1000) return "M" + Interpreter(number - 1000);
        if (number >= 900) return "CM" + Interpreter(number - 900);
        if (number >= 500) return "D" + Interpreter(number - 500);
        if (number >= 400) return "CD" + Interpreter(number - 400);
        if (number >= 100) return "C" + Interpreter(number - 100);
        if (number >= 90) return "XC" + Interpreter(number - 90);
        if (number >= 50) return "L" + Interpreter(number - 50);
        if (number >= 40) return "XL" + Interpreter(number - 40);
        if (number >= 10) return "X" + Interpreter(number - 10);
        if (number >= 9) return "IX" + Interpreter(number - 9);
        if (number >= 5) return "V" + Interpreter(number - 5);
        if (number >= 4) return "IV" + Interpreter(number - 4);
        if (number >= 1) return "I" + Interpreter(number - 1);
        else
        {
            return "???";
        }
    }
}

