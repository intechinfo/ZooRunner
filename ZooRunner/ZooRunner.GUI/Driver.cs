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
            for (int i = 0; i <= box.Area.Height; i += 10) // 100 => number of biome in a box
            {
                for (int n = 0; n <= box.Area.Width; n += 10)
                {
                    decimal offsetN = (decimal)n / (decimal)box.Area.Width * 100;
                    double x = InferiorBoundaryX + Interval / 100 * (double)offsetN;

                    decimal offsetI = (decimal)i / (decimal)box.Area.Height * 100;
                    double y = SuperiorBoundaryY - Interval / 100 * (double)offsetI;

                    x = Math.Round(x, 5);
                    y = Math.Round(y, 5);

                    //double x2 = x + Interval / 10;
                    //double y2 = y;

                    //double x3 = x + Interval / 10;
                    //double y3 = y - Interval / 10;

                    //double x4 = x;
                    //double y4 = y - Interval / 10;

                    //double x5 = x + (Interval / 10) / 2;
                    //double y5 = y - (Interval / 10) / 2;

                    //Color intermediateColor = Zoo.ColorAt(x, y);
                    //Color intermediateColor2 = Zoo.ColorAt(x2, y2);
                    //Color intermediateColor3 = Zoo.ColorAt(x3, y3);
                    //Color intermediateColor4 = Zoo.ColorAt(x4, y4);
                    //Color intermediateColor5 = Zoo.ColorAt(x5, y5);

                    //int alpha = (intermediateColor.A + intermediateColor2.A + intermediateColor3.A + intermediateColor4.A + intermediateColor5.A) / 5;
                    //int red = (intermediateColor.R + intermediateColor2.R + intermediateColor3.R + intermediateColor4.R + intermediateColor5.R) / 5;
                    //int green = (intermediateColor.G + intermediateColor2.G + intermediateColor3.G + intermediateColor4.G + intermediateColor5.G) / 5;
                    //int blue = (intermediateColor.B + intermediateColor2.B + intermediateColor3.B + intermediateColor4.B + intermediateColor5.B) / 5;

                    //Color biomeColor = Color.FromArgb(alpha, red, green, blue);

                    Color biomeColor = Zoo.ColorAt(x, y);
                    Brush biomeBrush = new SolidBrush(biomeColor);
                    Pen biomePen = new Pen(biomeColor);
                    Rectangle biome = new Rectangle(n, i, 10, 10);

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
