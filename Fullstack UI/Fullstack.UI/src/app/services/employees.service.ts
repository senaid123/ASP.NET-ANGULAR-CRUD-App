import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>('https://localhost:7152/api/employees');
  }

  addEmployee(addEmployeeRequest: Employee) : Observable<Employee>{
    addEmployeeRequest.id = "00000000-0000-0000-0000-000000000000";
    return this.http.post<Employee>('https://localhost:7152/api/employees', addEmployeeRequest);
  }

  getEmployee(employeeId : string): Observable<Employee>{
    return this.http.get<Employee>('https://localhost:7152/api/employees/' + employeeId);
  }

  updateEmployee(id : String, employee : Employee) : Observable<Employee>{
    return this.http.put<Employee>('https://localhost:7152/api/employees/' + id, employee);
  }
  deleteEmployee(id: String) : Observable<Employee>{
    return this.http.delete<Employee>('https://localhost:7152/api/employees/' + id);
  }
}
