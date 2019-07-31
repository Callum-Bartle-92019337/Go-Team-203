using System;
using System.Collections.Generic;
using System.Text;
using Java.Sql;
using SQLite;//Important

namespace DataExample
{
    class Merchandiser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }//Primary key ID

        public string Name { get; set; }//Merchandiser given name
        public string Number { get; set; }//Merchandiser ID Number for ticket allocation
        public string Address { get; set; }//Merchandiser Address
        public string Email { get; set; }//Merchandiser Email
    }
}
