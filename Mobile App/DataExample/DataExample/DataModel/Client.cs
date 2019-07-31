using System;
using System.Collections.Generic;
using System.Text;
using Java.Sql;
using SQLite;//Important

namespace DataExample
{
    class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }//Primary key ID

        public string Name { get; set; }//Clients given name
        public string Number { get; set; }//Clients Phone number
        public string Address { get; set; }//Clients Address
        public string Email { get; set; }//Clients Email
    }
}
