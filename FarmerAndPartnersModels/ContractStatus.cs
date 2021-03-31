using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmerAndPartnersModels
{
    public class ContractStatus
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Definition { get; set; }
        public virtual ICollection<Company> Companies { get; set; } = new HashSet<Company>();
        public override string ToString() => $"{nameof(Id)}: {Id}" +
                                             $"{nameof(Definition)}: {Definition}";
    }
}
