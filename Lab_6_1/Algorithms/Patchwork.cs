using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_1.Algorithms
{
    /// <summary>
    /// Patchwork class.
    /// </summary>
    internal static class Patchwork
    {
        private const int Offset = 54;
        private const int NumberOfColor = 3;
        private const int NumberOfIterations = 10000;
        private const byte Sigma = 3;

        /// <summary>
        /// Sets the watermark.
        /// </summary>
        /// <param name="picture">The picture.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        internal static bool SetWatermark(byte[] picture, int key)
        {
            var random = new Random(key);
            var numberOfDots = (picture.Length - Offset) / NumberOfColor;

            for (var i = 0; i < NumberOfIterations; i++)
            {
                var numberOfFirstDot = random.Next(numberOfDots);
                var numberOfSecindDot = random.Next(numberOfDots);

                for (var j = 0; j < NumberOfColor; j++)
                    picture[Offset + numberOfFirstDot * NumberOfColor + j] += picture[Offset + numberOfFirstDot * NumberOfColor + j] < (255 - Sigma) ? Sigma : (byte)0;

                for (var j = 0; j < NumberOfColor; j++)
                    picture[Offset + numberOfSecindDot * NumberOfColor + j] -= picture[Offset + numberOfSecindDot * NumberOfColor + j] > Sigma ? Sigma : (byte)255;
            }

            return true;
        }

        /// <summary>
        /// Checks the watermark.
        /// </summary>
        /// <param name="picture">The picture.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        internal static bool CheckWatermark(byte[] picture, int key)
        {
            var random = new Random(key);
            var sum = 0;
            var numberOfDots = (picture.Length - Offset) / NumberOfColor;

            for (var i = 0; i < NumberOfIterations; i++)
            {
                var s1 = 0;
                var s2 = 0;

                var numberOfFirstDot = random.Next(numberOfDots);
                var numberOfSecindDot = random.Next(numberOfDots);

                s1 += (int)(0.299 * picture[Offset + numberOfFirstDot * NumberOfColor]);
                s1 += (int)(0.587 * picture[Offset + numberOfFirstDot * NumberOfColor + 1]);
                s1 += (int)(0.114 * picture[Offset + numberOfFirstDot * NumberOfColor + 2]);

                s2 += (int)(0.299 * picture[Offset + numberOfSecindDot * NumberOfColor]);
                s2 += (int)(0.587 * picture[Offset + numberOfSecindDot * NumberOfColor + 1]);
                s2 += (int)(0.114 * picture[Offset + numberOfSecindDot * NumberOfColor + 2]);

                sum += s1 - s2;
            }

            if (sum > Sigma * NumberOfIterations)
            {
                return true;
            }

            return false;
        }
    }
}
