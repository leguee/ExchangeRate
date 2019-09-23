import React, { Component} from 'react';
import './App.css';
import Cotizaciones from '../Components/Cotizaciones';

class App extends Component {
  render(){
    return(
      <div className="App">
       <Cotizaciones />
      </div>
    );
  }
}

export default App;
