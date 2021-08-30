import { Component, Input, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Department, DepartmentCreate, DepartmentUpdate } from 'src/app/model/department.interface';
import { SharedService } from 'src/app/service/shared.service';
import { AbstractBaseComponent } from '../../abstract-base/abstract-base.component';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.scss']
})
export class AddEditDepComponent extends AbstractBaseComponent implements OnInit {

  @Input() department!: Department;

  constructor(private sharedService: SharedService) { super(); }

  departmentName: string = "";

  ngOnInit(): void {
    this.departmentName = this.department.departmentName!;
  }

  addDepartment() {
    const departmentCreate: DepartmentCreate = {
      departmentName: this.departmentName
    };
    this.sharedService.addDepartment(departmentCreate)
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        alert(res.toString());
      });
  }

  updateDepartment() {
    const departmentUpdate: DepartmentUpdate = {
      departmentName: this.departmentName
    };
    this.sharedService.updateDepartment(this.department.id!, departmentUpdate)
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        alert(res.toString());
      });
  }
}
