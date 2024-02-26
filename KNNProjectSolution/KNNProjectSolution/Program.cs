using System;

namespace KNNProjectSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* SAMPLE INPUTS : 
                 * 
                 * Eggs 211.28 8.6 4.56 0
                 * Apple 202.88 1.46 2.63 1
                 * Sweet_Potato 159.62 8.39 1.7 1
                 * 
                 */

                KNN knn = new KNN();

                Console.WriteLine("Please Enter your ingridient and data related to it (SOLUTION IN CLASS) : ");
                string[] input = Console.ReadLine().Split();


                Console.WriteLine("Please enter same input as above(SOLUTION WITH K): ");
                string[] input2 = Console.ReadLine().Split();

                Console.WriteLine("Enter the number of k-nearest neighbors : ");
                int k = Convert.ToInt32(Console.ReadLine());

                knn.cleaningdata();
                knn.creatincridentcodes();
                knn.adddatatodictionary();

                Console.WriteLine(knn.knnclassify(input));


                Console.WriteLine(knn.kclassify(input2, k));



            }
            catch (Exception e)
            {

                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }

        }
    }
}
