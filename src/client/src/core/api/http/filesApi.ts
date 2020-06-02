import { HttpApi } from "./httpApi";

interface FileInfoDto {
    id: string;
    name: string;
    reference: string;
}

const uri = "/files";

export class FilesApi {
    public static upload = async (file: File): Promise<FileInfoDto> => {
        const data = new FormData();
        data.append("file", file);
        return HttpApi.post<FileInfoDto>(uri, data);
    };

    public static getLinkToDownload(fileId: string) {
        return `${uri}/${fileId}`;
    }
}
