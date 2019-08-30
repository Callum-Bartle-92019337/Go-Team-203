using System;
using System.Collections.Generic;
using DataExample.DataModel;
using Java.Lang;
using Xamarin.Forms;

namespace DataExample.GlobalMethods
{
    public class BindingObject
    {
        //Global stuff
        public string FILE_PATH { get; set; }
        public string Font1 { get; set; }
        public string Font2{ get; set; }
        public string Font3 { get; set; }
        public string FontSmall { get; set; }
        public string FontMed { get; set; }
        public string FontLarge { get; set; }
        public string ColorTx1 { get; set; }
        public string ColorTx2 { get; set; }
        public string ColorTx3 { get; set; }
        public string ColorBg1 { get; set; }
        public string ColorBg2 { get; set; }
        public string ColorBg3 { get; set; }
        public string ColorFg1 { get; set; }
        public string ColorFg2 { get; set; }
        public string ColorFg3 { get; set; }


        //Database stuff
        public Activities Activities { get; set; } = null;
    }

    public static class Globals
    {
        public static void DropTables<T>()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.DropTable<T>();
            conn.Dispose();
        }

        public static void CreateTables<T>()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.CreateTable<T>();
            conn.Dispose();
        }

        //Insert a class object into the DB
        public static async void InsertIntoTable<T>(T classObject, Page page)
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Insert row and display if Success
            if (conn.Insert(classObject) != 0)
            { await page.DisplayAlert("Success", "", "OK"); }
            else
            { await page.DisplayAlert("Failed", "", "OK"); }
            //Close connection
            conn.Dispose();
        }

        //When we click the finalize button
        public static async void InsertAllIntoTable<T>(List<T> listObject, Page page)
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Insert row and display if Success
            if (conn.InsertAll(listObject) != 0)
            { await page.DisplayAlert("Success", "", "OK"); }
            else
            { await page.DisplayAlert("Failed", "", "OK"); }
            //Close connection
            conn.Dispose();
        }
    }
}
