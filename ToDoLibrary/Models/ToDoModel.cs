using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLibrary.Models
{
    public class ToDoModel
    {

        public int Id { get; set; }
        public string? Task { get; set; }
        public int AssignedTo { get; set; }
        public bool IsComplete { get; set; }
    }
}
