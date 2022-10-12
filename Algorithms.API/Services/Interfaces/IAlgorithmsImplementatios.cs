using DataModels;

namespace Algorithms.API.Services
{
    public interface IAlgorythmsImplementation
    {
        List<int> bubbleSort(DataSet listForSorting);
        List<int> insertionSort(DataSet listForSorting);
        List<int> mergeSort(DataSet listForSorting);
        List<int> quickSort(DataSet listForSorting);
        List<int> selectionSort(DataSet listForSorting);


        Task<DataSetResponse> getDataSetResponseFromAlgorythm(Func<DataSet, List<int>> sortedAlgorythm, DataSet listForSorting);
    }
}