using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fronta
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Když nechci prvky odstranit ale chci je projet všechny

            Console.WriteLine("-- ENQUEUE ---------------------------------------------------");
            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            foreach (var i in queue.ToArray())
            {
                Console.WriteLine(i);

            }

            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //PEEK - veme první vložený prvek a použije ho

            Console.WriteLine("-- PEEK ------------------------------------------------------");
            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            foreach(var i in queue)
            {
                Console.WriteLine(queue.Peek());

            }

            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //DEQUEUE - veme první vložený prvek, použije a odstraní ho
            
            Console.WriteLine("\n-- DEQUEUE --------------------------------------------------");
            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            while (queue.Count > 0)
            {

                //Console.WriteLine((Convert.ToInt32(queue.Dequeue()))+2); // normální přetyování na int
                Console.WriteLine(queue.Dequeue());

            }

            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //CLEAR - odstraní prvky z fronty

            Console.WriteLine("\n-- CLEAR ----------------------------------------------------");

            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue("Four");

            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);

            queue.Clear();

            Console.WriteLine("Number of elements in the Queue: {0}", queue.Count);



            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.ReadKey();
            
        }

    }
    
}
