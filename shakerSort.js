function shakerSort(a) {
    var start = 0; 
    var finish = a.length - 1;
    var sorted = false;
    
    while (!sorted) {
        sorted = true;
        
        for (var i = start; i < finish - 1; i++) {
            if (a[i] > a[i + 1]) {
                var t = a[i];
                a[i] = a[i + 1]; 
                a[i + 1] = t;
                sorted = false;
            }
        }
        finish -= 1;
        
        for (var i = finish; i > start; i--) {
            if (a[i] < a[i - 1]) {
                var t = a[i];
                a[i] = a[i - 1]; 
                a[i - 1] = t;
                sorted = false;
            }
        }
        start += 1;
    }
    
    return a;
}
