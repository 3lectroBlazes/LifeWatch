using INFP_Proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace INFP_Proj.Data
{
    public class AppDbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<AppRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            if (userManager.Users.Any()) return;

            // Runs all code ONCE to seed the database with initial data. Extra seeds above ^^

            // Seed Roles
            string[] roles = { "Nurse", "Doctor", "Reception", "User" };

            async Task<AppRole> CreateRole(string role)
            {
                AppRole roles = new AppRole
                {
                    Name = role,
                    IsAdmin = true ? role != "User" : false

                };
                await roleManager.CreateAsync(roles);
                return roles;
            }

            foreach (string role in roles)
            {
                await CreateRole(role);

            }

            // Seed Users
            async Task<AppUser> CreateUser(string firstName, string lastName, string email, string phoneNumber, string role)
            {
                AppUser user = new AppUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = email,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "Password@123");
                await context.SaveChangesAsync();
                await userManager.AddToRoleAsync(user, role);
                return user;
            }

            AppUser kailuo = await CreateUser("Kai", "Luo", "kailuo@hospital.com", "12345678", "Nurse");
            AppUser xavier = await CreateUser("Xavier", "Wee", "xavier.wee@hospital.com", "12345678", "Doctor");
            AppUser evan = await CreateUser("Evan", "IDK", "evan@hospital.com", "12345678", "Reception");
            AppUser sadev = await CreateUser("Sadev", "Mawadavilage", "sadev.mawadavilage@hospital.com", "12345678", "User");
            AppUser miku = await CreateUser("Hatsune", "Miku", "hatsune.miku@hospital.com", "12345678", "User");
            AppUser teto = await CreateUser("Kasane", "Teto", "kasane.teto@hospital.com", "12345678", "User");
            AppUser nurse = await CreateUser("Hoshimachi", "Suisei", "nurse@nur.com", "12345678", "Nurse");
            AppUser doctor = await CreateUser("Sherbelle", "Tee", "doctor@hospital.com", "12345678", "Doctor");
            AppUser reception = await CreateUser("Edgar", "Markov", "reception@hospital.com", "12345678", "Reception");
            AppUser user1 = await CreateUser("John", "Doe", "john.doe@hospital.com", "12345678", "User");
            AppUser user2 = await CreateUser("Jane", "Doe", "jane.doe@hospital.com", "12345678", "User");
            AppUser user3 = await CreateUser("Dylan", "Tan", "dylan@hospital.com", "12345678", "User");

            // Hospitals
            Hospitals hospital = new Hospitals
            {
                HospitalName = "City General Hospital",
                HospitalAddress = "123 Main Street"
            };
            Hospitals magic = new Hospitals
            {
                HospitalName = "Paya lebar Games Haven",
                HospitalAddress = "456 PLGH street"
            };
            context.Hospitals.AddRange(hospital,magic);

            // Wards
            Wards AE = new Wards
            {
                WardName = "A&E",
                MaxCapacity = 20
            };
            Wards general = new Wards
            {
                WardName = "General",
                MaxCapacity = 50
            };
            Wards disease = new Wards
            {
                WardName = "Diseases",
                MaxCapacity = 30
            };
            Wards special = new Wards
            {
                WardName = "Specialized",
                MaxCapacity = 10
            };
            context.Wards.AddRange(AE, general, disease, special);

            // Allergies
            Allergies Penicillin = new Allergies { Allergy = "Penicillin" };
            Allergies Peanuts = new Allergies { Allergy = "Peanuts" };
            Allergies Grass = new Allergies { Allergy = "Grass" };
            context.Allergies.AddRange(Penicillin, Peanuts, Grass);

            // Diagnoses
            Diagnoses diagnosis = new Diagnoses { DiagnosisName = "Hypertension" };
            Diagnoses autism = new Diagnoses { DiagnosisName = "Autism" };
            context.Diagnoses.AddRange(diagnosis, autism);

            // Medications
            Medications paracetamol = new Medications
            {
                MedicationName = "Paracetamol",
                ConsumptionTime = new TimeOnly(8, 0)
            };
            Medications brainrot = new Medications
            {
                MedicationName = "Brainrot",
                ConsumptionTime = new TimeOnly(20, 0)
            };
            context.Medications.AddRange(paracetamol, brainrot);

            // Save so IDs are generated before we reference them
            await context.SaveChangesAsync();

            // Bracelet
            Bracelet sadevBracelet = new Bracelet
            {
                Battery = 85.5f,
                SystolicBloodPressure = 120.0f,
                DiastolicBloodPressure = 80.0f, 
                HeartRate = 72.0f,
                RespiratoryRate = 18.0f
            };

            Bracelet mikuBracelet = new Bracelet
            {
                Battery = 90.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f, 
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            Bracelet emptyBracelet1 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f, 
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            Bracelet emptyBracelet2 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f,
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            Bracelet emptyBracelet3 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f,
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };
            Bracelet emptyBracelet4 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f, 
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            Bracelet emptyBracelet5 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f,
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            Bracelet emptyBracelet6 = new Bracelet
            {
                Battery = 100.0f,
                SystolicBloodPressure = 110.0f,
                DiastolicBloodPressure = 70.0f,
                HeartRate = 68.0f,
                RespiratoryRate = 16.0f
            };

            context.Bracelets.AddRange(
                sadevBracelet,
                mikuBracelet,
                emptyBracelet1,
                emptyBracelet2,
                emptyBracelet3,
                emptyBracelet4,
                emptyBracelet5,
                emptyBracelet6
            );
            await context.SaveChangesAsync();

            // Patients
            Patients sadevPatient = new Patients
            {
                UserID = sadev.Id,
                Status = "Admitted"
            };
            Patients tetoPatient = new Patients
            {
                UserID = teto.Id,
                Status = "Admitted"
            };
            Patients johnPatient = new Patients
            {
                UserID = user1.Id,
                Status = "Admitted"
            };
            Patients janePatient = new Patients
            {
                UserID = user2.Id,
                Status = "Admitted"
            };
            Patients dylPatient = new Patients
            {
                UserID = user3.Id,
                Status = "Admitted"
            };
            context.Patients.AddRange(sadevPatient, tetoPatient, johnPatient, janePatient, dylPatient);
            await context.SaveChangesAsync();


            // AllergyList
            context.AllergyLists.AddRange(
                new AllergyList { PatientID = sadevPatient.PatientID, AllergyID = Penicillin.AllergyID },
                new AllergyList { PatientID = sadevPatient.PatientID, AllergyID = Peanuts.AllergyID },
                new AllergyList { PatientID = tetoPatient.PatientID, AllergyID = Grass.AllergyID },
                new AllergyList { PatientID = johnPatient.PatientID, AllergyID = Peanuts.AllergyID },
                new AllergyList { PatientID = janePatient.PatientID, AllergyID = Penicillin.AllergyID },
                new AllergyList { PatientID = dylPatient.PatientID, AllergyID = Grass.AllergyID }
            );

            // MedicationList
            MedicationList sadevList = new MedicationList
            {
                PatientID = sadevPatient.PatientID,
                MedicationID = paracetamol.MedicationID,
                Dosage = "500mg"
            };
            MedicationList tetoList = new MedicationList
            {
                PatientID = tetoPatient.PatientID,
                MedicationID = brainrot.MedicationID,
                Dosage = "250mg"
            };
            MedicationList johnList = new MedicationList
            {
                PatientID = johnPatient.PatientID,
                MedicationID = brainrot.MedicationID,
                Dosage = "300mg"
            };
            MedicationList janeList = new MedicationList
            {
                PatientID = janePatient.PatientID,
                MedicationID = paracetamol.MedicationID,
                Dosage = "450mg"
            };
            MedicationList DylList = new MedicationList
            {
                PatientID = dylPatient.PatientID,
                MedicationID = brainrot.MedicationID,
                Dosage = "500mg"
            };
            context.MedicationLists.AddRange(sadevList, tetoList, johnList, janeList, DylList);
            await context.SaveChangesAsync();

            // Beds
            Beds sadevBed = new Beds
            {
                PatientID = sadevPatient.PatientID,
                WardID = general.WardID,
                Sector = "A",
                Floor = "1",
                Room = "101",
                Weight = 70.0f,
                Location = "Near Window"
            };
            Beds tetoBed = new Beds
            {
                PatientID = tetoPatient.PatientID,
                WardID = general.WardID,
                Sector = "A",
                Floor = "1",
                Room = "102",
                Weight = 60.0f,
                Location = "Near Door"
            };
            Beds emptyBed1 = new Beds
            {
                WardID = general.WardID,
                Sector = "A",
                Floor = "1",
                Room = "103",
                Weight = 60.0f,
                Location = "Middle"
            };
            Beds emptyBed2 = new Beds
            {
                WardID = disease.WardID,
                Sector = "A",
                Floor = "1",
                Room = "104",
                Weight = 60.0f,
                Location = "Near Window"
            };
            Beds emptyBed3 = new Beds
            {
                WardID = special.WardID,
                Sector = "A",
                Floor = "1",
                Room = "105",
                Weight = 60.0f,
                Location = "Near Door"
            };
            Beds johnBed = new Beds
            {
                WardID = disease.WardID,
                Sector = "A",
                Floor = "1",
                Room = "106",
                Weight = 60.0f,
                Location = "Near Window"
            };
            Beds janeBed = new Beds
            {
                WardID = AE.WardID,
                Sector = "A",
                Floor = "1",
                Room = "107",
                Weight = 60.0f,
                Location = "Near Door"
            };
            Beds dylBed = new Beds
            {
                WardID = special.WardID,
                Sector = "A",
                Floor = "1",
                Room = "108",
                Weight = 60.0f,
                Location = "Near Door"
            };
            context.Beds.AddRange(
                sadevBed,
                tetoBed,
                emptyBed1,
                emptyBed2,
                emptyBed3,
                johnBed,
                janeBed,
                dylBed
            );
            await context.SaveChangesAsync();

            // Records
            Records sadevRecord = new Records
            {
                PatientID = sadevPatient.PatientID,
                BedID = sadevBed.BedID,
                WardID = general.WardID,
                HospitalID = hospital.HospitalID,
                DiagnosisID = diagnosis.DiagnosisID,
                Description = "Patient mentions Severe Chest Pain",
                AdmissionDateTime = DateTime.UtcNow,
                DischargeDateTime = null
            };
            Records tetoRecord = new Records
            {
                PatientID = tetoPatient.PatientID,
                BedID = tetoBed.BedID,
                WardID = general.WardID,
                HospitalID = hospital.HospitalID,
                DiagnosisID = autism.DiagnosisID,
                Description = "Patient is constantly singing",
                AdmissionDateTime = DateTime.UtcNow,
                DischargeDateTime = null
            };
            Records johnRecord = new Records
            {
                PatientID = johnPatient.PatientID,
                BedID = johnBed.BedID,
                WardID = disease.WardID,
                HospitalID = hospital.HospitalID,
                DiagnosisID = autism.DiagnosisID,
                Description = "Patient is constantly singing",
                AdmissionDateTime = DateTime.UtcNow,
                DischargeDateTime = null
            };
            Records janeRecord = new Records
            {
                PatientID = janePatient.PatientID,
                BedID = janeBed.BedID,
                WardID = AE.WardID,
                HospitalID = magic.HospitalID,
                DiagnosisID = autism.DiagnosisID,
                Description = "Patient is constantly singing",
                AdmissionDateTime = DateTime.UtcNow,
                DischargeDateTime = null
            };
            Records dylRecord = new Records
            {
                PatientID = dylPatient.PatientID,
                BedID = dylBed.BedID,
                WardID = special.WardID,
                HospitalID = magic.HospitalID,
                DiagnosisID = autism.DiagnosisID,
                Description = "Patient is constantly chanting magic the gathering",
                AdmissionDateTime = DateTime.UtcNow,
                DischargeDateTime = null
            };

            context.Records.AddRange(sadevRecord, tetoRecord, johnRecord, janeRecord, dylRecord);
            await context.SaveChangesAsync();

            // Link each MedicationList entry back to its Record now that RecordIDs exist
            sadevList.RecordID = sadevRecord.RecordID;
            tetoList.RecordID = tetoRecord.RecordID;
            johnList.RecordID = johnRecord.RecordID;
            janeList.RecordID = janeRecord.RecordID;
            DylList.RecordID = dylRecord.RecordID;
            await context.SaveChangesAsync();
            // Vitals
            DateTime vitalsBaseTime = DateTime.Now.AddDays(-7);
            var goodReadings = new (float systolic, float diastolic, float hr, float rr, float temp)[]
            {
                (119, 79, 70, 16, 36.4f), (120, 80, 71, 17, 36.5f), (121, 81, 70, 16, 36.4f),
                (119, 79, 72, 17, 36.5f), (120, 80, 71, 16, 36.5f), (121, 81, 70, 17, 36.4f),
                (120, 80, 72, 16, 36.5f), (119, 79, 71, 17, 36.6f), (121, 81, 70, 16, 36.5f),
                (120, 80, 72, 17, 36.4f), (119, 79, 71, 16, 36.5f), (121, 81, 70, 17, 36.5f),
                (120, 80, 72, 16, 36.4f), (119, 79, 71, 17, 36.5f),
            };
            var badReadings = new (float systolic, float diastolic, float hr, float rr, float temp)[]
            {
                (118, 78, 72, 17, 36.6f), (116, 76, 74, 18, 36.7f), (114, 75, 76, 18, 36.8f),
                (112, 74, 78, 19, 36.9f), (110, 73, 80, 19, 37.1f), (108, 72, 82, 20, 37.3f),
                (106, 70, 84, 20, 37.5f), (104, 69, 86, 21, 37.6f), (102, 68, 88, 22, 37.8f),
                (100, 67, 90, 22, 37.9f), ( 98, 66, 92, 23, 38.1f), ( 96, 64, 94, 24, 38.3f),
                ( 94, 63, 96, 24, 38.5f), ( 92, 62, 98, 25, 38.7f),
            };
            for (var i = 0; i < goodReadings.Length; i++)
            {
                var sadevReading = goodReadings[i];
                var tetoReading = badReadings[i];
                foreach (var (patient, reading) in new[]
                    {
                        (sadevPatient, sadevReading),
                        (tetoPatient, tetoReading),
                        (johnPatient, goodReadings[i]),
                        (janePatient, goodReadings[i]),
                        (dylPatient, badReadings[i])
                    })
                {
                    context.Vitals.Add(new Vitals
                    {
                        PatientID = patient.PatientID,
                        SystolicBloodPressure = reading.systolic,
                        DiastolicBloodPressure = reading.diastolic,
                        HeartRate = reading.hr,
                        RespiratoryRate = reading.rr,
                        RecordedAt = vitalsBaseTime.AddHours(i * 12)
                    });
                }
            }

            context.Thresholds.Add(new Thresholds
            {
                SBPUpperThreshold = 140.0f,
                SBPLowerThreshold = 90.0f,
                DBPUpperThreshold = 90.0f,
                DBPLowerThreshold = 60.0f,
                HeartRateUpperPercentageThreshold = 20.0f,
                HeartRateLowerPercentageThreshold = 20.0f,
                RespiratoryRateUpperPercentageThreshold = 25.0f,
                RespiratoryRateLowerThreshold = 20.0f
            });

            // Relationships
            context.Relationships.AddRange(
                new Relationships { PatientID = tetoPatient.PatientID, UserID = miku.Id },
                new Relationships { PatientID = sadevPatient.PatientID, UserID = miku.Id }
            );

            context.BraceletRelations.AddRange(
                new BraceletRelation { BraceletID = sadevBracelet.BraceletID, PatientID = sadevPatient.PatientID },
                new BraceletRelation { BraceletID = mikuBracelet.BraceletID, PatientID = tetoPatient.PatientID }
            );

            await context.SaveChangesAsync();
        }
    }
}
