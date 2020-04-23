import React from "react";
import { observer } from "mobx-react-lite";
import { CardSectionsGroup } from "../../../components/layouts/sections/cardSectionsGroup";
import { CardSection } from "../../../components/layouts/sections/cardSection";
import { TabConfig, TabsControl } from "../../../components/layouts/tabs/tabsControl";
import { SignUpStudent } from "./student/signUpStudent";
import { Local } from "../../../core/localization/local";

export const SignUpPage = observer(() => {
    return (
        <CardSectionsGroup title="SignUp">
            <CardSection>
                <TabsControl tabs={tabs} />
            </CardSection>
        </CardSectionsGroup>
    );
});

const tabs: Array<TabConfig> = [
    {
        title: "Student",
        content: SignUpStudent,
    },
    {
        title: "Instructor",
        content: () => <Local id="NotImplementedYet" />,
    },
];
