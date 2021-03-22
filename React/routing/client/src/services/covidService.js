const covidApiUrl = "https://localhost:44326/covid";

export const getInfected = () => {
    return fetch((covidApiUrl + '/infected'))
        .then(res => res.json())
        .catch(err => console.log(err));
}
