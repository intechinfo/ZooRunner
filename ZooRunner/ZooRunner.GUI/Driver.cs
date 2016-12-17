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
            for(int i = 0; i < _animals.Count; i++)
            {
                int x = Truncate(_animals[i].X);
                int y = Truncate(_animals[i].Y);

                Rectangle animalBody = new Rectangle(x, y, 100, 100); // 100 & 100 => Animal size

                if (AnimalsRepresentation != null && AnimalsRepresentation.AnimalsRepresentation.ContainsKey(_animals[i].GetType))
                {
                    Pen customPen = new Pen(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].ChangeColor);

                    if(AnimalsRepresentation.AnimalsRepresentation[_animals[i].GetType].Figure == "Rectangle")
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

        private int Truncate(double myDouble)
        {
            if (myDouble < 0) myDouble = myDouble * -1;

            myDouble = Math.Round(myDouble, 4);
            myDouble = myDouble * 10000;

            if (myDouble > 1000) // 1000 => Box size (cm)
            {
                string step = myDouble.ToString();
                step = step.Substring(1);
                myDouble = Convert.ToDouble(step);
            }
            return (int)myDouble;
        }

        public AnimalsRedering AnimalsRepresentation { get; set; }
    }
}
