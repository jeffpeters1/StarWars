using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.CORE.Entities.Main
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
