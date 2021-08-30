import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { takeUntil } from 'rxjs/operators';
import { Department } from 'src/app/model/department.interface';
import { SharedService } from 'src/app/service/shared.service';
import { AbstractBaseComponent } from '../../abstract-base/abstract-base.component';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.scss']
})
export class ShowDepComponent extends AbstractBaseComponent implements OnInit {

  constructor(private sharedService: SharedService, private modalService: NgbModal) {
    super();
  }

  departmentList: Department[] = [];
  modalTitle: string = "";
  activateAddEditDepartmentComponent: boolean = false;
  department: Department = {};
  modalRef: NgbModalRef | null = null;

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  refreshDepartmentList() {
    this.sharedService.getDepartmentList()
      .pipe(takeUntil(this.isDestroyed$))
      .subscribe(res => {
        this.departmentList = res;
      })
  }

  addClick(content: TemplateRef<any>) {
    this.department = {};
    this.modalTitle = "Add Department";
    this.activateAddEditDepartmentComponent = true;
    this.modalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg', backdrop: true });
  }

  editClick(content: TemplateRef<any>, department: Department) {
    this.department = department;
    this.modalTitle = "Edit Department";
    this.activateAddEditDepartmentComponent = true;
    this.modalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg', backdrop: true });
  }

  deleteClick(department: Department) {
    if (confirm('Are you sure?')) {
      this.sharedService.deleteDepartment(department.id!)
        .pipe(takeUntil(this.isDestroyed$))
        .subscribe(res => {
          this.refreshDepartmentList();
        })
    }
  }

  closeClick() {
    this.activateAddEditDepartmentComponent = false;
    this.refreshDepartmentList();
    this.modalRef?.close();
  }
}
