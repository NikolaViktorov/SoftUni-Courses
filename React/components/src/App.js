import './App.css';
import Heading from './components/Heading';
import Body from './components/Body';
import BookList from './components/BookList'
import Counter from './components/Counter';
import Footer from './components/Footer';

const books = [
  {_id: 1, title: 'The Lord of the Rings', description: 'The best film!'},
  {_id: 2, title: 'The Hobbit', description: 'Hobbits are small!'},
  {_id: 3, title: 'Robin Hood', description: 'Arrow man!'},
];

function App() {
  return (
    <div className="site-wrapper">
      <Heading />
      <Body />

      <Counter />
      <Counter />

      <BookList books={books} />

      <Footer />
    </div>
  );
}

export default App;
