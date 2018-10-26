using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Findmedian
{
    class Program
    {
        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int aCount = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[aCount];

            for (int aItr = 0; aItr < aCount; aItr++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[aItr] = aItem;
            }

            double[] result = runningMedianHeapify(a, aCount);
            for (int r = 0; r < aCount; r++)
            {
                Console.WriteLine(string.Format("{0:0.0}", result[r]));
            }
            Console.ReadLine();

         
            //List<Node> nodes = new List<Node>();
            //nodes.Add(new Node(5));
            //nodes.Add(new Node(6));
            //nodes.Add(new Node(10));
            //nodes.Add(new Node(7));
            //nodes.Add(new Node(8));
            //nodes.Add(new Node(9));
            //nodes.Add(new Node(11));
            //Node n1 = new Node(5);
            //Heap minHeap = new Heap(nodes,1);
            //Heap maxHeap = new Heap(nodes, 0);
            ////minHeap.Add(new Node(4));

            ////minHeap.Remove();
            //maxHeap.Add(new Node(15));

        }
        private static double[] runningMedianHeapify(int[] a, int n)
        {
            double[] res = new double[n];
            Heap minHeap= null, maxHeap = null;
            double median = 0;

            for (int i=0;i<a.Length;i++)
            {
                if (i == 0)
                {
                    minHeap = new Heap(1);
                    maxHeap = new Heap(0);
                }
                if (a[i]<= median)
                {
                    maxHeap.Add(new Node(a[i]));
                } else
                {
                    minHeap.Add(new Node(a[i]));
                }

                if(minHeap.nodeCount > maxHeap.nodeCount +1)
                {
                    if (minHeap.nodeCount > 0)
                    {
                        maxHeap.Add(new Node(minHeap.Top()));
                        minHeap.Remove();
                    }
                }
                if (maxHeap.nodeCount > minHeap.nodeCount + 1)
                {
                    if (maxHeap.nodeCount > 0)
                    {
                        minHeap.Add(new Node(maxHeap.Top()));
                        maxHeap.Remove();
                    }
                }

                if (minHeap.nodeCount == maxHeap.nodeCount)
                {
                    median = (minHeap.Top() + maxHeap.Top()) / 2.0;
                }
                if (minHeap.nodeCount > maxHeap.nodeCount)
                {
                    median = (double)minHeap.Top();
                } else if (minHeap.nodeCount < maxHeap.nodeCount)
                {
                    median = (double)maxHeap.Top();
                }
                res[i] = median;
            }

            return res;
        }
        private static double[] runningMedian(int[] a, int n)
        {
            List<int> b = new List<int>(); ;
            double[] res = new double[n];
            for (int r = 0; r < n; r++)
            {
                b.Add(a[r]);
                if (r == 0)
                {
                    res[r] = b[r];
                    continue;
                }

                b.Sort();
                double median = 0.0;
                if (b.Count() % 2 == 0)
                {
                    int f = r / 2;
                    int l = f + 1;
                    median = (double)(b[f] + b[l]) / 2;
                }
                else
                {
                    int x = r / 2;
                    median = b[x];
                }
                res[r] = median;
            }
            return res;
        }
    }

    class Node
    {
        public int data;
        public Node left, right;
        
        public Node parent;
        public Node (int d)
        {
            this.data = d;
        }
        public Node (Node pointer)
        {
            this.parent = pointer;
        }
    }
    class Heap
    {
        Node root;
        public int nodeCount=0;
        Node pointer;
        int Type; // type=1 - minheap, 2- max heap;
        public Heap(int type)
        {
            this.Type = type;
        }
        public Heap(List<Node> nodes)
        {
            nodeCount = 0;
           // this.Type = type;
           for (int i = 0; i < nodes.Count(); i++)
            {
                Add(nodes[i]);
            }
        }


        public int Top()
        {
            if (root != null)
            {
                return root.data;
            } else
            {
                return 0;
            }
        }
        public void Add(Node node)
        {

            if (root == null)
            {
                root = node;
                nodeCount++;
                return;
            }
            // int count = nodes.Count();
            pointer = root; //= nodes.Where(x => x.parent == null).FirstOrDefault();
            string binCount = Convert.ToString(nodeCount + 1,2);
            for (int c = 1;c < binCount.Length;c++)
            {
                if (binCount[c] == '0')
                {
                    if(pointer.left == null)
                    {
                        pointer.left = new Node(pointer);
                    }
                    pointer = pointer.left;
                } else
                {
                    if (pointer.right == null)
                    {
                        pointer.right = new Node(pointer);
                    }
                    pointer = pointer.right;
                }

            }
            pointer.data = node.data;
            // return root;
            // Heapify(root);
            while (true)
            {
                if (pointer == root)
                {
                    break;
                }
                if (Type == 1)
                {
                    if (pointer.data < pointer.parent.data)
                    {
                        int temp = pointer.data;
                        pointer.data = pointer.parent.data;
                        pointer.parent.data = temp;
                        pointer = pointer.parent;
                    }
                    else
                    {
                        break;
                    }
                } else
                {
                    if (pointer.data > pointer.parent.data)
                    {
                        int temp = pointer.data;
                        pointer.data = pointer.parent.data;
                        pointer.parent.data = temp;
                        pointer = pointer.parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            nodeCount++;
         //   Heapify();
        }

        private void Heapify()
        {
            //var firstroot = nodes.First(x => x.parent == null);
            pointer = root; //= nodes.Where(x => x.parent == null).FirstOrDefault();
            //string binCount = Convert.ToString(nodeCount + 1, 2);
            
            Node compare;
            while (true)
            {
                if (pointer.left == null)
                {
                    break;
                }
                if (pointer.right == null)
                {
                    compare = pointer.left;
                }
                else
                {
                    if (Type == 1)
                    {
                        if (pointer.left.data <= pointer.right.data)
                        {
                            compare = pointer.left;
                        }
                        else
                        {
                            compare = pointer.right;
                        }
                    } else
                    {
                        if (pointer.left.data >= pointer.right.data)
                        {
                            compare = pointer.left;
                        }
                        else
                        {
                            compare = pointer.right;
                        }
                    }
                }

                if (Type == 1)
                {
                    if (pointer.data > compare.data)
                    {
                        int temp = pointer.data;
                        pointer.data = compare.data;
                        compare.data = temp;
                        pointer = compare;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (pointer.data < compare.data)
                    {
                        int temp = pointer.data;
                        pointer.data = compare.data;
                        compare.data = temp;
                        pointer = compare;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        public void Remove ()
        {
            //var firstroot = nodes.First(x => x.parent == null);
            if (root == null)
            {
                return;
            }
            if (nodeCount == 1)
            {
                nodeCount=0;
                root.data = 0;
                return;
            }
            pointer = root; //= nodes.Where(x => x.parent == null).FirstOrDefault();
            string binCount = Convert.ToString(nodeCount, 2);
            int output = root.data;

        
            for (int c = 1; c < binCount.Length; c++)
            {
                if (binCount[c] == '0')
                {

                    pointer = pointer.left;
                }
                else
                {
                    pointer = pointer.right;
                }

            }
            root.data = pointer.data;

            if (pointer.parent != null)
            {
                if (pointer.parent.left == pointer)
                {
                    pointer.parent.left = null;
                }
                else
                {
                    pointer.parent.right = null;
                }
            }
            nodeCount--;
            Heapify();
        }
    }
}
