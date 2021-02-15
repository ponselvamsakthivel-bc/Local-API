import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Data } from '../../models/data';
import { identityService } from '../identity/identity.service';
import { JwtToken } from '../../models/jwtToken';
import { from, Observable, of, throwError } from 'rxjs';
import { switchMap, catchError, map } from 'rxjs/operators';
import { Scheme } from '../../models/scheme';
import { fromFetch } from 'rxjs/fetch'
import { ajax } from 'rxjs/ajax';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ciiService {

  public url: string = environment.uri.api.cii;
  public token: string = environment.token.api.cii;

  constructor(private http: HttpClient, private identityService: identityService) { }

  getSchemes(): Observable<any> {
    return fromFetch(`${this.url}/identities/schemes`, {
      headers: {
        'Content-Type': 'application/json',
        'Apikey': this.token,
      },
      method: 'GET'
    }).pipe(
      switchMap(response => {
        if (response.ok) {
          return response.json();
        } else {
          return of({ error: true, message: `Error ${response.status}` });
        }
      }),
      catchError(err => {
        console.error(err);
        return of({ error: true, message: err.message })
      })
    );
  }

  getDetails(scheme: string, id: string): Observable<any> {
    return fromFetch(`${this.url}/identities/schemes/organisation?scheme=${scheme}&id=${id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Apikey': this.token,
      },
      method: 'GET'
    }).pipe(
      switchMap(response => {
        if (response.ok) {
          return response.json();
        } else {
          return of({ error: true, message: `Error ${response.status}` });
        }
      }),
      catchError(err => {
        console.error(err);
        return of({ error: true, message: err.message })
      })
    );
  }

  addOrganisation(json: string | null): Observable<any> {
    const body = JSON.parse(json+'');
    return ajax({
      url: `${this.url}/identities/schemes/organisation`,
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Apikey': this.token
      },
      body:  body
    });
  }

}
