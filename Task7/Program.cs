// Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
// int[,] labirynth1 = new int[,]
// {
// {1, 1, 1, 1, 1, 1, 1 },
// {1, 0, 0, 0, 0, 0, 1 },
// {1, 0, 1, 1, 1, 0, 1 },
// {0, 0, 0, 0, 1, 0, 0 },
// {1, 1, 0, 0, 1, 1, 1 },
// {1, 1, 1, 0, 1, 1, 1 },
// {1, 1, 1, 0, 1, 1, 1 }
// };

// Сигнатура метода:

// static int HasExit(int startI, int startJ, int[,] l)


// csharp
// // Решение задачи по определению количества выходов в лабиринте
// static int hasexit(int starti, int startj, int[,] l)
// {
//     int rowCount = l.GetLength(0);
//     int colCount = l.GetLength(1);

//     // Проверяем, что стартовые координаты находятся в пределах лабиринта и открыты
//     if (starti < 0 || starti >= rowCount || startj < 0 || startj >= colCount || l[starti, startj] != 0)
//     {
//         return 0;
//     }

//     int exitCount = 0;

//     // Запускаем рекурсивную функцию для поиска выходов
//     findExit(starti, startj, l, ref exitCount);

//     return exitCount;
// }

// // Рекурсивная функция для поиска выходов
// static void findExit(int i, int j, int[,] l, ref int exitCount)
// {
//     int rowCount = l.GetLength(0);
//     int colCount = l.GetLength(1);

//     // Проверяем, что текущие координаты находятся в пределах лабиринта и ячейка открыта
//     if (i >= 0 && i < rowCount && j >= 0 && j < colCount && l[i, j] == 0)
//     {
//         // Помечаем ячейку как посещенную
//         l[i, j] = -1;

//         // Если текущая ячейка находится на краю лабиринта, то есть выход
//         if (i == 0 || i == rowCount - 1 || j == 0 || j == colCount - 1)
//         {
//             exitCount++;
//         }
//         else
//         {
//             // Рекурсивно ищем выходы во всех соседних ячейках
//             findExit(i - 1, j, l, ref exitCount); // Вверх
//             findExit(i + 1, j, l, ref exitCount); // Вниз
//             findExit(i, j - 1, l, ref exitCount); // Влево
//             findExit(i, j + 1, l, ref exitCount); // Вправо
//         }
//     }
// }


// В данном коде мы используем рекурсивную функцию findExit, которая осуществляет поиск выходов из лабиринта, начиная с заданных стартовых координат starti и startj. 
// При каждом посещении ячейки мы помечаем ее как посещенную, чтобы не заходить в нее снова.
// Если текущая ячейка находится на краю лабиринта, то мы считаем ее выходом и увеличиваем счетчик exitCount. 
// В противном случае, мы рекурсивно вызываем findExit для соседних ячеек вверх, вниз, влево и вправо.
// Наконец, в функции hasexit мы инициализируем переменную exitCount и передаем ее по ссылке в findExit. 
// В конце мы возвращаем значение exitCount, которое представляет количество выходов в лабиринте.


// csharp
// static int HasExit(int startI, int startJ, int[,] l)
// {
// if (startI < 0 || startI >= l.GetLength(0) || startJ < 0 || startJ >= l.GetLength(1))
// {
// return 0;
// }

// if (l[startI, startJ] == 1)
// {
// return 0;
// }

// if ((startI == 0 || startI == l.GetLength(0) - 1 || startJ == 0 || startJ == l.GetLength(1) - 1) && l[startI, startJ] == 0)
// {
// return 1;
// }

// l[startI, startJ] = 1;

// return HasExit(startI + 1, startJ, l) + HasExit(startI - 1, startJ, l) + HasExit(startI, startJ + 1, l) + HasExit(startI, startJ - 1, l);
// }


// Пример вызова метода для данного лабиринта:

// int result = HasExit(1, 0, labirynth1);
// Console.WriteLine("Total exits in the labyrinth: " + result);


// Метод `HasExit` рекурсивно проверяет все возможные направления движения из текущей точки в лабиринте и возвращает количество выходов из лабиринта.


{
int count = 0;
HasExit(startI, startJ, l, ref count);
return count;
}

static void HasExit(int i, int j, int[,] l, ref int count)
{
if (i < 0 || i >= l.GetLength(0) || j < 0 || j >= l.GetLength(1))
{
return;
}

if (l[i, j] == 0)
{
if (i == 0 || i == l.GetLength(0) - 1 || j == 0 || j == l.GetLength(1) - 1)
{
count++;
}

l[i, j] = 2;
HasExit(i + 1, j, l, ref count);
HasExit(i - 1, j, l, ref count);
HasExit(i, j + 1, l, ref count);
HasExit(i, j - 1, l, ref count);
}
}