import React, { createContext } from "react";

interface Context {
    add: (validator: () => boolean) => void;
    remove: (validator: () => boolean) => void;
}

type ValidatorType = () => boolean;

const defaultContextValue: Context = {
    add: () => {
    },
    remove: () => {
    },
};

export const ValidationContext = createContext<Context>(defaultContextValue);

export class ValidationProvider extends React.Component {
    private readonly contextObj: Context;
    private validators: Array<ValidatorType> = [];

    constructor(props: any) {
        super(props);

        this.contextObj = {
            add: this.addValidator,
            remove: this.removeValidator,
        };
    }

    public render() {
        return (
            <ValidationContext.Provider value={this.contextObj}>
                {this.props.children}
            </ValidationContext.Provider>
        );
    }

    public validate = (): boolean => {
        let result = true;
        for (const val of this.validators) {
            result = val() && result;
        }

        return result;
    };

    private addValidator = (validator: ValidatorType) => {
        this.validators.push(validator);
    };

    private removeValidator = (validator: ValidatorType) => {
        this.validators = this.validators.filter(v => v !== validator);
    };
}
