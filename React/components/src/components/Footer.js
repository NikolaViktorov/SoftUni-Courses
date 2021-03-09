import { Component } from 'react'
import Message from './Message'

class Footer extends Component {

    constructor(props) {
        super(props)
    }

    componentDidMount() {
        console.log("Mounted!");
    }

    render() {
        return <Message text="&copy; Copyright Rights go to GOKO Company" />
    }
}

export default Footer