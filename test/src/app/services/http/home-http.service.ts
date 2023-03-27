import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, first, of, switchMap, tap} from "rxjs";
import {environment} from "../../../environments/environment";
import {Router} from "@angular/router";

export interface ILoginInterface {
  surname: string,
  password: string
}
@Injectable({
  providedIn: 'root'
})
export class HomeHttpService {
  constructor(private http: HttpClient, private _router: Router) { }
  login(data: ILoginInterface) {
    localStorage.setItem('surname', data.surname);
    this.http.post(`${environment.apiUrl}/home`, data, { responseType: 'text' }).pipe(
      first(),
      tap((resp) => {
        localStorage.setItem('jwt_token', resp)
        this._router.navigate(['/main']);
      }),
      catchError((err) => {
        if(err.status !== 200) {
          alert('error handler')
          return of(err);
        } else {
          return of([])
        }
      })
    ).subscribe()
  }
  getData()
  {
    return this._getUserId({SurName: localStorage.getItem('surname') || ''}).pipe(
      first(),
      switchMap((data) => {
        return this.http.get(`${environment.apiUrl}/home/${data}`).pipe(
          first(),
          catchError((err) => {
            if (err.status !== 200) {
              alert('error handler')
              return of(err);
            } else {
              return of([])
            }
          })
        )
      })
    )
  }
  private _getUserId(surname: any)
  {
    return this.http.post(`${environment.apiUrl}/home/Surname?SurName=${surname.SurName}`, surname).pipe(
      first(),
      catchError((err) => {
        if (err.status !== 200) {
          alert('error handler')
          return of(err);
        } else {
          return of([])
        }
      })
    )
  }
}
