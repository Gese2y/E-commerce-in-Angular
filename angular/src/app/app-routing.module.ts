import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// import { SettingsComponent } from './services/settings/settings.component';
// import { GiveAdminRoleComponent } from './services/give-admin-role/give-admin-role.component';

const routes: Routes = [
  // {path:'Setting',component:SettingsComponent},
// {path:'Adminrole',component:GiveAdminRoleComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
