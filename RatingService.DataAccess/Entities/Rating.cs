using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatingService.DataAccess.Entities
{
    [Table("rating")]
    public class Rating
    {
        [Key]
        [Column("rating_id")]
        public Guid RatingId { get; set; }

        [Required]
        [Column("user_id")]
        public Guid UserId { get; set; } 

        [Column("average_rating", TypeName = "decimal(3, 2)")]
        public decimal AverageRating { get; set; } = 0.0m;

        [Column("count_5_stars")]
        public int Count5Stars { get; set; } = 0;

        [Column("count_4_stars")]
        public int Count4Stars { get; set; } = 0;

        [Column("count_3_stars")]
        public int Count3Stars { get; set; } = 0;

        [Column("count_2_stars")]
        public int Count2Stars { get; set; } = 0;

        [Column("count_1_star")]
        public int Count1Star { get; set; } = 0;
    }
}
