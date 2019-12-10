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

        public Neuron(int sizeX, int sizeY, int[,] inP)
        {
            weight = new int[sizeX, sizeY];
            mul = new int[sizeX, sizeY];

            input = new int[sizeX, sizeY];
            input = inP; // Получаем входные данные
        }

        /// <summary>
        /// Масштабирование
        /// </summary>
        public void Mul_n()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 3; y++) // Пробегаем по каждому аксону
                {
                    mul[x, y] = input[x, y] * weight[x, y]; // Умножаем его сигнал (0 или 1) на его собственный вес и сохраняем в массив.
                }
            }
        }

        /// <summary>
        /// Сложение
        /// </summary>
        public void ActivationAmount()
        {
            sum = 0;
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    sum += mul[x, y];
                }
            }
        }

        /// <summary>
        /// Сравнение
        /// </summary>
        /// <returns></returns>
        public bool Rezult()
        {
            if (sum >= limit)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Если ответ "false" неверный
        /// </summary>
        /// <param name="inP"></param>
        public void incWeight(int[,] inP)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    weight[x, y] += inP[x, y];
                }
            }
        }

        /// <summary>
        /// Если ответ "true" неверный
        /// </summary>
        /// <param name="inP"></param>
        public void decWweight(int[,] inP)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    weight[x, y] -= inP[x, y];
                }
            }
        }
    }
}
