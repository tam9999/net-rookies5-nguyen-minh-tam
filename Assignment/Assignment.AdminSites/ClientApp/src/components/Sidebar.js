import React, { Component } from 'react';
import classnames from "classnames";
import Header from "./Header";
import "bootstrap/dist/css/bootstrap.min.css";
import "./Sidebar.css";
import Product from "../Products/Product";
import { Link } from 'react-router-dom';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';

class Sidebar extends React.Component {
    state = {
        open: window.matchMedia("(min-width: 1024px)").matches || false
    };

    ontoggleNav = () => {
        this.setState(prevState => ({
        open: !prevState.open
        }));
    };

    render() {
        const { open } = this.state;
        const mobile = window.matchMedia("(max-width: 768px)").matches;
        console.log(mobile, open);
        return (
        <div>
            <div className="navHeaderWrap">
            <Header ontoggleNav={this.ontoggleNav} />
            </div>
            <div className="bodyWrap">
            <div className={classnames({ blur: mobile && open })} />
            <div
                className={classnames(
                "sidenav",
                { sidenavOpen: open },
                { sidenavClose: !open }
                )}
            >
                <a
                href="javascript:void(0)"
                className="closebtn hidex"
                onClick={() => this.ontoggleNav("0px")}
                >
                &times;
                </a>

            <Navbar className="navbar" light>
                {/* <NavbarBrand tag={Link} to="/"><img src="/NavbarLogo.png" alt="Logo" className="navbar-logo"/></NavbarBrand> */}
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
            </div>

        <div
        className={classnames(
            "main",
            { mainShrink: open },
            { mainExpand: !open },
            { noscroll: mobile && open }
        )}
        >

        </div>
    </div>
    </div>
);
}
}

export default Sidebar;
