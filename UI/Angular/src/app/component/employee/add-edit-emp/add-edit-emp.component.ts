import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Department } from 'src/app/model/department.interface';
import { Employee, EmployeeCreate, EmployeeUpdate } from 'src/app/model/employee.interface';
import { SharedService } from 'src/app/service/shared.service';
import { AbstractBaseComponent } from '../../abstract-base/abstract-base.component';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.scss']
})
export class AddEditEmpComponent extends AbstractBaseComponent implements OnInit {

  @Input() employee!: Employee;
  @Output() close = new EventEmitter();

  constructor(private sharedService: SharedService) { super(); }

  employeeName: string = "";
  department: string = "";
  dateOfJoining: Date = new Date();
  photoFileName: string = "";
  photoFilePath: string = "";

  departmentList: Department[] = [];

  ngOnInit(): void {
    this.employeeName = this.employee.employeeName!;
    this.department = this.employee.department!;
    this.dateOfJoining = this.employee.dateOfJoining!;
    this.photoFileName = this.employee.photoFileName!;
    this.photoFilePath = this.photoFileName ? this.sharedService.getPhotoPath(this.photoFileName) : "";
    this.loadDepartmentList();
  }

  addEmployee() {
    const employeeCreate: EmployeeCreate = {
      employeeName: this.employeeName,
      department: this.department,
      dateOfJoining: this.dateOfJoining,
      photoFileName: this.photoFileName
    };
    this.sharedService.addEmployee(employeeCreate)
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.close.emit();
      });
  }

  updateEmployee() {
    const employeeUpdate: EmployeeUpdate = {
      employeeName: this.employeeName,
      department: this.department,
      dateOfJoining: this.dateOfJoining,
      photoFileName: this.photoFileName
    };
    this.sharedService.updateEmployee(this.employee.id!, employeeUpdate)
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.close.emit();
      });
  }

  uploadPhoto(event: any) {
    const file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('uploadedFile', file, file.name);

    this.sharedService.uploadPhoto(formData)
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.photoFileName = res.toString();
        this.photoFilePath = this.sharedService.getPhotoPath(this.photoFileName);
      })
  }

  loadDepartmentList() {
    this.sharedService.getDepartmentList()
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.departmentList = res;
      });
  }
}
