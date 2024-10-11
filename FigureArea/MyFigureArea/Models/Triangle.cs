using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFigureArea.Models
{
    public class Triangle : Figure
    {
        private string _side1;
        private string _side2;
        private string _side3;

        public Triangle(string side1, string side2, string side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }
        public override double CalculateArea()
        {
            if (double.TryParse(_side1, out double side1) && double.TryParse(_side2, out double side2)
                            && double.TryParse(_side3, out double side3))
            {
                if (side1 >= 0 && side2 >= 0 && side3 >= 0)
                {
                    if (side1 < side2 + side3 && side2 < side1 + side3 && side3 < side1 + side2)
                    {
                        double halfPerimetr = (side1 + side2 + side3) / 2;
                        double area = Math.Round((Math.Sqrt(halfPerimetr * (halfPerimetr - side1) *
                            (halfPerimetr - side2) * (halfPerimetr - side3))), 2);
                        if (Math.Pow(side1, 2) == Math.Pow(side2, 2) + Math.Pow(side3, 2) ||
                            Math.Pow(side2, 2) == Math.Pow(side1, 2) + Math.Pow(side3, 2) ||
                            Math.Pow(side3, 2) == Math.Pow(side1, 2) + Math.Pow(side2, 2))
                        {
                            Console.WriteLine($"Площадь прямоугольного треугольника с указанными сторонами = {area}");
                            return area;
                        }
                        else
                        {
                            Console.WriteLine($"Площадь треугольника с указанными сторонами = {area}");
                            return area;
                        }
                    }
                    else
                    {
                        throw new ArgumentException(message: "Треугольника с такими сторонами не существует, начните заново.");
                    }
                }
                if (side1 < 0 || side2 < 0 || side3 < 0)
                {
                    throw new Exception(message: "Сторона/ы не может/ут быть отрицательным/и, начните заново.");
                }


            }
            else
            {
                Console.WriteLine($"Вы ввели неверный формат данных, начните заново.");
            }
            return 0;
        }
    }
}
