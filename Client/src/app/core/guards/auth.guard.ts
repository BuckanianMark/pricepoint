import { inject } from '@angular/core';
import {  Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';


export const authGuard = () => {
  const authService = inject(AccountService)
  const router = inject(Router)
  authService.currentUser$.subscribe((data) => {
    const user = data
    if(user?.token)
    {
      return true
    }else{
      router.navigate(['/login'])
      return false;
    }
  })
};
