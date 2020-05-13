import React, { PropsWithChildren } from "react";

export const DisableCopyPasteWrapper = ({ children }: PropsWithChildren<{}>) => {
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
