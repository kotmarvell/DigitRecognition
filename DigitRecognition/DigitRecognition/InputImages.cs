using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DigitRecognition
{
    public static class InputImages
    {
        /// <summary>
        /// Чтение всех изображений. на которых мы хотим что-то найти
        /// </summary>
        public static void input()
        {
            string path = "E:/DigitRecognition/DigitRecognition/DigitRecognition/input/input_image.txt";
            
            StreamReader file = new StreamReader(path); // Загружаем файл
            string line = "";
            List<string> images = new List<string>();
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                images.Add(line);
                Console.WriteLine(images[i]);
                i++;
            }
            file.Close();
        }
    }
}
