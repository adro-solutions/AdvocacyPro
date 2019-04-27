import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({providedIn: 'root'})
export class AppResolver implements Resolve<Observable<boolean>> {
  constructor() {}

  resolve() {
    return of(true);
  }
}
