import React, { Component, useRef } from "react";
import axios from "axios";
import { setAuthToken } from "./setAuthToken";
import { Button } from 'reactstrap';


let baseAddress = "https://localhost:5445/api/";
export default class Login extends Component{
    // Base api URL


    handleSubmit = (e) => {
        e.preventDefault();
        let loginPayload = {
            Email: this.refs.Email.value,
            Password: this.refs.Password.value
        }
        // Login request
        if(loginPayload.Username===''||loginPayload.Password===''){
            alert("Do not leave fields empty!!!")
            return;
        }
        axios
            .post(baseAddress + "Users/login", loginPayload)
            .then((response) => {
                // Get token from response
                const accessToken = response.data.accessToken;
                
                // Set JWT token to local
                localStorage.setItem("accessToken", accessToken);

                // Set token to axios common header
                setAuthToken(accessToken);

                // Redirect user to Home page

                // window.location.href="/"
                if(accessToken){
                    alert("Login success. Redirecting to Dashboard")
                    window.location.href="/"
                }
                if(!accessToken){
                    alert("Wrong Username or Password")
                }
                // if(!response.data.token)
                
            })
            .catch((error) => {
                alert("Something went wrong")
            });
    };
    render() {
        return (
            <div className="login-container">
                <form className="card-body p-5 text-center login-input-container">
                    <h2 className="mb-5">Log In</h2>
                        <div className="form-group mb-4">
                            <input
                                type="email"
                                className="form-control form-control-lg"
                                id="Email"
                                name="Email"
                                placeholder="Email"
                                ref="Email"
                                required
                            />
                        </div>
                        <div className="form-outline mb-4">
                            <input
                                type="password"
                                className="form-control form-control-lg"
                                id="password"
                                name="password"
                                placeholder="Password"
                                ref="Password"
                                required
                            />
                        </div>
                        <Button
                        color="warning"
                        className="button"
                        type="submit"
                        onClick={this.handleSubmit}
                        >
                            Login
                        </Button>
                </form>
            </div>
        );
    }
}

