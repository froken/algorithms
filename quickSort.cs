public static void quicksort(int[] a, int left, int right)
{
    int i = left, j = right;
    int pivot = a[(i + j)/2];

    while (i < j) 
    {
        while (a[i] < pivot) 
        {
            i++;
        }

        while (a[j] > pivot) 
        {
            j--;
        } 

        if (i <= j) 
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;

            i++;
            j--;
        }
    }

    if (i < right) 
    {
        quickSort(a, i, right);
    }

    if (j > left) 
    {
        quickSort(a, left, j);
    }
}
