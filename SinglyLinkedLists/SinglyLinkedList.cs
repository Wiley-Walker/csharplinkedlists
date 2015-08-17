﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first_node;
        private int listLength = 0;
        // public SinglyLinkedList(string expected, )
        //{
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        //}

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {

            for (int i = 0; i < values.Count(); i++)
            {
                this.AddLast(values[i] as String);
            }
        }


        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx

        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set {
                var thisNode = new SinglyLinkedList();
                for (var x = 0; x < this.Count(); x++)
                {
                    if (x == 2)
                    {
                        thisNode.AddLast(value);
                    }
                    else
                    {
                        thisNode.AddLast(this.ElementAt(x));
                    }
                }
                first_node = new SinglyLinkedListNode(thisNode.First());
                for (var w = 1; w < thisNode.Count(); w++)
                {
                    this.AddLast(thisNode.ElementAt(w));
                }
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            var NodeOne = first_node;
            bool NotTheEnd = false;
            while (!(NodeOne.IsLast()))
            {
                if (NodeOne.Value == existingValue)
                {
                    NotTheEnd = true;
                    break;
                }
                else
                {
                    NodeOne = NodeOne.Next;
                }
            }
            if (NodeOne.IsLast() && NodeOne.Value == existingValue)
            {
                this.AddLast(value);
                return;
            }

            if (!NotTheEnd) { throw new ArgumentException(); }

            if (NotTheEnd)
            {
                var newNode = new SinglyLinkedListNode(value);
                newNode.Next = NodeOne.Next;
                NodeOne.Next = newNode;
                listLength += 1;

            }

        }

        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var newFirstNode = new SinglyLinkedListNode(value);
                newFirstNode.Next = this.first_node;
                this.first_node = newFirstNode;
            }

            listLength += 1;
        }

        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var node = this.first_node;
                while (!node.IsLast()) // What's another way to do this???? 
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);

            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            if (this.First() == null)
            {
                return 0;
            } else {
                int length = 1;
                var node = this.first_node;
                // Complexity is O(n)                  
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }
                return length;
            }

        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {      
            var node = this.first_node;

            for (var i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    break;
                }
                node = node.Next;
            }
            return node.Value;

        }
              
} 
 




        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            }
            else
            {
                return this.first_node.Value;
            }
            


        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            var node = this.first_node;
            if (node == null)
            {
                return null;
            }
            else
            {
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }
        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            string[] Ray = new string[this.Count()];
            for (int i = 0; i < this.Count(); i++)
            {
                Ray[i] = this.ElementAt(i);
            }
            return Ray;
        }
        public override string ToString()
        {
            var opening = "{";
            var ending = "}";
            var space = " ";
            var output = "";
            var quote = "\"";
            var comma = "," + space;
            output += opening;
            var node = this.first_node;
            if (this.Count() >= 1)
            {
                output += space;
                while (!node.IsLast())
                {
                    output += quote + node.Value + quote + comma;
                    node = node.Next;
                }
                output += quote + this.Last() + quote;
            }
            output += space;
            output += ending;
            return output;
        }
    }
}
