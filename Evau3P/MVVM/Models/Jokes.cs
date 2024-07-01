using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evau3P.MVVM.Models
{
    public class Jokes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string value { get; set; }
        public int ApiId { get; set; }
    }
}
