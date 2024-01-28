﻿namespace EFCore_101.App_Data.Entities
{
    public class State: EntityBase
    {
        public string StateName { get; set; } = null!;
        public ICollection<City>? Cities { get; set; }
    }
}
