using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using BattleOfMinds.Core.Entity;

#region Default Convention
namespace BattleOfMinds.Models.Models
{
    public class Questions : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string QuestionType { get; set; }

        [Required]
        [StringLength(500)]
        public string QuestionCategory { get; set; }

        [Required]
        [StringLength(500)]
        public string QuestionDescription { get; set; }

        [Required]
        [StringLength(500)]
        public string QuestionAnswer { get; set; }

        [AllowNull]
        [StringLength(200)]
        public string Option1 { get; set; }

        [AllowNull]
        [StringLength(200)]
        public string Option2 { get; set; }

        [AllowNull]
        [StringLength(200)]
        public string Option3 { get; set; }

        [AllowNull]
        [StringLength(200)]
        public string Option4 { get; set; }

        [DefaultValue(false)]
        public bool isApproved { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        [DefaultValue(1)]
        public int CompetitionsId { get; set; }


    }
}
#endregion