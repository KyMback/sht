import { action, observable, runInAction } from "mobx";
import { AsyncInitializable } from "../../../../typings/customTypings";
import { ViewModeType } from "../../../../components/forms/view/core/viewContextStore";
import { StudentProfileModificationDto } from "../../../../typings/dataContracts";
import { StudentsActionsService } from "../../../../services/students/StudentsActionsService";
import { notifications } from "../../../../components/notifications/notifications";

export class StudentProfileStore implements AsyncInitializable {
    @observable viewModeType: ViewModeType = ViewModeType.View;
    @observable email: string = "";
    @observable firstName?: string;
    @observable lastName?: string;
    @observable group?: string;

    @action public setFirstName = (value?: string) => (this.firstName = value);
    @action public setLastName = (value?: string) => (this.lastName = value);
    @action public setGroup = (value?: string) => (this.group = value);

    public init = async () => {
        const profile = await StudentsActionsService.getProfileData();

        runInAction(() => {
            Object.assign(this, profile);
        });
    };

    @action public toggleViewMode = () => {
        this.viewModeType = this.viewModeType === ViewModeType.View ? ViewModeType.Edit : ViewModeType.View;
    };

    public update = async () => {
        await StudentsActionsService.updateStudentProfile(this.getDto());
        notifications.successfullySaved();
        this.viewModeType = ViewModeType.View;
    };

    private getDto = (): StudentProfileModificationDto => {
        return StudentProfileModificationDto.fromJS({
            email: this.email,
            firstName: this.firstName,
            lastName: this.lastName,
            group: this.group,
        });
    };
}
