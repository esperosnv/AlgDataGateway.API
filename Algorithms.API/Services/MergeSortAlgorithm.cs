namespace Algorithms.API.Services
{
    public class MergeSortAlgorithm
    {
        public void merge(List<int> sortedList, int l, int m, int r)
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

        public void sort(List<int> listForSorting, int l, int elementsCount)
        {
            if (l < elementsCount)
            {
                int m = l + (elementsCount - l) / 2;

                sort(listForSorting, l, m);
                sort(listForSorting, m + 1, elementsCount);

                merge(listForSorting, l, m, elementsCount);
            }
        }

    }
}
