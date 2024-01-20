import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
// import { SettingsComponent } from './services/settings/settings.component';
// import { GiveAdminRoleComponent } from './services/give-admin-role/give-admin-role.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    // SettingsComponent,
    // GiveAdminRoleComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
