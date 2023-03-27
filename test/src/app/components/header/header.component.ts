import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{
  constructor(private _router: Router) {

  }

  get isUserAuth() {
    return Boolean(localStorage.getItem('jwt_token'));
  }
  ngOnInit() {
  }

  login() {
    this._router.navigate(['/login'])
  }

  logout() {
    localStorage.clear();
    this._router.navigate(['/home'])
  }
}
