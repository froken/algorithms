public static void Quicksort(int[] elements, int left, int right)
{
    int i = left, j = right;
    IComparable pivot = elements[(left + right) / 2];

    while (i <= j)
    {
        while (elements[i].CompareTo(pivot) < 0)
        {
            i++;
        }

        while (elements[j].CompareTo(pivot) > 0)
        {
            j--;
        }

        if (i <= j)
        {
            // Swap
            var tmp = elements[i];
            elements[i] = elements[j];
            elements[j] = tmp;

            i++;
            j--;
        }
    }

    // Recursive calls
    if (left < j)
    {
        Quicksort(elements, left, j);
    }

    if (i < right)
    {
        Quicksort(elements, i, right);
    }
}
