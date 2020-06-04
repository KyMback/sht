import { FileInfo, FilesRenderer, SimpleFilesUpload, SimpleFilesUploadProps } from "../simpleFilesUpload";
import React, { MouseEvent, useCallback } from "react";
import { Local } from "../../../../core/localization/local";
import { FilesApi } from "../../../../core/api/http/filesApi";
import { ActionIcon } from "../../../buttons/actionIcon/actionIcon";
import { icons } from "../../../icons/icon";

export type ImagesFilesUploadProps = Omit<SimpleFilesUploadProps, "filesRenderer">;

export const ImagesFilesUpload = ({ accept, ...rest }: ImagesFilesUploadProps) => {
    return <SimpleFilesUpload {...rest} accept={accept || ".gif, .png, .jpeg, .jpg"} filesRenderer={ImagesRenderer} />;
};

const ImagesRenderer: FilesRenderer = ({ value, onChange }) => {
    const remove = useCallback(
        (e: MouseEvent, toRemove: FileInfo) => {
            e.stopPropagation();
            onChange && onChange(value.filter(e => e !== toRemove));
        },
        [onChange, value],
    );

    return (
        <div>
            <div>
                <span>
                    <Local id="DragAndDropOrClickToSelectFile" />
                </span>
            </div>
            <div className="d-flex flex-row flex-wrap mt-3">
                {value.map((f, index) => (
                    <div
                        key={index}
                        className="file-image"
                        onClick={e => {
                            e.stopPropagation();
                            window.open(FilesApi.getLinkToDownload(f.id));
                        }}
                    >
                        <div className="image-container">
                            <img key={index} alt={f.name} src={FilesApi.getLinkToDownload(f.id)} />
                        </div>
                        <div className="d-flex justify-content-between">
                            <div className="truncate">{f.name}</div>
                            <ActionIcon
                                className="delete-icon"
                                icon={icons.close}
                                onClick={e => remove(e, f)}
                                tooltip="Remove"
                            />
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};
