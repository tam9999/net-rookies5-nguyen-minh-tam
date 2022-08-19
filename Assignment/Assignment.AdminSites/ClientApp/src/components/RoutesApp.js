import React from "react";
import { Switch, Router } from "react-router-dom";
import RouteGuard from "./RouteGuard";
import { Layout } from './Layout';
//history
import { history } from "../Auth/history";

//pages
import AddCategory from '../Category/AddCategory';  
import CategoryList from '../Category/CategoryList';  
import EditCategory from '../Category/EditCategory'; 
import AddProduct from '../Products/AddProduct';
import ProductList from '../Products/ProductList';  
import EditProduct from '../Products/EditProduct';
import User from '../Users/User';
import Login from '../Auth/Login';
import { Route, Routes, Link } from 'react-router-dom'


function RoutesApp() {
    return (
        <>
            <Router history={history}>
                <Routes>
                <Route path="/Login" element={<Login />} />
                
                    <RouteGuard exact path='/AddCategory' element={<AddCategory />} />  
                    <RouteGuard path='/edit/:categoryId' element={<EditCategory />} />  
                    <RouteGuard path='/CategoryList' element={<CategoryList />} />  
                    <RouteGuard path='/AddProduct' element={<AddProduct />} />
                    <RouteGuard path='/product/:productId' element={<EditProduct />} />  
                    <RouteGuard path='/ProductList' element={<ProductList />} /> 
                    <RouteGuard path='/User' element={<User />} /> 
                </Routes>
            </Router>
        </>
    );
}

export default RoutesApp;