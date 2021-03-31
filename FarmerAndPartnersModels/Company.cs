using FarmerAndPartnersModels.BaseModel;
using System.Collections.Generic;

namespace FarmerAndPartnersModels
{
    public class Company : BaseEntity
    {
        public int ContractStatusId { get; set; }
        public virtual ContractStatus ContractStatus { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public override string ToString() => $"{base.ToString()}" +
                                             $"{nameof(ContractStatusId)}: {ContractStatus.Id}" +
                                             $"{nameof(ContractStatus)}: {ContractStatus.Definition}" +
                                             $"{nameof(Users)}: {Users?.Count}";
    }
}
