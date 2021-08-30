import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './component/department/department.component';
import { ShowDepComponent } from './component/department/show-dep/show-dep.component';
import { AddEditDepComponent } from './component/department/add-edit-dep/add-edit-dep.component';
import { EmployeeComponent } from './component/employee/employee.component';
import { ShowEmpComponent } from './component/employee/show-emp/show-emp.component';
import { AddEditEmpComponent } from './component/employee/add-edit-emp/add-edit-emp.component';
import { SharedService } from './service/shared.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AbstractBaseComponent } from './component/abstract-base/abstract-base.component';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    EmployeeComponent,
    ShowDepComponent,
    AddEditDepComponent,
    ShowEmpComponent,
    AddEditEmpComponent,
    AbstractBaseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
