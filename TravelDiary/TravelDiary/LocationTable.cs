﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TravelDiary
{
    class LocationTable
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]

        public int id { get; set; } // AutoIncrement and set primarykey  

        [MaxLength(25)]

        public string locationName { get; set; }

        [MaxLength(15)]

        public string latitude { get; set; }

        [MaxLength(15)]

        public string longitude { get; set; }
    }
}