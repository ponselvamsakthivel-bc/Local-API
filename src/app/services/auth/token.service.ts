import { Injectable } from "@angular/core";
import jwt_decode from 'jwt-decode';

@Injectable()
export class TokenService {
  constructor() {
  }

  getDecodedIdToken(token: string): any {
    try{
        let jwtToken = jwt_decode(token);
        return jwtToken
    }
    catch(Error){
        return null;
    }
  }
}