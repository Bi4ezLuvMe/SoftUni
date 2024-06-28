namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctorsByName = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patientsByName = new Dictionary<string, Patient>();
        public void AddDoctor(Doctor doctor)
        {
            if (doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }
            doctorsByName.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }
            patient.doctor = doctor;
            patientsByName.Add(patient.Name, patient);
            doctor.patients.Add(patient);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!doctorsByName.ContainsKey(oldDoctor.Name) || !doctorsByName.ContainsKey(newDoctor.Name) || !patientsByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }
            oldDoctor.patients.Remove(patient);
            newDoctor.patients.Add(patient);
            patient.doctor = newDoctor;
        }

        public bool Exist(Doctor doctor) => doctorsByName.ContainsKey(doctor.Name);
        public bool Exist(Patient patient) => patientsByName.ContainsKey(patient.Name);

        public IEnumerable<Doctor> GetDoctors() => doctorsByName.Values;

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry) => doctorsByName.Values.Where(x => x.Popularity == populariry);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc() => doctorsByName.Values.OrderByDescending(x => x.patients.Count).ThenBy(x => x.Name);

        public IEnumerable<Patient> GetPatients() => patientsByName.Values;

        public IEnumerable<Patient> GetPatientsByTown(string town) => patientsByName.Values.Where(x => x.Town == town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi) => patientsByName.Values.Where(x => x.Age >= lo && x.Age <= hi);

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge() => patientsByName.Values.OrderBy(x => x.doctor.Popularity).ThenByDescending(x => x.Height).ThenBy(x => x.Age);

        public Doctor RemoveDoctor(string name)
        {
            if (!doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }
             Doctor doctor = doctorsByName[name];
            doctorsByName.Remove(name);
            foreach (var patient in doctor.patients)
            {
                patientsByName.Remove(patient.Name);
            }
            return doctor;
        }
    }
}
