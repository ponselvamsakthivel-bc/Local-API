import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, map, timeout } from 'rxjs/operators';

import { BaseComponent } from 'src/app/components/base/base.component';
import { slideAnimation } from 'src/app/animations/slide.animation';
import { Scheme } from '../../../models/scheme';
import { UIState } from 'src/app/store/ui.states';
import { AuthService } from 'src/app/services/auth/auth.service';
import { ciiService } from 'src/app/services/cii/cii.service';

@Component({
  selector: 'app-manage-organisation-registration-change-password',
  templateUrl: './manage-organisation-registration-change-password.component.html',
  styleUrls: ['./manage-organisation-registration-change-password.component.scss'],
  animations: [
      slideAnimation({
          close: { 'transform': 'translateX(12.5rem)' },
          open: { left: '-12.5rem' }
      })
  ],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ManageOrgRegChangePasswordComponent extends BaseComponent implements OnInit {

  formGroup: FormGroup;
  submitted: boolean = false;

  constructor(private formBuilder: FormBuilder, private translateService: TranslateService, private authService: AuthService, private ciiService: ciiService, private router: Router, private route: ActivatedRoute, protected uiStore: Store<UIState>) {
    super(uiStore);
    this.formGroup = this.formBuilder.group({
      userName: ['', Validators.compose([Validators.required])],
      password: ['', Validators.compose([Validators.required, Validators.minLength(8)])],
      confirmPassword: ['', Validators.compose([Validators.required])]
    });
  }

  ngOnInit() {

  }

  public onSubmit(form: FormGroup) {
    this.submitted = true;
    const token = localStorage.getItem('brickedon_aws_tokens');
    if (this.formValid(form) && token) {
      const t = JSON.parse(token);
      this.authService.changePassword(form.get('userName')?.value, form.get('password')?.value, t.sessionId).toPromise().then((response) => {
        console.log('---------CHANGE PASSWORD RESPONSE START---------');
        console.log(response);
        console.log('---------CHANGE PASSWORD RESPONSE FINISH--------');
        this.router.navigateByUrl('manage-org/register/success');
      }, (err) => {
          console.log(err);
          this.router.navigateByUrl('manage-org/register/success');
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
