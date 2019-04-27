import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { ValuesService } from '../services/values.service';
import { take, filter, map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class AppResolver implements Resolve<Observable<boolean>> {
  constructor(private valuesService: ValuesService) {}

  resolve() {
    return this.valuesService.initialize().pipe(
      filter(loaded => loaded),
      take(1),
      map(_ => true)
    );
  }
}
