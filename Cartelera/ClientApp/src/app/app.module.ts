import { BrowserModule } from '@angular/platform-browser';
import { NgModule , LOCALE_ID} from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { registerLocaleData } from '@angular/common';
import  localeEs  from '@angular/common/locales/es';
// import {HeadComponent} from './component/shared/head/head.component'
// import {ContentComponent} from './component/shared/content/content.component'
// import {FooterComponent} from './component/shared/footer/footer.component'
// import {MenuComponent} from './component/shared/menu/menu.component'
// import {SettingComponent} from './component/shared/setting/setting.component';
import { LoginComponent } from './login/login.component';
import { RegsiterComponent } from './regsiter/regsiter.component';
import { ProductsComponent } from './products/products.component'
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.moule';
import { NavMenuComponent } from './nav-menu/nav-menu.component';


registerLocaleData(localeEs, 'es');
@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    //HeadComponent,
    //ContentComponent,
    //FooterComponent,
    //MenuComponent,
    //SettingComponent,
    LoginComponent,
    RegsiterComponent,
    ProductsComponent,
    HomeComponent,
    NavMenuComponent
    //FormsModule, 
    //ReactiveFormsModule
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' } ],
  bootstrap: [AppComponent]
})
export class AppModule { }
