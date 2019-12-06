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
        public static List<string> Input()
        {
            string path = "E:/DigitRecognition/DigitRecognition/DigitRecognition/input/input_image.txt";
            
            StreamReader file = new StreamReader(path); // Загружаем файл
            string line = "";
            List<string> images = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                images.Add(line);
            }
            file.Close();

            return images;
        }

        /// <summary>
        /// Преобразует все изображения в список
        /// с их матрицами пикселей
        /// </summary>
        /// <param name="imagesName"></param>
        /// <returns></returns>
        public static List<ColorFloatPixel[,]> ImagesToCheck(List<string> imagesName)
        {
            List<ColorFloatPixel[,]> pixelImages = new List<ColorFloatPixel[,]>();
            string path = "E:/DigitRecognition/DigitRecognition/assets/";
            for (int i = 0; i < imagesName.Count; i++)
            {
                string InputFileName = path + imagesName[i];
                ColorFloatImageFormat image = ImageIO.FileToColorFloatImage(InputFileName);
                pixelImages.Add(PatternHelper.ColorImage(image));
            }

            return pixelImages;
        }

    }
}
