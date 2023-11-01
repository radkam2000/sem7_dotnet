using System.ComponentModel.DataAnnotations;
public class Genre
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}