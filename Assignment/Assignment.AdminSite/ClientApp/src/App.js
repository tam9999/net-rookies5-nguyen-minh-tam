import { Button } from 'bootstrap';
import React, { useState } from 'react';
import './App.css';
import Sidebar from './components/Sidebar';
//import CreateNewProduct from './components/CreateNewProduct';
import Product from './Products/Product';
import { Router } from "react-router";

function App() {
  return (
    <div className="container">
      
      <Sidebar />
      
    </div>
    
  );
}

export default App;