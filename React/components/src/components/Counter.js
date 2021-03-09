import { Component } from 'react'

class Counter extends Component {
    constructor(props) {
        super(props)

        this.state = {
            count: 11
        };
    }

    decreaseCounter() {
        this.setState(prevState => ({count: prevState.count - 1}));
    }

    render() {
        return (
            <div className="counter">
                <h4>Book Counter</h4>
                <span>{this.state.count}</span>
                <button onClick={(e) => this.setState({count: this.state.count + 1})}>+</button>
                <button onClick={(e) => this.decreaseCounter()}>-</button>
            </div>
        );
    }
}

export default Counter;