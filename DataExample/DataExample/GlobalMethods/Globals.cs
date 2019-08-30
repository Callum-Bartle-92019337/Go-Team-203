using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace DataExample.GlobalMethods
{
    public static class Globals
    {
        public static void DropTables<T>()
        {
            //DB Connection
            var conn = new SQLiteConnection(App.dbPath);
            //Drop the table we were passed
            conn.DropTable<T>();
            //Close the DB Connection
            conn.Dispose();
        }

        public static void CreateTables<T>()
        {
            //DB Connection
            var conn = new SQLiteConnection(App.dbPath);
            //Creates the table of type T
            conn.CreateTable<T>();
            //Close the DB Connection
            conn.Dispose();
        }

        //Insert a class object into the DB
        public static async void InsertIntoTable<T>(T classObject, Page page)
        {
            //DB Connection
            var conn = new SQLiteConnection(App.dbPath);
            //Insert row and display if Success
            if (conn.Insert(classObject) != 0)
                await page.DisplayAlert("Success", "", "OK");
            else
                await page.DisplayAlert("Failed", "", "OK");
            //Close connection
            conn.Dispose();
        }

        //When we click the finalize button
        public static async void InsertAllIntoTable<T>(List<T> listObject, Page page)
        {
            //DB Connection
            var conn = new SQLiteConnection(App.dbPath);
            //Insert row and display if Success
            if (conn.InsertAll(listObject) != 0)
                await page.DisplayAlert("Success", "", "OK");
            else
                await page.DisplayAlert("Failed", "", "OK");
            //Close connection
            conn.Dispose();
        }
    }
}