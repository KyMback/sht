import { DropdownItem, DropdownMenu, DropdownToggle, UncontrolledDropdown } from "reactstrap";
import { Icon, icons } from "../../../components/icons/icon";
import { ensureLocal } from "../../../core/localization/local";
import React from "react";
import { rootViewStore } from "../../../stores/rootViewStore";
import { observer } from "mobx-react-lite";

export const AccountControl = observer(() => {
    const accountItems = rootViewStore.accountMenuItems;

    if (!accountItems) {
        return null;
    }

    return (
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
    );
});
