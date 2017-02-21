using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp.Models
{
    [Table("UserInfo")]
    public class UserInfoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Nickname is too long, must be longer than 2 and less than 100 characters.", MinimumLength = 3)]
        [DisplayName("Nick")]
        public string NickName { get; set; }

        [Required(ErrorMessage ="Date and time are required.")]
        [DataType(DataType.DateTime)]
        [DisplayName("Favorite date and time")]
        public DateTime FavoriteDateTime { get; set; }

        [Required(ErrorMessage = "Favorite number is required.")]
        [DisplayName("Favorite number")]
        [Range(float.MinValue, float.MaxValue, ErrorMessage = "Max or min number exceeded.")]
        public float FavoriteNumber { get; set; }

        [Required(ErrorMessage = "Day of week is required.")]
        [DisplayName("Favorite day of week")]
        [Column("FavoriteDayOfWeekId")]
        public int FavoriteDayOfWeekId { get; set; }

        [ForeignKey("Id")]
        public virtual ICollection<DaysOfWeek> DaysOfWeek { get; set; }

    }

    [Table("DaysOfWeek")]
    public class DaysOfWeek
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }

}