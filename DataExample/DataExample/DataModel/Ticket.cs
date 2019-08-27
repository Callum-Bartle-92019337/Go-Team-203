using System;
using SQLite;

//Important

namespace DataExample.DataModel
{
    public class Ticket
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }//Primary key ticket ID 

        public string Notes { get; set; }//Any notes stored on the ticket
        public string Merchandiser { get; set; }//The merchandisers Number, NOT their ID
        public DateTime Date { get; set; }//The date it was created
        public DateTime DateDue { get; set; }//The date its due
        public int TimeTaken { get; set; } = 0;//The timer stored for each ticket

        public bool Completed { get; set; } = false;//Weather or not the ticket is finished
    }
}
