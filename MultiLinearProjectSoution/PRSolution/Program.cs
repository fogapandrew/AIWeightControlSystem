using System;

namespace PRSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* SAMPLE TEST INPUT : 
                 * 
                * Spinach 193.07 4.2 0.92 0
                * Sweet_Potato 159.62 8.39 1.7 1
                * Banana 113.54 9.4 2.67 1
                */

                ML PR = new ML();

                Console.WriteLine("Please Enter your ingridient and data related to it : ");

                string[] intput = Console.ReadLine().Split(" ");

                PR.cleaningdata(); 
                PR.creatingfeatures();
                PR.creatincridentcodes();
                PR.sqaureddata();
                PR.xyproduct();
                PR.allxproduct();
                PR.sumoffeaturesqaure();
                PR.sumofxyfeatures();
                PR.sumallxfeatures();
                PR.calculatebcoeffiecient();
                

                Console.WriteLine(PR.prediction(intput));
                Console.WriteLine(PR.rsquared());
            }
            catch (Exception e)
            {

                Console.WriteLine("An unexpected error occurred: " + e.Message);
            }
           

        }
    }
}
