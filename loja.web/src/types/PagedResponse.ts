export interface PagedResponse<T> {
  page: number
  pageSize: number
  totalItems: number
  totalPages: number
  data: T[]
}