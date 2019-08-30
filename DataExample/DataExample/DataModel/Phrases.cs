using SQLite;

namespace DataExample.DataModel
{
    public class Phrases
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; } //Primary key Phrases ID 

        public string EnglishPhrase { get; set; } //
        public string JapanesePhrase { get; set; } //
        public string PhoneticPhrase { get; set; } //
        public int Type { get; set; } //1 Travel, 2 Food, 3 Common
    }
}