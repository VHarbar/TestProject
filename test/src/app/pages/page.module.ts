import { NgModule } from '@angular/core';
import {PageComponent} from "./page.component";
import { LoginComponent } from './login/login.component';
import {CheckboxModule} from "primeng/checkbox";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {InputTextModule} from "primeng/inputtext";
import {RouterOutlet} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import { MainPageComponent } from './main-page/main-page.component';
import {CardModule} from "primeng/card";
import {NgForOf, NgIf} from "@angular/common";

@NgModule({
  declarations: [
    PageComponent,
    LoginComponent,
    MainPageComponent,
  ],
  imports: [
    CheckboxModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
    RouterOutlet,
    ReactiveFormsModule,
    CardModule,
    NgForOf,
    NgIf,
  ],
  providers: [],
  exports: [
    PageComponent
  ],
  bootstrap: [PageComponent]
})
export class PageModule { }
