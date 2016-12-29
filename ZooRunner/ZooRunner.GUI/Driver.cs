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
            for (int i = 0; i < _animals.Count; i++)
            {
                double x = 0;
                double y = 0;

                // x
                x = InferiorBoundaryX - _animals[i].X;
                x = x / Interval * box.Area.Width;

                if (x < 0) x = x * -1;

                // y
                y = SuperiorBoundaryY - _animals[i].Y;
                y = y / Interval * box.Area.Height;

                if (y < 0) y = y * -1;

                // Animals size compensation
                int animalsSize = 100;
                x -= animalsSize / 2;
                y -= animalsSize / 2;

                Rectangle animalBody = new Rectangle((int)x, (int)y, animalsSize, animalsSize);

                if (AnimalsRepresentation != null && AnimalsRepresentation.AnimalsRepresentation.ContainsKey(_animals[i].GetType))
                {
                    Pen customPen = new Pen(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].ChangeColor);

                    if (AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Rectangle")
                    {

                        g.DrawRectangle(customPen, animalBody);
                    }
                    else
                    {
                        g.DrawEllipse(customPen, animalBody);
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

        public AnimalsRedering AnimalsRepresentation { get; set; }

        public double Interval { get; set; }

        public double InferiorBoundaryX { get; set; }

        public double SuperiorBoundaryY { get; set; }

    }
}
