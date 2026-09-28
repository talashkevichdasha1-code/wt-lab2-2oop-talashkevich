namespace wt_lab2_2oop_talashkevich.Models;

public class Workout : BaseEntity
{
    public string WorkoutType { get; set; }
    public int DurationMinutes { get; set; }
    public string TrainerName { get; set; }

    public Workout(
        int id,
        string workoutType,
        int durationMinutes,
        string trainerName)
        : base(id)
    {
        WorkoutType = workoutType;
        DurationMinutes = durationMinutes;
        TrainerName = trainerName;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Тип тренировки: {WorkoutType}");
        Console.WriteLine($"Продолжительность: {DurationMinutes} минут");
        Console.WriteLine($"Тренер: {TrainerName}");
        Console.WriteLine($"Дата создания: {CreatedAt}");
    }
}