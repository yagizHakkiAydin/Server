
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleOfMinds.Core.Entity;

namespace BattleOfMinds.Models.Models
{
    public class Users : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }


        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string UserType { get; set; }

        [DefaultValue(0)]
        public int Score { get; set; }

        [DefaultValue(0)]

        public int Championship { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        [DefaultValue(false)]
        public bool isApproved { get; set; }

        public string ApprovedCode { get; set; }

    }
}
