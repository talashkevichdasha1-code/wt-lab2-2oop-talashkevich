using wt_lab2_2oop_talashkevich.Models;
using wt_lab2_2oop_talashkevich.Interfaces;
using wt_lab2_2oop_talashkevich.Services;

Console.WriteLine("======================================");
Console.WriteLine("   СПОРТИВНЫЙ КЛУБ «FITNESS CLUB»");
Console.WriteLine("======================================");
Console.WriteLine("Добро пожаловать!");
Console.WriteLine();
Console.WriteLine("Выберите операцию:");
Console.WriteLine("1. Работа с тренерами");
Console.WriteLine("2. Работа с клиентами");
Console.WriteLine("3. Работа с абонементами");
Console.WriteLine("4. Работа с тренировками");
Console.WriteLine("0. Выход");
Console.WriteLine();
Console.Write("Введите номер операции: ");

string? choice = Console.ReadLine();

Console.WriteLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Выбран раздел: Тренеры");
        break;

    case "2":
        Console.WriteLine("Выбран раздел: Клиенты");
        break;

    case "3":
        Console.WriteLine("Выбран раздел: Абонементы");
        break;

    case "4":
        Console.WriteLine("Выбран раздел: Тренировки");
        break;

    case "0":
        Console.WriteLine("Выход из программы.");
        break;

    default:
        Console.WriteLine("Ошибка: неизвестная операция.");
        break;
}
Console.WriteLine();
Console.WriteLine("=== Информация о тренере ===");

Trainer trainer = new Trainer(
    1,
    "Анна Петрова",
    "Фитнес-тренер",
    5
);

trainer.PrintInfo();

Console.WriteLine();
Console.WriteLine("=== Работа с TrainerService ===");

IItemService<Trainer> trainerService = new TrainerService();

Trainer trainer2 = new Trainer(
    2,
    "Максим Иванов",
    "Персональный тренер",
    7
);

trainerService.Add(trainer2);

trainerService.Add(
    new Trainer(3, "Елена Смирнова", "Йога", 4),
    "Тренер по групповым занятиям"
);

Console.WriteLine();
Console.WriteLine("Все тренеры:");

foreach (Trainer item in trainerService.GetAll())
{
    item.PrintInfo();
    Console.WriteLine("-----------------------------");
}

Console.WriteLine();
Console.WriteLine("=== Поиск тренера по ID ===");

Trainer? foundTrainer = trainerService.GetById(2);

if (foundTrainer != null)
{
    foundTrainer.PrintInfo();
}
else
{
    Console.WriteLine("Тренер не найден.");
}

Console.WriteLine();
Console.WriteLine("=== Демонстрация protected ===");

TrainerServiceTest serviceTest = new TrainerServiceTest();

serviceTest.Add(new Trainer(
    4,
    "Олег Кузнецов",
    "Кардио-тренер",
    6
));

serviceTest.ShowServiceInfo();

Console.WriteLine();
Console.WriteLine("=== Работа со списком тренеров ===");

List<Trainer> trainerList = new List<Trainer>
{
    new Trainer(1, "Анна Петрова", "Фитнес-тренер", 5),
    new Trainer(2, "Максим Иванов", "Персональный тренер", 7),
    new Trainer(3, "Елена Смирнова", "Йога", 4),
    new Trainer(4, "Олег Кузнецов", "Кардио-тренер", 6),
    new Trainer(5, "Мария Волкова", "Пилатес", 3),
    new Trainer(6, "Дмитрий Орлов", "Силовой тренер", 8)
};

foreach (Trainer item in trainerList)
{
    item.PrintInfo();
    Console.WriteLine("-----------------------------");
}

Console.WriteLine();
Console.WriteLine("=== Dictionary тренеров ===");

Dictionary<int, Trainer> trainerDictionary = new Dictionary<int, Trainer>
{
    { 1, new Trainer(1, "Анна Петрова", "Фитнес-тренер", 5) },
    { 2, new Trainer(2, "Максим Иванов", "Персональный тренер", 7) },
    { 3, new Trainer(3, "Елена Смирнова", "Йога", 4) },
    { 4, new Trainer(4, "Олег Кузнецов", "Кардио-тренер", 6) }
};

if (trainerDictionary.TryGetValue(2, out Trainer? selectedTrainer))
{
    Console.WriteLine("Тренер найден:");
    selectedTrainer.PrintInfo();
}
else
{
    Console.WriteLine("Тренер с таким ID не найден.");
}

