import React from 'react';   
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';  
import axios from 'axios'  
import {useLocation, useNavigate, useParams } from 'react-router-dom'

class EditCategory extends React.Component {  
    constructor(props) {  
        super(props);  

        //this.state(this.onChangeName).bind(this);
    // this.onChangeName = this.onChangeName.bind(this);  
    // this.onChangeRollNo = this.onChangeRollNo.bind(this);  
    // this.onChangeClass = this.onChangeClass.bind(this);  
    // this.onChangeAddress = this.onChangeAddress.bind(this);  
    // this.onSubmit = this.onSubmit.bind(this);  

        this.state = {  
            categoryName: '',  
            description: '',  
            createdDate: '',  
            updatedDate: ''  

        }  
    
    }  

    componentDidMount() {  
        axios.get('https://localhost:5445/api/Categories/GetCategoryById?categoryId='+this.props.params.categoryId)  
            .then(response => {  
                this.setState({   
                    categoryName: response.data.categoryName,   
                    description: response.data.description,  
                    createdDate: response.data.createdDate,  
                    updatedDate: response.data.updatedDate });  
                    console.log()
                })  
                .catch(function (error) {  
                    console.log(error);  
                })  
        //console.log(this.props.params.categoryId)
        console.log(this.props)
        }  

    onChangeName = (e) => {  
    this.setState({  
        categoryName: e.target.value  
    });  
}  
    onChangeRollNo = (e) => {  
    this.setState({  
        description: e.target.value  
    });    
}  
    onChangeClass = (e) => {  
    this.setState({  
        createdDate: e.target.value  
    });  
}  
    onChangeAddress = (e) => {  
        this.setState({  
            updatedDate: e.target.value  
        });  
}  

onSubmit = (e) => {  
//debugger;  
    e.preventDefault();  
    const obj = {  
        Id: this.props.params.categoryId,  
        categoryName: this.state.categoryName,  
        description: this.state.description,  
        // createdDate: this.state.createdDate,  
        updatedDate: this.state.updatedDate  
    
    };  
    axios.put('https://localhost:5445/api/Categories/', obj)  
        .then(res => console.log(res.data));  
        //debugger;  
        // this.props.history.push('/Studentlist')  
        console.log(obj);
        alert('Update Successfully!');
        window.location = "/CategoryList";
        
}  
    render() {  
        return (  
            <Container className="App">  

            <h4 className="PageHeading">Update Category</h4>  
                <Form className="form" onSubmit={this.onSubmit}>  
                    <Col>  
                        <FormGroup row>  
                            <Label for="name" sm={2}>Category Name</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="categoryName" value={this.state.categoryName} onChange={this.onChangeName}  
                                placeholder="Enter categoryName" />  
                            </Col>  
                        </FormGroup>  
                        <FormGroup row>  
                            <Label for="Password" sm={2}>Description</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="description" value={this.state.description} onChange={this.onChangeRollNo} placeholder="Enter description" />  
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

export default withRouter(EditCategory);
