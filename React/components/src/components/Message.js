import { Component } from 'react'

class Message extends Component {

    constructor(props) {
        super(props)
    }

    ShowMessage() {
    }

    render() {
        return <span onClick={this.ShowMessage} >{this.props.text}</span>
    }
}

export default Message