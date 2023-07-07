using System;

namespace LinkedListReverse
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            LinkedList<int> intList = new LinkedList<int>();
            intList.Add(6); 
            intList.Add(4);
            intList.Add(1);
            intList.Add(2);
            intList.Add(9);

            Console.WriteLine("Pre reverse list with ints");
            intList.Write();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            intList.Reverse();
            Console.WriteLine("Reversed list with ints");
            intList.Write();
            
            // as extra test that generic typing also works.
            LinkedList<string> stringList = new LinkedList<string>();
            stringList.Add("hey"); 
            stringList.Add("how");
            stringList.Add("is");
            stringList.Add("it");
            stringList.Add("going");

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Pre reverse list with strings");
            stringList.Write();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            stringList.Reverse();
            Console.WriteLine("Reversed list with strings");
            stringList.Write();
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> firstNode;

        public void Add(T value)
        {
            var nodeToAdd = new LinkedListNode<T>(value);

            if (firstNode == null)
            {
                // no next references to be set because this is the first one.
                firstNode = nodeToAdd;
            }
            else
            {
                var current = firstNode;
                //loop through every node starting at the first until the end of the linkedlist.
                while (current.NextNode != null)
                {
                    // replace the current with a reference of the next. because its in a while loop this wont happen at the last one where the reference would be null.
                    current = current.NextNode;
                }
                // at the last iteration of the list set the next reference of the node to the new node to add.
                current.NextNode = nodeToAdd;
            }
        }

        public void Reverse()
        {
            // previous keeps track of the previous node that has been checked and reversed
            LinkedListNode<T> previousNode = null;
            var currentNode = firstNode;
            
            // now we get to the fun part :)
            while (currentNode != null)
            {
                // This stores the next reference of the original order.
                var originalNextNode = currentNode.NextNode;
                // We change the reference of the next node to the previous node. This reverses the connection. And continously moves the node to the correct position.
                // if the first node is 6, second is 4, third is 1 next node for 6 gets set to null. the next for 4 is set to 6 and the next for 1 is set to 4 and so on if the list is longer.
                // for the first node this will be set to null since it will now become the last node throughout this process.
                currentNode.NextNode = previousNode;
                //currentNode now becomes the previousNode
                previousNode = currentNode;
                // and the new current node is the original next node.
                // essentially just moving to the next index in the original list.
                currentNode = originalNextNode;
                // by repeating these steps we esentially just traverse the entire list and its connections and reverse said connections.
            }
            //after running the while loop all references have been reversed and the current previousnode is now the start of all the references and is not referenced by any nextNode
            firstNode = previousNode;
        }

        // just a quality of life function to write the entire list
        public void Write()
        {
            var current = firstNode;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.NextNode;
            }
        }
    }

    public class LinkedListNode<T>
    {
        //reference to the next node in the list.
        public LinkedListNode<T> NextNode { get; set; }
        //value stored in the node.
        public T Value { get; }

        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
}