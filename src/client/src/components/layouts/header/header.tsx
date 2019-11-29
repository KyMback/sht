import React from "react";
import {
    Navbar, NavbarBrand,
} from "reactstrap";

export const Header = () => {
    return (
        <header>
            <Navbar dark color="dark">
                <NavbarBrand>
                    Logo
                </NavbarBrand>
            </Navbar>
        </header>
    );
};
