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
                "\nPush, which adds an element to the collection, and \n Pop, which removes the most recently added element that was not yet removed." +
                "\nThe order in which elements come off a stack gives rise to its alternative name, LIFO(last in, first out)." +
                "\nStack is useful when we need quick access to only the latest added element. Its drawback is slow access to other elements.",
                "AVERAGE TIME COMPLEXITY for operations Push, Pop and Peek is O(1)");

            DataStructureClass queue = new DataStructureClass(
                "Queue",
                "A queue is defined as a linear data structure that is open at both ends and the operations are performed in First In First Out (FIFO) order." +
                " We define a queue to be a list in which all additions to the list are made at one end, and all deletions from the list are made at the other end." +
                " The element which is first pushed into the order, the operation is first performed on that." +
                "\nQueue is useful when we need quick access to only the first element(s) added. We cannot access next elements without removing the first one.",
                "Average time complexity for accessing the first element and adding a new element is O(1), other elements O(n)");

            DataStructureClass linkedList = new DataStructureClass(
                "LinkedList",
                "A linked list is a linear data structure, in which the elements are not stored at contiguous memory locations." +
                " In simple words, a linked list consists of nodes where each node contains a data field and a reference (link) to the next node in the list." +
                "\nLinked List is useful when we need access to all elements, but quick access to the first element is critical." +
                " Unlike array, Linked List is slow at accessing arbitrary elements.",
                "Averate time complexity: Search O(n), Insertion O(1), Deletion O(1)");

            DataStructureClass hashTable = new DataStructureClass(
                "HashTable",
                "Hash Table is a data structure that implements an associative array or dictionary. It maps keys to values." +
                " A hash table uses a hash function to compute a hash code into an array of buckets, from which the desired value can be found." +
                "\nHash table is useful when we need quick search, insertion and deletion of elements." +
                " The drawback is that hash table cannot store the same elements. Also, it is slow when the so called key collision occurs.",
                "Average time complexity for Search, Insertion and Deletion is O(1), worst O(n)");

            DataStructureClass binarySearchTree = new DataStructureClass(
                "Binary Search Tree",
                "Binary Search Tree is a node-based binary tree data structure which has the following properties:" +
                "\nThe left subtree of a node contains only nodes with keys lesser than the node’s key." +
                "\nThe right subtree of a node contains only nodes with keys greater than the node’s key." +
                "\nThe left and right subtree each must also be a binary search tree." +
                "\nBinary Search Tree is useful when we need to search an element in an existing structure, but adding and deleting new elements occurs rarely.",
                "Average time complexity for Access, Search, Insertion and Deletion is O(log(n)), worst O(n)");

            DataStructureClass graph = new DataStructureClass(
                "Graph",
                "A Graph is a non-linear data structure consisting of vertices and edges." +
                " The vertices are sometimes also referred to as nodes and the edges are lines or arcs that connect any two nodes in the graph." +
                " Graphs are used to solve many real-life problems. Graphs are used to represent networks." +
                " The networks may include paths in a city or telephone network or circuit network.",
                "Adding edge: O(1), removing edge: O(1) for adjacency matrix and O(N) for adjacency list");

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
