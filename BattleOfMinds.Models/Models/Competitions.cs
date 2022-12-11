using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleOfMinds.Core.Entity;
using System.Diagnostics.CodeAnalysis;

#region Default Convention
namespace BattleOfMinds.Models.Models
{
    public class Competitions : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string GameMode { get; set; }

        [DefaultValue(0)]
        public int userCapacity { get; set; }

        [DefaultValue(false)]
        public bool isStarted { get; set; }

        public virtual ICollection<Users> currentUsers { get; set; }

        public virtual ICollection<Questions> askedQuestions { get; set; }


    }
}

#endregion
