using System.ComponentModel.DataAnnotations;

namespace Algorithms.API.Models
{
    public class DataSetResponse
    {
        [Required]
        public List<int> sortedValue { get; set; }

        [Required]
        public double timeOfCalculation { get; set; }

    }
}
