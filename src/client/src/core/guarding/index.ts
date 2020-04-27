import { GenericButtonProps } from "../../components/buttons/genericButton/genericButton";

export type GuardedActions<TStore> = Array<GuardRule<TStore, Array<GenericButtonProps>>>;

export interface GuardRule<TStore, TData> {
    guard?: (store: TStore) => boolean;
    data: (store: TStore) => TData;
}

export class GuardsApplier {
    public static applyGuardedArrays<TStore, TData>(store: TStore, rules: Array<GuardRule<TStore, Array<TData>>>) {
        return rules.filter(e => (e.guard ? e.guard(store) : true)).flatMap(e => e.data(store));
    }
}
