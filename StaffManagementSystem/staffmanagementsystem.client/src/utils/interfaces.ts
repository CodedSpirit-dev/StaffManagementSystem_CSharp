interface EmployeeData {
  socialSecurityNumber: number;
  rfc: string;
  curp: string;
  firstName: string;
  middleName: string;
  lastName: string;
  secondLastname: string;
  birthDate: BirthDate;
  gender: string;
  bloodType: string;
  maritalStatus: string;
  children: number;
  studyGrade: string;
  contactInfo: ContactInfo;
  address: Address;
  employmentDetails: EmploymentDetails;
  emergencyContact: EmergencyContact;
}

interface EmergencyContact {
  emergencyContactName: string;
  emergencyPhone: string;
  emergencyRelationship: string;
}

interface EmploymentDetails {
  hiringDate: string;
  resignationDate: string;
  department: string;
  position: string;
  bossName: string;
  shift: string;
  hiredBy: string;
  isActive: boolean;
  insuranceActive: boolean;
  isFileComplete: boolean;
  notes: string;
}

interface Address {
  addressLine: string;
  postalCode: string;
  neighborhood: string;
  city: string;
  state: string;
}

interface ContactInfo {
  email: string;
  phoneNumber: string;
}

interface BirthDate {
  year: number;
  month: number;
  day: number;
  dayOfWeek: number;
}

export type { EmployeeData };