import React from "react";
import { Route, Navigate  } from "react-router-dom";

const RouteGuard = ({ component: Component, ...rest }) => {
function hasJWT() {
    let flag = false;

    let accessToken = localStorage.getItem("accessToken");
    // Check if user has JWT token and authorize
    if (accessToken != null) {
        flag = true;
    } else {
        flag = false;
    }

    return flag;
    }

    return (
    <Route
        {...rest}
        render={(props) =>
        hasJWT() ? (
            <Component {...props} />
        ) : (
            <Navigate  to={{ pathname: '/Login' }} />
        )
        }
    />
    );
};

export default RouteGuard;