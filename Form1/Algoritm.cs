using System;
using System.Collections.Generic;


namespace Form1 
{
    public class Algoritm
    {
        private float areaLengthX;
        private float areaLengthY;
        private float areaCameraX;
        private float areaCameraY;
        private float height;
        private float fovX;
        private float fovY;
        private float nowX = 0;
        private float nowY = 0;

        private int counter = 0;

        private byte[] ratio = new byte[2];

        public List<float> routeX = new List<float>();
        private List<float> routeY = new List<float>();


        public Algoritm(float areaLengthX, float areaLengthY, float height, byte fov, byte[] ratio)
        {
            this.areaLengthX = areaLengthX;
            this.areaLengthY = areaLengthY;
            this.height = height;
            this.ratio = ratio;

            fovX = fov;
            fovY = RatioCalculate();

            areaCameraX = AreaCalculation(fovX);
            areaCameraY = AreaCalculation(fovY);
        }

        private float RatioCalculate()
        {
            return (ratio[1] * fovX) / ratio[0];
        }

        private float AreaCalculation(float fov)
        {
            return (float)(2 * Math.Sqrt(Math.Pow(height / Math.Sin((180 - (90 + fov / 2)) * (Math.PI / 180)), 2) - Math.Pow(height, 2)));
        }

        private int PointCalculator()
        {
            return (int)(areaLengthX / areaCameraX);
        }

        public float[,] RouteCreate()
        {
            nowX = areaCameraX / 2;
            nowY = areaCameraY / 2;

            routeX.Add(nowX);
            routeY.Add(nowY);

            routeX.Add(nowX);
            routeY.Add(nowY + (areaLengthY - areaCameraY));
            nowY = nowY + (areaLengthY - areaCameraY);
            counter++;

            routeX.Add(nowX + areaCameraX);
            routeY.Add(nowY);
            nowX = nowX + areaCameraX;

            routeX.Add(nowX);
            routeY.Add(nowY - (areaLengthY - areaCameraY));
            nowY = nowY - (areaLengthY - areaCameraY);
            counter++;

            while (counter < PointCalculator())
            {
                routeX.Add(nowX + areaCameraX);
                routeY.Add(nowY);
                nowX = nowX + areaCameraX;

                routeX.Add(nowX);
                routeY.Add(nowY + (areaLengthY - areaCameraY));
                nowY = nowY + (areaLengthY - areaCameraY);
                counter++;

                routeX.Add(nowX + areaCameraX);
                routeY.Add(nowY);
                nowX = nowX + areaCameraX;

                routeX.Add(nowX);
                routeY.Add(nowY - (areaLengthX - areaCameraX));
                nowY = nowY - (areaLengthX - areaCameraX);
                counter++;
            }

            float[,] route = new float[routeX.Count, 2];

            for (int y = 0; y < routeY.Count; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    switch (x)
                    {
                        case 0:
                            route[y, x] = Convert.ToSingle(routeX[y]);
                            break;
                        case 1:
                            route[y, x] = Convert.ToSingle(routeY[y]);
                            break;
                    }

                }
            }
            return route;
        }
    }
}
