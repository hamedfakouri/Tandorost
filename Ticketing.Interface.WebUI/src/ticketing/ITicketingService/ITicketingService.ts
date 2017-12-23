import { Observable } from 'rxjs/Rx';
export interface ITicketingService<T> {
    getById(id: any): T;
    getAll(): Observable<Array<T>>;
    remove(id: any): void;
    create(item: T): Observable<any>;
}