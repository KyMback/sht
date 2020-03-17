import React from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { FormSingleSelect } from "../../../../../../../components/forms";
import useAsyncEffect from "use-async-effect";
import { Local } from "../../../../../../../core/localization/local";
import { required } from "../../../../../../../components/forms/validations";
import { Form } from "../../../../../../../components/forms/form";
import { StartStudentTestModalStore } from "./startStudentTestModalStore";
import { observer } from "mobx-react-lite";

interface Props {
    store: StartStudentTestModalStore;
}

export const StartStudentTestModal = observer(({ store }: Props) => {
    useAsyncEffect(store.loadData, [store]);

    return (
        <Modal centered isOpen={store.isOpen} toggle={store.close}>
            <Form onValidSubmit={store.submit}>
                <ModalHeader toggle={store.close}>
                    <Local id="StudentTestSession_StartTestModalTitle" />
                </ModalHeader>
                <ModalBody>
                    <FormSingleSelect
                        label="StudentTestSession_ChooseVariant"
                        options={store.variants}
                        value={store.variant}
                        onChange={store.setVariant}
                        validations={[required]}
                    />
                </ModalBody>
                <ModalFooter>
                    <Button color="secondary" onClick={store.close}>
                        <Local id="Cancel" />
                    </Button>
                    <Button color="primary">
                        <Local id="StudentTestSession_StartTestModalButton" />
                    </Button>
                </ModalFooter>
            </Form>
        </Modal>
    );
});
