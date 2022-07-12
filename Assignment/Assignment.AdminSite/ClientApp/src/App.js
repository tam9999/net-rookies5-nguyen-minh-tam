import { Button } from 'bootstrap';
import React, { useState } from 'react';
import './App.css';
import Sidebar from './components/Sidebar';
//import CreateNewProduct from './components/CreateNewProduct';
import Product from './Products/Product';

function App() {
  return (
    <div className="container">
      <Product></Product>
      <Sidebar />
    </div>
    
  );
}

export default App;