import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./pages/login/login.component";
import {PageComponent} from "./pages/page.component";
import {MainPageComponent} from "./pages/main-page/main-page.component";
import {AuthGuard} from "./guards/auth.guard";

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./pages/page.module').then( m => m.PageModule),
    component: PageComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'main',
    component: MainPageComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
