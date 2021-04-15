using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Permutations
{
    public class Permutations:IPermutations
    {
        // Initialize a list of strings to hold the output of HeapPermutation().
        private static readonly List<string> list = new ();

        /// <summary>
        /// Prints a sequence if it is unique.
        /// </summary>
        /// <param name="sequence">Sequence of characters.</param>
        private static void PrintPermutation(string sequence)
        {
            if (!list.Contains(sequence))
            {
                Console.WriteLine(sequence);
            }
        }

        /// <summary>
        /// Method to generate permutations using Heap's Algorithm.
        /// </summary>
        /// <param name="sequence">List of characters.</param>
        /// <param name="size">Size of the sequence.</param>
        private static async Task HeapPermutation(char[] sequence, int size)
        {
            // if size becomes 1 then prints the obtained
            // permutation
            if (size == 1)
            {
                string permutation = new (sequence);
                PrintPermutation(permutation);
                list.Add(permutation);
            }

            if (size > 1)
            {
                for (int i = 0; i < size; i++)
                {
                    await HeapPermutation(sequence, size - 1);

                    // if size is odd, swap 0th i.e (first) and
                    // (size-1)th i.e (last) element
                    if (size % 2 == 1)
                    {
                        char temp = sequence[0];
                        sequence[0] = sequence[size - 1];
                        sequence[size - 1] = temp;
                    }

                    // If size is even, swap ith and
                    // (size-1)th i.e (last) element
                    else
                    {
                        char temp = sequence[i];
                        sequence[i] = sequence[size - 1];
                        sequence[size - 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Command line input.
        /// </summary>
        /// <returns>The command line input as a string.</returns>
        private static string Input()
        {
            Console.WriteLine("Please input a string.");
            return Console.ReadLine();
        }

        /// <inheritdoc/>
        public async Task Run()
        {
            char[] sequence = Input().ToCharArray();
            Console.WriteLine("\nThe permutations are:");
            await HeapPermutation(sequence, sequence.Length);
            Console.WriteLine("\nPress any key to close.");
            Console.Read();
        }
    }
}
