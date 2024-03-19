﻿// Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:

csharp
// Решение задачи по определению количества выходов в лабиринте
static int hasexit(int starti, int startj, int[,] l)
{
    int rowCount = l.GetLength(0);
    int colCount = l.GetLength(1);

    // Проверяем, что стартовые координаты находятся в пределах лабиринта и открыты
    if (starti < 0 || starti >= rowCount || startj < 0 || startj >= colCount || l[starti, startj] != 0)
    {
        return 0;
    }

    int exitCount = 0;

    // Запускаем рекурсивную функцию для поиска выходов
    findExit(starti, startj, l, ref exitCount);

    return exitCount;
}

// Рекурсивная функция для поиска выходов
static void findExit(int i, int j, int[,] l, ref int exitCount)
{
    int rowCount = l.GetLength(0);
    int colCount = l.GetLength(1);

    // Проверяем, что текущие координаты находятся в пределах лабиринта и ячейка открыта
    if (i >= 0 && i < rowCount && j >= 0 && j < colCount && l[i, j] == 0)
    {
        // Помечаем ячейку как посещенную
        l[i, j] = -1;

        // Если текущая ячейка находится на краю лабиринта, то есть выход
        if (i == 0 || i == rowCount - 1 || j == 0 || j == colCount - 1)
        {
            exitCount++;
        }
        else
        {
            // Рекурсивно ищем выходы во всех соседних ячейках
            findExit(i - 1, j, l, ref exitCount); // Вверх
            findExit(i + 1, j, l, ref exitCount); // Вниз
            findExit(i, j - 1, l, ref exitCount); // Влево
            findExit(i, j + 1, l, ref exitCount); // Вправо
        }
    }
}


// В данном коде мы используем рекурсивную функцию findExit, которая осуществляет поиск выходов из лабиринта, начиная с заданных стартовых координат starti и startj. 
// При каждом посещении ячейки мы помечаем ее как посещенную, чтобы не заходить в нее снова.
// Если текущая ячейка находится на краю лабиринта, то мы считаем ее выходом и увеличиваем счетчик exitCount. 
// В противном случае, мы рекурсивно вызываем findExit для соседних ячеек вверх, вниз, влево и вправо.
// Наконец, в функции hasexit мы инициализируем переменную exitCount и передаем ее по ссылке в findExit. 
// В конце мы возвращаем значение exitCount, которое представляет количество выходов в лабиринте.
