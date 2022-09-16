namespace CalculationHostedService
{
    public interface ICalculation
    {
        List<int> bubbleSort(List<int> listForSorting);
    }

    public class Calculation : ICalculation
    {
        public List<int> bubbleSort(List<int> listForSorting)
        {
            List<int> elements = listForSorting;
            int elementsCount = listForSorting.Count;

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
    }
}
