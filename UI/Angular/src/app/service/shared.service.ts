import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Department, DepartmentCreate, DepartmentUpdate } from '../model/department.interface';
import { Employee, EmployeeCreate, EmployeeUpdate } from '../model/employee.interface';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44308/api/v1";
  readonly PhotoUrl = "https://localhost:44308/Photos";

  constructor(private http: HttpClient) { }

  getDepartmentList(): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.APIUrl}/Departments`);
  }

  addDepartment(obj: DepartmentCreate): Observable<Department> {
    return this.http.post<Department>(`${this.APIUrl}/Departments`, obj);
  }

  updateDepartment(id: string, obj: DepartmentUpdate) {
    return this.http.put(`${this.APIUrl}/Departments/${id}`, obj);
  }

  deleteDepartment(id: string) {
    return this.http.delete(`${this.APIUrl}/Departments/${id}`);
  }

  getEmployeeList(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.APIUrl}/Employees`);
  }

  addEmployee(obj: EmployeeCreate): Observable<Employee> {
    return this.http.post<Employee>(`${this.APIUrl}/Employees`, obj);
  }

  updateEmployee(id: string, obj: EmployeeUpdate) {
    return this.http.put(`${this.APIUrl}/Employees/${id}`, obj);
  }

  deleteEmployee(id: string) {
    return this.http.delete(`${this.APIUrl}/Employees/${id}`);
  }

  uploadPhoto(val: any) {
    return this.http.post(`${this.APIUrl}/Employees/SaveFile`, val);
  }

  getPhotoPath(photoFileName: string) {
    return `${this.PhotoUrl}/${photoFileName}`;
  }
}
