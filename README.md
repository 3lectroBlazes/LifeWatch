# LifeWatch

A smart healthcare monitoring and hospital management system. Patients wear a smart bracelet that tracks their vital signs. A role-based dashboard connects patients, their families, doctors, nurses and receptionists in one place.

Built as a team project for the Infocomm Solutions Project module (IT3681) in the Diploma in Infocomm & Security at Nanyang Polytechnic.

## The problem
Hospitals are understaffed, and nurses spend a lot of time on routine vital checks. LifeWatch automates that monitoring and flags abnormal readings straight away, even ones that happen in private spaces. It also gives patients and their families direct visibility into the patient's care.

## Highlights
- **Live vitals monitoring and alerts.** The app tracks heart rate, respiratory rate and blood pressure against thresholds you can configure. When a reading goes out of range, it raises an emergency log that staff must acknowledge.
- **Role-based access control.** Five roles (Doctor, Nurse, Reception, Patient and delegated User) each get their own dashboard. Custom claims and authorization policies keep sensitive data restricted. For example, patients never see conversations between nurses and doctors.
- **Caregiver delegation.** A patient generates a relation code that links a family member's account to theirs. A caregiver linked to several patients can switch between them.
- **Appointment orchestration.** Patients request appointments, the app checks for scheduling conflicts, and reception confirms them. Either side can request a change.
- **Clinical workflows.** Doctors manage medications, register new drugs and complete death certificates. Reception admits, registers and transfers patients, and sees ward and bed capacity across hospitals.
- **Audit logging and PDF export.** Admin actions are logged, and patient records can be exported to PDF.

## Tech stack
- ASP.NET Core 8 Razor Pages
- ASP.NET Core Identity (authentication and role-based authorization)
- Entity Framework Core (Azure SQL in production, in-memory database for local runs)
- Bootstrap
- iText for PDF generation

## Getting started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run
```bash
git clone https://github.com/3lectroBlazes/INFP-Proj.git
cd INFP-Proj/INFP-Proj
dotnet run
```
Then open http://localhost:5287. You can also open `INFP-Proj.sln` in Visual Studio and press F5.

The app runs on an in-memory database that is seeded with demo data on startup. All interactions resets when the app restarts.

## Demo accounts
All seeded accounts use the password **`Password@123`**.

| Role                       | Email                       |
|----------------------------|-----------------------------|
| Doctor                     | `xavier.wee@hospital.com`   |
| Nurse                      | `kailuo@hospital.com`       |
| Reception                  | `evan@hospital.com`         |
| Patient                    | `kasane.teto@hospital.com`  |
| User (delegate of Kasane Teto) | `hatsune.miku@hospital.com` |

More accounts are listed in the full documentation below

## Team
| Member | Role |
|---|---|
| Xavier Wee | Group Leader: feature design, Doctor dashboard, bracelet data integration |
| Woo Kai Luo | System Integrator: CI/CD, Azure deployment, base app, Nurse and Admin dashboards |
| Sadev Dulneth Weerasinghe | User dashboard |
| Lim Si Wei Evan | Reception dashboard |

Full Documentation: https://docs.google.com/document/d/1geHcBNCjiBTg1xl5I0L-AAOwUlozhEFZ/edit?usp=sharing&ouid=115079590539218700046&rtpof=true&sd=true