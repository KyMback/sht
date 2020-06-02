import React, { useCallback, MouseEvent } from "react";
import { FilesDropzone, FilesDropzoneProps } from "./filesDropzone/filesDropzone";
import { ControlProps } from "../index";
import { FilesApi } from "../../../core/api/http/filesApi";
import { ListGroup, ListGroupItem } from "reactstrap";
import { ActionIcon } from "../../buttons/actionIcon/actionIcon";
import { icons } from "../../icons/icon";
import { Local } from "../../../core/localization/local";
import { isEmpty } from "lodash";

export type SimpleFilesUploadValue = Array<FileInfo>;

export interface SimpleFilesUploadProps
    extends Omit<FilesDropzoneProps, "onUploaded" | "className" | "text">,
        ControlProps<SimpleFilesUploadValue> {}

export interface FileInfo {
    id: string;
    name: string;
    reference: string;
}

export const SimpleFilesUpload = ({ value, onChange, ...rest }: SimpleFilesUploadProps) => {
    const onUploaded = useCallback(
        async (files: Array<File>) => {
            const uploadedFiles = await Promise.all(files.map(FilesApi.upload));
            const result = rest.multiple === false ? uploadedFiles : value.concat(uploadedFiles);
            onChange && onChange(result);
        },
        [onChange, rest.multiple, value],
    );

    return (
        <FilesDropzone
            {...rest}
            onUploaded={onUploaded}
            text={<FilesRenderer value={value} onChange={onChange} {...rest} />}
        />
    );
};

const FilesRenderer = ({ value, onChange }: ControlProps<SimpleFilesUploadValue>) => {
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
            {!isEmpty(value) && (
                <ListGroup className="pt-3">
                    {value.map(f => (
                        <ListGroupItem key={f.id} className="p-1" onClick={e => e.stopPropagation()}>
                            <div className="d-flex justify-content-between">
                                <a
                                    href={FilesApi.getLinkToDownload(f.id)}
                                    onClick={e => e.stopPropagation()}
                                    rel="noopener noreferrer"
                                    target="_blank"
                                >
                                    {f.name}
                                </a>
                                <ActionIcon icon={icons.close} onClick={e => remove(e, f)} tooltip="Remove" />
                            </div>
                        </ListGroupItem>
                    ))}
                </ListGroup>
            )}
        </div>
    );
};
