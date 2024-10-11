using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFigureArea.Models
{
    public class Rectangle : Figure
    {
        private string _side1;
        private string _side2;
        public Rectangle(string side1, string side2)
        {
            _side1 = side1;
            _side2 = side2;
        }
        public override double CalculateArea()
        {
            if (double.TryParse(_side1, out double side1) && double.TryParse(_side2, out double side2))
            {
                double area = Math.Round(side1 * side2, 2);
                if (side1 > 0 && side2 > 0)
                {
                    if (side1 == side2)
                    {
                        Console.WriteLine($"Площадь квадрата с указанными сторонами = {area}");
                        return area;
                    }
                    else
                    {
                        Console.WriteLine($"Площадь прямоугольника с указанными сторонами = {area}");
                        return area;
                    }
                }
                if (side1 < 0 || side2 < 0)
                {
                    throw new FormatException(message: "Сторона/ы не может/ут быть отрицательным/и, начните заново.");
                }
                if (side1 == 0 || side2 == 0)
                {
                    throw new ArgumentException(message: "Это прямая, начните заново.");
                }
            }
            else
            {
                throw new Exception(message: "Вы ввели неверный формат данных, начните заново.");
            }
            return 0;
        }
    }
}
