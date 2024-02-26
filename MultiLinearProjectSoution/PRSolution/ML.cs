using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PRSolution
{
    class ML
    {
        string[] data = File.ReadAllLines("weightvaluedummydata.csv");

        private List<string> cleandata = new List<string>();

        private Dictionary<string, int> incridentcodes = new Dictionary<string, int>();

        List<double> x1 = new List<double>();
        List<double> x2 = new List<double>();
        List<double> x3 = new List<double>();
        List<double> x4 = new List<double>();
        List<double> x5 = new List<double>();

        double outputss;

        List<double> x1square = new List<double>();
        List<double> x2square = new List<double>();
        List<double> x3square = new List<double>();
        List<double> x4square = new List<double>();
        List<double> x5square = new List<double>();


        List<double> x1Y = new List<double>();
        List<double> x2Y = new List<double>();
        List<double> x3Y = new List<double>();
        List<double> x4Y = new List<double>();
        List<double> x5Y = new List<double>();


        List<double> x1x2x3x4x5 = new List<double>();

       
        double sumx1square = 0.0;
        double sumx2square = 0.0;
        double sumx3square = 0.0;
        double sumx4square = 0.0;
        double sumx5square = 0.0;

        double sumx1y = 0.0;
        double sumx2y = 0.0;
        double sumx3y = 0.0;
        double sumx4y = 0.0;
        double sumx5y = 0.0;


        double b0 = 0.0;
        double b1 = 0.0;
        double b2 = 0.0;
        double b3 = 0.0;
        double b4 = 0.0;
        double b5 = 0.0;


        double sumx1x2x3x4x5 = 0; 

        List<double> y = new List<double>();


        // DATA PREPRATION -> Cleaning of the data set to create our features.

        // Data cleaning - > removing the header.
        public void cleaningdata()
        {
            if (data.Length > 1)
            {
                for (int i = 1; i < data.Length; i++)
                {
                    cleandata.Add(data[i]);
                }
            }
            else
            {
                Console.WriteLine("The file is empty please insert a complete list of data");
            }

        }

        // Ceating features for multi linear regression :
        public void creatingfeatures()
        {
            foreach (var item in cleandata)
            {
                string[] values = item.Split(',');
                x1.Add(Convert.ToDouble(values[1]));
                x2.Add(Convert.ToDouble(values[2]));
                x3.Add(Convert.ToDouble(values[3]));
                x4.Add(Convert.ToDouble(values[4]));
                x5.Add(Convert.ToDouble(values[5]));

                y.Add(Convert.ToDouble(values[values.Length - 1]));


            }
        }

       
        // creating incredent-code dictionary 
        public void creatincridentcodes()
        {
            foreach (var item in cleandata)
            {
                string[] values = item.Split(',');
                string firstValue = values[0];
                string lastValue = values[1];

                if (!incridentcodes.ContainsKey(firstValue))
                {
                    incridentcodes.Add(firstValue, Convert.ToInt32(lastValue));
                }
            }
        }




        // PREPROCESSING THE DATA.

        // Step 1: Calculate X12, X22, X1y, X2y and X1X2.

        private void creatingsqaureddata(List<double> inputs, List<double> outputs)
        {

            foreach (var item in inputs)
            {
                outputs.Add(Math.Pow(item, 2));
            }
        }

        private void creatingxy(List<double> xs, List<double> ys , List<double> output)
        {
            for (int i = 0; i < xs.Count; i++)
            {
                output.Add(xs[i] * ys[i]);
            }

        }

        private void creatingx1x2x3x4x5(List<double> xs1, List<double> xs2, List<double> xs3 , List<double> xs4 , List<double> xs5 , List<double> output)
        {
            for (int i = 0; i < xs1.Count; i++)
            {
                output.Add((xs1[i] * xs2[i] * xs3[i] * xs4[i] * xs5[i]));
            }
        }

        public void sqaureddata()
        {
            creatingsqaureddata(x1, x1square);
            creatingsqaureddata(x2, x2square);
            creatingsqaureddata(x3, x3square);
            creatingsqaureddata(x4, x4square);
            creatingsqaureddata(x5, x5square);

        }


        public void xyproduct()
        {
            creatingxy(x1, y, x1Y);
            creatingxy(x2, y, x2Y);
            creatingxy(x3, y, x3Y);
            creatingxy(x4, y, x4Y);
            creatingxy(x5, y, x5Y);
        }

        public void allxproduct()
        {
            creatingx1x2x3x4x5(x1, x2 , x3, x4, x5, x1x2x3x4x5);
        }



        // Step 2: Calculate Regression Sums.
        private double summationofsqaure(List<double> x , List<double> x2)
        {
            double sum;

            double sumx = x.ToArray().Sum();

            double sumx2 = x2.ToArray().Sum();

            int n = x.Count;

            sum = sumx2 - ((Math.Pow(sumx, 2) / n));

            return sum;
        }

        private double summationofxy(List<double> xy , List<double> X , List<double> y)
        {
            double sum;

            double sumxy = xy.ToArray().Sum();
            double sumx = X.ToArray().Sum();
            double sumy = y.ToArray().Sum();
            int n = X.Count;

            sum = sumxy - ((sumx * sumy) / n);


            return sum;
        }

        private double sumofallx(List<double> x1, List<double> x2, List<double> x3, List<double> x4 , List<double> x5 , List<double> allx)
        {
            double sum;

            double sumallx = allx.ToArray().Sum();

            double sumx1 = x1.ToArray().Sum();
            double sumx2 = x2.ToArray().Sum();
            double sumx3 = x3.ToArray().Sum();
            double sumx4 = x4.ToArray().Sum();
            double sumx5 = x5.ToArray().Sum();

            int n = x1.Count;


            sum = sumallx - ((sumx1 * sumx2 * sumx3 * sumx4 * sumx5) / n);
            return sum;
        }

        public void sumallxfeatures()
        {
            sumx1x2x3x4x5 = sumofallx(x1, x2, x3, x4, x5, x1x2x3x4x5);
        }

        
        public void sumoffeaturesqaure()
        {

            sumx1square = summationofsqaure(x1, x1square);
            sumx2square = summationofsqaure(x2, x2square);
            sumx3square = summationofsqaure(x3, x3square);
            sumx4square = summationofsqaure(x4, x4square);
            sumx5square = summationofsqaure(x4, x5square);

        }

        public void sumofxyfeatures()
        {

            sumx1y = summationofxy(x1Y, x1, y);
            sumx2y = summationofxy(x2Y, x2, y);
            sumx3y = summationofxy(x3Y, x3, y);
            sumx4y = summationofxy(x4Y, x4, y);
            sumx5y = summationofxy(x5Y, x5, y);

        }



        // Step 3: Calculate b0, b1, and b2.
        public void calculatebcoeffiecient()
        {
            // β1 = Σ(X1Y) - X1.meanΣY / Σ(X12) -  X1.meanΣX1

            b1 = ((sumx1y) - (x1.Average() * y.Sum())) / ((sumx1square) - (x1.Average() * x1.Sum()));

            // β2 = Σ(X2Y) - X2.meanΣY/Σ(X22) -  X2.meanΣX2

            b2 = ((sumx2y) - (x2.Average() * y.Sum())) / ((sumx2square) - (x2.Average() * x2.Sum()));

            // β3 = Σ(X3Y) - X3.meanΣY/Σ(X32) -  X3.meanΣX3

            b3 = ((sumx3y) - (x3.Average() * y.Sum())) / ((sumx3square) - (x3.Average() * x3.Sum()));

            // β4 = Σ(X4Y) - X4.meanΣY/Σ(X42) -  X4.meanΣX4

            b4 = ((sumx4y) - (x4.Average() * y.Sum())) / ((sumx4square) - (x4.Average() * x4.Sum()));

            // β4 = Σ(X5Y) - X5.meanΣY/Σ(X52) -  X5.meanΣX5

            b5 = ((sumx5y) - (x5.Average() * y.Sum())) / ((sumx5square) - (x5.Average() * x5.Sum()));


            b0 = (y.Average()) - (b1 * x1.Average()) - (b2 * x2.Average()) - (b3 * x3.Average()) - (b4 * x4.Average()) - (b5 * x5.Average());

        }

        // Pections given inputs 

        public string prediction(string [] inputdata)
        {
            bool found = false;

           

            foreach (var item in incridentcodes)
            {
                if (inputdata[0].ToLower() == item.Key.ToLower())
                {
                    inputdata[0] = item.Value.ToString();
                    found = true;
                }
            }

            if (found)
            {
                double[] numericinput = Array.ConvertAll(inputdata, double.Parse);

                outputss = b0 + (b1 * numericinput[0]) + (b2 * numericinput[1]) + (b3 * numericinput[2]) + (b4 * numericinput[3]) + (b5 * numericinput[4]);

                return "You estimate Weight_Contribution_Level is : " + (outputss).ToString();


            }
            else
            {
                Console.WriteLine("The incrident you entered does not exist in the file.");
            }

            return "no predictions";
        }

        public string rsquared()
        {
            // R2 = 1 - (Sum of sqaured residuals/ total sum of sqaures)
            // R2 = 1 - ∑0-n(yi - ymean)2 / ∑0-n(yi - yp)2

            double ymean = y.Average();

            double ypredict = outputss;

            double rsquare;

            double top = 0.0;

            double buttom = 0.0;


            foreach (var item in y)
            {
                top = top + (item - ymean);
            }

            foreach (var item in y)
            {
                buttom = buttom + ((item - ypredict));
            }

            rsquare = 1 - ((top / buttom));

            return $"R2 : {rsquare}";
        }

    }
}
