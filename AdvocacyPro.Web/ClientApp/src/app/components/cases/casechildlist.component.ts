import { CasesService } from 'src/app/services/cases.service';
import { CSPNotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { CaseChild } from 'src/app/models/casechild.model';

export class CaseChildListComponent<T extends CaseChild> {
    _caseId: number;
    caseEndpoint: string;
    items: T[];

    constructor(private api: CasesService, private popupService: CSPNotificationService, private router: Router) { }

    initializeBase(caseId: number, caseEndpoint) {
        this._caseId = caseId;
        this.caseEndpoint = caseEndpoint;
        this.api.getItems<T>(this._caseId, caseEndpoint).subscribe(a => {
            this.items = a;
        });
    }

    delete(id: number) {
        this.popupService.showConfirm('Delete?', 'Are you sure you want to delete this item?').subscribe(confirm => {
            if (confirm.response) {
                this.api.deleteItem<T>(this._caseId, id, this.caseEndpoint).subscribe(() => {
                    const i = this.items.filter((item) => item.id === id)[0];
                    this.items.splice(this.items.indexOf(i), 1);
                });
            }
        });
    }

    edit(id: number) {
        this.router.navigate([`/cases/${this._caseId}/${this.caseEndpoint}/${id}`]);
    }
}
