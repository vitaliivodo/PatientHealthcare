import { NumberInput } from "@angular/cdk/coercion";

export class PageRequestModel{
    constructor
    (
        public pageIndex: NumberInput,
        public pageSize: NumberInput
    ){}
}