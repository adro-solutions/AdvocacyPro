import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AppResolver } from './resolvers/app.resolver';

const routes = [
  { path: '', resolve: {app: AppResolver}, children: [] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
