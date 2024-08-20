using System;

namespace LifeSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Алан Нортон", 25);
            bool isAlive = true; // Переменная, определяющая, жив ли персонаж

            while (isAlive)
            {
                Console.Clear(); // Очищаем консоль для более удобного отображения информации
                Console.WriteLine(person); // Выводим информацию о персонаже

                // Предлагаем пользователю выбрать действие
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Работать");
                Console.WriteLine("2. Отдыхать");
                Console.WriteLine("3. Питаться");
                Console.WriteLine("4. Закончить игру");
                Console.Write("Введите номер действия: ");

                string choice = Console.ReadLine(); // Считываем выбор пользователя

                // Обрабатываем выбор пользователя с помощью switch
                switch (choice)
                {
                    case "1":
                        person.Work(); // Если выбрано работать, вызываем метод Work()
                        break;
                    case "2":
                        person.Rest(); // Если выбрано отдыхать, вызываем метод Rest()
                        break;
                    case "3":
                        person.Feed(); // Если выбрано питаться, вызываем метод Feed()
                        break;
                    case "4":
                        isAlive = false; // Если выбрано завершить игру, устанавливаем isAlive в false
                        break;
                    default:
                        Console.WriteLine("Неверный выбор."); // Если введено некорректное значение
                        break;
                }

                // Ожидаем нажатия клавиши перед повторением цикла
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }
    }

    // Класс, представляющий персонажа
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Energy { get; private set; }
        public int Hunger { get; private set; }

        // Конструктор класса, инициализирующий имя и возраст
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Energy = 100; // Начальная энергия равна 100
            Hunger = 0; // Начальный голод 0
        }

        // Метод, моделирующий работу персонажа
        public void Work()
        {
            // Проверяем, достаточно ли энергии и нет ли голода, чтобы работать
            if (Energy >= 10 && Hunger < 100)
            {
                Console.WriteLine($"{Name} работает...");
                Energy -= 10; // Уменьшаем энергию на 10
                Hunger += 10; // Увеличиваем голод на 10
            }
            else
            {
                Console.WriteLine($"{Name} не может работать. Попробуйте отдохнуть или поесть."); // Сообщаем о проблемах
            }
        }

        // Метод, моделирующий отдых персонажа
        public void Rest()
        {
            Console.WriteLine($"{Name} отдыхает...");
            Energy += 20; // Увеличиваем энергию на 20
            if (Energy > 100) Energy = 100; // Ограничиваем максимальную энергию 100
        }

        // Метод, моделирующий питание персонажа
        public void Feed()
        {
            // Проверяем, достаточно ли голода, чтобы поесть
            if (Hunger >= 10)
            {
                Console.WriteLine($"{Name} ест...");
                Hunger -= 10; // Уменьшаем уровень голода на 10
                if (Hunger < 0) Hunger = 0; // Ограничиваем минимальный уровень голода
            }
            else
            {
                Console.WriteLine($"{Name} не голоден."); // Если голод меньше 10, сообщаем об этом
            }
        }

        // Метод для вывода информации о персонаже
        public override string ToString()
        {
            return $"Имя: {Name}\nВозраст: {Age}\nЭнергия: {Energy} / 100\nГолод: {Hunger} / 100"; // Форматированный вывод
        }
    }
}