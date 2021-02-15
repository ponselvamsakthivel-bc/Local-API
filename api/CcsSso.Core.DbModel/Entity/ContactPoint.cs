using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CcsSso.DbModel.Entity
{
  public class ContactPoint : BaseEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Party Party { get; set; }

    public int PartyId { get; set; }

    public PartyType PartyType { get; set; }

    public int PartyTypeId { get; set; }

    public ContactDetail ContactDetail { get; set; }

    public int ContactDetailId { get; set; }

    public ContactPointReason ContactPointReason { get; set; }

    public int ContactPointReasonId { get; set; }
  }
}
