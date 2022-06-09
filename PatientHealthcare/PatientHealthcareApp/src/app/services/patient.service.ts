import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PageRequestModel } from '../models/PageRequestModel';
import { Observable } from 'rxjs';
import { ClinicPatientModel } from '../models/ClinicPatientModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  backUrl = environment.backendUrl + "api/patient/"

  constructor(private http: HttpClient) { }

  getPagedPatients(pageRequestModel: PageRequestModel):  Observable<ClinicPatientModel[]> {
    return this.http.post<ClinicPatientModel[]>(this.backUrl + 'GetPaginatedPatients/', pageRequestModel);
  }

  getPatients():  Observable<ClinicPatientModel[]> {
    return this.http.get<ClinicPatientModel[]>(this.backUrl + 'GetAllPatients/');
  }

  getPatientsAmount():  Observable<number> {
    return this.http.get<number>(this.backUrl + 'GetAllPatientsAmount/');
  }
}
