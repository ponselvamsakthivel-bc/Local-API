import { ChangeDetectionStrategy, Component, OnInit, Pipe, ViewEncapsulation } from '@angular/core';
import { Store } from '@ngrx/store';

import { BaseComponent } from 'src/app/components/base/base.component';
import { slideAnimation } from 'src/app/animations/slide.animation';
import { dataService } from 'src/app/services/data/data.service';
import { OrganisationService } from 'src/app/services/postgres/organisation.service';
import { UIState } from 'src/app/store/ui.states';
import { SystemModule } from 'src/app/models/system';
// import { Observable } from 'rxjs/internal/Observable';
import { Observable } from 'rxjs';
import { Organisation } from 'src/app/models/organisation';
import { environment } from 'src/environments/environment';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent implements OnInit {

  systemModules: SystemModule[] = [];
  ccsModules: SystemModule[] = [];
  organisation$!: Observable<Organisation>;
  idam_client_id: string = environment.idam_client_id;
  targetURL: string = environment.uri.api.security;
  opIFrameURL = this.sanitizer.bypassSecurityTrustResourceUrl(environment.uri.api.security + '/security/checksession/?origin=' + environment.uri.web.dashboard);
  rpIFrameURL = this.sanitizer.bypassSecurityTrustResourceUrl(environment.uri.web.dashboard + '/assets/rpIFrame.html');
  constructor(protected uiStore: Store<UIState>, private sanitizer: DomSanitizer, private organisationService: OrganisationService) {
    super(uiStore);
    
  }

  ngOnInit() {
    const orgId = JSON.parse(localStorage.getItem('organisation_id') + '');
    //const orgId: number = + JSON.parse(localStorage.getItem('organisation_id')+'');

    this.systemModules.push({ name: 'Manage users', description: 'Create and manage users and what they can do', route: '/' });
    this.systemModules.push({ name: 'Manage organisation(s)', description: 'View details for your organisation', route: '/manage-org/profile/' + orgId });
    this.systemModules.push({ name: 'Manage groups', description: 'Create groups and organise users', route: '/' });
    this.systemModules.push({ name: 'Manage my account', description: 'Manage your details and request a new role', route: '/profile' });
    this.systemModules.push({ name: 'Manage sign in providers', description: 'Add and manage sign in providers', route: '/' });
    this.ccsModules.push({ name: 'DigiTS', description: 'Book rail, accomodation, air travel, and more', route: '/' });
    this.ccsModules.push({ name: 'Buy a thing', description: 'Online catalog to purchase low volume, fixed price commodities', route: '/' });
    this.ccsModules.push({ name: 'Evidence locker', description: '', route: '/' });
    this.ccsModules.push({ name: 'Agreement service', description: '', route: '/' });
    this.ccsModules.push({ name: 'Test', description: 'Test app to demonstrate single sign-on', route: '/token' });

    if (orgId > 0) {
      this.organisation$ = this.organisationService.get(orgId);
    }
  }

}