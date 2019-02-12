function bubbleSort(a) {
    var sorted = false;
    
    while (!sorted) {
        sorted = true;
        
        for (var i = 0; i < a.length - 1; i++) {
            if (a[i] > a[i + 1]) {
                var t = a[i];
                a[i] = a[i + 1];
                a[i + 1] = t;
                sorted = false;
            }
        }
    }
    
    return a;
}
