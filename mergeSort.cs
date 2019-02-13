static int[] mergeSort(int[] a) 
{
    if (a.Length == 1) 
    {
        return a;
    }

    int middle = a.Length / 2;
    int[] left = new int[middle];
    int[] right = new int[a.Length - left.Length];

    for (int i = 0; i < middle; i++) 
    {
        left[i] = a[i];
    }

    for (int i = middle; i < a.Length; i++) 
    {
        right[i - middle] = a[i];
    }

    left = mergeSort(left);
    right = mergeSort(right);

    return merge(left, right);
}

static int[] merge(int[] a, int[] b) 
{
    int[] result = new int[a.Length + b.Length];
    int ia = 0;
    int ib = 0;
    int i = 0;

    while (i < result.Length && ia < a.Length && ib < b.Length) 
    {
        if (a[ia] < b[ib]) 
        {
            result[i] = a[ia];
            ia++;
        }
        else
        {
            result[i] = b[ib];
            ib++;
        }

        i++;
    }

    while (ia < a.Length) 
    {
        result[i] = a[ia];
        ia++;
        i++;
    }

    while (ib < b.Length) 
    {
        result[i] = b[ib];
        ib++;
        i++;
    }

    return result;
}
