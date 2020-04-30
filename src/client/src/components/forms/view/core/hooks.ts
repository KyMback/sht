import { useContext } from "react";
import { ViewContext } from "./viewContextStore";

export const useViewContext = () => {
    return useContext(ViewContext);
};
