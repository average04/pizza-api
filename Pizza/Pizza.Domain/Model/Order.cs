namespace Pizza.Domain;

public class Order : Entity<long>
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}
