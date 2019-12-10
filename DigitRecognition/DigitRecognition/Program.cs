using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DigitRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[5, 3];
            Neuron meNeuron = new Neuron(5, 3, input);
            string path = "E:/DigitRecognition/DigitRecognition/DigitRecognition/input/pattern_5.txt";

            StreamReader sr = new StreamReader(path); // Загружаем файл весов
            string line;
            string[] s1;
            int k = 0;
            while ((line = sr.ReadLine()) != null)
            {
                s1 = line.Split(' ');
                for (int i = 0; i < s1.Length; i++)
                {
                    meNeuron.weight[k, i] = Convert.ToInt32(s1[i]); // Назначаем каждой связи её записанный ранее вес
                    Console.Write(meNeuron.weight[k, i] + " "); // Выводим веса, для наглядности
                }
                k++;
                Console.WriteLine("");
            }
            sr.Close();
            Console.WriteLine(" ");

            List<string> filesName = InputImages.Input();
            List<ColorFloatPixel[,]> images = InputImages.ImagesToCheck(filesName);

            foreach (var item in images)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (item[i, l].R <= 100 && item[i, l].G <= 100 && item[i, l].B <= 100)
                        {
                            meNeuron.input[i, l] = 1;
                        }
                        else meNeuron.input[i, l] = 0;
                        Console.Write(meNeuron.input[i, l] + " ");
                    }
                    Console.WriteLine(" ");
                }

                meNeuron.Mul_n();
                meNeuron.ActivationAmount();
                if (meNeuron.Rezult())
                    Console.WriteLine(" - True, Sum = " + meNeuron.sum);
                else
                    Console.WriteLine(" - False, Sum = " + meNeuron.sum);

                int result = Convert.ToInt32(Console.ReadLine());
                if (result == 1)
                {
                    meNeuron.incWeight(meNeuron.input);
                }
                if (result == 0)
                {
                    meNeuron.decWweight(meNeuron.input);
                }

                StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(
                        Convert.ToString(meNeuron.weight[i, 0]) + " " +
                        Convert.ToString(meNeuron.weight[i, 1]) + " " +
                        Convert.ToString(meNeuron.weight[i, 2]));
                }
                sw.Close();
            }

        }
    }
}
