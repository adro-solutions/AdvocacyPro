import { Component, ViewChild, Input, OnInit } from '../../vendor';
import { ValuesService } from '../../services';
import { TrackedBase } from "../../models/trackedBase.model";

@Component({
    selector: 'last-edit-info',
    template: require('./lasteditinfo.component.html')
})
export class LastEditInfoComponent {
    @Input() item: TrackedBase; 
    @Input() title: string;

    constructor(private valueService: ValuesService) { }
}
