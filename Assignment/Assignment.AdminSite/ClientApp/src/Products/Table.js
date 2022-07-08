import React, { Component } from 'react';  
import axios from 'axios';  
import { Link } from 'react-router-dom';  
class Table extends Component {  
constructor(props) {  
    super(props);  
    }  

    DeleteProduct= () =>{  
    axios.delete('https://localhost:5445/api/Product/DeleteProduct?productId='+this.props.obj.Id)  
    .then(json => {  
    if(json.data != null){  
    alert('Record deleted successfully!!');  
    }  
    })  
    }  
    render() {  
        return (  
        <tr>  
            <td>  
                {this.props.obj.ProductName}  
            </td>  
            <td>  
                {this.props.obj.Qty}  
            </td>  
            <td>  
                {this.props.obj.Image}  
            </td>  
            <td>  
                {this.props.obj.Price}  
            </td> 
            <td>  
                {this.props.obj.Description}  
            </td>
            <td>  
                {this.props.obj.CreatedDate}  
            </td>
            <td>  
                {this.props.obj.UpdatedDate}  
            </td>
            <td>  
                {this.props.obj.IsDeleted}  
            </td>
            <td>  
                {this.props.obj.CategoryId}  
            </td>
            <td>  
                {this.props.obj.ProductRatingId}  
            </td>  
            {/* <td>  
            <Link to={"/edit/"+this.props.obj.Id} className="btn btn-success">Edit</Link>  
            </td>   */}
            <td>  
                <button type="button" onClick={this.DeleteProduct} className="btn btn-danger">Delete</button>  
            </td>  
        </tr>  
    );  
    }  
}  

export default Table; 