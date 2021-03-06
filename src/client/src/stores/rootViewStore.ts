import { action, computed, observable } from "mobx";
import { Dictionary } from "../typings/customTypings";
import { UserType } from "../typings/dataContracts";
import { AccountMenuItem, NavItemConfig } from "../components/layouts/header/header";
import { userContextStore } from "./userContextStore";
import { routingStore } from "./routingStore";

const navItemsDictionary: Dictionary<Array<NavItemConfig>> = {
    [UserType.Instructor]: [
        {
            title: "TestSessions",
            href: "/test-session",
        },
        // {
        //     title: "TestVariants",
        //     href: "/test-variants",
        // },
        {
            title: "Questions",
            href: "/questions",
        },
    ],
    [UserType.Student]: [
        {
            title: "TestSessions",
            href: "/test-session",
        },
        {
            title: "AnswersRatings",
            href: "/answers-ratings",
        },
    ],
};

const accountMenuItemsDictionary: Dictionary<Array<AccountMenuItem>> = {
    [UserType.Instructor]: [
        {
            title: "Profile",
            onClick: () => routingStore.goto("/profile"),
        },
        {
            title: "SignOut",
            onClick: () => routingStore.goto("/sign-out"),
            withDivider: true,
        },
    ],
    [UserType.Student]: [
        {
            title: "Profile",
            onClick: () => routingStore.goto("/profile"),
        },
        {
            title: "SignOut",
            onClick: () => routingStore.goto("/sign-out"),
            withDivider: true,
        },
    ],
};

const defaultAccountActions: Array<AccountMenuItem> = [
    {
        title: "SignIn",
        onClick: () => routingStore.goto("/login"),
    },
    {
        title: "SignUp",
        onClick: () => routingStore.goto("/sign-up"),
    },
];

class RootViewStore {
    @observable private loadingCount: number = 0;

    @computed
    public get navItems(): Array<NavItemConfig> | undefined {
        if (!userContextStore.userType) {
            return undefined;
        }

        return navItemsDictionary[userContextStore.userType];
    }

    @computed
    public get accountMenuItems(): Array<AccountMenuItem> | undefined {
        if (!userContextStore.userType) {
            return defaultAccountActions;
        }

        return accountMenuItemsDictionary[userContextStore.userType];
    }

    @computed
    public get loadingIsShown(): boolean {
        return this.loadingCount > 0;
    }

    @action
    public showLoading(): void {
        this.loadingCount++;
    }

    @action
    public hideLoading(): void {
        this.loadingCount = this.loadingCount > 0 ? this.loadingCount - 1 : 0;
    }
}

export const rootViewStore = new RootViewStore();
