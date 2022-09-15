using Microsoft.AspNetCore.Mvc;
using Algorithms.API.Services;
using DataModels;
using Algorithms.API.RabbitMQ;


namespace Algorithms.API.Controllers
{

    [Route("Algorithms")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {

        private readonly IAlgorythmsImplementation _algorithmsImplementation;
        private readonly IRabbitMqService _mqService;

        public AlgorithmsController(IAlgorythmsImplementation algorythmsImplementation, IRabbitMqService mqService)
        {
            _algorithmsImplementation = algorythmsImplementation;
            _mqService = mqService;
        }

        /// <summary>
        /// Get sorted list of integers  
        /// </summary> 

        [HttpPost("Sequence")]
        public async Task<ActionResult> calculateSequence([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.bubbleSort, unsortedList);

            _mqService.SendMessage(dataSetResponse); 

            return Ok("Сообщение отправлено");
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

        [HttpPost("SelectionSort")]
        public async Task<ActionResult<DataSetResponse>> sortingBySelectionSortAlgorithm([FromBody] DataSet unsortedList)
        {
            DataSetResponse dataSetResponse = _algorithmsImplementation.getDataSetResponseFromAlgorythm(_algorithmsImplementation.selectionSort, unsortedList);
            return Ok(dataSetResponse);
        }

    }
}
