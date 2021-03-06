﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList  
    {
        private SinglyLinkedListNode first_node;
        public SinglyLinkedList() //you can tell its a constructor because the name of that method is the name of the name of the class itself 
        { 
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)//this is what is being passed in is the parameteres of an array
        {
            if (values.Count() == 0)
            {
                throw new ArgumentException();
            }
            
            for (var i=0; i < values.Count(); i++)

            {//being passed as an array of objects so needs to be converted to a string
                this.AddLast(values[i].ToString());
            }
                  
          
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]// list [i] = value; i is new list q is old list
        {
            get { return this.ElementAt(i); }
            set {
                var placeHolderList = new SinglyLinkedList();

                for (var q = 0; q < this.Count(); q++)
                {
                   if (q==i)
                    {
                        placeHolderList.AddLast(value);
                    }
                    else
                    {
                        placeHolderList.AddLast(this.ElementAt(q));
                    }
                }

                first_node = new SinglyLinkedListNode(placeHolderList.First());
                for (var w = 1; w < placeHolderList.Count(); w++)
                {
                    this.AddLast(placeHolderList.ElementAt(w));
                }
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            int testForValue = -1;

            for (var i = 0; i < this.Count(); i++)
            {
                if (this.ElementAt(i) == existingValue)
                {
                    testForValue = i;
                    break;
                }
              
            }
            if (testForValue == -1)
            {
                throw new ArgumentException();
            }//one = equalss setting value, two == equals tests for equality
            var placeHolderList = new SinglyLinkedList();

            for (var q = 0; q < this.Count(); q++)
            {
                placeHolderList.AddLast(this.ElementAt(q));

                if (q ==testForValue)
                {
                    placeHolderList.AddLast(value);
                }
            }

            first_node = new SinglyLinkedListNode(placeHolderList.First());
            for (var w = 1; w <placeHolderList.Count(); w++)
            {
                this.AddLast(placeHolderList.ElementAt(w));
            }
        }
   
        public void AddFirst(string value)
        {
            if (this.First() == null)
            { first_node = new SinglyLinkedListNode(value); }
            else
            {
                var newNode = new SinglyLinkedListNode(value); //this is how you make a new node
                var theoldNode = this.first_node; //this creates a variable for first nodes
                newNode.Next = theoldNode; // this points the newest node at the original first node
                this.first_node = newNode; // this saves the newest node to the singly linked list, refresh 
            }
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
            // If the list is empty
            // this.Count() == 0
            if (this.First() == null)
            {
                return 0;
            }
            else
            {
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


            // Provide a second implementation
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

            // return this.first_node ? null : this.first_node.Value;

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
                // Step 1: Do I need to loop??????
                // Step 2: IF yes, Do I already have an example of how??? ***
                // Step 3: How can I modify the previous examples?
                // Step 4: Write what I think works.
                // Step 5: Rebuild/Re-run tests
                // Step 6: Rinse and repeat
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
            var node = this.first_node; //first node will be null on an empty list
            var mylist = new List<string>();
            if (node == null) return mylist.ToArray();
            while (!node.IsLast()) //code will break here because null is not an object
            {
                mylist.Add(node.Value); 
                node = node.Next;
            }
            
            mylist.Add(node.Value);
            return mylist.ToArray();

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