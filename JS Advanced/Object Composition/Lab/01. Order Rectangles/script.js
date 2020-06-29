function solve(recs) {
    const orderedRecs = [];
    for (let rec of recs) {
        [w, h] = rec;
        orderedRecs.push({
            width: w,
            height: h,
            area: function() { return this.width * this.height},
            compareTo: function(other) {
                return other.area() - this.area() || other.width - this.width;
            }
        });
    }

    orderedRecs.sort((a, b) => a.compareTo(b));

    return orderedRecs;
}


solve([[10,5],[5,12]]);
solve([[10,5], [3,20], [5,12]])