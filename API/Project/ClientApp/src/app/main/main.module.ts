import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule,Routes } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { BrowserModule } from '@angular/platform-browser';


const mainRoutes: Routes = [
{ path: 'student', component: StudentComponent}
];



@NgModule({
  imports: [
    CommonModule, BrowserModule, RouterModule.forRoot(mainRoutes)
  ],
  declarations: [MainComponent,StudentComponent]
})
export class MainModule { }
