import { FormInput } from "../index";
import { KeyOrJSX, PropsWithStore } from "../../../typings/customTypings";
import { FormControlProps } from "../formControls";
import { Observer } from "mobx-react-lite";
import React from "react";
import { ValidationFunction } from "../formControlWrapper";
import { InputControlProps } from "../../controls/inputControl";
import { ResponsiveWrapper } from "../../layouts/responsiveWrapper";

type StoreProps<TStore, TValue> = (store: TStore) => TValue;
type StorePropsOrDefault<TStore, TValue> = StoreProps<TStore, TValue> | TValue;

type TextInputValue = string | undefined;

type StoreFormsFactoryBuilder<TStore> = (factory: StoreFormsFactory<TStore>) => void;

export class StoreFormsFactory<TStore = any> {
    private controls: Array<React.FC<PropsWithStore<TStore>>> = [];

    public static new<TStore>() {
        return new StoreFormsFactory<TStore>();
    }

    public inResponsiveWrapper = (
        colsInRow: number,
        builder: StoreFormsFactoryBuilder<TStore>,
    ): StoreFormsFactory<TStore> => {
        const factory = new StoreFormsFactory<TStore>();
        builder(factory);
        this.controls.push(({ store }: PropsWithStore<TStore>) => (
            <ResponsiveWrapper colsInRow={colsInRow}>
                {factory.controls.map((Control, index) => (
                    <Control key={index} store={store} />
                ))}
            </ResponsiveWrapper>
        ));

        return this;
    };

    public inGroup = (builder: StoreFormsFactoryBuilder<TStore>): StoreFormsFactory<TStore> => {
        const factory = new StoreFormsFactory<TStore>();
        builder(factory);
        this.controls.push(({ store }: PropsWithStore<TStore>) => (
            <div>
                {factory.controls.map((Control, index) => (
                    <Control key={index} store={store} />
                ))}
            </div>
        ));

        return this;
    };

    public input = (
        label: StorePropsOrDefault<TStore, KeyOrJSX>,
        valueAccessor: keyof TStore,
        onChange: StoreProps<TStore, (v: TextInputValue) => void> = createDefaultOnChange(valueAccessor),
        validations: StorePropsOrDefault<TStore, Array<ValidationFunction<TextInputValue>>> = [],
        options: StorePropsOrDefault<TStore, Partial<FormControlProps<TextInputValue, InputControlProps>>> = {},
    ): StoreFormsFactory<TStore> => {
        this.pushControl<FormControlProps<TextInputValue, InputControlProps>>(FormInput, store => ({
            label: convertToValue(store, label),
            value: store[valueAccessor] as any,
            onChange: onChange(store),
            validations: convertToValue(store, validations),
            ...convertToValue(store, options),
        }));

        return this;
    };

    public build = (): React.FC<PropsWithStore<TStore>> => {
        return ({ store }: PropsWithStore<TStore>) => (
            <>
                {this.controls.map((Control, index) => (
                    <Control key={index} store={store} />
                ))}
            </>
        );
    };

    private pushControl = <TProps extends any>(
        Control: React.ComponentType<TProps>,
        options: (store: TStore) => TProps,
    ): StoreFormsFactory<TStore> => {
        this.controls.push(({ store }: PropsWithStore<TStore>) => (
            <Observer>{() => <Control {...options(store)} />}</Observer>
        ));

        return this;
    };
}

function createDefaultOnChange<TStore, TValue>(valueAccessor: keyof TStore): StoreProps<TStore, (v: TValue) => void> {
    return (store: TStore) => v => ((store as any)[valueAccessor] = v);
}

function convertToValue<TStore, TValue>(store: TStore, value: StorePropsOrDefault<TStore, TValue>): TValue {
    return typeof value === "function" ? (value as Function)(store) : value;
}
