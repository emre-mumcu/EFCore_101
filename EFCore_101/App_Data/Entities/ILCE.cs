using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_101.App_Data.Entities
{
    public class ILCE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IlceKod { get; set; } = null!;
        public string Ilce { get; set; } = null!;

        // FK
        public string IlKod { get; set; } = null!;
    }
}
