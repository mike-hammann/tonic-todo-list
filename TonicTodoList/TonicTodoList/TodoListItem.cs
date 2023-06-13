using System.ComponentModel.DataAnnotations;

namespace TonicTodoList
{
    public class TodoListItem
    {
        [Key]
        public int ID { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
    }
}