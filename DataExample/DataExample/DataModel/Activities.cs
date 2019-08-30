using SQLite;

namespace DataExample.DataModel
{
    public class Activities
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; } //Primary key Phrases ID 

        public string Title { get; set; } //
        public string Content { get; set; } //
        public string Photo { get; set; } //URL or file path
    }
}