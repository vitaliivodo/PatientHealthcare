import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClinicPatientModel } from 'src/app/models/ClinicPatientModel';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  currentPatientId: string;
  patient: ClinicPatientModel;

  constructor(private patientService: PatientService,
              private router: Router
  ) 
  {if (this.router.getCurrentNavigation()?.extras.state != undefined)
    this.currentPatientId = (this.router.getCurrentNavigation()?.extras.state as any).patientId;}

  ngOnInit(): void {
    this.getPatientById();
  }

  getPatientById(){
    this.patientService.getPatientById(this.currentPatientId).subscribe((clinicPatient: ClinicPatientModel) => {
      this.patient = new ClinicPatientModel
      (
        this.currentPatientId, 
        clinicPatient.firstName, 
        clinicPatient.secondName, 
        clinicPatient.genderType,
        clinicPatient.birthDate,
        clinicPatient.city,
        clinicPatient.country,
        clinicPatient.street,
        clinicPatient.telephone,
        clinicPatient.deceased
        );
      console.log(this.patient);
    })
  }
}
