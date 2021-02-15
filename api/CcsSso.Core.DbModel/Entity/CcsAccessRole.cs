using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CcsSso.DbModel.Entity
{
  public class CcsAccessRole : BaseEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string CcsAccessRoleName { get; set; }

    public string CcsAccessRoleDescription { get; set; }

    public List<UserAccessRole> UserAccessRoles { get; set; }
  }
}
