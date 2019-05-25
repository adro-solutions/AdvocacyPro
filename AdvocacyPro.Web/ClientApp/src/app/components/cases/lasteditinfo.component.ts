import { Component, Input } from '@angular/core';
import { TrackedBase } from 'src/app/models/trackedBase.model';
import { ValuesService } from 'src/app/services/values.service';

@Component({
    selector: 'app-last-edit-info',
    templateUrl: './lasteditinfo.component.html'
})
export class LastEditInfoComponent {
    @Input() item: TrackedBase;
    @Input() title: string;

    constructor(private valueService: ValuesService) { }
}
