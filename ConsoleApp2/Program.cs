using System;
using ConsoleTables;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable ht = new HashTable();
            int groupSize = 9; // Количество строк в таблице (вместо колонок)

            // Вычисляем общее количество столбцов, необходимое для всех элементов
            int columnCount = (int)Math.Ceiling(ht.t / (double)groupSize);

            // Создаём заголовки для столбцов
            var headers = new string[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                headers[i] = $"Column {i + 1}";
            }

            // Создаём таблицу с динамическим количеством столбцов
            var table = new ConsoleTable(headers);

            // Построение таблицы
            for (int row = 0; row < groupSize; row++)
            {
                // Создаём массив данных для строки
                object[] rowData = new object[columnCount];

                for (int col = 0; col < columnCount; col++)
                {
                    int index = col * groupSize + row; // Индекс элемента в исходном массиве

                    // Проверяем, чтобы индекс не превышал размер массива
                    if (index < ht.t)
                    {
                        rowData[col] = $"{index}: {ht.arr[index]}";
                    }
                    else
                    {
                        rowData[col] = ""; // Заполняем пустыми строками, если данных нет
                    }
                }

                // Добавляем строку в таблицу
                table.AddRow(rowData);
            }

            // Вывод таблицы
            table.Write();
            Console.WriteLine($"Кол-во элементов = {ht.elementsCount}");
            Console.WriteLine($"Среднее число шагов для вставки одного элемента = {ht.getSR()}");
            Console.WriteLine($"a = {ht.getA()}");
        }
    }
}
