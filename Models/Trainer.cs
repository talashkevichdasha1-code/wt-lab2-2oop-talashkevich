namespace wt_lab2_2oop_talashkevich.Models;

public class Trainer : BaseEntity
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public int ExperienceYears { get; private set; }

    public Trainer(
        int id,
        string name,
        string specialization,
        int experienceYears)
        : base(id)
    {
        Name = name;
        Specialization = specialization;
        ExperienceYears = experienceYears;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Тренер: {Name}");
        Console.WriteLine($"Специализация: {Specialization}");
        Console.WriteLine($"Опыт работы: {ExperienceYears} лет");
        Console.WriteLine($"Дата создания: {CreatedAt}");
    }

    public void UpdateExperience(int years)
    {
        if (years >= 0)
        {
            ExperienceYears = years;
        }
        else
        {
            Console.WriteLine("Ошибка: опыт не может быть отрицательным.");
        }
    }
}