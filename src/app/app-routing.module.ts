import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';

import { AuthGuard } from './services/auth/auth.guard';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { ForgotPasswordComponent } from './pages/forgot-password/forgot-password.component';
import { TokenComponent } from './pages/token/token.component';
import { ChangePasswordComponent } from './pages/change-password/change-password.component';
import { AuthSuccessComponent } from './pages/auth-success/auth-success.component';
import { RegistrationSuccessComponent } from './pages/registration-success/registration-success.component';
import { ManageOrganisationLoginComponent } from './pages/manage-organisation/manage-organisation-login/manage-organisation-login.component';
import { ManageOrgRegStep1Component } from './pages/manage-organisation/manage-organisation-registration-step-1/manage-organisation-registration-step-1.component';
import { ManageOrgRegStep2Component } from './pages/manage-organisation/manage-organisation-registration-step-2/manage-organisation-registration-step-2.component';
import { ManageOrgRegStep3Component } from './pages/manage-organisation/manage-organisation-registration-step-3/manage-organisation-registration-step-3.component';
import { ManageOrgRegAdditionalIdentifiersComponent } from './pages/manage-organisation/manage-organisation-registration-additional-identifiers/manage-organisation-registration-additional-identifiers.component';
import { ManageOrgRegAddUserComponent } from './pages/manage-organisation/manage-organisation-registration-add-user/manage-organisation-registration-add-user.component';
import { ManageOrgRegChangePasswordComponent } from './pages/manage-organisation/manage-organisation-registration-change-password/manage-organisation-registration-change-password.component';
import { ManageOrgRegSuccessComponent } from './pages/manage-organisation/manage-organisation-registration-success/manage-organisation-registration-success.component';
import { ManageOrgRegFailureComponent } from './pages/manage-organisation/manage-organisation-registration-failure/manage-organisation-registration-failure.component';
import { ManageOrgRegErrorComponent } from './pages/manage-organisation/manage-organisation-registration-error/manage-organisation-registration-error.component';
import { ManageOrgRegErrorUsernameExistsComponent } from './pages/manage-organisation/manage-organisation-registration-error-username-already-exists/manage-organisation-registration-error-username-already-exists.component';
import { ManageOrgRegErrorNotFoundComponent } from './pages/manage-organisation/manage-organisation-registration-error-not-found/manage-organisation-registration-error-not-found.component';
import { ManageOrgRegConfirmComponent } from './pages/manage-organisation/manage-organisation-registration-confirm/manage-organisation-registration-confirm.component';
import { ManageOrgRegDetailsWrongComponent } from './pages/manage-organisation/manage-organisation-registration-error-details-wrong/manage-organisation-registration-error-details-wrong.component';
import { ManageOrgRegOrgNotFoundComponent } from './pages/manage-organisation/manage-organisation-registration-error-not-my-organisation/manage-organisation-registration-error-not-my-organisation.component';
import { ManageOrganisationProfileComponent } from './pages/manage-organisation/manage-organisation-profile/manage-organisation-profile.component';
import { ManageOrganisationContactEditComponent } from './pages/manage-organisation/manage-organisation-contact-edit/manage-organisation-contact-edit.component';
import { ManageOrganisationContactDeleteComponent } from './pages/manage-organisation/manage-organisation-contact-delete/manage-organisation-contact-delete.component';
import { ManageOrganisationContactOperationSuccessComponent } from './pages/manage-organisation/manage-organisation-contact-operation-success/manage-organisation-contact-operation-success.component';
import { UserProfileComponent } from './pages/user-profile/user-profile-component';
import { ManageOrgRegErrorGenericComponent } from './pages/manage-organisation/manage-organisation-registration-error-generic/manage-organisation-registration-error-generic.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', canActivate: [AuthGuard], pathMatch: 'full', component: HomeComponent },
  // { path: 'login', pathMatch: 'full', component: LoginComponent },// This was commented to hide the custom login page
  { path: 'profile', canActivate: [AuthGuard], pathMatch: 'full', component: UserProfileComponent },
  { path: 'register', pathMatch: 'full', component: RegisterComponent },
  { path: 'forgot-password', pathMatch: 'full', component: ForgotPasswordComponent },
  { path: 'change-password', pathMatch: 'full', component: ChangePasswordComponent },
  { path: 'token', canActivate: [AuthGuard], pathMatch: 'full', component: TokenComponent },
  { path: 'authsuccess', component: AuthSuccessComponent },
  { path: 'registration/success', component: RegistrationSuccessComponent },
  { path: 'manage-org/login', pathMatch: 'full', component: ManageOrganisationLoginComponent },
  { path: 'manage-org/register', pathMatch: 'full', component: ManageOrgRegStep1Component },
  { path: 'manage-org/register/search', pathMatch: 'full', component: ManageOrgRegStep2Component },
  { path: 'manage-org/register/search/:scheme/:id', pathMatch: 'full', component: ManageOrgRegStep3Component },
  { path: 'manage-org/register/search/:scheme/:id/additional-identifiers', pathMatch: 'full', component: ManageOrgRegAdditionalIdentifiersComponent },
  { path: 'manage-org/register/user', pathMatch: 'full', component: ManageOrgRegAddUserComponent },
  { path: 'manage-org/register/change-password', pathMatch: 'full', component: ManageOrgRegChangePasswordComponent },
  { path: 'manage-org/register/confirm', pathMatch: 'full', component: ManageOrgRegConfirmComponent },
  { path: 'manage-org/register/success', pathMatch: 'full', component: ManageOrgRegSuccessComponent },
  { path: 'manage-org/register/error', pathMatch: 'full', component: ManageOrgRegErrorComponent },
  { path: 'manage-org/register/error/generic', pathMatch: 'full', component: ManageOrgRegErrorGenericComponent },
  { path: 'manage-org/register/error/username', pathMatch: 'full', component: ManageOrgRegErrorUsernameExistsComponent },
  { path: 'manage-org/register/error/notfound', pathMatch: 'full', component: ManageOrgRegErrorNotFoundComponent },
  { path: 'manage-org/register/error/reg-id-exists', pathMatch: 'full', component: ManageOrgRegFailureComponent },
  { path: 'manage-org/register/error/wrong-details', pathMatch: 'full', component: ManageOrgRegDetailsWrongComponent },
  { path: 'manage-org/register/error/not-my-details', pathMatch: 'full', component: ManageOrgRegOrgNotFoundComponent },
  { path: 'manage-org/profile/:id', pathMatch: 'full', canActivate: [AuthGuard], component: ManageOrganisationProfileComponent },
  { path: 'manage-org/profile/:organisationId/contact-edit/:contactId', pathMatch: 'full', canActivate: [AuthGuard], component: ManageOrganisationContactEditComponent },
  { path: 'manage-org/profile/:organisationId/contact-delete/:contactId', pathMatch: 'full', canActivate: [AuthGuard], component: ManageOrganisationContactDeleteComponent },
  { path: 'manage-org/profile/:organisationId/contact-operation-success/:operation', pathMatch: 'full', canActivate: [AuthGuard], component: ManageOrganisationContactOperationSuccessComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

export const routingConfiguration: ExtraOptions = {
  paramsInheritanceStrategy: 'always'
};


@NgModule({
  imports: [RouterModule.forRoot(routes, routingConfiguration)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
