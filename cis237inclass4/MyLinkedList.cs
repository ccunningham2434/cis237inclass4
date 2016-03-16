﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class MyLinkedList
    {
        //Node that will 'point' to the current node we are looking at
        public Node Current
        {
            get;
            set;
        }

        //Node that will 'point' to the beginning of the linked list
        public Node Head
        {
            get;
            set;
        }

        //Node that will 'point' to the last node in the linked list
        public Node Tail
        {
            get;
            set;
        }

        //Constructor. Just initalize the properties to null
        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //This will be the add method to add a new node to the linked list
        public void Add(string content)
        {
            //Make a new node
            Node node = new Node();

            //Set the data for the node to the content that was passed in.
            node.Data = content;

            //If Head is null, that means that there are no nodes in the linked list.
            //We are about to add the first node.
            if (Head == null)
            {
                Head = node;
                //This next line got moved below the if/else, so it is no longer needed
                //Tail = node;
            }
            //This is the case where there is already at least 1 node in the linked list. Maybe many.
            else
            {
                //Take the Tail Node, which is the last one in the list, and set it's Next property
                //which was null, to the new node we just created.
                Tail.Next = node;

                //This is a valid replacement for Tail = node;, but might be harder to understand.
                //Tail = Tail.Next;
                //This next line got moved below the if/else
                //Tail = node;
            }
            //This was duplicated in both the if and the else, so we moved it down here since it must be
            //done for both of them.
            Tail = node;
        }

        public string Retrieve(int position)
        {
            // Used as a temporary pointer to a spot within the linked list.
            Node tempNode = Head;
            // Used to hold the node at the index indicated by the passd in position.
            Node returnNode = null;
            // Counter to see where we are in the list.
            int count = 0;

            // While our tempNode is not at the end of the list.
            while (tempNode != null)
            {
                // If the count and the position match. This means that it wil be
                // zero based. If we wanted it to be 1 based, we would neet to subtract
                // 1 from the position.
                if (count == position)
                {
                    // Set the returnNode var to the tempNode, which is the on we are looking for.
                    returnNode = tempNode;
                }
                // Increment the count so that we actually move through the list.
                count++;
                // Set the tempNode to tempNode's next property, which will move us to the next
                // node in the linked list.
                tempNode = tempNode.Next;
            }
            // We are going to use a ternary operater to do a small version of an if.
            // This could easily be written as an if/else. Essentially the part in the ()
            // is the test, and the part between the ? and the : is what will happen if true.
            // The part after the : is what will happen when false.
            return (returnNode != null) ? returnNode.Data : null;
        }

        public bool Delete(int position)
        {
            bool returnBool = false;

            // Set current to head.
            Current = Head;

            // If the position that we want to remove is the very first node, we need to do things
            // differnt than if it is 1 through the end.
            // this part is equivilent to always removing from the front. (hint, hint)
            if (position == 0)
            {
                // Set the head to the current.Next which will make Head poin to the node
                // at index 1, instead of index 0.
                Head = Current.Next;
                // Set the Next property of current to null so that the current
                // (which was the old Head) does not point to any other node.
                // This line is probably not 'required',  but it does illustrate how
                // to clean up a node so it no longer points to anything.
                Current.Next = null;
                // Set the current (which was the old Head) to null. Now that node no longer
                // exists, and can be garbage collected.
                Current = null;
                // Check to see if the Head is null, if so, the Tail must become null as well
                // because it means we just deleted the last node in the list.
                if (Head == null)
                {
                    Tail = null;
                }

                // Set the return bool to true since the move was succesfull.
                returnBool = true;
            }
            else
            {
                // Set a tempnode to the first position in the linkedlist.
                Node tempNode = Head;
                // Declare a previous temp that will get a value after the tempNode moves.
                Node previousTempNode = null;
                // Start a counter to use to move through the linked list.
                int count = 0;

                // Loop until the temp node is null, which means we are at the end.
                while (tempNode != null)
                {
                    // If we match the position and the count we are on, we found the
                    // one that we need to delete.
                    if (count == position)
                    {
                        // Set the previous node's next to the temp node's next
                        // jumping over the tempnode. The previous node's next will now
                        // point to the node AFTER the tempnode.
                        previousTempNode.Next = tempNode.Next;

                        // Check to see if we are deleting the very last node in the list
                        // if so we need to move the Tail pointer.
                        if (tempNode.Next == null)
                        {
                            // Set tail to the previousTempNode, which is the new end of the list.
                            Tail = previousTempNode;
                        }
                        // We fouond the one to delete, so set the return bool to true.
                        returnBool = true;
                    }
                    // Increment the count so we move through the linked list.
                    count++;
                    // Set the previous tempnode to the current tempnode. This way when we
                    // move the tempNode forward, we will still have a pointer to where
                    // the tempnode was before it moved.
                    previousTempNode = tempNode;
                    // Set the tempNode to the tempNode's next property, which will move it down
                    // the linked list one position.
                    tempNode = tempNode.Next;
                }

            }

            return returnBool;
        }
    }
}
