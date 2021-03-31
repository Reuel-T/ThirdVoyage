using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdVoyage
{
    class Caretaker
    {
        private List<Memento> mList = new List<Memento>();
        private Stack<Memento> mStack = new Stack<Memento>();
        private Queue<Memento> mQueue = new Queue<Memento>();

        public void add(Memento state) 
        {
            mStack.Push(state);
            Console.WriteLine($"State saved at {DateTime.Now}");
        }

        public void addQueue(Memento state) 
        {
            mQueue.Enqueue(state);
        }

        public Memento pullQueue() 
        {
            return mQueue.Dequeue();
        }

        public Memento GetMemento() 
        {
            return mStack.Pop();
        }
    }
}
