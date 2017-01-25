using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    class Driver : IBoxDriver
    {
        List<AnimalAdapter> _animals;
        bool _showBiomes;
        Bitmap _background;

        public Driver()
        {
            _animals = new List<AnimalAdapter>();
            _showBiomes = true;
        }

        public void Draw(Box box, Graphics g, Rectangle rectSource, float scaleFactor)
        {
            if (Zoo.CollectColorAtMethod)
            {
                if (_showBiomes)
                {
                    DrawBiomes(box, g, scaleFactor);
                    _showBiomes = false;
                }

                g.DrawImage(_background, 0, 0);
            }

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
                int animalsSize = 30;
                doubleX -= animalsSize / 2;
                doubleY -= animalsSize / 2;

                int x = (int)doubleX;
                int y = (int)doubleY;

                Rectangle animalBody = new Rectangle(x, y, animalsSize, animalsSize);

                if (AnimalsShapes != null && AnimalsShapes.AnimalsRepresentation.ContainsKey(_animals[i].TypeName))
                {
                    Pen customPen = new Pen(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].ChangeColor);

                    if (AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Figure == "Rectangle")
                    {
                        g.DrawRectangle(customPen, animalBody);
                    }
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Figure == "Ellipse")
                    {
                        g.DrawEllipse(customPen, animalBody);
                    }
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Figure == "Triangle")
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
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Figure == "Star")
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

        public void ClearAnimals()
        {
            _animals.Clear();
        }

        private void DrawBiomes(Box box, Graphics g, float scalefactor)
        {
            Bitmap backGround = new Bitmap((int)(box.Area.Width * scalefactor), (int)(box.Area.Height * scalefactor));

            for (int i = 0; i < backGround.Width; i++)
            {
                for (int n = 0; n < backGround.Height; n++)
                {
                    decimal offsetN = (decimal)n / (decimal)backGround.Width * 100;
                    double x = InferiorBoundaryX + Interval / 100 * (double)offsetN;

                    decimal offsetI = (decimal)i / (decimal)backGround.Height * 100;
                    double y = SuperiorBoundaryY - Interval / 100 * (double)offsetI;

                    Color customColor = Zoo.ColorAt(x, y);
                    backGround.SetPixel(n, i, customColor);
                }
            }
            _background = ResizeImage(backGround, box.Area.Width, box.Area.Height); //  for override aberration add for exemple 5
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);

            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public AnimalsRedering AnimalsShapes { get; set; }

        public double Interval { get; set; }

        public double InferiorBoundaryX { get; set; }

        public double SuperiorBoundaryY { get; set; }

        public ZooAdapter Zoo { get; set; }

        public object CastAnimalsRedering {
            set
            {
                AnimalsShapes = (AnimalsRedering)value;
            }
        }

    }
}
