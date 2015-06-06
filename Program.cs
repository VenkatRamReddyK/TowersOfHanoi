using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    class Program
    {
        static Stack<Node> nodeStack;
        static void Main(string[] args)
        {
            nodeStack = new Stack<Node>();
            Node currentNode = InitStack();
            Node nextNode;
            Node _nextNodeToBePushed;

            while (nodeStack.Count>0)
            {
                //Console.WriteLine("\n "+nodeStack.Count+" \n "+currentNode);
                nextNode=nodeStack.Pop();
                // Base case and print A move from Source to Destination
                if (nextNode.Size == 1)
                {
                    Console.WriteLine("\n Move From : [ " + nextNode.Middle.Source + " ]  to " + nextNode.Middle.Destination + " ]");
                }
                else
                {   // In DFS Approach Push Last , then middle and then first

                    // Pushing Last Node
                    _nextNodeToBePushed =new Node();
                    _nextNodeToBePushed = getNextLastNode(nextNode);
                    nodeStack.Push(_nextNodeToBePushed);

                    // Pushing Middle Node
                    _nextNodeToBePushed = new Node();
                    _nextNodeToBePushed = getNextMiddleNode(nextNode);
                    nodeStack.Push(_nextNodeToBePushed);

                    // Pushing First Node
                    _nextNodeToBePushed = new Node(); 
                    _nextNodeToBePushed = getNextFirstNode(nextNode);
                    nodeStack.Push(_nextNodeToBePushed);

                }
            }
            Console.ReadLine();
            
        }

        private static Node getNextMiddleNode(Node nextNode)
        {
            Node _middle;
            _middle = new Node();
            _middle.First = nextNode.Middle;
            _middle.Middle = nextNode.Middle;
            _middle.Last = nextNode.Middle;
            _middle.Size = 1;
            return _middle;
        }

        private static Node getNextFirstNode(Node nextNode)
        {
            Node _first;
            _first = new Node();
            _first.First = getFirstPosition(nextNode.First);
            _first.Middle = nextNode.First;
            _first.Last = getLastPosition(nextNode.First);
            _first.Size = nextNode.Size - 1;
            return _first;
        }
        /*
        private static Node getNextMiddleNode(Node nextNode)
        {
            Node _first;
            _first = new Node();
            _first.First = getFirstPosition(nextNode.Middle);
            _first.Middle = nextNode.First;
            _first.Last = nextNode.First;
            _first.Size = nextNode.Size - 1;
            return _first;
        }*/
        private static Node getNextLastNode(Node nextNode)
        {
            Node _last;
            _last = new Node();
            _last.First = getFirstPosition(nextNode.Last);
            _last.Middle = nextNode.Last;
            _last.Last = getLastPosition(nextNode.Last);
            _last.Size = nextNode.Size - 1;
            return _last;
        }

        /// <summary>
        /// Initializes stack with the current node with current position
        /// *** Update Get the current node positions and size from a configuration file using Singleton DP
        /// </summary>
        /// <returns></returns>
        private static Node InitStack()
        {
            string input;int size;bool inputNumberValid; 
            do{
                Console.Write("Towers of Hanoi Problem:\n Please Enter the size:  ");
                input=Console.ReadLine();                                        
                inputNumberValid = Int32.TryParse(input, out size);
                Console.WriteLine("Size cannot be non integer", input);
            }while(!inputNumberValid && size>0);
                      
                Console.WriteLine("Towers of Hanoi Solution");
                
                Position currentPostion = new Position();
                currentPostion.Source =  PositionName.SOURCE; 
                currentPostion.Auxilary = PositionName.AUXILARY; 
                currentPostion.Destination = PositionName.DESTIONATION;
            
                Node currentNode = new Node();
                currentNode.First = getFirstPosition(currentPostion);
                currentNode.Middle = currentPostion;
                currentNode.Last = getLastPosition(currentPostion);
                currentNode.Size = size;

                nodeStack.Push(currentNode);
                return currentNode;                        
        }

        /// <summary>
        /// Swap Auxilary and Destination 
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns> first Postion after applying swaping</returns>
        public static Position getFirstPosition(Position currentPosition){
            Position firstPostion = new Position();
            firstPostion.Source = currentPosition.Source; 

            firstPostion.Auxilary= currentPosition.Destination;
            firstPostion.Destination = currentPosition.Auxilary;

            return firstPostion;
        }   

        /// <summary>
        /// Swap Source and Auxilary 
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>last Postion after applying swaping</returns>
        public static Position getLastPosition(Position currentPosition)
        {
            Position lastPostion = new Position();

            lastPostion.Source = currentPosition.Auxilary; 
            lastPostion.Auxilary = currentPosition.Source; 

            lastPostion.Destination = currentPosition.Destination;
            return lastPostion;
        }
    }
}
