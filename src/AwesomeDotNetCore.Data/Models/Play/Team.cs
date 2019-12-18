using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeDotNetCore.Data.Models
{
    [Table("Team", Schema = "Play")]
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
