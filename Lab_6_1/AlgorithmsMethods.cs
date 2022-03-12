using Lab_6_1;
using Lab_6_1.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_1
{
    /// <summary>
    /// AlgorithmsMethods class.
    /// </summary>
    public static class AlgorithmsMethods
    {
        private const string CryptChoose = "1. Set watermark\n2. Check watermark";
        private const string Choice = "Input your choise: ";
        private const string InputPath = "Input path to input file: ";
        private const string OutputPath = "Output path to output file: ";
        private const string Key = "Input key: ";
        private const string TrueWatermark = "Watermark is true";
        private const string FalseWatermark = "Watermark is false";

        /// <summary>
        /// Patchworks this instance.
        /// </summary>
        /// <returns></returns>
        public static bool Patchwork()
        {
            Console.WriteLine(CryptChoose);
            var choose = ConsoleValidation.ValidateInt(Choice, 1, 2);

            switch (choose)
            {
                case 1:
                    Console.Write(InputPath);
                    var inputPath = Console.ReadLine();

                    Console.Write(OutputPath);
                    var outputPath = Console.ReadLine();

                    var key = ConsoleValidation.ValidateInt(Key);

                    FileWorker.SetWatermarkFile(inputPath, outputPath, key);

                    return true;

                    break;

                case 2:

                    Console.Write(InputPath);
                    inputPath = Console.ReadLine();

                    key = ConsoleValidation.ValidateInt(Key);

                    var result = FileWorker.CheckWatermarkFile(inputPath, key);

                    Console.WriteLine(result ? TrueWatermark : FalseWatermark);

                    return result;

                    break;

                default:
                    return false;
            }
        }
    }
}
