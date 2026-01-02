namespace MVCCourse.Models;

public class Item
{
   public int Id { get; set; }
    public required string  Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