Console.WriteLine();
Console.WriteLine("=== LINQ: Where ===");

var experiencedTrainers = trainerList
    .Where(t => t.ExperienceYears >= 5);

foreach (var trainerItem in experiencedTrainers)
{
    Console.WriteLine($"{trainerItem.Name} — {trainerItem.ExperienceYears} лет опыта");
}

Console.WriteLine();
Console.WriteLine("=== LINQ: OrderBy ===");

var sortedTrainers = trainerList
    .OrderBy(t => t.ExperienceYears);

foreach (var trainerItem in sortedTrainers)
{
    Console.WriteLine($"{trainerItem.Name} — {trainerItem.ExperienceYears} лет опыта");
}

Console.WriteLine();
Console.WriteLine("=== LINQ: Select ===");

var trainerNames = trainerList
    .Select(t => t.Name);

foreach (var name in trainerNames)
{
    Console.WriteLine(name);
}

Console.WriteLine();
Console.WriteLine("=== Агрегатные методы LINQ ===");

int trainerCount = trainerList.Count();
int totalExperience = trainerList.Sum(t => t.ExperienceYears);
double averageExperience = trainerList.Average(t => t.ExperienceYears);
int minExperience = trainerList.Min(t => t.ExperienceYears);
int maxExperience = trainerList.Max(t => t.ExperienceYears);

Console.WriteLine($"Количество тренеров: {trainerCount}");
Console.WriteLine($"Общий опыт: {totalExperience} лет");
Console.WriteLine($"Средний опыт: {averageExperience:F1} лет");
Console.WriteLine($"Минимальный опыт: {minExperience} лет");
Console.WriteLine($"Максимальный опыт: {maxExperience} лет");

Console.WriteLine();
Console.WriteLine("=== GroupBy по специализации ===");

var trainersBySpecialization = trainerList
    .GroupBy(t => t.Specialization);

foreach (var group in trainersBySpecialization)
{
    Console.WriteLine($"Специализация: {group.Key}");

    foreach (var trainerItem in group)
    {
        Console.WriteLine($"  - {trainerItem.Name}");
    }
}

Console.WriteLine();
Console.WriteLine("=== Блок 3. Асинхронность ===");

await Task.Delay(1000);

Console.WriteLine("Асинхронная операция завершена.");

Console.WriteLine();
Console.WriteLine("=== Асинхронная загрузка тренеров ===");

List<Trainer> loadedTrainers = await LoadTrainersAsync();

foreach (Trainer item in loadedTrainers)
{
    Console.WriteLine($"{item.Name} — {item.Specialization}");
}

static async Task<List<Trainer>> LoadTrainersAsync()
{
    await Task.Delay(1000);

    return new List<Trainer>
    {
        new Trainer(7, "Алексей Морозов", "Фитнес", 5),
        new Trainer(8, "Ольга Соколова", "Йога", 6),
        new Trainer(9, "Ирина Павлова", "Пилатес", 4)
    };
}

Console.WriteLine();
Console.WriteLine("=== Обработка исключений ===");

try
{
    int result = 10 / 2;
    Console.WriteLine($"Результат операции: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Произошла ошибка: {ex.Message}");
}
finally
{
    Console.WriteLine("Блок finally выполнен.");
}

Console.WriteLine();
Console.WriteLine("=== Task.WhenAll ===");

Task task1 = PrintMessageAsync("Загрузка расписания");
Task task2 = PrintMessageAsync("Загрузка списка клиентов");
Task task3 = PrintMessageAsync("Загрузка тренировок");

await Task.WhenAll(task1, task2, task3);

Console.WriteLine("Все асинхронные операции завершены.");

static async Task PrintMessageAsync(string message)
{
    await Task.Delay(500);
    Console.WriteLine(message);
}

Console.WriteLine();
Console.WriteLine("=== CancellationToken ===");

using CancellationTokenSource cancellationTokenSource =
    new CancellationTokenSource();

Task cancellationTask = LongOperationAsync(
    cancellationTokenSource.Token
);

await Task.Delay(1000);

cancellationTokenSource.Cancel();

try
{
    await cancellationTask;
}
catch (OperationCanceledException)
{
    Console.WriteLine("Асинхронная операция была отменена.");
}

static async Task LongOperationAsync(CancellationToken token)
{
    for (int i = 1; i <= 5; i++)
    {
        token.ThrowIfCancellationRequested();

        Console.WriteLine($"Выполняется шаг {i}...");
        await Task.Delay(500, token);
    }
}