import { MatPaginator } from "@angular/material/paginator";
import { FilterRequest } from "./filter-request";
import { SortingRequest } from "./sorting-request";

export class PaginationRequest {
    pageIndex: number;
    pageSize: number;
    sortingRequest: SortingRequest;
    filterRequest: FilterRequest;

    constructor(matPaginator: MatPaginator, sortingRequest: SortingRequest, filterRequest: FilterRequest) {
        this.pageIndex = matPaginator.pageIndex;
        this.pageSize = matPaginator.pageSize;
        this.sortingRequest = sortingRequest;
        this.filterRequest = filterRequest;
    }
}