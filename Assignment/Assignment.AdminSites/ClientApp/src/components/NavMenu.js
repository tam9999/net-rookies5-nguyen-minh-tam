import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
//import './NavMenu.css';

export default class NavMenu extends Component {
static displayName = NavMenu.name;

constructor (props) {
    super(props);

}



    render () {
        return (
        <>
            
            <Navbar className="navbar" light>
                <NavbarBrand tag={Link} to="/"><img src="/NavbarLogo.png" alt="Logo" className="navbar-logo"/></NavbarBrand>
                    <ul className="navbar-nav">
                    <NavItem>
                            <NavLink tag={Link} className="navbar-link" to="/"><i class="fa-solid fa-house"></i> Home</NavLink>
                    </NavItem>
                    <NavItem>
                            <NavLink tag={Link} className="navbar-link" to="/counter"><i class="fa fa-list-alt" aria-hidden="true"></i> Cateogry</NavLink>
                    </NavItem>
                    <NavItem>
                            <NavLink tag={Link} className="navbar-link" to="/vegetable"><i class="fa-solid fa-apple-whole"></i> Product</NavLink>
                    </NavItem>
                    <NavItem>
                            <NavLink tag={Link} className="navbar-link" to="/image"><i class="fa-solid fa-image"></i> Image</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={Link} className="navbar-link" to="/product-list"><i class="fa-solid fa-image"></i> Test</NavLink>
                    </NavItem>
                    
                    </ul>
            </Navbar>
        </>
        );
    }
}
