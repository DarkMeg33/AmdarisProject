import { SortDirection } from "./sort-direction";

export class SortingRequest {
    columnName: string;
    sortDirection: SortDirection;

    constructor(columnName: string = "HostelNumber", sortDirection: SortDirection = SortDirection.Ascending) {
        this.columnName = columnName;
        this.sortDirection = sortDirection;
    }
}