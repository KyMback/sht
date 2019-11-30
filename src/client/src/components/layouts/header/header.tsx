import React from "react";
import {
    Navbar, NavbarBrand,
} from "reactstrap";
import { routingStore } from "../../../stores/routingStore";

export const Header = () => {
    return (
        <header>
            <Navbar dark color="dark">
                <NavbarBrand href={routingStore.basePath}>
                    Logo
                </NavbarBrand>
            </Navbar>
        </header>
    );
};
