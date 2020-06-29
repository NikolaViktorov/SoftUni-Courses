"use strict"

function solve(input, criteria) {
    class Ticket {
        constructor(descriptor) {
            const [destination, price, status] = descriptor.split('|');
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const comparator = {
        destination: (a, b) => a.destination.localeCompare(b.destination),
        price: (a, b) => a - b,
        status: (a, b) => a.status.localeCompare(b.status)
    };

    return input.map(t => new Ticket(t)).sort(comparator[criteria]);
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');