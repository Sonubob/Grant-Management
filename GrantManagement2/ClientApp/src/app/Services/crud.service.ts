import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { retry,catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  constructor(private http: HttpClient) {
  }

  getdata(url): Observable<any> {
    return this.http.get<any>(url).pipe(
      retry(1),
      catchError(async (err) => this.httpError(err))
    )
  }

  postdata(url, data): Observable<any> {
    return this.http.post<any>(url, data).pipe(
      retry(1),
      catchError(async (err) => this.httpError(err))
    )
  }

  httpError(Error) {
    let msg: string;
    if (Error.error instanceof
      ErrorEvent) {
      msg = Error.error.message;
    } else {
      msg = 'Error occured';
    }

    console.log(msg);
  }

}
