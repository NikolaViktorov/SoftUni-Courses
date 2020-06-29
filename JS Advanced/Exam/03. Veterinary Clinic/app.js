class VeterinaryClinic {
    constructor (clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];

        this.currentWorkload = 0;
        this.totalProfit = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.currentWorkload + 1 > this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }
        let c = this.clients.find(c => c.name === ownerName);
        if (c !== undefined) {
            let p = c.pets.find(p => p.name === petName);
            if (p !== undefined && p.procedures.length > 0) {
                throw new Error(`This pet is already registered under ${c.name} name! ${p.name} is on our lists, waiting for ${p.procedures.join(', ')}.`)
            } else if (p !== undefined) {
                p.procedures = procedures;
            } else {
                p = {
                    name: petName,
                    kind: kind,
                    procedures: []
                };
                p.procedures = procedures;

                c.pets.push(p);

                this.currentWorkload++;
            }
        } else {
            let newC = {
                name: ownerName,
                pets: []
            };

            let p = {
                name: petName,
                kind: kind,
                procedures: []
            };
            p.procedures = procedures;

            newC.pets.push(p);
            this.clients.push(newC);
            this.currentWorkload++;
        }

        return `Welcome ${petName}!`;
    }

    onLeaving (ownerName, petName) {
        let c = this.clients.find(c => c.name === ownerName);
        if (c === undefined) {
            throw new Error(`Sorry, there is no such client!`);
        }
        let p = c.pets.find(p => p.name === petName);
        if (p === undefined || p.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        this.totalProfit += p.procedures.length * 500;
        this.currentWorkload--;
        p.procedures = [];

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString () {
        let result = `${this.clinicName} is ${Math.floor((this.currentWorkload/this.capacity)*100)}% busy today!\n`;
        result += `Total profit: ${this.totalProfit.toFixed(2)}$`;

        this.clients.sort((a, b) => a.name.localeCompare(b.name));
        this.clients.forEach(c => {
            c.pets.sort((a, b) => a.name.localeCompare(b.name));
        });

        this.clients.forEach(c => {
            result += `\n${c.name} with:`
            c.pets.forEach(p => {
                result += `\n---${p.name} - a ${p.kind.toLowerCase()} that needs: ${p.procedures.join(', ')}`;
            });
        });

        return result;
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']); 
console.log(clinic.toString());