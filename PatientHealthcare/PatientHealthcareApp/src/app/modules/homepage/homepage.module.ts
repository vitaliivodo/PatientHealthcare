import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomepageRoutingModule } from './homepage-routing.module';
import { HomepageComponent } from './homepage.component';
import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    HomepageComponent
  ],
  imports: [
    CommonModule,
    HomepageRoutingModule,
    MatPaginatorModule
  ],
  exports: [HomepageComponent]
})
export class HomepageModule { }
