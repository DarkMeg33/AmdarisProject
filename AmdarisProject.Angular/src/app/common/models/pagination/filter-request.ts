import { Filter } from "./filter";

export class FilterRequest {
    filters: Filter[];

    constructor() {
        this.filters = [];
    }
}