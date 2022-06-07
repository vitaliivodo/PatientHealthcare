import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainLayoutRoutingModule } from './main-layout-routing.module';
import { MainLayoutComponent } from './main-layout.component';
import { HeaderModule } from 'src/app/modules/header/header.module';
import { HeaderComponent } from 'src/app/modules/header/header.component';
import { FooterComponent } from 'src/app/modules/footer/footer.component';
import { MainPageComponent } from 'src/app/modules/main-page/main-page.component';
import { MainPageModule } from 'src/app/modules/main-page/main-page.module';


@NgModule({
  declarations: [
    MainLayoutComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    MainLayoutRoutingModule
  ],
  exports: [MainLayoutComponent]
})
export class MainLayoutModule { }
