﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScrumBoard.Model
{
    [Table("UserStory_TeamMember")]
    public partial class UserStoryTeamMember
    {
        [Key]
        [Column("UserStory_ID")]
        public int UserStoryId { get; set; }
        [Key]
        [Column("TeamMember_ID")]
        public int TeamMemberId { get; set; }
    }
}