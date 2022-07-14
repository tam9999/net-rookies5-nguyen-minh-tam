import React, { Component } from 'react';  
import axios from 'axios';  
import { Link } from 'react-router-dom'; 
import { Alert } from 'reactstrap';  
class Table extends Component {  
constructor(props) {  
    super(props);  
    }  

    DeleteCategory= () =>{  
        axios.delete('https://localhost:5445/api/Categories/DeleteCategory?categoryId='+this.props.obj.id)  
        .then(json => {  
            if(json.data.id !=''){  
                console.log(this.props.obj.id);  
                if(window.confirm("Do you really want to delete?")){
                    window.location = "/CategoryList";
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
                {this.props.obj.categoryName}  
            </td>  
            <td>  
                {this.props.obj.description}  
            </td>  
            <td>  
                {this.props.obj.createdDate}  
            </td>  
            <td>  
                {this.props.obj.updatedDate}  
            </td>  
            <td>  
            <Link to={"/edit/"+this.props.obj.id} className="btn btn-success">Edit</Link>  
            </td>  
            <td>  
                <button type="button" onClick={this.DeleteCategory} className="btn btn-danger">Delete</button>  
            </td>  
            </tr>  
        );  
    }  
}  

export default Table;