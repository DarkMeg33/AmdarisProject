import { Component, OnInit } from '@angular/core';
import { UserLogin } from 'src/app/common/models/user/user-login';
import { AccountService } from 'src/app/common/services/account.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  public user: UserLogin = {
    userName: "",
    password: ""
  };

  password1: string = "";

  constructor(
    private accountService: AccountService
  ) { }

  ngOnInit(): void {
  }

  public login() {
    // this.accountService.login(this.user).subscribe({
    //   next: (token: JwtToken) => {
    //     localStorage.setItem("accessToken", token.accessToken);
    //   },
    //   error: () => {},
    //   complete: () => {
    //     console.log(localStorage.getItem("accessToken"));
    //   }
    // });

    this.accountService.login(this.user).subscribe();
  }

}
