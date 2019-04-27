import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { UserData } from '../models/userData.model';
import { Feature } from '../models/feature.model';
import { Organization } from '../models/valueBase.model';
import { Product } from '../enums/product.enum';

@Injectable({providedIn: 'root'})
export class StateService {
    public menuOpen: boolean;
    public navsOpen: Array<{ [menu: string]: boolean; }> = new Array<{ [menu: string]: boolean; }>();

    constructor(private router: Router, private sanitizer: DomSanitizer) {
        this.menuOpen = true;
    }

    public signout(): void {
        sessionStorage.removeItem('_user');
        sessionStorage.removeItem('_authToken');
        sessionStorage.removeItem('_features');
        this.router.navigate(['login']);
    }

    get user(): UserData {
        if (sessionStorage.getItem('_user') == null) {
            this.router.navigate(['login']);
        }

        return <UserData>JSON.parse(sessionStorage.getItem('_user'));
    }
    set user(theUser: UserData) {
        sessionStorage.setItem('_user', JSON.stringify(theUser));
    }

    public hasFeature(feature: string): boolean {
        if (sessionStorage.getItem('_features') == null) {
            return false;
        }

        const claims: Feature[] = <Feature[]>JSON.parse(sessionStorage.getItem('_features'));
        return claims.findIndex(f => f.value === feature) === -1 ? false : true;
    }

    get features(): Feature[] {
        if (sessionStorage.getItem('_features') === null) {
            this.router.navigate(['login']);
        }

        return <Feature[]>JSON.parse(sessionStorage.getItem('_features'));
    }
    set features(userFeatures: Feature[]) {
        sessionStorage.setItem('_features', JSON.stringify(userFeatures));
    }


    get organization(): Organization {
        if (localStorage.getItem('_organization') === null) {
            this.router.navigate(['login']);
        }

        return <Organization>JSON.parse(localStorage.getItem('_organization'));
    }
    set organization(theOrganization: Organization) {
        localStorage.setItem('_organization', JSON.stringify(theOrganization));
    }

    get logo(): string {
        if (localStorage.getItem('_organization') === null) {
            return '/advocacypro.jpg';
        } else if (this.organization.logo === null) {
            if (this.organization.product === Product.CampusSafetyPro) {
                return '/campussafetypro.png';
            } else {
                return '/advocacypro.jpg';
            }
        } else {
            return 'data:image/png;base64,' + this.organization.logo;
               }
    }

    get productName(): SafeHtml {
        if (localStorage.getItem('_organization') == null) {
            return this.sanitizer.bypassSecurityTrustHtml('<b>Advocacy</b>Pro');
        } else if (this.organization.product === Product.CampusSafetyPro) {
            return this.sanitizer.bypassSecurityTrustHtml('<b>CampusSafety</b>Pro');
        } else {
            return this.sanitizer.bypassSecurityTrustHtml('<b>Advocacy</b>Pro');
        }
    }

    get productShortName(): SafeHtml {
        if (localStorage.getItem('_organization') == null) {
            return this.sanitizer.bypassSecurityTrustHtml('<b>A</b>P');
        } else if (this.organization.product === Product.CampusSafetyPro) {
            return this.sanitizer.bypassSecurityTrustHtml('<b>CS</b>P');
        } else {
            return this.sanitizer.bypassSecurityTrustHtml('<b>A</b>P');
        }
    }

    get authToken(): string {
        return sessionStorage.getItem('_authToken');
    }
    set authToken(theToken: string) {
        sessionStorage.setItem('_authToken', theToken);
    }
}
