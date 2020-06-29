class Bank {
    constructor (bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer (customer) {
        // {firstName, lastName, personalId}
        this.allCustomers.forEach(c => {
            if (c.personalId === customer.personalId) {
                throw Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
            }
        });

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney (personalId, amount) {
        const customer = this._getClient(personalId);

        if (customer === undefined) {
            throw Error('We have no customer with this ID!');
        }

        if (customer.totalMoney === undefined) {
            customer.totalMoney = amount;
            customer.transactions = [`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`];
        } else {
            customer.totalMoney += amount;
            customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        }

        return `${customer.totalMoney}$`;
    }

    withdrawMoney (personalId, amount) {
        const customer = this._getClient(personalId);

        if (customer === undefined) {
            throw Error('We have no customer with this ID!');
        }

        if (customer.totalMoney === undefined || customer.totalMoney < amount) {
            throw Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    customerInfo (personalId) {
        const customer = this._getClient(personalId);

        if (customer === undefined) {
            throw Error('We have no customer with this ID!');
        }

        let info = `Bank name: ${this._bankName}\n`;
        info += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        info += `Customer ID: ${customer.personalId}\n`;
        info += `Total Money: ${customer.totalMoney}$\n`;
        info += `Transactions:\n`;
        for (let i = customer.transactions.length - 1; i >= 0; i--) {
            if (i === 0) {
                info += `${i + 1}. ${customer.transactions[i]}`;
            } else {
                info += `${i + 1}. ${customer.transactions[i]}\n`;
            }
        }

        return info;
    }

    _getClient(personalId) {
        let customer = undefined;
        this.allCustomers.forEach(c => {
            if (c.personalId === personalId) {
                customer = c;
            }
        })

        return customer;
    }
}


let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 6233267}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));