export interface ControlProps<TValue> {
    value: TValue;
    onChange: (value: TValue) => void;
    valid?: boolean;
    isRequired?: boolean;
}
