using System;
using System.Collections.Generic;
using System.Text;

namespace DigitRecognition
{
    public static class PatternHelper
    {
        /// <summary>
        /// Преобразование из одномерного массива пикселей в матрицу, в соответвии с размерами картинки
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static ColorFloatPixel[,] ColorImage(ColorFloatImageFormat image)
        {
            ColorFloatPixel[,] imageData = new ColorFloatPixel[image.Height, image.Width];

            for (int height = 0, countPixel = 0; height < image.Height; ++height)
            {
                for (int width = 0; width < image.Width; ++width)
                {
                    imageData[height, width] = image.RawData[countPixel++];
                }
            }

            return imageData;
        }
    }
}