using EFCore_101.App_Data.Abstract;

namespace EFCore_101.App_Data.Entities
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
