import { ControlProps } from "../index";
import { FileInfo, SimpleFilesUpload, SimpleFilesUploadProps, SimpleFilesUploadValue } from "./simpleFilesUpload";
import React, { useCallback } from "react";

export type SimpleSingleFileUploadValue = FileInfo | undefined;

export interface SimpleSingleFileUploadProps
    extends Omit<SimpleFilesUploadProps, keyof ControlProps<SimpleFilesUploadValue> | "min" | "max" | "multiple">,
        ControlProps<SimpleSingleFileUploadValue> {}

export const SimpleSingleFileUpload = ({ value, onChange, ...rest }: SimpleSingleFileUploadProps) => {
    const onChangeCallback = useCallback(files => onChange && onChange(files[0]), [onChange]);

    return <SimpleFilesUpload {...rest} multiple={false} value={value ? [value] : []} onChange={onChangeCallback} />;
};
