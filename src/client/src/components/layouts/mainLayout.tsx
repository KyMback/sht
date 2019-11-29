import React, { ReactNode } from "react";
import { Header } from "./header/header";
import { Footer } from "./footer/footer";
import { Container } from "reactstrap";

interface Props {
    children: ReactNode;
}

export const MainLayout = (props: Props) => {
    return (
        <>
            <Header/>
            <main>
                <Container fluid>
                    {props.children}
                </Container>
            </main>
            <Footer/>
        </>
    );
};
