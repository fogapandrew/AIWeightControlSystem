using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace KNNProjectSolution
{
    class KNN
    {
        string[] data = File.ReadAllLines("weightdummydata.csv");

        private List<string> cleandata = new List<string>();

        private Dictionary<string, int> incridentcodes = new Dictionary<string, int>();

        private Dictionary<double[], string> Dictionary = new Dictionary<double[], string>();


        private Dictionary<double, string> distanceandclassdictionary = new Dictionary<double, string>();


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



        // Adding data to dictionary -> forming a key (igredents,Taste_Rating,Fiber_Content,Is_Healthy , Calories) value (Weight_Contribution) pair
        public void adddatatodictionary()
        {
            foreach (string item in cleandata)
            {
                List<string> strings = item.Split(',').ToList();

                string value = strings[strings.Count - 1];

                strings.RemoveAt(strings.Count - 1);

                strings.RemoveAt(0);


                double[] features = Array.ConvertAll(strings.ToArray(), Convert.ToDouble);

                Dictionary[features] = value;
            }
        }


        public double CalculateDistance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Different lenghts!");

            double distance = 0;
            for (int i = 0; i < p.Length; i++)
            {
                distance += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(distance);
        }


        public string knnclassify(string[] inputdata)
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


                double minDistance = int.MaxValue;
                string closestClass = null;

                foreach (var item in Dictionary)
                {
                    double distance = CalculateDistance(numericinput, item.Key);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestClass = item.Value;
                    }
                }
                return "Your estimate Weight_Contribution_Level is (solution without k): " + closestClass;


            }
            else
            {
                Console.WriteLine("The incrident you entered does not exist in the file.");
            }

            return "no predictions";
        }


        public string kclassify(string[] data, int k)
        {
            bool found = false;
            foreach (var item in incridentcodes)
            {
                if (data[0].ToLower() == item.Key.ToLower())
                {
                    data[0] = item.Value.ToString();
                    found = true;
                }
            }

            if (found)
            {

                double[] numericinput = Array.ConvertAll(data, double.Parse);

                if (k <= 0)
                    throw new ArgumentException("k must be greater than zero.");

                foreach (var item in Dictionary)
                {
                    distanceandclassdictionary.Add(CalculateDistance(numericinput, item.Key), item.Value);
                }

                var sortedDCList = distanceandclassdictionary.ToList();


                sortedDCList.Sort((x, y) => x.Key.CompareTo(y.Key));

                var TopkNbors = sortedDCList.Take(k);

                var classcountsdictionary = new Dictionary<string, int>();

                foreach (var item in TopkNbors)
                {
                    if (classcountsdictionary.ContainsKey(item.Value))
                    {

                        classcountsdictionary[item.Value]++;
                    }
                    else
                    {
                        classcountsdictionary[item.Value] = 1;
                    }
                       
                }

                // Find the class with the maximum count (majority class)

                string Maxminumclass = null;

                int maximumcount = int.MinValue;

                foreach (var item in classcountsdictionary)
                {
                    if (item.Value > maximumcount)
                    {
                        maximumcount = item.Value;

                        Maxminumclass = item.Key;
                    }
                }

                return "Your estimate Weight_Contribution_Level is (solution with k): " + Maxminumclass;


            }
            else
            {
                Console.WriteLine("The incrident you entered does not exist in the file.");
            }

            return "no predictions";
        }                                                                                                           
    }
}
