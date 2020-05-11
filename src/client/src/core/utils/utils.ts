export class Utils {
    public static css = (...classes: Array<string | undefined | null>) => {
        return classes.filter(e => !!e).join(" ");
    };
}
