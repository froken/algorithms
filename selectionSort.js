function selectionSort(a) {
    var sorted = 0;
    var t;
    var mini;
    
    for (var i = 0; i < a.length; i++) {
        mini = i;
        
        for (var j = i + 1; j < a.length; j++) {
            if (a[j] < a[mini]) {
                mini = j;
            }
        }
        
        t = a[j];
        a[j] = a[mini];
        a[mini] = t;
    }
}
