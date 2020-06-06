import { HttpApi } from "../../core/api/http/httpApi";
import { StudentProfileModificationDto } from "../../typings/dataContracts";

export interface StudentProfileData {
    email: string;
    firstName: string;
    group: string;
    lastName: string;
}

const getStudentProfile = `
{
  profile:studentProfile {
    email
    firstName
    group
    lastName
  }
}`;

const updateStudentProfile = `
mutation($data: StudentProfileModificationDtoInput!) {
  updateStudentProfile(data: $data)
}
`;

export class StudentsActionsService {
    public static async getProfileData(): Promise<StudentProfileData> {
        const { profile } = await HttpApi.graphQl<{ profile: StudentProfileData }>(getStudentProfile);
        return profile;
    }

    public static async updateStudentProfile(data: StudentProfileModificationDto) {
        await HttpApi.graphQl(updateStudentProfile, {
            data,
        });
    }
}
