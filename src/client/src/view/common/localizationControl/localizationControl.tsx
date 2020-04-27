import { observer } from "mobx-react-lite";
import { DropdownItem, DropdownMenu, DropdownToggle, UncontrolledDropdown } from "reactstrap";
import { Icon, icons } from "../../../components/icons/icon";
import React from "react";
import { localStore } from "../../../stores/localStore";
import { LocalizationService } from "../../../services/common/localizationService";

export const LocalizationControl = observer(() => {
    return (
        <UncontrolledDropdown className="localization-menu">
            <DropdownToggle className="localization-toggler">
                <Icon icon={icons.language} />
                <span className="language-abbr">{localStore.language}</span>
            </DropdownToggle>
            <DropdownMenu right>
                {localStore.supportedLanguages.map((value, index) => (
                    <div key={index}>
                        <DropdownItem onClick={() => LocalizationService.setLocalization(value.abbr)}>
                            {value.name}
                        </DropdownItem>
                    </div>
                ))}
            </DropdownMenu>
        </UncontrolledDropdown>
    );
});
