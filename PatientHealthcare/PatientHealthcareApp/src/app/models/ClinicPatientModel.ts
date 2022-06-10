import { GenderType } from "../enums/GenderType";

export class ClinicPatientModel {
    constructor(
        public patientId: string,
        public firstName: string,
        public secondName: string,
        public genderType: Number,
        public birthDate: Date,
        public city: string,
        public country: string,
        public street: string,
        public telephone: string,
        public deceased: Date
    ){}
}