import React from 'react';
import axios from 'axios';
import '../Products/Create.css'
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';

class Create extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            ProductName: '',
            Qty: '',
            Image: '',
            Price: '',
            Description: '',
            CreatedDate: '',
            UpdatedDate: '',
            IsDeleted: '',
            CategoryId: '',
            ProductRatingId: ''
        }
    }
    CreateProduct = () => {
        axios.post('https://localhost:5445/api/Product/AddProduct/', {
            ProductName: this.state.ProductName, Qty: this.state.Qty,
            Image: this.state.Image, Price: this.state.Price, Description: this.state.Description,
            CreatedDate: this.state.CreatedDate, UpdatedDate: this.state.UpdatedDate, IsDeleted: this.state.IsDeleted,
            CategoryId: this.state.CategoryId, ProductRatingId: this.state.ProductRatingId,
        })
            .then(json => {
                if (json.data.Status === 'Success') {
                    console.log(json.data.Status);
                    alert("Data Save Successfully");
                    this.props.history.push('/Studentlist')
                }
                else {
                    alert('Data not Saved');
                    debugger;
                    this.props.history.push('/Studentlist')
                }
            })
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    }

    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Product Informations</h4>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="ProductName" sm={2}>ProductName</Label>
                            <Col sm={10}>
                                <Input type="text" name="ProductName" onChange={this.handleChange} value={this.state.ProductName} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Qty" sm={2}>Qty</Label>
                            <Col sm={10}>
                                <Input type="text" name="Qty" onChange={this.handleChange} value={this.state.Qty} placeholder="Enter Qty" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Password" sm={2}>Class</Label>
                            <Col sm={10}>
                                <Input type="text" name="Class" onChange={this.handleChange} value={this.state.Class} placeholder="Enter Class" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Password" sm={2}>Address</Label>
                            <Col sm={10}>
                                <Input type="text" name="Address" onChange={this.handleChange} value={this.state.Address} placeholder="Enter Address" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <button type="button" onClick={this.Addstudent} className="btn btn-success">Submit</button>
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

export default Create;  