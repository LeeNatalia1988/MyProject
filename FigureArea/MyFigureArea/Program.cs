using MyFigureArea.Models;

namespace MyAreaOfFigure
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Begining: Console.WriteLine("Введите значение стороны или сторон фигуры через пробел, " +
            "дробную часть разделите запятой" +
            " или Enter для завершения программы: ");
            string stringOfSides = Console.ReadLine();
            if (string.IsNullOrEmpty(stringOfSides))
            {
                Console.WriteLine("До свидания!");
            }
            else
            {
                string[] sides = stringOfSides.Split(' ');
                switch (sides.Length)
                {
                    case 1:
                        Circle circle = new Circle(sides[0]);
                        try
                        {
                            circle.CalculateArea();
                            goto Begining;
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            goto Begining;
                        }

                    case 2:
                        Rectangle rectangle = new Rectangle(sides[0], sides[1]);
                        try
                        {
                            rectangle.CalculateArea();
                            goto Begining;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            goto Begining;
                        }

                    case 3:
                        Triangle triangle = new Triangle(sides[0], sides[1], sides[2]);
                        try
                        {
                            triangle.CalculateArea();
                            goto Begining;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            goto Begining;
                        }
                }
            }
        }
    }
}
