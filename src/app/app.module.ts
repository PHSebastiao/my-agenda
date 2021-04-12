import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EventListComponent } from './events/event-list/event-list.component';
import { EventFormComponent } from './events/event-form/event-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EventListComponent,
    EventFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
