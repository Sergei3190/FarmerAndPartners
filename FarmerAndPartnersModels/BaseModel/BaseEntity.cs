using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmerAndPartnersModels.BaseModel
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public override string ToString() => $"{nameof(Id)}: {Id}" +
                                             $"{nameof(Name)}: {Name}";
    }
}
