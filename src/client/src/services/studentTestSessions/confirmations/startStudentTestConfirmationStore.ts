import { action, observable, runInAction } from "mobx";
import { SelectItem } from "../../../components/controls/multiSelect/multiSelect";
import { HttpApi } from "../../../core/api/http/httpApi";
import { Lookup } from "../../../typings/dataContracts";
import { RefObject } from "react";
import { FormActions } from "../../../components/forms/form";
import { AsyncInitializable } from "../../../typings/customTypings";
import { MouseEvent } from "react";

export class StartStudentTestConfirmationStore implements AsyncInitializable {
    @observable public formRef?: RefObject<FormActions>;
    @observable public variantId?: string;
    @observable public variants: Array<SelectItem<string>> = [];

    @action public setVariant = (value?: string) => (this.variantId = value);
    public setFormRef = (value?: RefObject<FormActions>) => (this.formRef = value);

    constructor(private studentTestSessionId: string) {}

    public init = async () => {
        await this.loadData();
    };

    public submit = async (e: MouseEvent, resolve: (variantId: string) => void) => {
        if (!this.formRef!.current!.isValid()) {
            e.preventDefault();
            return;
        }

        resolve(this.variantId!);
    };

    public cancel = (resolve: () => void) => {
        resolve();
    };

    private loadData = async () => {
        const { variants } = await loadData(this.studentTestSessionId);

        runInAction(() => {
            this.variants = variants;
        });
    };
}

interface LoadedData {
    variants: Array<Lookup>;
}

const query = `
query q($id: Uuid!) {  
  variants: studentTestSessionVariants(studentTestSessionId: $id) {
    text
    value
  }
}
`;

async function loadData(studentTestSessionId: string): Promise<LoadedData> {
    return HttpApi.graphQl(query, { id: studentTestSessionId });
}
