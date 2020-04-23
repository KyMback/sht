import { KeyOrJSX } from "../../../typings/customTypings";
import React, { useState } from "react";
import { Nav, NavItem, NavLink, TabContent, TabPane } from "reactstrap";
import { ensureLocal } from "../../../core/localization/local";
import { LazyComponent } from "../../common/lazyComponent";

export interface TabConfig {
    title: KeyOrJSX;
    content: React.FC;
}

interface Props {
    tabs: Array<TabConfig>;
}

export const TabsControl = ({ tabs }: Props) => {
    const [activeTab, setActiveTab] = useState<number>(0);

    return (
        <>
            <Nav tabs className="mb-3">
                {tabs.map((e, index) => (
                    <NavItem key={index}>
                        <NavLink className="clickable" active={index === activeTab} onClick={_ => setActiveTab(index)}>
                            {ensureLocal(e.title)}
                        </NavLink>
                    </NavItem>
                ))}
            </Nav>
            <TabContent activeTab={activeTab}>
                {tabs.map((e, index) => (
                    <TabPane key={index} tabId={index}>
                        <LazyComponent active={index === activeTab} component={e.content} />
                    </TabPane>
                ))}
            </TabContent>
        </>
    );
};
