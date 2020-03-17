import React, { ReactNode, ReactNodeArray } from "react";

interface Props {
    children: ReactNode | ReactNodeArray;
}

export const DisableCopyPasteWrapper = ({ children }: Props) => {
    return (
        <div
            className="disable-copy-paste"
            onCut={e => e.preventDefault()}
            onPaste={e => e.preventDefault()}
            onCopy={e => e.preventDefault()}
        >
            {children}
        </div>
    );
};
