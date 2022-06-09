import { NumberInput } from '@angular/cdk/coercion';
import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ClinicPatientModel } from 'src/app/models/ClinicPatientModel';
import { PageRequestModel } from 'src/app/models/PageRequestModel';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  pagedPatients: ClinicPatientModel[] = [];
  pageIndex: NumberInput = 0;
  pageSize: NumberInput = 3;
  patientsAmount: number = 0;

  constructor(private patientService: PatientService

  ) { }

  ngOnInit(): void {
    this.patientService.getPatientsAmount().subscribe((amount: number) => {
      this.patientsAmount = amount;
    })
    this.getPagedPatientsMethod();
  }

  onChangePage(event: PageEvent){
    console.log(event);
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getPagedPatientsMethod();
  }

  getPagedPatientsMethod(){
    this.patientService.getPagedPatients(new PageRequestModel(this.pageIndex, this.pageSize)).subscribe((clinicPatients: ClinicPatientModel[]) => {
      this.pagedPatients = clinicPatients;
      this.pagedPatients = [...this.pagedPatients];
    });
  }
}
