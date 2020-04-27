import React, { ReactNode } from "react";
import { Header } from "../../components/layouts/header/header";
import { Footer } from "../../components/layouts/footer/footer";
import { Container } from "reactstrap";
import { rootViewStore } from "../../stores/rootViewStore";
import { observer } from "mobx-react-lite";
import { AccountControl } from "./accountControl/accountControl";
import { LocalizationControl } from "./localizationControl/localizationControl";

interface Props {
    children?: ReactNode;
}

export const MainLayout = observer((props: Props) => {
    return (
        <div className="layout">
            <Header navItems={rootViewStore.navItems} additionalItem={<AdditionalItem />} />
            <main>
                <Container className="content-container" fluid>
                    {props.children}
                </Container>
            </main>
            <Footer />
        </div>
    );
});

const AdditionalItem = () => {
    return (
        <>
            <LocalizationControl />
            <AccountControl />
        </>
    );
};
