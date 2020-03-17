import { action, observable } from "mobx";
import { SelectItem } from "../../../../../../../components/controls/multiSelect/multiSelect";
import { StudentTestSessionApi } from "../../../../../../../core/api/studentTestSessionApi";
import { studentTestSessionTransitionDataKeys } from "../studentTestSessionTransitionDataKeys";
import { studentTestSessionStateTriggers } from "../studentTestSessionStateTriggers";

export class StartStudentTestModalStore {
    @observable isOpen: boolean = false;
    @observable variant?: string;
    @observable variants: Array<SelectItem<string>> = [];

    @action setIsOpen = (value: boolean) => (this.isOpen = value);
    @action setVariant = (value?: string) => (this.variant = value);

    constructor(
        private studentTestSessionId: string,
        private stateTransition: (trigger: string, data?: string) => void,
        private onClose: () => void,
    ) {}

    public loadData = async () => {
        const result = await StudentTestSessionApi.getTestVariants(this.studentTestSessionId);

        this.variants = result.map(e => ({
            value: e,
            text: e,
        }));
    };

    public submit = async () => {
        const data = {} as any;
        data[studentTestSessionTransitionDataKeys.testVariant] = this.variant;
        await this.stateTransition(studentTestSessionStateTriggers.startTest, data);
        this.close();
    };

    public open = () => {
        this.setIsOpen(true);
    };

    public close = () => {
        this.setIsOpen(false);
        this.onClose();
    };
}
