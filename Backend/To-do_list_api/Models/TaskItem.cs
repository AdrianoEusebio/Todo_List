using System.ComponentModel.DataAnnotations.Schema;

[Table("TaskItems")]
public class TaskItem
{ 
    [Column("Id")]
    public long Id { get; set; }
    [Column("Name")]
    public string? Name { get; set; }
    [Column("IsComplete")]
    public bool IsComplete { get; set; }
}