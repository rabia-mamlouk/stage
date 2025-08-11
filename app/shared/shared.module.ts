import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterLink, RouterModule } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';



@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent
  ],
  exports: [
    HeaderComponent,
    SidebarComponent
  ],
  imports: [
    CommonModule, RouterModule, RouterLink
  ]
})
export class SharedModule { }
