using SMCinema.Domain.Enumerations.Statuses;
using System.ComponentModel.DataAnnotations;

namespace SMCinema.Infrastructure.Database.Entities
{
    public class Category
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        public CategoryStatus Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required, MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required, MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
