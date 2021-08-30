import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './component/department/department.component';
import { EmployeeComponent } from './component/employee/employee.component';

const routes: Routes = [
  { path: 'employee', component: EmployeeComponent },
  { path: 'department', component: DepartmentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
