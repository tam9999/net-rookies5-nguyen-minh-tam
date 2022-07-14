import React from 'react';   
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';  
import axios from 'axios'  
import {useLocation, useNavigate, useParams } from 'react-router-dom'

class EditProduct extends React.Component {  
    constructor(props) {  
        super(props);  

        this.state = {  
            productName:'',
            price: '',
            qty:'',
            description:'',  
            image: '',  
            createdDate: '',  
            updatedDate: '' ,
            categoryId:'' ,
            categories: [] 

        }  
    
    }  
    
    componentDidMount =()=> {  
        axios.get('https://localhost:5445/api/Product/'+this.props.params.productId)  
            .then(response => {  
                this.setState({   
                    productName: response.data.name,   
                    price: response.data.price,  
                    qty: response.data.qty,  
                    description: response.data.description,
                    image: response.data.image,
                    categoryId: response.data.categoryId });  
                })  
                .catch(function (error) {  
                    console.log(error);  
                })  
        //console.log(this.props.params.categoryId)
        console.log(this.props)
        axios.get('https://localhost:5445/api/Categories/GetAllCategory')  
            .then(response => {  
            this.setState({ categories: response.data });  
            })  
            .catch(function (error) {  
            console.log(error);  
            }) 
        }  
    
    onChangeName = (e) => {  
    this.setState({  
        productName: e.target.value  
    });  
}  
    onChangePrice = (e) => {  
    this.setState({  
        price: e.target.value  
    });    
}  
    onChangeQty = (e) => {  
    this.setState({  
        qty: e.target.value  
    });  
}  
    onChangeDes = (e) => {  
        this.setState({  
            description: e.target.value  
        });  
}  
onChangeImage = (e) => {  
    this.setState({  
        image: e.target.value  
    });  
}
onChangeCategory = (e) => {  
    this.setState({  
        categoryId: e.target.value  
    });  
}  
onSubmit = (e) => {  
//debugger;  
    e.preventDefault();  
    const obj = {  
        Id: this.props.params.productId,  
        productName: this.state.productName,  
        price: this.state.price,  
        qty: this.state.qty,   
        description: this.state.description,
        image: this.state.image,
        categoryId: this.state.categoryId
        //updatedDate: this.state.updatedDate  
    
    };  
    axios.put('https://localhost:5445/api/Product/UpdateProduct', obj)  
        .then(res => console.log(res.data));  
        debugger;  
        // this.props.history.push('/Studentlist')  
        console.log(obj);
        alert('Update Successfully!');
        window.location = "/ProductList";
        
}  
    render() {  
        const {categories} = this.state;
        return (  
            <Container className="App">  

            <h4 className="PageHeading">Update Product</h4>  
                <Form className="form" onSubmit={this.onSubmit}>  
                    <Col>  
                        <FormGroup row>
                            <Label sm={2} for="exampleSelect">Category</Label>
                            <Col sm={10}>
                                <Input type="select" required>
                                {this.state.categories.map((category,index)=>{
                                return <option key={index} value={this.state.categoryId = category.id} onChange={this.onChangeCategory}>{category.categoryName}</option>
                                })}
                                </Input>
                            </Col>
                        </FormGroup>

                        <FormGroup row>  
                            <Label for="name" sm={2}>Product Name</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="productName" value={this.state.productName} onChange={this.onChangeName}  
                                placeholder="Enter Product Name" />  
                            </Col>  
                        </FormGroup>  

                        <FormGroup row>  
                            <Label for="price" sm={2}>Price</Label>  
                            <Col sm={10}>  
                                <Input type="number" name="price" value={this.state.price} onChange={this.onChangePrice}  
                                placeholder="Enter Price" />  
                            </Col>  
                        </FormGroup>  

                        <FormGroup row>  
                            <Label for="qty" sm={2}>Quantity</Label>  
                            <Col sm={10}>  
                                <Input type="number" name="qty" value={this.state.qty} onChange={this.onChangeQty}  
                                placeholder="Enter Quantity" />  
                            </Col>  
                        </FormGroup>  

                        <FormGroup row>  
                            <Label for="description" sm={2}>Description</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="description" value={this.state.description} onChange={this.onChangeDes}  
                                placeholder="Enter Description" />  
                            </Col>  
                        </FormGroup>  

                        <FormGroup row>  
                            <Label for="image" sm={2}>Description</Label>  
                            <Col sm={10}>  
                                <Input type="file" name="image"  onChange={this.onChangeImage} placeholder="Enter Image" />  
                            </Col>  
                        </FormGroup>  
                    </Col>  
                    <Col>  
                        <FormGroup row>  
                            <Col sm={5}>  
                            </Col>  
                            <Col sm={1}>  
                            <Button type="submit" color="success">Submit</Button>{' '}  
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

const withRouter = (Component) => (props) => {
    const history = useNavigate();
    const location = useLocation();
    const params = useParams(); 
    return <Component params = {params} history={history} location={location} {...props} />;
};

export default withRouter(EditProduct);
