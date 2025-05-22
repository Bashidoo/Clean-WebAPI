import logo from './logo.svg';
import './App.css';
import ProductList from './api/productList';


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <ProductList />
      </header>
    </div>
  );
}

export default App;
