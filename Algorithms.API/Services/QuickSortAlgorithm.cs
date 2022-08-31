namespace Algorithms.API.Services
{
    public class QuickSortAlgorithm
    {
        private static void swap(List<int> listForSorting, int i, int j)
        {
            int temp = listForSorting[i];
            listForSorting[i] = listForSorting[j];
            listForSorting[j] = temp;
        }

        private static int partition(List<int> listForSorting, int low, int high)
        {

            int pivot = listForSorting[high];

            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (listForSorting[j] < pivot)
                {
                    i++;
                    swap(listForSorting, i, j);
                }
            }
            swap(listForSorting, i + 1, high);
            return (i + 1);
        }

        public static void quickSort(List<int> listForSorting, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(listForSorting, low, high);

                quickSort(listForSorting, low, pi - 1);
                quickSort(listForSorting, pi + 1, high);
            }
        }
    }
}
