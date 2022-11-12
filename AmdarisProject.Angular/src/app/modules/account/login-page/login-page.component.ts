import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLogin } from 'src/app/common/models/user/user-login';
import { AccountService } from 'src/app/common/services/account.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  private returnUrl: string = "";
  public user: UserLogin = {
    userName: "",
    password: ""
  };

  password1: string = "";

  constructor(
    private accountService: AccountService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'];
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

    this.accountService.login(this.user).subscribe(() => {
      this.router.navigate([this.returnUrl]);
    });
  }

}
