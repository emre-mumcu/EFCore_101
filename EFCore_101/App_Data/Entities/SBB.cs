using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_101.App_Data.Entities
{
    public class SBB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SbbKod { get; set; } = null!;
        public string SemtBucakBelde { get; set; } = null!;

        // FK
        public string IlKod { get; set; } = null!;
        public string IlceKod { get; set; } = null!;
    }
}
