import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
     { path: '', component: HomeComponent },
     { path: 'home', component: HomeComponent,pathMatch:'full' },
      { path: 'estrenos', component: CounterComponent,pathMatch:'full' },
      { path: 'login', component: LoginComponent,pathMatch:'full' },
     { path: '**', redirectTo:'/home' }
     
  ])],
  exports: [RouterModule]
})

export class AppRoutingModule {}
