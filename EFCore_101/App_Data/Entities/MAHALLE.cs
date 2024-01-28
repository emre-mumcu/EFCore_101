using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_101.App_Data.Entities
{
    public class MAHALLE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MahalleKod { get; set; } = null!;
        public string Mahalle { get; set; } = null!;
        public string PostaKod { get; set; } = null!;

        // FK
        public string IlKod { get; set; } = null!;
        public string IlceKod { get; set; } = null!;
        public string SbbKod { get; set; } = null!;
    }
}
