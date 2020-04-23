import React, { useEffect, useMemo, useState } from "react";

interface Props {
    active: boolean;
    component: React.FC;
}

export const LazyComponent = ({ active, component: Component }: Props) => {
    const [isLoaded, setIsLoaded] = useState<boolean>(active);
    useEffect(() => {
        if (active) {
            setIsLoaded(true);
        }
    }, [active]);

    return useMemo(() => (isLoaded ? <Component /> : null), [isLoaded]);
};
