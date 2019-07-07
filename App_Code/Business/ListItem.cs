using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content.Business
{
    /// <summary>
    /// Represents a smaller version of the artist or album, used for wish lists, viewing history, or shopping carts
    /// </summary>
    public class ListItem
    {
        private int _id;
        private string _title;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public ListItem(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}