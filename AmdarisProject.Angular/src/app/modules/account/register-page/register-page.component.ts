import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRegister } from 'src/app/common/models/user/user-register';
import { AccountService } from 'src/app/common/services/account.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    userName: new FormControl("", Validators.required),
    password: new FormControl("", Validators.required),
    email: new FormControl("", [
      Validators.required,
      Validators.email
    ])
  });

  constructor(
    private accountService: AccountService
  ) { }

  ngOnInit(): void {
  }

  public register() {
    const user: UserRegister = this.registerForm.value;
    this.accountService.register(user).subscribe();
  }

}
