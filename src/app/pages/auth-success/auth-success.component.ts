import { Component, ViewEncapsulation, ChangeDetectionStrategy, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { timeout } from 'rxjs/operators';
import * as _ from 'lodash';

import { BaseComponent } from 'src/app/components/base/base.component';
import { Data } from 'src/app/models/data';
import { dataService } from 'src/app/services/data/data.service';
import { UIState } from 'src/app/store/ui.states';
import { slideAnimation } from 'src/app/animations/slide.animation';
import { AuthService } from 'src/app/services/auth/auth.service';
import { TokenService } from 'src/app/services/auth/token.service';
import { TokenInfo } from 'src/app/models/auth';


@Component({
    selector: 'app-auth-success',
    templateUrl: './auth-success.component.html',
    styleUrls: ['./auth-success.component.scss'],
    animations: [
        slideAnimation({
            close: { 'transform': 'translateX(12.5rem)' },
            open: { left: '-12.5rem' }
        })
    ],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AuthSuccessComponent extends BaseComponent implements OnInit {

    constructor(private dataService: dataService,
        private formBuilder: FormBuilder,
        // private spinnerService: SpinnerService,
        private translateService: TranslateService,
        // private utilitiesService: UtilitiesService,
        private router: Router,
        private route: ActivatedRoute,
        private authService: AuthService,
        protected uiStore: Store<UIState>,
        private readonly tokenService: TokenService
    ) {
        super(uiStore);
    }

    ngOnInit() {
        this.route.queryParams.subscribe(params => {
            if (params['code']) {
                this.authService.token(params['code']).toPromise().then((tokenInfo: TokenInfo) => {
                    console.log('---------TOKEN RESPONSE START---------');
                    console.log(tokenInfo);
                    console.log('---------TOKEN PASSWORD RESPONSE FINISH--------');
                    localStorage.setItem('brickedon_aws_tokens', JSON.stringify(tokenInfo));
                    let idToken = this.tokenService.getDecodedIdToken(tokenInfo.idToken);
                    localStorage.setItem('brickedon_user', idToken.email);
                    localStorage.setItem('user_name', idToken.email);
                    localStorage.setItem('session_state', tokenInfo.sessionState)
                    this.authService.publishAuthStatus(true);
                    this.router.navigateByUrl('home');
                }, (err) => {
                    this.router.navigateByUrl('login');
                });
            }
            else if (params['error']) {
                let error = params['error'];
                if (error == 'login_required') {
                    this.authService.logOutAndRedirect();
                }
            }
        });
        this.route.fragment.subscribe((fragment: string) => {
            console.log("My hash fragment is here => ", fragment)
        })
    }
}