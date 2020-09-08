using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Step Step { get; set; }

        [ForeignKey("Step")]
        public int StepId { get; set; }
    }
}
