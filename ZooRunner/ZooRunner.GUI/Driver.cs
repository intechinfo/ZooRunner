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
        bool _backgroundNeeded;
        Bitmap _background;

        public Driver()
        {
            _animals = new List<AnimalAdapter>();
            _backgroundNeeded = true;
        }

        public void Draw(Box box, Graphics g, Rectangle rectSource, float scaleFactor)
        {
            if (Zoo.CollectColorAtMethod)
            {
                if (_backgroundNeeded)
                {
                    DrawBiomes(box, g, scaleFactor);
                    _backgroundNeeded = false;
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
                int animalsSize = 30; // Hard Code must to change
                doubleX -= animalsSize / 2;
                doubleY -= animalsSize / 2;

                int x = Convert.ToInt32(doubleX);
                int y = Convert.ToInt32(doubleY);

                Rectangle animalBody = new Rectangle(x, y, animalsSize, animalsSize);

                if (AnimalsShapes != null && AnimalsShapes.AnimalsRepresentation.ContainsKey(_animals[i].TypeName))
                {
                    Pen customPen = new Pen(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].ChangeColor);

                    if (AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Shape == Shape.Rectangle)
                    {
                        g.DrawRectangle(customPen, animalBody);
                    }
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Shape == Shape.Ellipse)
                    {
                        g.DrawEllipse(customPen, animalBody);
                    }
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Shape == Shape.Triangle)
                    {
                        ShapeDrawingHelpers.DrawTriangle(g, customPen, x, y, animalsSize);
                    }
                    else if(AnimalsShapes.AnimalsRepresentation[_animals[i].TypeName].Shape == Shape.Star)
                    {
                        ShapeDrawingHelpers.DrawStar(g, customPen, x, y, animalsSize);

                    }
                    else
                    {
                        ShapeDrawingHelpers.DrawRhombus(g, customPen, x, y, animalsSize);
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
            _background = ResizeImage(backGround, box.Area.Width + 5, box.Area.Height + 5); //  for override aberration add for exemple 5
            //_background = backGround;
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

        public Bitmap BackGround => _background;

    }
}
