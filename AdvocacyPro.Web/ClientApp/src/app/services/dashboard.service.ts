import { Injectable } from '@angular/core';
import { Case } from '../models/case.model';
import { Fire } from '../models/fire.model';
import { HttpClient } from '@angular/common/http';
import { StateService } from './state.service';
import { forkJoin } from 'rxjs';

@Injectable({providedIn: 'root'})
export class DashboardService {
    cases: Case[];
    fires: Fire[];
    caseDaysOld = 0;
    fireDaysOld = 0;
    totalOpenCases = 0;
    totalOpenFires = 0;

    constructor(private http: HttpClient, private stateService: StateService) { }

    public refresh() {
        if (this.stateService.user != null) {
            const hasFires: boolean = this.stateService.hasFeature('fires');
            const hasCases: boolean = this.stateService.hasFeature('cases');

            const obv = [];
            if (hasFires) {
                obv.push(this.http.get<Fire[]>(`api/Users/${this.stateService.user.id}/Fires`));
                obv.push(this.http.get<number>('api/Fires/Count/Open'));
            }

            if (hasCases) {
                obv.push(this.http.get<Case[]>(`api/Users/${this.stateService.user.id}/Cases`));
                obv.push(this.http.get<number>('api/Cases/Count/Open'));
            }

            forkJoin(
                obv
            ).subscribe(d => {
                const curDate: Date = new Date();
                let usedDate: Date;

                if (hasFires) {
                    this.fires = <Fire[]>d[0];
                    this.totalOpenFires = <number>d[1];

                    this.fireDaysOld = -1;

                    this.fires.forEach(f => {
                        if (f.updateDate != null) {
                            usedDate = new Date(f.updateDate);
                        } else {
                            usedDate = new Date(f.createDate);
                        }

                        const daysDiff = Math.round((curDate.getTime() - usedDate.getTime()) / (1000 * 60 * 60 * 24));
                        if (daysDiff > this.fireDaysOld) {
                            this.fireDaysOld = daysDiff;
                        }
                    });
                }

                if (hasCases) {
                    this.cases = <Case[]>d[hasFires ? 2 : 0];
                    this.totalOpenCases = <number>d[hasFires ? 3 : 1];

                    this.caseDaysOld = -1;

                    this.cases.forEach(c => {
                        if (c.updateDate != null) {
                            usedDate = new Date(c.updateDate);
                        } else {
                            usedDate = new Date(c.createDate);
                        }

                        const daysDiff = Math.round((curDate.getTime() - usedDate.getTime()) / (1000 * 60 * 60 * 24));
                        if (daysDiff > this.caseDaysOld) {
                            this.caseDaysOld = daysDiff;
                        }
                    });
                }
            });
        }
    }
}
