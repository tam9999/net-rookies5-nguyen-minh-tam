import { Button } from 'bootstrap';
import React, { useState } from 'react';
import './App.css';
//import CreateNewProduct from './components/CreateNewProduct';
import Product from './Products/Product';

function App() {
  const [productList, setproductList] = useState([])
  function getProduct(){
    const url ="https://localhost:5445/api/Product/GetAllProduct/"

    fetch(url,{
      method:'GET'
    }).then(res => res.json())
    .then((responsefronserver)=>{
      console.log(responsefronserver)
      setproductList(responsefronserver)
    })
    .catch(error => {
      console.log(error)
    })
  }
  return (
    <div className="container">
                <nav 
                  onClick={getProduct}
                  className="btn-warning  btn-lg w-100">
                  Get SuperHero Form Server
                  </nav>
                
              <Product></Product>
    </div>
    
  );
  function renderTable() {
    return (
      <nav className="btn btn-warning navbar navbar-expand-lg navheader">    
    
                <div className="collapse navbar-collapse" >  
                <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">ProductName</th>
              <th scope="col">Description</th>
              <th scope="col">Price</th>
              <th scope="col">Action</th>
            </tr>
          </thead>
          <tbody>
            {productList.map((item) => (
              <tr key={item.id}>
                <th scope="row"> {item.id} </th>
                <td>{item.productName}</td>
                <td>{item.description}</td>
                <td>{item.price}</td>
                
              </tr>
            ))}
          </tbody>
        </table>
      </div>
                </div>
    </nav>
      
    );
  }
}

export default App;