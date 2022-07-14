import React from 'react';  
import axios from 'axios';  
import { Container, Col, Form, Row, FormGroup, Label, Input, Button, Alert } from 'reactstrap';  
class AddCategory extends React.Component{  
constructor(props){  
    super(props)  
    this.state = {  
        categoryName:'',  
        description:'',  
        createdDate:'', 
        updatedDate:''  
    }  
}   



AddCategory=()=>{  
    axios.post('https://localhost:5445/api/Categories/AddCategory/', {
        categoryName:this.state.categoryName,
        description:this.state.description,  
        // createdDate:this.state.createdDate, 
        // updatedDate:this.state.updatedDate
    })  
    .then(json => {  
        if(json.data.id !==''){  
        console.log(json.data.Status);  
        alert('Create New Category Successfully!'); 
        window.location = "/CategoryList";  
        }  
        else{  
        alert('Data not Saved!');  
        //debugger;  
        //this.props.history.push('/CategoryList')  
        
        }  
    })  
}  

handleChange= (e)=> {  
this.setState({[e.target.name]:e.target.value});
}  

render() {  
return (  
    <Container className="App">  
        <h4 className="PageHeading">Enter New Category</h4>  
        <Form className="form">  
        <Col>  
            <FormGroup row>  
            <Label for="name" sm={2}>Category Name</Label>  
            <Col sm={10}>  
                <Input type="text" name="categoryName" onChange={this.handleChange} value={this.state.categoryName} placeholder="Enter categoryName" />  
            </Col>  
            </FormGroup>  
            <FormGroup row>  
            <Label for="description" sm={2}>Description</Label>  
            <Col sm={10}>  
                <Input type="text" name="description" onChange={this.handleChange} value={this.state.description} placeholder="Enter description" />  
            </Col>  
            </FormGroup>  
        </Col>  
        <Col>  
            <FormGroup row>  
            <Col sm={5}>  
            </Col>  
            <Col sm={1}>  
            <button type="button" onClick={this.AddCategory} className="btn btn-success">Submit</button>  
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

export default AddCategory;  