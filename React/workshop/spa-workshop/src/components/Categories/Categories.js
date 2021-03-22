import { Component } from 'react';

import CategoryNavigation from './CategoryNavigation/CategoryNavigation';
import * as petsService from '../../services/petsService';
import Pet from '../Pet/Pet';

export class Categories extends Component {

    constructor(props) {
        super(props);

        this.state = {
            pets: [],
            currentCategory: 'all'
        }
    }

    componentDidMount() {
        petsService.getAll()
            .then(pets => this.setState({ pets }));
    }

    componentDidUpdate(prevProps) {
        const category = this.props.match.params.category;

        if (prevProps.match.params.category == category) {
            return;
        }

        petsService.getAll(category)
            .then(res => {
                this.setState({ pets: res, currentCategory: category })
            })
    }

    render() {
        return (
            <section className="dashboard">
                <h1>Dashboard</h1>
    
                <CategoryNavigation />
    
                <ul className="other-pets-list">
                    {
                        this.state.pets.map(p => 
                            <Pet key={p.id} data={p} />
                            )
                    }
                </ul>
            </section>
        );
    }
};