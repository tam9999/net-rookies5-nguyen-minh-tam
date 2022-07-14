import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
//import './testStyles.css'
//import '../css/Vegetable.css'


let baseURL = "http://localhost:5002/api/Product/GetAllProduct/"
export default class Detail extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: [],
            
        };
    }

    refreshList() {
        axios.get(baseURL)
            .then(res => {
                this.setState({ products:res.data})
            })
    }


    deleteVegetable = (id) => {
        axios.delete(baseURL + "Product/DeleteProduct/" + id)
    }

    render() {
        const { products } = this.state;
        return (
            <div className="product-container">

                <h2>PRODUCTS</h2>
                <Link to="/vegetable-create" className="button"><i class="fa-solid fa-circle-plus"></i> CREATE</Link>
                <table >
                    <thead className="table-header">
                        <tr>
                            <th>Id</th>
                            <th>Category</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody className="table-body">
                        <tr>
                            <td>1</td>
                            <td>2</td>
                            <td>3</td>
                            <td>4</td>
                            <td>5</td>
                            <td className="button-container"><button className="button"><i class="fa-solid fa-pen"></i> Edit</button><button className="button delete-button"><i class="fa-solid fa-trash"></i> Delete</button></td>
                        </tr>
                        {products.map(p => (
                            <tr key={p.id}>
                                <td>{p.id}</td>
                                <td>{p.categoryId}</td>
                                <td>{p.productName}</td>
                                <td>{p.Price}</td>
                                <td>{p.Description}</td>
                                <td className="button-container">
                                    {/*<button className="button" value={vegetable.id} onClick={event => this.getVegetableInfo(event.target.value)}> <i class="fa-solid fa-pen"></i> Edit</button>*/}
                                    <button className="button delete-button" value={p.id} onClick={event => this.deleteVegetable(event.target.value)}><i class="fa-solid fa-trash"></i> Delete</button>
                                    {/*<button value={vegetable.id} >Delete</button>*/}
                                    {/*<button value={vegetable.id} >Edit</button>*/}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }

}