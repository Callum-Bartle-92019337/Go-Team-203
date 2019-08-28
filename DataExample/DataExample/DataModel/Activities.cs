using System;
using SQLite;
using Xamarin.Forms;

//Important

namespace DataExample.DataModel
{
    public class Activities
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }//Primary key Phrases ID 

        public string Title { get; set; }//
        public string Content { get; set; }//
        public string Photo { get; set; }//

        public ImageSource ImgSrc { get { return ImageSource.FromUri(new Uri(Photo)); } }
    }
}
