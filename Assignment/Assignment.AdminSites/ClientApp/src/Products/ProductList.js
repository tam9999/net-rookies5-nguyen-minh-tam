import React, { Component } from 'react';  
import axios from 'axios';  
import Table from './Table';  

export default class ProductList extends Component {  

    constructor(props) {  
        super(props);  
        this.state = {business: []};  
        }  
        componentDidMount(){  
        //debugger;  
        axios.get('https://localhost:5445/api/Product/GetAllProduct')  
            .then(response => {  
            this.setState({ business: response.data });  
            //debugger;  

            })  
            .catch(function (error) {  
            console.log(error);  
            })  
        }  

        tabRow(){  
        return this.state.business.map(function(object, i){  
            return <Table obj={object} key={i} />;  
        });  
        }  

        render() {  
        return (  
            <div>  
            <h4 align="center">Product List</h4>  
            <table className="table table-striped" style={{ marginTop: 10 }}>  
                <thead>  
                <tr>
                    <th>Product Name</th>  
                    <th>Price</th>
                    <th>Quantity</th>  
                    <th>Description</th>
                    <th>Image</th>  
                    <th>Created Date</th>  
                    <th>Updated Date</th>  
                    <th colSpan="4">Action</th>  
                </tr>  
                </thead>  
                <tbody>  
                { this.tabRow() }   
                </tbody>  
            </table>  
            </div>  
        );  
        }  
    }  