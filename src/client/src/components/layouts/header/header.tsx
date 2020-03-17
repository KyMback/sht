import React, { useState } from "react";
import {
    Collapse,
    DropdownItem,
    DropdownMenu,
    DropdownToggle,
    Nav,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    NavItem,
    NavLink,
    UncontrolledDropdown,
} from "reactstrap";
import { routingStore } from "../../../stores/routingStore";
import { KeyOrJSX } from "../../../typings/customTypings";
import { ensureLocal } from "../../../core/localization/local";
import { Icon, icons } from "../../icons/icon";
import { useLocation } from "react-router-dom";

interface Props {
    logo?: KeyOrJSX;
    navItems?: Array<NavItemConfig>;
    accountItems?: Array<AccountMenuItem>;
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

export const Header = ({ logo, navItems, accountItems }: Props) => {
    const [isCollapsed, setIsCollapsed] = useState<boolean>(false);

    return (
        <header>
            <Navbar dark color="primary" expand>
                <NavbarBrand className="clickable" onClick={routingStore.gotoBase}>
                    {logo ? ensureLocal(logo) : "Logo"}
                </NavbarBrand>
                <NavbarToggler onClick={_ => setIsCollapsed(!isCollapsed)} className="mr-2" />
                <Collapse isOpen={isCollapsed} navbar className="justify-content-between">
                    <NavBar navItems={navItems} />
                    {accountItems && (
                        <UncontrolledDropdown className="account-menu">
                            <DropdownToggle className="account-toggler">
                                <Icon icon={icons.account} />
                            </DropdownToggle>
                            <DropdownMenu right>
                                {accountItems.map((value, index) => (
                                    <div key={index}>
                                        {value.withDivider && <DropdownItem divider />}
                                        <DropdownItem onClick={value.onClick}>{ensureLocal(value.title)}</DropdownItem>
                                    </div>
                                ))}
                            </DropdownMenu>
                        </UncontrolledDropdown>
                    )}
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
                        <NavLink className="clickable" onClick={_ => routingStore.goto(item.href)}>
                            {ensureLocal(item.title)}
                        </NavLink>
                    </NavItem>
                ))}
        </Nav>
    );
};
