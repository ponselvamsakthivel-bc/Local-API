import { Component, HostBinding, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { OverlayContainer } from '@angular/cdk/overlay';
import { TranslateService } from '@ngx-translate/core';
import { UIState } from './store/ui.states';
import { getSideNavVisible } from './store/ui.selectors';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './services/auth/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  @HostBinding('class') className = '';
  public sideNavVisible$: Observable<boolean>;

  toggleControl = new FormControl(false);

  constructor(private dialog: MatDialog, private overlay: OverlayContainer, private translate: TranslateService, protected uiStore: Store<UIState>, private router: Router,
    private route: ActivatedRoute,private authService: AuthService) {
    translate.setDefaultLang('en');
    this.sideNavVisible$ = this.uiStore.pipe(select(getSideNavVisible));
  }

  ngOnInit(): void {
    this.toggleControl.valueChanges.subscribe((darkMode) => {
      const darkClassName = 'darkMode';
      this.className = darkMode ? darkClassName : '';
      if (darkMode) {
        this.overlay.getContainerElement().classList.add(darkClassName);
      } else {
        this.overlay.getContainerElement().classList.remove(darkClassName);
      }      
    });
    if(!localStorage.getItem('client_id'))
    {
      localStorage.setItem('client_id',environment.idam_client_id);
    }

    if(!localStorage.getItem('securityapiurl'))
    {
      localStorage.setItem('securityapiurl',environment.uri.api.security);
    }

    if(!localStorage.getItem('redirect_uri'))
    {
      localStorage.setItem('redirect_uri',environment.uri.web.dashboard);
    }
    // this.route.queryParams.subscribe(params => {
    //   if (params.code) {
    //       this.authService.token(params.code).toPromise().then((response) => {
    //           console.log('---------TOKEN RESPONSE START---------');
    //           console.log(response);
    //           console.log('---------TOKEN PASSWORD RESPONSE FINISH--------');
    //           this.router.navigateByUrl('login');
    //       }, (err) => {
    //           console.log(err);
    //       });
    //   }
    // });
    // this.route.queryParams.subscribe(params => {
    //   if (params['code']) {
    //     this.authService.token(params['code']).toPromise().then((response) => {
    //         console.log('---------TOKEN RESPONSE START---------');
    //         console.log(response);
    //         console.log('---------TOKEN PASSWORD RESPONSE FINISH--------');
    //         localStorage.setItem('brickedon_aws_tokens', JSON.stringify(response));
    //         this.router.navigateByUrl('home');
    //     }, (err) => {
    //         console.log(err);
    //     });
    //   }
    // });
  }

  navigate(tab: any, subLink = null) {
    // this.selectedTab = tab.name;
  }

  onToggle(): void {
    this.uiStore.dispatch({ type: '[UI] Side Nav Toggle' });
  }

  public logOut(): void {
    this.authService.logOutAndRedirect();
  }

  public isAuthenticated(): Observable<boolean> {
    return this.authService.isAuthenticated();
  }
}
