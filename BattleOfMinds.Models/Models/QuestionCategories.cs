using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleOfMinds.Core.Entity;

namespace BattleOfMinds.Models.Models
{
    public class QuestionCategories : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string QuestionCategoryName { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }
    }
}
