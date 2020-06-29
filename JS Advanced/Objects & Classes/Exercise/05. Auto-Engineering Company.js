"use strict" 

function solve (data){
    const cars = data.map(x => x.split('|').map(x => x.trim()))
        .reduce((acc, [brand, model, cars]) => {
            if (!acc[brand]) {
                acc[brand] = {};
            }
            if (!acc[brand][model]) {
                acc[brand][model] = 0;
            }
            acc[brand][model] += +cars;
            return acc;
        }, []);
    
    for (let [brand, model] of Object.entries(cars)) {
        console.log(brand);
        let cars = Object.entries(model).map(a => `###${a[0]} -> ${a[1]}`);
        console.log(cars.join('\n'));
    }
}


solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);