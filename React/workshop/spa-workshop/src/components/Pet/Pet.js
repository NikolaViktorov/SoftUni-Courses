import { Link } from 'react';

const Pet = ({
    data
}) => {
    
    return (
        <li className="otherPet">
            <h3>Name: {data.name}</h3>
            <p>Category: {data.category}</p>
            <p className="img"><img src={data.imageURL} /></p>
            <p className="description">{data.description}</p>
            <div className="pet-info">
                <Link to=""><button className="button"><i className="fas fa-heart"></i> Pet</button></Link>
                <Link to={`/pets/details/${data.id}`}><button className="button">Details</button></Link>
                <i className="fas fa-heart"></i> <span> {data.likes}</span>
            </div>
        </li>
    );
}

export default Pet;