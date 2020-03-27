import { action, observable } from "mobx";
import { SelectItem } from "../../../../../../../components/controls/multiSelect/multiSelect";
import { studentTestSessionTransitionDataKeys } from "../studentTestSessionTransitionDataKeys";
import { studentTestSessionStateTriggers } from "../studentTestSessionStateTriggers";
import { HttpApi } from "../../../../../../../core/api/http/httpApi";

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
        const { variants } = await loadData(this.studentTestSessionId);

        this.variants = variants.map(e => ({
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

interface LoadedData {
    variants: Array<string>;
}

const query = `
query q($id: Uuid!) {  
  variants: studentTestSessionVariants(studentTestSessionId: $id)
}
`;

async function loadData(studentTestSessionId: string): Promise<LoadedData> {
    return HttpApi.graphQl(query, { id: studentTestSessionId });
}
