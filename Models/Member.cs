namespace wt_lab2_2oop_talashkevich.Models;

public class Member : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string MembershipType { get; set; }

    public Member(
        int id,
        string name,
        int age,
        string membershipType)
        : base(id)
    {
        Name = name;
        Age = age;
        MembershipType = membershipType;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Клиент: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Тип абонемента: {MembershipType}");
        Console.WriteLine($"Дата регистрации: {CreatedAt}");
    }
}