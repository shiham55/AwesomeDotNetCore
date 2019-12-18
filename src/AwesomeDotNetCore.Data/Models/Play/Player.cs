using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeDotNetCore.Data.Models
{
    [Table("Player", Schema = "Play")]
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
    }
}
