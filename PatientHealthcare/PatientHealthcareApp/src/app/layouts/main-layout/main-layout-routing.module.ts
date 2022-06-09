import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './main-layout.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'home', loadChildren: () => import('../../modules/main-page/main-page.module').then(s => s.MainPageModule) },
      { path: 'profile-page', loadChildren: () => import('../../modules/profile-page/profile-page.module').then(s => s.ProfilePageModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainLayoutRoutingModule { }
