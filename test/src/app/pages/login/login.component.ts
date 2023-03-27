import {Component, OnInit} from '@angular/core';
import {HomeHttpService} from "../../services/http/home-http.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements  OnInit{

  public loginForm = new FormGroup({
    surname: new FormControl('', [Validators.required, Validators.minLength(1)]),
    password: new FormControl('', [Validators.required, Validators.minLength(1)])
  })
  constructor(private _homeHttp: HomeHttpService, private fb:FormBuilder, private _router: Router) {
  }
  ngOnInit() {
    if(localStorage.getItem('jwt_token')) {
      this._router.navigate(['/main'])
    }
  }

  login() {
    if(this.loginForm.valid) {
      this._homeHttp.login({
        surname: this.loginForm.get('surname')?.getRawValue(),
        password: this.loginForm.get('password')?.getRawValue(),
      })
    }
  }
}
