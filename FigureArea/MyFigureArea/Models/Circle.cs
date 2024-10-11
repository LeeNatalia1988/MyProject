using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFigureArea.Models
{
    public class Circle : Figure
    {
        private string _side;
        public Circle(string radius)
        {
            _side = radius;
        }
        public override double CalculateArea()
        {
            if (double.TryParse(_side, out double radius))
            {
                if (radius > 0)
                {
                    double area = Math.Round(Math.PI * Math.Pow(radius, 2), 2);
                    Console.WriteLine($"Площадь круга с указанным радиусом = {area}");
                    return area;
                }
                if (radius < 0)
                {
                    throw new FormatException(message: "Радиус не может быть отрицательным, начните заново.");
                }
                if (radius == 0)
                {
                    throw new ArgumentException(message: "Это точка, начните заново.");
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
