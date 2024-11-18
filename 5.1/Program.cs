using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        // Основне меню програми
        Console.WriteLine("Виберіть дію:");
        Console.WriteLine("1. Прочитати дані з файлу");
        Console.WriteLine("2. Записати дані у файл");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        // Виконання дії залежно від вибору користувача
        switch (choice)
        {
            case "1":
                ReadFromFile(); // Виклик методу для читання з файлу
                break;

            case "2":
                WriteToFile(); // Виклик методу для запису у файл
                break;

            default:
                Console.WriteLine("Неправильний вибір. Завершення програми.");
                break;
        }
    }

    /// <summary>
    /// Метод для читання даних з текстового файлу.
    /// </summary>
    static void ReadFromFile()
    {
        Console.Write("Введіть шлях до файлу для читання: ");
        string filePath = Console.ReadLine();

        // Перевірка існування файлу
        if (File.Exists(filePath))
        {
            try
            {
                // Зчитування вмісту файлу
                string content = File.ReadAllText(filePath);

                // Вивід вмісту файлу на екран
                Console.WriteLine("Вміст файлу:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                // Обробка помилок, якщо файл не вдалося прочитати
                Console.WriteLine($"Помилка під час читання файлу: {ex.Message}");
            }
        }
        else
        {
            // Повідомлення користувачу, якщо файл не існує
            Console.WriteLine("Файл не знайдено. Перевірте шлях і спробуйте ще раз.");
        }
    }

    /// <summary>
    /// Метод для запису тексту у файл (з вибором режиму запису).
    /// </summary>
    static void WriteToFile()
    {
        Console.Write("Введіть шлях до файлу для запису: ");
        string filePath = Console.ReadLine();

        // Запит режиму запису
        Console.WriteLine("Виберіть режим запису:");
        Console.WriteLine("1. Додати текст до файлу");
        Console.WriteLine("2. Перезаписати файл");
        Console.Write("Ваш вибір: ");
        string mode = Console.ReadLine();

        Console.Write("Введіть текст для запису: ");
        string userInput = Console.ReadLine();

        try
        {
            if (mode == "1")
            {
                // Додати текст у кінець файлу
                File.AppendAllText(filePath, userInput + Environment.NewLine);
                Console.WriteLine("Текст успішно додано до файлу.");
            }
            else if (mode == "2")
            {
                // Перезаписати файл новим текстом
                File.WriteAllText(filePath, userInput + Environment.NewLine);
                Console.WriteLine("Файл успішно перезаписано.");
            }
            else
            {
                // Повідомлення у разі неправильного вибору
                Console.WriteLine("Неправильний режим запису.");
            }
        }
        catch (Exception ex)
        {
            // Обробка помилок, якщо запис у файл не вдався
            Console.WriteLine($"Помилка під час запису у файл: {ex.Message}");
        }
    }
}