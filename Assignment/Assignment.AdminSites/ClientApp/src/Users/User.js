import React, { Component } from 'react';  
import axios from 'axios';  

export default class User extends Component {  

    constructor(props) {  
        super(props);  
        this.state = {user: []};  
        }  
        componentDidMount(){  
        //debugger;  
        axios.get('https://localhost:5445/api/Users/GetUsers')  
            .then(response => {  
            this.setState({ user: response.data });  
            //debugger;  

            })  
            .catch(function (error) {  
            console.log(error);  
            })  
        }  

        render() {  
            const {user} = this.state;
        return (  
            <div>  
            <h4 align="center">Customer List</h4>  
            <table className="table table-striped" style={{ marginTop: 10 }}>  
                <thead>  
                    <tr>
                        <th>Email</th>  
                        <th>First Name</th>
                        <th>Last Name</th>  
                        <th>Phone Number</th>
                        <th>Address</th>  
                        <th>Created Date</th>  
                        <th>Updated Date</th>  
                    
                    </tr>  
                </thead>  
                <tbody>  
                    {user.map(user => (
                        <tr key={user.email}>
                            <td>{user.email}</td>
                            <td>{user.firstName}</td>
                            <td>{user.lastName}</td>
                            <td>{user.phone}</td>
                            <td>{user.address}</td>
                            <td>{user.createdDate}</td>
                            <td>{user.updatedDate}</td>
                        </tr>
                        ))}
                </tbody>  
            </table>  
            </div>  
        );  
        }  
    }  