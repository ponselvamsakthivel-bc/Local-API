import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.scss']
})
export class TopNavComponent {
  isAuthenticated: boolean = false;
  constructor(public authService: AuthService) {
  }

  ngOnInit() {
    this.isAuthenticated = this.authService.isUserAuthenticated();
  }

  signout() {
    const userName = localStorage.getItem('brickedon_user') + '';
    this.authService.logOutAndRedirect(userName);
  }
}
