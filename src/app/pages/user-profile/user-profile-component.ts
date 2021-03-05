import { ChangeDetectionStrategy, Component, ViewChild, ViewEncapsulation } from "@angular/core";
import { OnInit } from "@angular/core";
import { Store } from "@ngrx/store";
import { BaseComponent } from "src/app/components/base/base.component";
import { UIState } from "src/app/store/ui.states";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { slideAnimation } from "src/app/animations/slide.animation";
import { UserService } from "src/app/services/postgres/user.service";
import { User, UserGroup } from "src/app/models/user";
import { MatTableDataSource } from '@angular/material/table';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile-component.html',
    styleUrls: ['./user-profile-component.scss'],
    animations: [
        slideAnimation({
            close: { 'transform': 'translateX(12.5rem)' },
            open: { left: '-12.5rem' }
        })
    ],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserProfileComponent extends BaseComponent implements OnInit {
    submitted!: boolean;
    userProfileForm!: FormGroup;
    //@ViewChild('table') table: MatTable<any> | undefined;
    columnsToDisplay = ['group', 'role'];
    //userGroups: UserGroup[] = [];
    dataSource = new MatTableDataSource<UserGroup>();
    constructor(private userService: UserService, protected uiStore: Store<UIState>,
        private formBuilder: FormBuilder) {
        super(uiStore);
        this.userProfileForm = this.formBuilder.group({
            firstName: '',
            lastName: ['', Validators.compose([Validators.required])],
            userName: ['', Validators.compose([Validators.required])]
        });
    }

    ngOnInit() {
        let userName = localStorage.getItem('user_name') || '';
        this.userService.getUser(userName).subscribe({
            next: (user: User) => {
                if (user != null) {
                    this.dataSource.data = user.userGroups;
                    this.userProfileForm.setValue({
                        firstName: user.firstName,
                        lastName: user.lastName,
                        userName: user.userName
                    });
                }
            },
            error: (error: any) => {
            }
        });

    }
}