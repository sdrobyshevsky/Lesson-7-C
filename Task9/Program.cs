// Разработка приложения на C# (семинары)
// Урок 7. Рефлексия

// Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.
// Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.
// [CustomName(“CustomFieldName”)]
// public int I = 0.
// Если использовать формат строки с данными использованной нами для предыдущего примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0
// Подсказка:
// Если GetProperty(propertyName) вернул null то очевидно свойства с таким именем нет и возможно имя является алиасом заданным с помощью CustomName. 
// Возможно, если перебрать все поля с таким атрибутом то для одного из них propertyName = совпадает с таковым заданным атрибутом.



using System;
using System.Reflection;

// Создаем атрибут CustomName
[AttributeUsage(AttributeTargets.Field)]
public class CustomNameAttribute : Attribute
{
    public string CustomFieldName { get; }

    public CustomNameAttribute(string customFieldName)
    {
        CustomFieldName = customFieldName;
    }
}

// Создаем класс с методами для сериализации и десериализации
public class SerializationHelper
{
    // Метод для сериализации объекта в строку
    public static string ObjectToString(object obj)
    {
        Type type = obj.GetType();
        string result = "";

        foreach (FieldInfo field in type.GetFields())
        {
            string fieldName = field.Name;
            string fieldValue = field.GetValue(obj).ToString();

            // Проверяем наличие атрибута CustomName
            CustomNameAttribute attribute = (CustomNameAttribute)Attribute.GetCustomAttribute(field, typeof(CustomNameAttribute));
            if (attribute != null)
            {
                fieldName = attribute.CustomFieldName;
            }

            result += $"{fieldName}:{fieldValue}\n";
        }

        return result;
    }

    // Метод для десериализации строки в объект
    public static void StringToObject(string data, object obj)
    {
        string[] lines = data.Split('\n');

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            string fieldName = parts[0];
            string fieldValue = parts[1];

            // Поиск поля с атрибутом CustomName
            FieldInfo field = obj.GetType().GetField(fieldName);
            if (field == null)
            {
                field = obj.GetType().GetFields().FirstOrDefault(f =>
                {
                    CustomNameAttribute attribute = (CustomNameAttribute)Attribute.GetCustomAttribute(f, typeof(CustomNameAttribute));
                    return attribute != null && attribute.CustomFieldName == fieldName;
                });
            }

            if (field != null)
            {
                field.SetValue(obj, Convert.ChangeType(fieldValue, field.FieldType));
            }
        }
    }
}

// Пример использования
public class MyClass
{
    [CustomName("customfieldname")]
    public int i = 0;
    public string name = "John";
}

public class Program
{
    public static void Main()
    {
        MyClass obj = new MyClass();
        string serializedData = SerializationHelper.ObjectToString(obj);
        Console.WriteLine(serializedData);

        MyClass newObj = new MyClass();
        SerializationHelper.StringToObject(serializedData, newObj);
        Console.WriteLine($"New object: i={newObj.i}, name={newObj.name}");
    }
}

// Этот код создает атрибут CustomName, который позволяет задать произвольное имя поля. 
// Методы ObjectToString и StringToObject позволяют сериализовать объект в строку с учетом атрибутов и десериализовать строку в объект. 
// Пример использования показывает сохранение и восстановление значения поля i с использованием заданного алиаса customfieldname.