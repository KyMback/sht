import { observable, runInAction } from "mobx";
import { AsyncInitializable } from "../../../../typings/customTypings";
import { ViewModeType } from "../../../../components/forms/view/core/viewContextStore";
import { HttpApi } from "../../../../core/api/http/httpApi";

export class StudentProfileStore implements AsyncInitializable {
    @observable viewModeType: ViewModeType = ViewModeType.View;
    @observable email: string = "";
    @observable firstName: string = "";
    @observable lastName: string = "";
    @observable group: string = "";

    public init = async () => {
        const { profile } = await HttpApi.graphQl<{ profile: ProfileData }>(query);

        runInAction(() => {
            Object.assign(this, profile);
        });
    };
}

interface ProfileData {
    email: string;
    firstName: string;
    group: string;
    lastName: string;
}

const query = `
{
  profile:studentProfile {
    email
    firstName
    group
    lastName
  }
}`;
