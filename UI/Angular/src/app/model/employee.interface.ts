export interface Employee {
  id?: string;
  employeeId?: number;
  employeeName?: string;
  department?: string;
  dateOfJoining?: Date;
  photoFileName?: string;
  createdDate?: Date;
}

export interface EmployeeCreate {
  employeeName: string;
  department: string;
  dateOfJoining: Date;
  photoFileName: string;
}

export interface EmployeeUpdate {
  employeeName: string;
  department: string;
  dateOfJoining: Date;
  photoFileName: string;
}
