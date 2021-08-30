import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { takeUntil } from 'rxjs/operators';
import { Employee } from 'src/app/model/employee.interface';
import { SharedService } from 'src/app/service/shared.service';
import { AbstractBaseComponent } from '../../abstract-base/abstract-base.component';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.scss']
})
export class ShowEmpComponent extends AbstractBaseComponent implements OnInit {

  constructor(private sharedService: SharedService, private modalService: NgbModal) {
    super();
  }

  employeeList: Employee[] = [];
  modalTitle: string = "";
  activateAddEditEmployeeComponent: boolean = false;
  employee: Employee = {};
  modalRef: NgbModalRef | null = null;

  ngOnInit(): void {
    this.refreshEmployeeList();
  }

  refreshEmployeeList() {
    this.sharedService.getEmployeeList()
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.employeeList = res;
      })
  }

  addClick(content: TemplateRef<any>) {
    this.employee = {};
    this.modalTitle = "Add Employee";
    this.activateAddEditEmployeeComponent = true;
    this.modalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg', backdrop: true });
  }

  editClick(content: TemplateRef<any>, employee: Employee) {
    this.employee = employee;
    this.modalTitle = "Edit Employee";
    this.activateAddEditEmployeeComponent = true;
    this.modalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg', backdrop: true });
  }

  deleteClick(employee: Employee) {
    if (confirm('Are you sure?')) {
      this.sharedService.deleteEmployee(employee.id!)
        .pipe(takeUntil(this.isDestroyed$))
        .subscribe(res => {
          this.refreshEmployeeList();
        })
    }
  }

  closeClick() {
    this.activateAddEditEmployeeComponent = false;
    this.refreshEmployeeList();
    this.modalRef?.close();
  }

}
