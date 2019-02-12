function insertionSort(a) {
    var sorted = 1;
    
    for (var i = 0; i < a.length; i++) {
        var j = i;
        
        while (j > 0 && a[j] < a[j - 1]) {
            var t = a[j];
            a[j] = a[j - 1];
            a[j - 1] = t;
            j--;
        }
    }
    
    return a;
}
