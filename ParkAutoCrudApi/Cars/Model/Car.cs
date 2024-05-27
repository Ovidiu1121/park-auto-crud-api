using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkAutoCrudApi.Cars.Model
{
    [Table("car")]
    public class Car
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("brand")]
        public string Brand { get; set; }

        [Required]
        [Column("price")]
        public int Price { get; set; }

        [Required]
        [Column("horse_power")]
        public int Horse_power { get; set; }

        [Required]
        [Column("fabrication_year")]
        public int Fabrication_year { get; set; }


    }
}
