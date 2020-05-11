import { Col, Collapse, ListGroup, ListGroupItem, ListGroupItemHeading, Row } from "reactstrap";
import { ActionIcon } from "../../../../../../components/buttons/actionIcon/actionIcon";
import { icons } from "../../../../../../components/icons/icon";
import { FormCheckbox, FormInput } from "../../../../../../components/forms";
import { nameShouldBeUniq, required } from "../../../../../../components/forms/validations";
import React from "react";
import { observer } from "mobx-react-lite";
import { DefaultCol } from "../../../../../../components/layouts/defaultCol";
import { PropsWithStore } from "../../../../../../typings/customTypings";
import { TestSessionVariantStore } from "./testSessionVariantStore";
import { LazyComponent } from "../../../../../../components/common/lazyComponent";
import { GenericButton } from "../../../../../../components/buttons/genericButton/genericButton";
import { SubSection } from "../../../../../../components/layouts/sections/subSection";
import { TestSessionVariantQuestion } from "./questions/testSessionVariantQuestion";

export const TestSessionVariant = observer(({ store }: PropsWithStore<TestSessionVariantStore>) => {
    return (
        <ListGroupItem>
            <div className="d-flex justify-content-between">
                <ListGroupItemHeading>{store.name}</ListGroupItemHeading>
                <ActionIcon icon={icons.close} onClick={store.remove} tooltip="Remove" />
            </div>
            <Row className="mt-2">
                <Col>
                    <GenericButton
                        color="primary"
                        icon={store.expandIcon}
                        text="ExpandDetails"
                        onClick={store.toggleExpand}
                    />
                </Col>
            </Row>
            <Collapse isOpen={store.isExpanded} color="primary">
                <LazyComponent
                    active={store.isExpanded}
                    component={() => <TestSessionVariantEditDetails store={store} />}
                />
            </Collapse>
        </ListGroupItem>
    );
});

const TestSessionVariantEditDetails = observer(({ store }: PropsWithStore<TestSessionVariantStore>) => {
    return (
        <>
            <Row className="mt-3">
                <DefaultCol>
                    <FormInput
                        label="TestSession_TestVariantName"
                        value={store.name}
                        onChange={store.setName}
                        validations={[required]}
                    />
                </DefaultCol>
                <DefaultCol>
                    <FormCheckbox
                        label="TestSession_IsRandomOrder"
                        value={store.isRandomOrder}
                        onChange={store.setIsRandomOrder}
                    />
                </DefaultCol>
            </Row>
            <SubSection
                title="Questions"
                actions={[
                    {
                        onClick: store.addQuestion,
                        color: "primary",
                        icon: icons.add,
                    },
                ]}
            >
                <ListGroup>
                    {store.questions.map((e, index) => (
                        <TestSessionVariantQuestion store={e} key={index} />
                    ))}
                </ListGroup>
            </SubSection>
        </>
    );
});
