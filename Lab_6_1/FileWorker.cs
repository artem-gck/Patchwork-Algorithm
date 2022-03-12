using Lab_6_1.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_1
{
    /// <summary>
    /// FileWorker class.
    /// </summary>
    public static class FileWorker
    {
        /// <summary>
        /// Sets the watermark file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool SetWatermarkFile(string inputPath, string outputPath, int key)
        {
            var array = File.ReadAllBytes(inputPath);
            var result = Patchwork.SetWatermark(array, key);
            File.WriteAllBytes(outputPath, array);

            return result;
        }

        /// <summary>
        /// Checks the watermark file.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool CheckWatermarkFile(string inputPath, int key)
        {
            var array = File.ReadAllBytes(inputPath);
            var result = Patchwork.CheckWatermark(array, key);

            return result;
        }
    }
}
