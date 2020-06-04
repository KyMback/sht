import React, { useState } from "react";
import { Collapse, Nav, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from "reactstrap";
import { routingStore } from "../../../stores/routingStore";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { useLocation } from "react-router-dom";

interface Props {
    logo?: KeyOrJSX;
    navItems?: Array<NavItemConfig>;
    additionalItem: React.ReactNode;
}

export interface NavItemConfig {
    href: string;
    title: KeyOrJSX;
}

export interface AccountMenuItem {
    title: KeyOrJSX;
    onClick: () => void;
    withDivider?: boolean;
}

export const Header = ({ logo, navItems, additionalItem }: Props) => {
    const [isCollapsed, setIsCollapsed] = useState<boolean>(false);

    return (
        <header>
            <Navbar className="header-navbar" dark color="primary" expand>
                <NavbarBrand className="clickable" onClick={routingStore.gotoBase}>
                    {logo ? ensureLocal(logo) : "Logo"}
                </NavbarBrand>
                <NavbarToggler onClick={_ => setIsCollapsed(!isCollapsed)} className="mr-2" />
                <Collapse isOpen={isCollapsed} navbar className="justify-content-between">
                    <NavBar navItems={navItems} />
                    <div className="d-flex flex-row">{additionalItem}</div>
                </Collapse>
            </Navbar>
        </header>
    );
};

interface NavBarProps {
    navItems?: Array<NavItemConfig>;
}

const NavBar = ({ navItems }: NavBarProps) => {
    const location = useLocation();

    return (
        <Nav navbar>
            {navItems &&
                navItems.map((item, index) => (
                    <NavItem key={index} active={location.pathname.startsWith(item.href)}>
                        <NavLink href={item.href}>{ensureLocal(item.title)}</NavLink>
                    </NavItem>
                ))}
        </Nav>
    );
};
