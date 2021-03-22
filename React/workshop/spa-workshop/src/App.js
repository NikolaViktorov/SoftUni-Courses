import { Route, Switch } from 'react-router-dom';

import './App.css';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import { Categories } from './components/Categories/Categories';
import PetDetails from './components/PetDetails/PetDetails';

function App() {
  return (
    <div className="container">
      <Header />
      
      <Switch>
        <Route path="/" exact component={Categories} />
        <Route path="/pets/details/:petId" component={PetDetails} />
        <Route path="/categories/:category" component={Categories} />
      </Switch>

      <Footer />
    </div>
  );
}

export default App;
