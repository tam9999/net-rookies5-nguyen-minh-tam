import React, { Component } from 'react';  
import axios from 'axios';
import Table from './Table';

export default class List extends Component {
    constructor(props) {
        super(props);
        this.state = { business: [] };
    }
    componentDidMount() {
        debugger;
        axios.get('https://localhost:5445/api/Product/GetAllProduct/')
            .then(response => {
                this.setState({ business: response.data });
                debugger;
            })
            .catch(function (error) {
                console.log(error);
            })
    }
    tabRow() {
        return this.state.business.map(function (object, i) {
            return <Table obj={object} key={i} />;
        });
    }
    render() {
        return (
            <div>
                <h4 align="center">List Product</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th>Qty</th>
                            <th>Image</th>
                            <th>Price</th>
                            <th>Description</th>
                            <th>Created Date</th>
                            <th>UpdatedDate</th>
                            <th>IsDeleted</th>
                            <th>Category Id</th>
                            <th>Product Rating Id</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.tabRow()}
                    </tbody>
                </table>
            </div>
        );
    }
}
