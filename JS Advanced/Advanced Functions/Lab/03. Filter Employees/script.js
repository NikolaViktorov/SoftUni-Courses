function sort(data, criteria) {
    // parse the input
    const employees = JSON.parse(data);
    const [criteriaName, criteriaValue] = criteria.split('-');

    let counter = 0;
    // sort and print employees that match criteria if all print all
    employees.forEach(p => {
        if(p[criteriaName] === criteriaValue) {
            console.log(`${counter}. ${p.first_name} ${p.last_name} - ${p.email}`)
            counter++;
        }
    });  

}


sort(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female'
);