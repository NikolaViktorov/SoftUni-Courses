import { Component } from 'react'
import Book from './Book'

class BookList extends Component {
    constructor(props) {
        super(props); 
    }

    render() {
        return (
            <div className="book-list">
                <h2>Book Collection:</h2>
                {
                    this.props.books.map(x => {
                        return <Book
                            key={x._id} 
                            title={x.title}
                            description={x.description} 
                         />;
                    })
                }
            </div>
        )
    }
}

export default BookList;