using System.ComponentModel.DataAnnotations;

namespace MyMvcProject.Models
{
    public class LocationData
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
