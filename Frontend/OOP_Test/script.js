function Station(city, lines) {
    this.city = city;
    this.lines = lines;
    this.getLine = function() {
        return this.lines;
    }
}

bh1 = new Station("Jena", 5);
bh2 = new Station("Köln", 10);