using System.ComponentModel.DataAnnotations;

namespace Algorithms.API.Models
{
    public class DataSet
    {
        [Required]
        public List<int> values { get; set; }
    }
}
