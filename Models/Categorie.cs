using System.ComponentModel.DataAnnotations;

namespace TP6WebAPI.Models
{
    public class Categorie
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

