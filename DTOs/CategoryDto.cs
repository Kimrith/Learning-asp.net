using System.ComponentModel.DataAnnotations;

namespace Learning.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set;}
        public string NameCategory { get; set; } = string.Empty;
    }
}
