        Console.WriteLine("Добро пожаловать в программу-калькулятор!");
        Console.WriteLine("Введите выражение вида a + b, a - b, a / b, a * b, чтобы вычислить его.");

        // Считываем выражение из командной строки
        Console.Write("Введите выражение: ");
        string expression = Console.ReadLine();

        // Делим введенное выражение на операнды и операцию
        string[] expressionParts = expression.Split(' ');
        double a = double.Parse(expressionParts[0]);
        double b = double.Parse(expressionParts[2]);
        string operation = expressionParts[1];

        // Вычисляем результат в зависимости от операции
        double result = 0;
        switch (operation)
        {
            case "+":
                result = a + b;
                break;
            case "-":
                result = a - b;
                break;
            case "*":
                result = a * b;
                break;
            case "/":
                // Проверяем деление на ноль
                if (b == 0)
                {
                    Console.WriteLine("Ошибка: Нельзя делить на ноль!");
                    return;
                }
                result = a / b;
                break;
            default:
                Console.WriteLine("Ошибка: Неизвестная операция!");
                return;
        }

        // Выводим результат на экран
        Console.WriteLine("Результат: " + result);
    