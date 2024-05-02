using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day12First.Models
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        public Season HarvestSeason { get; set; }
        public enum FruitCategory
        {
            Citrus,
            Berry,
            Tropical,
            StoneFruit,
            Melon,
            Apple,
            Grape,
            Other
        }
        public FruitCategory Categories { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsChecked { get; set; }
    }
}
