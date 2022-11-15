export interface PaginationResult<T> {
    pageIndex: number;
    pageSize: number;
    totalItems: number;
    items: T[];
}