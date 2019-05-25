import { ValueAPIEndpoints } from './../../../models/constants';
import { FormService } from './../../../services/form.service';
import { ValuesService } from './../../../services/values.service';
import { State } from './../../../models/valueBase.model';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    templateUrl: './state.component.html'
})
export class StateComponent implements OnInit {
    id: number;
    state: State;
    formGroup: FormGroup;
    submitted = false;

    constructor(private api: ValuesService, private route: ActivatedRoute, private formService: FormService, private router: Router) { }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.id = +params['id'];

            if (this.id > 0) {
                this.api.get<State>(ValueAPIEndpoints.states, this.id).subscribe(a => {
                    this.state = a;
                    this.formService.buildFormGroup<State>(this.state, 'State')
                        .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
                });
            } else {
                this.state = new State();
                this.formService.buildFormGroup<State>(this.state, 'State')
                    .subscribe((fbg: FormGroup) => { this.formGroup = fbg; });
            }
        });

    }

    submit(value: any) {
        this.submitted = true;
        if (this.formGroup.valid) {
            this.formService.buildObject(value, this.state);
            if (this.id === 0) {
                this.api.create<State>(ValueAPIEndpoints.states, this.state)
                    .subscribe(() => this.router.navigate(['/admin/values/states']));
            } else {
                this.api.update<State>(ValueAPIEndpoints.states, this.id, this.state).subscribe(() => {
                    this.router.navigate(['/admin/values/states']);
                });
            }
        }
    }

}
