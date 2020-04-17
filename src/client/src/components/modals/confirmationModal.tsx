import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import React, { useMemo, MouseEvent } from "react";
import { Color, KeyOrJSX } from "../../typings/customTypings";
import { ensureLocal } from "../../core/localization/local";

interface Props {
    isOpen: boolean;
    hide: () => void;
    body: KeyOrJSX;
    title: KeyOrJSX;
    actions: Array<ConfirmationHandler>;
}

export interface ConfirmationHandler {
    onClick?: (e: MouseEvent) => void;
    title: KeyOrJSX;
    color: Color;
}

export const ConfirmationModal = ({ isOpen, body, title, actions, hide }: Props) => {
    const buttons = useMemo(
        () =>
            actions.map((action, index) => (
                <Button
                    key={index}
                    color={action.color}
                    onClick={e => {
                        action.onClick && action.onClick(e);

                        if (!e.isDefaultPrevented()) {
                            hide();
                        }
                    }}
                >
                    {ensureLocal(action.title)}
                </Button>
            )),
        [actions, hide],
    );

    return (
        <Modal centered isOpen={isOpen}>
            <ModalHeader>{ensureLocal(title)}</ModalHeader>
            <ModalBody>{ensureLocal(body)}</ModalBody>
            <ModalFooter>{buttons}</ModalFooter>
        </Modal>
    );
};
