import v4 from "uuid/v4";

export function uniqId(prefix?: string): string {
    return prefix + v4();
}
