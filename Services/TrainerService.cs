using wt_lab2_2oop_talashkevich.Interfaces;
using wt_lab2_2oop_talashkevich.Models;

namespace wt_lab2_2oop_talashkevich.Services;

public class TrainerService : IItemService<Trainer>
{
    private readonly List<Trainer> trainers = new();

    public void Add(Trainer item)
    {
        trainers.Add(item);
    }

    public void Add(Trainer item, string description)
    {
        Console.WriteLine($"Описание: {description}");
        trainers.Add(item);
    }

    public List<Trainer> GetAll()
    {
        return trainers;
    }

    public Trainer? GetById(int id)
    {
        return trainers.FirstOrDefault(t => t.Id == id);
    }

    protected void PrintServiceInfo()
    {
        Console.WriteLine($"Количество тренеров: {trainers.Count}");
    }
}
public class TrainerServiceTest : TrainerService
{
    public void ShowServiceInfo()
    {
        PrintServiceInfo();
    }
}