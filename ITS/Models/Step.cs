using System.Collections.Generic;

namespace ITS.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
