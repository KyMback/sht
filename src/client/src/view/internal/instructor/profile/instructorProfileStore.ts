import { observable, runInAction } from "mobx";
import { ViewModeType } from "../../../../components/forms/view/core/viewContextStore";
import { HttpApi } from "../../../../core/api/http/httpApi";
import { AsyncInitializable } from "../../../../typings/customTypings";

export class InstructorProfileStore implements AsyncInitializable {
    @observable public viewModeType: ViewModeType = ViewModeType.View;
    @observable public email: string = "";

    public init = async () => {
        const { profile } = await HttpApi.graphQl<{ profile: ProfileData }>(query);

        runInAction(() => {
            Object.assign(this, profile);
        });
    };
}

interface ProfileData {
    email: string;
}

const query = `
{
  profile:instructorProfile {
    email
  }
}
`;
