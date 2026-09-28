namespace wt_lab2_2oop_talashkevich.Interfaces;

public interface IItemService<T>
{
    void Add(T item);
    void Add(T item, string description);
    List<T> GetAll();
    T? GetById(int id);
}