import useAsyncEffect from "use-async-effect";
import { AsyncInitializable, Disposable } from "../../typings/customTypings";

type StoreType = AsyncInitializable & Partial<Disposable>;

export function useStoreLifeCycle<TStore extends StoreType>(store: TStore) {
    useAsyncEffect(store.init, () => store.dispose && store.dispose(), []);
}
