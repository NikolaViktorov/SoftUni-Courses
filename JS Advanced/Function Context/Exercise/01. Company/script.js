class Company {
    constructor (){
        this.departments = [];
    }
    addEmployee(username, salary, pos, depatment) {
        this._validateParam(username);
        this._validateParam(salary);
        this._validateParam(pos);
        this._validateParam(depatment);
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
        
        let cur = this.departments.find(d => d.name === depatment);

        if (cur === undefined) {
            cur = {
                name: depatment,
                employees: [] 
            };
            this.departments.push(cur);
        }
        
        cur.employees.push({username, salary, pos});
        return `New employee is hired. Name: ${username}. Position: ${pos}`
    }
    bestDepartment() {
        const departments = this.departments.map(d => {
            const de = Object.assign({}, d);
            de.averageSalary = d.employees.reduce((p, c, i, a) => {
                    return p + c.salary;
                }, 0) / d.employees.length;
            return de;
        }); 

        departments.sort((a, b) => b.averageSalary - a.averageSalary);

        const best = departments[0];
        if (best !== undefined) {
            best.employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));
            const result = [
                `Best Department is: ${best.name}`,
                `Average salary: ${best.averageSalary.toFixed(2)}`
            ];
            best.employees.forEach(e => {
                result.push(`${e.username} ${e.salary} ${e.pos}`)
            });
            return result.join('\n');
        }
    }
    _validateParam(param) {
        if (param === '' || param === undefined || param === null) {
            throw new Error('Invalid input!');
        }
    }
}


let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
