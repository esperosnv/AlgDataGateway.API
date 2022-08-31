using Algorithms.API.Models;
using System.Diagnostics;

namespace Algorithms.API.Services
{
    public class AlgorythmsImplementation : IAlgorythmsImplementation
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

        private void merge(List<int> sortedList, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = sortedList[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = sortedList[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    sortedList[k] = L[i];
                    i++;
                }
                else
                {
                    sortedList[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                sortedList[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                sortedList[k] = R[j];
                j++;
                k++;
            }
        }

        private void sort(List<int> listForSorting, int l, int elementsCount)
        {
            if (l < elementsCount)
            {
                int m = l + (elementsCount - l) / 2;

                sort(listForSorting, l, m);
                sort(listForSorting, m + 1, elementsCount);

                merge(listForSorting, l, m, elementsCount);
            }
        }

        public List<int> mergeSort(DataSet listForSorting)
        {
            List<int> elements = listForSorting.values;
            int elementsCount = listForSorting.values.Count;

            AlgorythmsImplementation ob = new AlgorythmsImplementation();
            ob.sort(elements, 0, elementsCount - 1);
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
