namespace DataStructure.API.Services
{
    public interface IDataStructureSeeder
    {
        List<DataStructureClass> getDataStructureList();
    }

    public class DataStructureSeeder : IDataStructureSeeder
    {

        public List<DataStructureClass> getDataStructureList()
        {
            List<DataStructureClass> dataStructureList = new List<DataStructureClass>();

            DataStructureClass stack = new DataStructureClass(
           "Stack",
           "A stack is an abstract data type that serves as a collection of elements, with two main principal operations:" +
           "\n Push, which adds an element to the collection, and \n Pop, which removes the most recently added element that was not yet removed." +
           "\n The order in which elements come off a stack gives rise to its alternative name, LIFO(last in, first out).",
           "AVERAGE TIME COMPLEXITY for operations Push, Pop and Peek is O(1)");

            DataStructureClass queue = new DataStructureClass(
                "Queue",
                " A queue is defined as a linear data structure that is open at both ends and the operations are performed in First In First Out (FIFO) order." +
                "We define a queue to be a list in which all additions to the list are made at one end, and all deletions from the list are made at the other end." +
                "The element which is first pushed into the order, the operation is first performed on that.",
                "BigONatation");

            DataStructureClass linkedList = new DataStructureClass(
                "LinkedList",
                "A linked list is a linear data structure, in which the elements are not stored at contiguous memory locations. In simple words, a linked list consists of nodes where each node contains a data field and a reference(link) to the next node in the list.",
                "Search O(n), Insert O(1), Deletion O(1)");

            DataStructureClass hashTable = new DataStructureClass(
                "HashTable",
                "Description",
                "BigO");

            DataStructureClass binarySearchTree = new DataStructureClass(
                "Binary Search Tree",
                "Description",
                "BigO");

            DataStructureClass graph = new DataStructureClass(
                "Graph",
                "Description",
                "BigO");

            dataStructureList.Add(stack);
            dataStructureList.Add(queue);
            dataStructureList.Add(linkedList);
            dataStructureList.Add(hashTable);
            dataStructureList.Add(binarySearchTree);
            dataStructureList.Add(graph);
            return dataStructureList;
        }
    }
}
