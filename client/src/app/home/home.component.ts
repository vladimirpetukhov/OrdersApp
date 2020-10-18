import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
   console.log(!this.jwtHelper.isTokenExpired(token));
  }



  registerToggle() {
    this.registerMode = true;

  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
