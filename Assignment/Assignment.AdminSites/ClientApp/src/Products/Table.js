import React, { Component } from 'react';  
import axios from 'axios';  
import { Link } from 'react-router-dom'; 
import { Alert } from 'reactstrap';  
class Table extends Component {  
constructor(props) {  
    super(props);  
    }  

    DeleteProduct= () =>{  
        axios.delete('https://localhost:5445/api/Product/DeleteProduct?ProductId='+this.props.obj.id)  
        .then(json => {  
            if(json.data.id !=''){  
                console.log(this.props.obj.id);  
                if(window.confirm("Do you really want to delete?")){
                    window.location = "/ProductList";
                }
            } 
            else{
                alert('Sorry!!!');
            } 
        })  
    }  
    
    render() {  
        return (  
            <tr>  
            <td>  
                {this.props.obj.name}  
            </td>  
            <td>  
                {this.props.obj.price}  
            </td>  
            <td>  
                {this.props.obj.qty}  
            </td>  
            <td>  
                {this.props.obj.description}  
            </td>  
            <td>  
                {this.props.obj.image}  
            </td> 
            <td>  
                {this.props.obj.createdDate}  
            </td> 
            <td>  
                {this.props.obj.updatedDate}  
            </td> 
            <td>  
            <Link to={"/product/"+this.props.obj.id} className="btn btn-success">Edit</Link>  
            </td>  
            <td>  
                <button type="button" onClick={this.DeleteProduct} className="btn btn-danger">Delete</button>  
            </td>  
            </tr>  
        );  
    }  
}  

export default Table;