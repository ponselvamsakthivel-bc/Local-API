import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { slideAnimation } from 'src/app/animations/slide.animation';
import { BaseComponent } from 'src/app/components/base/base.component';
import { UIState } from 'src/app/store/ui.states';
import { Organisation } from 'src/app/models/organisation';
import { ContactDetails, Address, ContactType } from 'src/app/models/contactDetail';
import { contactService } from 'src/app/services/contact/contact.service';
import { OrganisationService } from 'src/app/services/postgres/organisation.service';

@Component({
    selector: 'app-manage-organisation-profile',
    templateUrl: './manage-organisation-profile.component.html',
    styleUrls: ['./manage-organisation-profile.component.scss'],
    animations: [
        slideAnimation({
            close: { 'transform': 'translateX(12.5rem)' },
            open: { left: '-12.5rem' }
        })
    ],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.Default
})
export class ManageOrganisationProfileComponent extends BaseComponent implements OnInit {

    organisationId: number;
    contactData: ContactDetails[];
    organisationAddress: Address;
    siteData: any[];
    registries: any[];
    displayedColumns: string[] = ['name', 'email', 'teamName', 'phoneNumber', 'actions'];
    siteTableDisplayedColumns: string[] = ['name', 'createdDate', 'actions'];
    registriesTableDisplayedColumns: string[] = ['authority', 'id', 'actions'];
    organisation$!: Observable<Organisation>;
    
    constructor(private contactService: contactService, private organisationService: OrganisationService, private router: Router, private route: ActivatedRoute, protected uiStore: Store<UIState>) {
        super(uiStore);
        this.contactData = [];
        this.organisationAddress = {};
        this.siteData = [];
        this.registries = [];
        this.organisationId = parseInt(this.route.snapshot.paramMap.get('id') || '0');
        this.organisation$ = this.organisationService.get(this.organisationId);
    }

    ngOnInit() {
        //TODO Get the organisation to show legal name etc..
        this.contactService.getContacts(this.organisationId)
            .subscribe(data => {
                if (data && data.length > 0){
                    var personContacts= data.filter(c=> c.contactType == ContactType.OrganisationPerson);
                    this.contactData = personContacts;
                    var orgContact = data.find(c => c.contactType== ContactType.Organisation);
                    if (orgContact && orgContact.address){
                        this.organisationAddress = orgContact.address;
                    }
                }
            });
    }

    public onContactAddClick() {
        this.router.navigateByUrl(`manage-org/profile/${this.organisationId}/contact-edit/0`);
    }

    public onContactEditClick(event: any, contactId:number){
        this.router.navigateByUrl(`manage-org/profile/${this.organisationId}/contact-edit/${contactId}`);
    }

    public onSiteAddClick() {
        console.log("Add site");
    }

    public onSiteEditClick(event: any){
        console.log("Edit site");
    }

    public onRegistryAddClick() {
        console.log("Add registry");
    }

    public onRegistryRemoveClick(event: any){
        console.log("Remove registry");
    }

}
