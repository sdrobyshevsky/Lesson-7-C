// Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран близких родственников (жену/мужа). 
// Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.

csharp
// Определяем класс для представления человека
public class Person
{
    public string Name { get; set; }
    public Person Spouse { get; set; }
}

// Определяем класс для генеалогического дерева
public class GenealogyTree
{
    private Person root;

    public GenealogyTree(Person root)
    {
        this.root = root;
    }

    // Рекурсивно выводим генеалогическое дерево с разделителями
    private void PrintTree(Person person, string prefix = "", bool isLast = true)
    {
        Console.WriteLine(prefix + (isLast ? "└── " : "├── ") + person.Name);

        // Если есть супруг, выводим его
        if (person.Spouse != null)
        {
            Console.WriteLine(prefix + (isLast ? "    " : "│   ") + "└── " + person.Spouse.Name);
        }

        // Перебираем детей и выводим их вместе с горизонтальными разделителями
        var children = GetChildren(person);
        for (int i = 0; i < children.Count; i++)
        {
            var child = children[i];
            var isLastChild = i == children.Count - 1;
            PrintTree(child, prefix + (isLast ? "    " : "│   "), isLastChild);
        }
    }

    // Метод для получения всех детей человека
    private List<Person> GetChildren(Person person)
    {
        // Здесь можно добавить логику получения детей для конкретного человека
        // Например, можно воспользоваться списком детей в классе Person

        // В данном примере просто возвращаем пустой список детей
        return new List<Person>();
    }

    // Печатаем генеалогическое дерево с расположением близких родственников вертикально и горизонтально
    public void Print()
    {
        PrintTree(root);
    }
}

// Пример использования
public static void Main(string[] args)
{
    // Создаем персональные объекты
    var john = new Person { Name = "John" };
    var anna = new Person { Name = "Anna" };
    var alice = new Person { Name = "Alice" };
    var bob = new Person { Name = "Bob" };
    var linda = new Person { Name = "Linda" };

    // Устанавливаем связи между персонами
    john.Spouse = anna;
    john.Children = new List<Person> { alice, bob };
    bob.Spouse = linda;

    // Создаем объект для генеалогического дерева
    var tree = new GenealogyTree(john);

    // Выводим дерево на экран
    tree.Print();
}


// В данном примере представлено решение на языке C# для доработки приложения генеалогического дерева, чтобы программа выводила на экран близких родственников (жена/муж). 

// Добавлена новая связь в классе Person - Spouse, которая представляет супругу/супруга. Метод PrintTree рекурсивно выводит генеалогическое дерево, добавляя горизонтальные и вертикальные черточки для более красивого отображения. Для каждого человека он выводит его собственное имя, а также супруга/супругу, если они есть. Метод GetChildren позволяет получить всех детей у конкретного человека (можно добавить свою логику для получения детей). Метод Print вызывает PrintTree для корневого узла генеалогического дерева.

// Пример использования демонстрирует создание нескольких персон и установление связей между ними. Затем создается объект GenealogyTree, передается корневой узел и вызывается метод Print для вывода дерева на экран.