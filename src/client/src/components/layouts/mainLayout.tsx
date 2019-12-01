import React, { ReactNode } from "react";
import { Header } from "./header/header";
import { Footer } from "./footer/footer";
import { Container } from "reactstrap";
import { rootViewStore } from "../../stores/rootViewStore";
import { observer } from "mobx-react-lite";

interface Props {
    children?: ReactNode;
}

export const MainLayout = observer((props: Props) => {
    return (
        <>
            <Header navItems={rootViewStore.navItems} accountItems={rootViewStore.accountMenuItems}/>
            <main>
                <Container fluid>
                    {props.children}
                </Container>
            </main>
            <Footer/>
        </>
    );
});
