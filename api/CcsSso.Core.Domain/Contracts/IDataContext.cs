using CcsSso.DbModel.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CcsSso.Domain.Contracts
{
  public interface IDataContext
  {
    DbSet<Party> Party { get; set; }

    DbSet<PartyType> PartyType { get; set; }

    DbSet<Organisation> Organisation { get; set; }

    DbSet<TradingOrganisation> TradingOrganisation { get; set; }

    DbSet<EnterpriseType> EnterpriseType { get; set; }

    DbSet<OrganisationEnterpriseType> OrganisationEnterpriseType { get; set; }

    DbSet<ProcurementGroup> ProcurementGroup { get; set; }

    DbSet<Person> Person { get; set; }

    DbSet<User> User { get; set; }

    DbSet<UserGroup> UserGroup { get; set; }

    DbSet<UserGroupMembership> UserGroupMembership { get; set; }

    DbSet<UserSettingType> UserSettingType { get; set; }

    DbSet<UserSetting> UserSetting { get; set; }

    DbSet<IdentityProvider> IdentityProvider { get; set; }

    DbSet<CcsAccessRole> CcsAccessRole { get; set; }

    DbSet<UserAccessRole> UserAccessRole { get; set; }

    DbSet<OrganisationAccessRole> OrganisationAccessRole { get; set; }

    // TODO - clarify
    // DbSet<UserGroupAccessRole> UserGroupAccessRole { get; set; }

    DbSet<ContactPoint> ContactPoint { get; set; }

    DbSet<ContactDetail> ContactDetail { get; set; }

    DbSet<PhysicalAddress> PhysicalAddress { get; set; }

    DbSet<VirtualAddress> VirtualAddress { get; set; }

    DbSet<VirtualAddressType> VirtualAddressType { get; set; }

    DbSet<ContactPointReason> ContactPointReason { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  }
}
