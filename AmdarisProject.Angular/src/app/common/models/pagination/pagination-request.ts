import { MatPaginator } from "@angular/material/paginator";
import { SortingRequest } from "./sorting-request";

export class PaginationRequest {
    pageIndex: number;
    pageSize: number;
    sortingRequest: SortingRequest;

    constructor(matPaginator: MatPaginator, sortingRequest: SortingRequest) {
        this.pageIndex = matPaginator.pageIndex;
        this.pageSize = matPaginator.pageSize;
        this.sortingRequest = sortingRequest;
    }
}