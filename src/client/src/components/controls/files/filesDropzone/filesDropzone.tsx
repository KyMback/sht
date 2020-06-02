import { useDropzone } from "react-dropzone";
import React from "react";
import { KeyOrJSX } from "../../../../typings/customTypings";
import { ensureLocal } from "../../../../core/localization/local";
import { Utils } from "../../../../core/utils/utils";

export interface FilesDropzoneProps {
    className?: string;
    accept?: Array<string> | string;
    max?: number;
    min?: number;
    multiple?: boolean;
    disabled?: boolean;
    text?: KeyOrJSX;
    onUploaded: (files: Array<File>) => void;
}

export const FilesDropzone = ({ className, text, onUploaded, ...rest }: FilesDropzoneProps) => {
    const { getRootProps, getInputProps } = useDropzone({
        ...rest,
        onDrop: onUploaded,
    });

    return (
        <div
            {...getRootProps({
                className: Utils.css("files-dropzone", className, rest.disabled ? "disabled" : undefined),
            })}
        >
            <input {...getInputProps()} />
            {text && <span className="dropzone-text">{ensureLocal(text)}</span>}
        </div>
    );
};
