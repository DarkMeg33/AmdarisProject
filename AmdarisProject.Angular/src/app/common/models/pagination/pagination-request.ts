import { MatPaginator } from "@angular/material/paginator";

export class PaginationRequest {
    pageIndex: number;
    pageSize: number;

    constructor(matPaginator: MatPaginator) {
        this.pageIndex = matPaginator.pageIndex;
        this.pageSize = matPaginator.pageSize;
    }
}