using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CylanceContext.Entities
{
    [Table("Guid", Schema = "public")]
    public class Guid
    {
        [Key]
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
