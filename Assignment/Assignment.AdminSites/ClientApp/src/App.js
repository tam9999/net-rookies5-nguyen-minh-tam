import React from 'react';  
import AddCategory from './Category/AddCategory';  
import CategoryList from './Category/CategoryList';  
import EditCategory from './Category/EditCategory'; 
import AddProduct from './Products/AddProduct';
import ProductList from './Products/ProductList';  
import EditProduct from './Products/EditProduct';
import User from './Users/User';
import Login from './Auth/Login';
import { Route, Routes, Navigate } from 'react-router-dom'
import { Link } from 'react-router-dom';
import './App.css';  

function App() {  
    return (  
        <>
        <div className="container">  
            <nav className="navbar navbar-expand-lg navheader">  
            <div className="collapse navbar-collapse" >  
                <ul className="navbar-nav mr-auto">  
                <li className="nav-item">  
                    <Link to={'/AddCategory'} className="nav-link">Create Category</Link>  
                </li>  
                <li className="nav-item">  
                    <Link to={'/CategoryList'} className="nav-link">Category List</Link>  
                </li>
                <li className="nav-item">  
                    <Link to={'/AddProduct'} className="nav-link">Create Product</Link>  
                </li>
                <li className="nav-item">  
                    <Link to={'/ProductList'} className="nav-link">Product List</Link>  
                </li>
                <li className="nav-item">  
                    <Link to={'/User'} className="nav-link">Customer</Link>  
                </li>
                </ul>  
            </div>  
            </nav> <br />  
            <Routes>  
            <Route index element={<Navigate to="/ProductList" replace />} />
            <Route path='/AddCategory' element={<AddCategory />} />  
            <Route path='/edit/:categoryId' element={<EditCategory />} />  
            <Route path='/CategoryList' element={<CategoryList />} />  
            <Route path='/AddProduct' element={<AddProduct />} />
            <Route path='/product/:productId' element={<EditProduct />} />  
            <Route path='/ProductList' element={<ProductList />} /> 
            <Route path='/User' element={<User />} /> 
            <Route path='/Login' element={<Login />} /> 
            </Routes>  
        </div>  
        </>
    );  
}  

export default App;  
