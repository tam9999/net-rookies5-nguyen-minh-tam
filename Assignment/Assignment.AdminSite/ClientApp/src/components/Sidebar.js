import React from "react";
import classnames from "classnames";
import Header from "./Header";
import "bootstrap/dist/css/bootstrap.min.css";
import "./Sidebar.css";
import Product from "../Products/Product";
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';

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

                <a href="#">
                <i class="fa fa-fw fa-home" />
                Home
                </a>
                <Routes>
                    <Route element={<Produt />}></Route>
                </Routes>
                <a href="#">Category</a>
                <a href="#">Customer</a>
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
