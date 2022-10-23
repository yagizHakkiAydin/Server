using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfMinds.Models.Models
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string QuestionTypeName { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }
    }
}
