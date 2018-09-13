using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directionRadians">Угол направелния движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
        /// <returns></returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            double direction = (directionRadians * 180) / Math.PI;
            double wallInclination = (wallInclinationRadians * 180) / Math.PI;
            // по формуле x = 2b-a 
            // a - угол между направлением удара и осью Х
            // b - угол между стеной и осью Х
            // x - угол отскока 
            return (2 * wallInclination - direction) * Math.PI / 180;
        }
    }
}