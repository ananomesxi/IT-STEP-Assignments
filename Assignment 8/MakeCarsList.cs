using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Assignment_8
{
    internal class MakeCarsList
    {
       public static void LoadCarsData (string path, out Cars[] car)
        {
            LinesArray(path, out string[] lines);

            car = new Cars[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                car[i] = new Cars();

                CarProperties(car[i], data);
            }
        }

        public static void LinesArray (string path, out string[] lines)
        {
            lines = File.ReadAllLines(path);
        }

        public static void CarProperties (Cars car, string[] data)
        {
            car.Name = data[0];
            car.Model = data[1];
            car.Year = int.Parse(data[2]);
            car.Price = decimal.Parse(data[3]);
            car.Color = data[4];
        }

        

    }
}
