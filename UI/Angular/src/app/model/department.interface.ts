export interface Department {
  id?: string;
  departmentId?: number;
  departmentName?: string;
  createdDate?: Date;
}

export interface DepartmentCreate {
  departmentName: string;
}

export interface DepartmentUpdate {
  departmentName: string;
}
