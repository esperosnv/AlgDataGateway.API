using Microsoft.AspNetCore.Mvc;
using DataStructure.API.Services;

namespace DataStructure.API.Controllers
{
    [Route("DataStructures")]
    [ApiController]
    public class DataStructureController : ControllerBase
    {
        private readonly IDataStructureSeeder _datastructureSeeder;
        private readonly List<DataStructureClass> dataStructureList;

        public DataStructureController(IDataStructureSeeder datastructureSeeder)
        {
            _datastructureSeeder = datastructureSeeder;
            dataStructureList = _datastructureSeeder.getDataStructureList();
        }

        /// <summary>
        /// Get stack information
        /// </summary> 
        /// 
        [HttpGet("stack")]
        public async Task<ActionResult<DataStructureClass>> GetStackInformation()
        {
            DataStructureClass stackInformation = dataStructureList.Find(x => x.Name == "Stack");
            return Ok(stackInformation);
        }
        /// <summary>
        /// Get stack information
        /// </summary> 
        /// 
        [HttpGet("queue")]
        public async Task<ActionResult<DataStructureClass>> GetQueueInformation()
        {
            DataStructureClass queueInformation = dataStructureList.Find(x => x.Name == "Queue");
            return Ok(queueInformation);
        }
        /// <summary>
        /// Get stack information
        /// </summary> 
        /// 
        [HttpGet("linkedList")]
        public async Task<ActionResult<DataStructureClass>> GetLinkedListInformation()
        {
            DataStructureClass linkedListInformation = dataStructureList.Find(x => x.Name == "LinkedList");
            return Ok(linkedListInformation);
        }
        /// <summary>
        /// Get stack information
        /// </summary> 
        /// 
        [HttpGet("hashTable")]
        public async Task<ActionResult<DataStructureClass>> GetHashTableInformation()
        {
            DataStructureClass hashTableInformation = dataStructureList.Find(x => x.Name == "HashTable");
            return Ok(hashTableInformation);
        }
        /// <summary>
        /// Get stack information
        /// </summary> 
        /// 
        [HttpGet("binaryTree")]
        public async Task<ActionResult<DataStructureClass>> GetBinarySearchTreeInformation()
        {
            DataStructureClass binarySearchTreeInformation = dataStructureList.Find(x => x.Name == "Binary Search Tree");
            return Ok(binarySearchTreeInformation);
        }
        /// <summary>
        /// Get graph information
        /// </summary> 
        /// 
        [HttpGet("graph")]
        public async Task<ActionResult<DataStructureClass>> GetGraphInformation()
        {
            DataStructureClass graphInformation = dataStructureList.Find(x => x.Name == "Graph");
            return Ok(graphInformation);
        }
    }
}
