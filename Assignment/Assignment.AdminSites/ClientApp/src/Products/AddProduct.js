import React from 'react';  
import axios from 'axios';  
import { Container, Col, Form, Row, FormGroup, Label, Input, Button, Alert } from 'reactstrap';  
class AddProduct extends React.Component{  
constructor(props){  
    super(props)  
    this.state = {  
        categoryId:'',
        productName:'',  
        description:'', 
        price:'',
        qty:'', 
        createdDate:'', 
        updatedDate:'' ,
        image:'',
        imageId:'0',
        categories: [] 
    }  
}   

AddProduct=()=>{  
    debugger;
    //them hinh => idimage
    axios.post('https://localhost:5445/api/Product/AddProduct', {
        categoryId:this.state.categoryId,
        productName:this.state.productName,
        description:this.state.description,
        price:this.state.price,
        qty:this.state.qty,
        image:this.state.image,
        imageId:'0',
        
    })  
    .then(json => {  
        if(json.data.id !==''){  
        console.log(json.data.Status);  
        alert('Create New Product Successfully!'); 
        window.location = "/ProductList";  
        }  
        else{  
        alert('Data not Saved!'); 
        }  
    })  
    console.log(this.props);
}  

componentDidMount =()=>{  
    axios.get('https://localhost:5445/api/Categories/GetAllCategory')  
        .then(response => {  
        this.setState({ categories: response.data });  
        })  
        .catch(function (error) {  
        console.log(error);  
        })  
}

handleChange = (e)=> {  
this.setState({[e.target.name]:e.target.value});
}  

render() {  
return (  
    <Container className="App">  
        <h4 className="PageHeading">Enter New Product</h4>  
        <Form className="form">  
        <Col>  
            
            <FormGroup row>
                <Label sm={2} for="exampleSelect">Category</Label>
                <Col sm={10}>
                    <Input type="select" required>
                    {this.state.categories.map((category,index)=>{
                    return <option key={index} value={this.state.categoryId = category.id}>{category.categoryName}</option>
                    })}
                    </Input>
                </Col>
            </FormGroup>
            
            <FormGroup row>  
            <Label for="productName" sm={2}>Product Name</Label>  
            <Col sm={10}>  
                <Input type="text" name="productName" onChange={this.handleChange} value={this.state.productName} placeholder="Enter productName" required/>  
            </Col>  
            </FormGroup> 

            <FormGroup row>  
            <Label for="description" sm={2}>Description</Label>  
            <Col sm={10}>  
                <Input type="text" name="description" onChange={this.handleChange} value={this.state.description} placeholder="Enter description"required />  
            </Col>  
            </FormGroup> 

            <FormGroup row>  
            <Label for="price" sm={2}>Price</Label>  
            <Col sm={10}>  
                <Input type="number" name="price" onChange={this.handleChange} value={this.state.price} placeholder="Enter price" required />  
            </Col>  
            </FormGroup> 

            <FormGroup row>  
            <Label for="qty" sm={2}>Quantity</Label>  
            <Col sm={10}>  
                <Input type="number" name="qty" onChange={this.handleChange} value={this.state.qty} placeholder="Enter qty" required />  
            </Col>  
            </FormGroup>  

            <FormGroup row>  
            <Label for="image" sm={2}>Image</Label>  
            <Col sm={10}>  
                <Input ref={this.input} type="file" name="image" onChange={this.handleChange} value={this.state.image}  />  
            </Col>  
            </FormGroup> 
        </Col>  
        <Col>  
            <FormGroup row>  
            <Col sm={5}>  
            </Col>  
            <Col sm={1}>  
            <button type="button" onClick={this.AddProduct} className="btn btn-success">Submit</button>  
            </Col>  
            <Col sm={1}>  
                <Button color="danger">Cancel</Button>{' '}  
            </Col>  
            <Col sm={5}>  
            </Col>  
            </FormGroup>  
        </Col>  
        </Form>  
    </Container>  
);  
}  

}  

export default AddProduct;  