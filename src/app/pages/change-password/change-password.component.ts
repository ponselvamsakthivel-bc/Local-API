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

@Component({
    selector: 'app-change-password',
    templateUrl: './change-password.component.html',
    styleUrls: ['./change-password.component.scss'],
    animations: [
        slideAnimation({
            close: { 'transform': 'translateX(12.5rem)' },
            open: { left: '-12.5rem' }
        })
    ],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ChangePasswordComponent extends BaseComponent implements OnInit {

  formGroup: FormGroup;
  submitted: boolean = false;
  sessionId!: string;

  constructor(private formBuilder: FormBuilder, private translateService: TranslateService, private authService: AuthService, private router: Router, private route: ActivatedRoute, protected uiStore: Store<UIState>) {
    super(uiStore);
    this.formGroup = this.formBuilder.group({
      userName: [localStorage.getItem('brickedon_user'), Validators.compose([Validators.required])],
      password: ['', Validators.compose([Validators.required, Validators.minLength(8)])],
      confirmPassword: ['', Validators.compose([Validators.required])]
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['session']) {
        this.sessionId = params['session'];
      }
    });
  }

  public onSubmit(form: FormGroup) {
    this.submitted = true;
    if (this.formValid(form)) {
      this.authService.changePassword(form.get('userName')?.value.replace('"', '').replace('"', ''), form.get('password')?.value, this.sessionId).toPromise().then((response) => {
        console.log('---------CHANGE PASSWORD RESPONSE START---------');
        console.log(response);
        localStorage.setItem('brickedon_aws_tokens', JSON.stringify(response));
        localStorage.setItem('user_name', form.get('userName')?.value);
        console.log('---------CHANGE PASSWORD RESPONSE FINISH--------');
        // this.router.navigateByUrl('home');
        this.router.navigateByUrl('registration/success');
        // window.location.href = '/home';
      }, (err) => {
        console.log(err);
      });
    }
  }

  /**
    * iterate through each form control and validate
    */
  public formValid(form: FormGroup): Boolean {
    if (form == null) return false;
    if (form.controls == null) return false;
    return form.valid;
    // let array = _.takeWhile(form.controls, function(c:FormControl) { return !c.valid; });
    // let array = _.takeWhile([], function(c:FormControl) { return !c.valid; });
    // return array.length > 0;
  }
}
