using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera_Week4
{
    public class MyStack<T>
    {
        private StackNode<T> top;
        public MyStack()
        {
            //top = new StackNode<T>();

        }

        public void Push (T data)
        {
            StackNode<T> item = new StackNode<T>(data);
            item.next = top;
            top = item;
        }
        public T Peek()
        {
           if (top == null) { throw new Exception(" top is null"); };
            return top.data;
        }
        public T Pop()
        {
            if (top == null) { throw new Exception(" top is null"); };
            T item = top.data;
            top = top.next;
            return item;
        }
    }

    public class StackNode<T>
    {
        public T data;
        public StackNode<T> next;
        public StackNode( T data)
        {
            this.data = data;
        }
    }
     
}
