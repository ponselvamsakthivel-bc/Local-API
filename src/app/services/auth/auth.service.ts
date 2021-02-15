import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';
// import { Observable } from 'rxjs/internal/Observable';
import 'rxjs/add/observable/of';
import { Observable, Subject } from 'rxjs';

import { environment } from '../../../environments/environment';
import { ajax } from 'rxjs/ajax';

@Injectable()
export class AuthService {

  public url: string = environment.uri.api.security;

  constructor(
    private readonly httpService: HttpClient
  ) {
  }

  login(username: string, password: string): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    //ccs-sso-reliable-toucan-ab.london.cloudapps.digital
    const body = { userName: username, userPassword: password }
    return this.httpService.post(`${this.url}/security/login`, body, options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }

  public loginRedirect(): Observable<any> {
    
    return this.httpService.get(this.url + '/security/authorize');
  }
 
  public isUserAuthenticated(): boolean {
    const tokens = localStorage.getItem('brickedon_aws_tokens');
    return tokens != null;
    // return this.httpService.get<boolean>('/auth/isAuthenticated');
  }

  private authSuccessSource = new Subject<boolean>();

  // Observable string streams
  userAutnenticated$ = this.authSuccessSource.asObservable();

  publishAuthStatus(authSuccess: boolean) {
    this.authSuccessSource.next(authSuccess);
  }

  public isAuthenticated(): Observable<boolean> {
    const tokens = localStorage.getItem('brickedon_aws_tokens');
    if (tokens) {
      return Observable.of(true);
    }
    return Observable.of(false);
  }

  register(firstName: string, lastName: string, username: string, email: string): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    const body = { FirstName: firstName, LastName: lastName, UserName: username, Email: email, Role: 'Admin', Groups: [] }
    return this.httpService.post(`${this.url}/security/register`, body, options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }

  changePassword(username: string, password: string, sessionId: string): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    const body = { userName: username, sessionId: sessionId, newPassword: password }
    return this.httpService.post(`${this.url}/security/passwordchallenge`, body, options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }

  resetPassword(userName: string): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    return this.httpService.post(`${this.url}/security/passwordresetrequest`,  "\"" + userName + "\"" , options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        return "";
      })
    );
  }

  token(code: string): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    }
    const body = {
      code: code,
      grant_type: 'authorization_code',
      redirect_uri: environment.uri.web.dashboard + '/authsuccess'
    };
    return this.httpService.post(`${this.url}/security/token`, body, options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        return throwError(error);
      })
    );
  }

  getSignOutEndpoint() {
    return environment.uri.api.security + '/security/logout?redirecturi=' + environment.uri.web.dashboard;
  }

  getAuthorizedEndpoint() {
    return environment.uri.api.security + '/security/authorize?callbackUrl=' + environment.uri.web.dashboard + '/authsuccess';
  }

  public signOut() {
    localStorage.removeItem('brickedon_aws_tokens');
    localStorage.removeItem('brickedon_user');
    localStorage.removeItem('user_name');
    localStorage.removeItem('ccs_organisation_id');
    localStorage.removeItem('cii_organisation');
    localStorage.removeItem('brickendon_org_reg_email_address');
    this.setWindowLocationHref('/login');
  }

  // public logOut(username: string | null): Observable<any> {
  //   return this.httpService.get(`${this.url}/Security/logout?userName=${username}`);
  // }
  public logOut(userName: string | null): Observable<any> {
    const options = {
      headers: new HttpHeaders().append('Content-Type', 'application/json')
    };
    return this.httpService.post(`${this.url}/security/logout?userName=${userName}`, null, options).pipe(
      // return this.httpService.post(`${this.url}/security/logout`, '' + userName + '', options).pipe(
      // return this.httpService.post(`${this.url}/security/logout`, { userName: userName }, options).pipe(
      map(data => {
        return data;
      }),
      catchError(error => {
        // return Observable.of('');
        return throwError(error);
      })
    );

    //const params = new HttpParams().set("userName", userName);
    //const httpOptions = {
    //  headers: new HttpHeaders({
    //    'Accept': 'application/json',
    //  }),
    //  params: params
    //};

    //const body = JSON.parse(userName + ''.replace('"', '').replace('"', ''));
    //return ajax({
    //  url: `${this.url}/security/logout?userName=${userName+''.replace('"', '').replace('"', '')}`,
    //  method: 'POST',
    //  headers: {
    //    'Content-Type': 'application/json',
    //    'Accept': 'application/json',
    //  },
    //  body: body
    //});
  }

  public logOutAndRedirect(username: string | null) {
  
    this.signOut();
    window.location.href = this.getSignOutEndpoint();
  }

  public setWindowLocationHref(href: string) {
    window.location.href = href;
  }
}
