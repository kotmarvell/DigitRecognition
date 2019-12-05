using System;
using System.Collections.Generic;
using System.Text;

namespace DigitRecognition
{
    class Neuron
    {
        public int[,] mul; // Тут будем хранить отмасштабированные сигналы
        public int[,] weight; // Массив для хранения весов
        public int[,] input; // Входная информация
        public int limit = 9; // Порог - выбран экспериментально, для быстрого обучения
        public int sum; // Тут сохраним сумму масштабированных сигналов

        public Neuron(int sizex, int sizey, int[,] inP) // Задаем свойства при создании объекта
        {
            weight = new int[sizex, sizey]; // Определяемся с размером массива (число входов)
            mul = new int[sizex, sizey];

            input = new int[sizex, sizey];
            input = inP; // Получаем входные данные
        }

        /// <summary>
        /// Масштабирование
        /// </summary>
        public void Mul_n()
        {
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 4; y++) // Пробегаем по каждому аксону
                {
                    mul[x, y] = input[x, y] * weight[x, y]; // Умножаем его сигнал (0 или 1) на его собственный вес и сохраняем в массив.
                }
            }
        }

        /// <summary>
        /// Сложение
        /// </summary>
        public void Sum()
        {
            sum = 0;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    sum += mul[x, y];
                }
            }
        }

        /// <summary>
        /// Сравнение
        /// </summary>
        /// <returns></returns>
        public bool Rez()
        {
            if (sum >= limit)
                return true;
            else
                return false;
        }
    }
}
