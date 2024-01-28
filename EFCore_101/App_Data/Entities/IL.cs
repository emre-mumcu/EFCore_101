using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_101.App_Data.Entities
{
    public class IL
    {
        // [Key] attribute is required since the key property name is not Id/ID or does not end with ...Id/...ID
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IlKod { get; set; } = null!;
        public string Il { get; set; } = null!;
    }
}
