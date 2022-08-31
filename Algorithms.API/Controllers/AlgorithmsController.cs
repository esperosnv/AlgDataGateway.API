using Microsoft.AspNetCore.Mvc;
using Algorithms.API.Services;
using Algorithms.API.Models;

namespace Algorithms.API.Controllers
{

    [Route("api/Algorithms")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {

        private readonly IAlgorythmsImplementation _algorithmsImplementation;

        public AlgorithmsController(IAlgorythmsImplementation algorythmsImplementation)
        {
            _algorithmsImplementation = algorythmsImplementation;
        }


        /// <summary>
        /// Get sorted list of integers by bubble sort algorithm 
        /// </summary> 
         
        [HttpPost("BubbleSort")]
        public async Task<ActionResult<DataSetResponse>> sortingByBubbleSortAlgorithm([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.bubbleSort, unsortedList);
            return Ok(dataSetResponse);
        }

        /// <summary>
        /// Get sorted list of integers by insertion sort algorithm 
        /// </summary> 

        [HttpPost("InsertionSort")]
        public async Task<ActionResult<DataSetResponse>> sortingByInsertionSortAlgorithm([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.insertionSort, unsortedList);
            return Ok(dataSetResponse);
        }

        [HttpPost("MergeSort")]
        public async Task<ActionResult<DataSetResponse>> sortingByMergeSortAlgorithm([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.mergeSort, unsortedList);
            return Ok(dataSetResponse);
        }

        [HttpPost("QuickSort")]
        public async Task<ActionResult<DataSetResponse>> sortingByQuickSortAlgorithm([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.mergeSort, unsortedList);
            return Ok(dataSetResponse);
        }

    }
}
