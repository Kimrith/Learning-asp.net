namespace Learning.Models
{
    public class Category
    {
        public int Id { get; set; }   // ✅ PRIMARY KEY
        public string NameCategory { get; set; } = string.Empty;
    }
}
