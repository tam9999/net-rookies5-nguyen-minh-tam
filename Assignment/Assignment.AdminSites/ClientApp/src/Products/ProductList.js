import React, { Component, useEffect, useState } from 'react';  
import axios from 'axios';  
import Table from './Table';  
import Pagination from '@material-ui/lab/Pagination';
export default class ProductList extends Component {  
    
    constructor(props) {  
        super(props);  
        this.handlePageChange = this.handlePageChange.bind(this);
        this.state = {
            business: [],
            numberPage: 0,  
            pageNo: 1,  
            pageSize: 4,  
            
        };  
        }  
        
        componentDidMount(){  
        //debugger;  
        axios.get(`https://localhost:5445/api/Product/GetAllProduct/${this.state.pageNo}/${this.state.pageSize}`)  
            .then(response => {  
            this.setState({ 
                business: response.data.products,
                numberPage: response.data.numberPage,
                pageNo: response.data.currentPage
            });    
            console.log(response.data);
            })  
            .catch(function (error) {  
            console.log(error);  
            })  
        }  
        handlePageChange(event, value) {
            this.setState(
                {
                    pageNo: value,
                },
                () => {
                    this.componentDidMount();
                }
                );
            }
        tabRow(){  
        return this.state.business.map(function(object, i){  
            return <Table obj={object} key={i} />;  
        });  
        }  
        
        render() {  
            const {
                pageNo,
                numberPages
            } = this.state;
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
            <Pagination 
            count={this.state.numberPage} 
            page={pageNo}
            color="primary"
            onChange={this.handlePageChange}
            />
            </div>  
        );  
        }  
    }  