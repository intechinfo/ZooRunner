using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    class Driver : IBoxDriver
    {
        List<AnimalAdapter> _animals;

        public Driver()
        {
            _animals = new List<AnimalAdapter>();
        }

        public void Draw(Box box, Graphics g, Rectangle rectSource, float scaleFactor)
        {
            DrawBiomes(box, g, rectSource);

            for (int i = 0; i < _animals.Count; i++)
            {
                double doubleX = 0;
                double doubleY = 0;

                // x
                doubleX = InferiorBoundaryX - _animals[i].X;
                doubleX = doubleX / Interval * box.Area.Width;

                if (doubleX < 0) doubleX = doubleX * -1;

                // y
                doubleY = SuperiorBoundaryY - _animals[i].Y;
                doubleY = doubleY / Interval * box.Area.Height;

                if (doubleY < 0) doubleY = doubleY * -1;

                // Animals size compensation
                int animalsSize = 100;
                doubleX -= animalsSize / 2;
                doubleY -= animalsSize / 2;

                int x = (int)doubleX;
                int y = (int)doubleY;

                Rectangle animalBody = new Rectangle(x, y, animalsSize, animalsSize);

                if (AnimalsRepresentation != null && AnimalsRepresentation.AnimalsRepresentation.ContainsKey(_animals[i].GetType))
                {
                    Pen customPen = new Pen(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].ChangeColor);

                    if (AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Rectangle")
                    {
                        g.DrawRectangle(customPen, animalBody);
                    }
                    else if(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Ellipse")
                    {
                        g.DrawEllipse(customPen, animalBody);
                    }
                    else if(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Triangle")
                    {
                        Point one = new Point(x, y);
                        Point two = new Point(x + animalsSize, y);
                        Point tree = new Point(x + animalsSize / 2, y + animalsSize);

                        Point[] trianglePoints =
                        {
                            one,
                            two,
                            tree
                        };

                        g.DrawPolygon(customPen, trianglePoints);
                    }
                    else if(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Star")
                    {
                        Point one = new Point(x + animalsSize / 2, y);
                        Point two = new Point(x +  animalsSize / 3 * 2, y + animalsSize / 4);
                        Point tree = new Point(x + animalsSize, y + animalsSize / 4);
                        Point four = new Point(x + animalsSize / 6 * 5, y + animalsSize / 2);
                        Point five = new Point(x + animalsSize, y + animalsSize / 4 * 3);
                        Point six = new Point(x + animalsSize / 3 * 2, y + animalsSize / 4 * 3);
                        Point seven = new Point(x + animalsSize / 2, y + animalsSize);
                        Point eight = new Point(x + animalsSize / 3, y + animalsSize / 4 * 3);
                        Point nine = new Point(x, y + animalsSize / 4 * 3);
                        Point ten = new Point(x + animalsSize / 6, y + animalsSize / 2);
                        Point eleven = new Point(x, y + animalsSize / 4);
                        Point twelve = new Point(x + animalsSize / 3 , y + animalsSize / 4);

                        Point[] starPoints =
                        {
                            one,
                            two,
                            tree,
                            four,
                            five,
                            six,
                            seven,
                            eight,
                            nine,
                            ten,
                            eleven,
                            twelve
                        };

                        g.DrawPolygon(customPen, starPoints);

                    }
                    else
                    {
                        Point one = new Point(x + animalsSize / 2, y);
                        Point two = new Point(x + animalsSize, y + animalsSize / 2);
                        Point tree = new Point(x + animalsSize / 2, y + animalsSize);
                        Point four = new Point(x, y + animalsSize / 2);

                        Point[] rhombusPoints =
                        {
                            one,
                            two,
                            tree,
                            four
                        };

                        g.DrawPolygon(customPen, rhombusPoints);
                    }
                }
                else
                {
                    Pen blackPen = new Pen(Color.Black);
                    g.DrawRectangle(blackPen, animalBody);
                }
            }
        }

        public void  AddAnimal (AnimalAdapter animal)
        {
            _animals.Add(animal);
        }

        private void DrawBiomes(Box box, Graphics g, Rectangle rectSource)
        {
            for (int i = 0; i <= box.Area.Height; i += 100) // 100 => number of biome in a box
            {
                for (int n = 0; n <= box.Area.Width; n += 100)
                {
                    decimal offsetN = (decimal)n / (decimal)box.Area.Width * 100;
                    double x = InferiorBoundaryX + Interval / 100 * (double)offsetN;

                    decimal offsetI = (decimal)i / (decimal)box.Area.Height * 100;
                    double y = SuperiorBoundaryY - Interval / 100 * (double)offsetI;

                    Color biomeColor = Zoo.ColorAt(x, y);
                    Brush biomeBrush = new SolidBrush(biomeColor);
                    Rectangle biome = new Rectangle(n, i, 100, 100);
                    g.FillRectangle(biomeBrush, biome);
                }
            }
        }

        public AnimalsRedering AnimalsRepresentation { get; set; }

        public double Interval { get; set; }

        public double InferiorBoundaryX { get; set; }

        public double SuperiorBoundaryY { get; set; }

        public ZooAdapter Zoo { get; set; }

        public int BoxCount { get; set; }
    }
}
