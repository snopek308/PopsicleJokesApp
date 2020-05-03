using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopsicleJokesApp.Models
{
    public class JokeItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Joke { get; set; }
    }
}
