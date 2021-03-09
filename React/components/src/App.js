import './App.css';
import Heading from './components/Heading';
import Body from './components/Body';
import BookList from './components/BookList'
import Counter from './components/Counter';

const books = [
  {title: 'The Lord of the Rings', description: 'The best film!'},
  {title: 'The Hobbit', description: 'Hobbits are small!'},
  {title: 'Robin Hood', description: 'Arrow man!'},
];

function App() {
  return (
    <div className="site-wrapper">
      <Heading />
      <Body />

      <Counter />
      <Counter />

      <BookList books={books} />
    </div>
  );
}

export default App;
