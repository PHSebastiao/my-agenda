import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventFormComponent } from './events/event-form/event-form.component';
import { EventListComponent } from './events/event-list/event-list.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [{
  path: '',
  component: EventListComponent
}, {
  path: 'new',
  component: EventFormComponent
}, {
  path: 'edit/:id',
  component: EventFormComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
