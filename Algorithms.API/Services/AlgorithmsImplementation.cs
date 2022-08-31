using Algorithms.API.Models;
using System.Diagnostics;

namespace Algorithms.API.Services
{
    public class AlgorithmsImplementation : IAlgorythmsImplementation
    {

        public List<int> bubbleSort(DataSet listForSorting)
        {
            List<int> elements = listForSorting.values;
            int elementsCount = listForSorting.values.Count;

            for (int i = 0; i < elementsCount - 1; i++)
                for (int j = 0; j < elementsCount - i - 1; j++)
                    if (elements[j] > elements[j + 1])
                    {
                        int temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                    }
            return elements;
        }

        public List<int> insertionSort(DataSet listForSorting)
        {
            List<int> elements = listForSorting.values;
            int elementsCount = listForSorting.values.Count;
            
            for (int i = 1; i < elementsCount; ++i)
            {
                int selectedElements = elements[i];
                int j = i - 1;

                while (j >= 0 && elements[j] > selectedElements)
                {
                    elements[j + 1] = elements[j];
                    j = j - 1;
                }
                elements[j + 1] = selectedElements;
            }
            return elements;
        }


        public List<int> mergeSort(DataSet listForSorting)
        {
            List<int> elements = listForSorting.values;
            int elementsCount = listForSorting.values.Count;

            MergeSortAlgorithm ob = new MergeSortAlgorithm();
            ob.sort(elements, 0, elementsCount - 1);
            return elements;
        }


        public List<int> quickSort(DataSet listForSorting)
        {
            List<int> elements = listForSorting.values;
            int elementsCount = listForSorting.values.Count;
            QuickSortAlgorithm.quickSort(elements, 0, elementsCount - 1);
            return elements;
        }









        public DataSetResponse getDataSetResponseFromAlgorythm(Func<DataSet, List<int>> sortedAlgorythm, DataSet listForSorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> sortedList = sortedAlgorythm(listForSorting);
            //Thread.Sleep(10);
            sw.Stop();
            DataSetResponse dataSetResponse = new DataSetResponse();
            dataSetResponse.sortedValue = sortedList;
            double microseconds = (sw.ElapsedTicks * 1000000 / Stopwatch.Frequency);
            dataSetResponse.timeOfCalculation = microseconds;
            return dataSetResponse;
        }
    }
}
