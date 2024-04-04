using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncuestaComunitaria.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Microsoft.Datasync.Client;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Alerts;
using System.Threading;

namespace EncuestaComunitaria.Services
{
    public class PatientService : IPatientService
    {
        public SQLiteAsyncConnection _connection;

        public const SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        public PatientService()
        {
            SetUpDb();          
        }           

        private async void SetUpDb() 
        {  
            if(_connection == null)
            {
                //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Patients.db3");
                var path = Microsoft.Maui.Storage.FileSystem.AppDataDirectory;
                string dbPath = Path.Combine(path, "Patients.db3");
                _connection = new SQLiteAsyncConnection(dbPath, Flags);
                await _connection.CreateTableAsync<PatientModel>();
                await _connection.CreateTableAsync<DolorSieteDias>();
                await _connection.CreateTableAsync<DolorHistoirico>();
                await _connection.CreateTableAsync<CargaBiomecanica>();
                await _connection.CreateTableAsync<Enfermedades>();
                await _connection.CreateTableAsync<MedicamentoTratamiento>();
                await _connection.CreateTableAsync<Funcionales>();
                //por hacer
                await _connection.CreateTableAsync<Medicamento>();
                await _connection.CreateTableAsync<MedicamentoOtro>();
                await _connection.CreateTableAsync<FechaVisitaExterna>();
                await _connection.CreateTableAsync<FechaVisitaUrgencia>();
                await _connection.CreateTableAsync<FechaVisitaHosp>();
            }
        }

        public async Task SaveFile(CancellationToken cancellationToken)
        {
            if (_connection == null)
            {
                return;
            }

            await Task.Factory.StartNew(() =>
            {
                _connection.GetConnection().Close();
                _connection.GetConnection().Dispose();
                _connection = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            });
            
            string appDataDirectory = Microsoft.Maui.Storage.FileSystem.AppDataDirectory;
            string dbPath = Path.Combine(appDataDirectory, "Patients.db3");
            using var stream = File.OpenRead(dbPath);
            string newFileName = "Patients-copy.db3";
            var fileSaverResult = await FileSaver.Default.SaveAsync(newFileName, stream, cancellationToken);
            if (fileSaverResult.IsSuccessful)
            {
                await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show(cancellationToken);
            }
            else
            {
                await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show(cancellationToken);
            }
            _connection = new SQLiteAsyncConnection(dbPath, Flags);
        }

        public async Task ReplaceDatabaseAsync()
        {
            // Allow the user to pick the new .db3 file
            var pickResult = await FilePicker.Default.PickAsync();

            if (pickResult != null)
            {
                // Close the database connections
                if (_connection == null)
                {
                    return;
                }

                await Task.Factory.StartNew(() =>
                {
                    _connection.GetConnection().Close();
                    _connection.GetConnection().Dispose();
                    _connection = null;

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });

                // Get the path to the current database file
                string currentDbPath = Path.Combine(FileSystem.AppDataDirectory, "Patients.db3");

                // Copy the new database file to the AppDataDirectory, replacing the old one
                using (var newDbStream = await pickResult.OpenReadAsync())
                {
                    // Ensure the target file is not in use by deleting it first if it exists
                    if (File.Exists(currentDbPath))
                    {
                        File.Delete(currentDbPath);
                    }

                    // Create a new file and write the contents of the new database file to it
                    using (var fileStream = File.Create(currentDbPath))
                    {
                        await newDbStream.CopyToAsync(fileStream);
                    }
                }
                string appDataDirectory = Microsoft.Maui.Storage.FileSystem.AppDataDirectory;
                string dbPath = Path.Combine(appDataDirectory, "Patients.db3");
                _connection = new SQLiteAsyncConnection(dbPath, Flags);
            }
        }


        public async Task<PatientModel> AddPatientAsync(PatientModel patient)
        {
            PatientModel newpatient;
            await _connection.InsertAsync(patient);
            newpatient = patient;
            return newpatient;
        }

        public async Task<int> DeletePatientAsync(PatientModel patient)
        {
            await _connection.Table<DolorHistoirico>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<DolorSieteDias>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<CargaBiomecanica>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<Enfermedades>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<MedicamentoTratamiento>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            //por hacer
            await _connection.Table<FechaVisitaExterna>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<FechaVisitaUrgencia>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            await _connection.Table<FechaVisitaHosp>().Where(i => i.PatientId == patient.Id).DeleteAsync();
            return await _connection.DeleteAsync(patient);
        }
        public async Task<int> UpdatePatientAsync(PatientModel patient)
        {
            return await _connection.UpdateAsync(patient);
        }

        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            //return await _connection.FindAsync<PatientModel>(id);
            return await _connection.Table<PatientModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<PatientModel>> GetPatientsAsync()
        {
            return await _connection.Table<PatientModel>().ToListAsync();
        }

        public async Task<int> AddDolorSieteAsync(DolorSieteDias dolorSieteDias)
        {
            return await _connection.InsertAsync(dolorSieteDias);
        }
        public async Task<int> UpdateDolorSieteAsync(DolorSieteDias DolorSieteDias)
        {
            return await _connection.UpdateAsync(DolorSieteDias);
        }
        public async Task<List<DolorSieteDias>> GetDolorSieteAsync(int id)
        {
            return await _connection.Table<DolorSieteDias>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteDolorSieteAsync(int id, int id_dolor)
        {
            return await _connection.Table<DolorSieteDias>().Where(i => i.PatientId == id && i.Id == id_dolor).DeleteAsync();
        }

        public async Task<int> AddDolorHistoricoAsync(DolorHistoirico dolorHistoirico)
        {
            return await _connection.InsertAsync(dolorHistoirico);
        }
        public async Task<int> UpdateDolorHistoricoAsync(DolorHistoirico dolorHistoirico)
        {
            return await _connection.UpdateAsync(dolorHistoirico);
        }
        public async Task<List<DolorHistoirico>> GetDolorHistoricoAsync(int id)
        {
            return await _connection.Table<DolorHistoirico>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteDolorHistoricoAsync(int id, int id_dolor)
        {
            return await _connection.Table<DolorHistoirico>().Where(i => i.PatientId == id && i.Id == id_dolor).DeleteAsync();
        }

        public async Task<int> AddTrabajoAsync(CargaBiomecanica cargaBiomecanica)
        {
            return await _connection.InsertAsync(cargaBiomecanica);
        }
        public async Task<int> UpdateTrabajoAsync(CargaBiomecanica cargaBiomecanica)
        {
            return await _connection.UpdateAsync(cargaBiomecanica);
        }
        public async Task<List<CargaBiomecanica>> GetTrabajoAsync(int id)
        {
            return await _connection.Table<CargaBiomecanica>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteTrabajoAsync(int id, int id_trabajo)
        {
            return await _connection.Table<CargaBiomecanica>().Where(i => i.PatientId == id && i.Id == id_trabajo).DeleteAsync();
        }



        public async Task<int> AddMedicamentoTratamientoAsync(MedicamentoTratamiento medicamentoTratamiento)
        {
            return await _connection.InsertAsync(medicamentoTratamiento);
        }
        public async Task<int> UpdateMedicamentoTratamientoAsync(MedicamentoTratamiento medicamentoTratamiento)
        {
            return await _connection.UpdateAsync(medicamentoTratamiento);
        }
        public async Task<List<MedicamentoTratamiento>> GetMedicamentoTratamientoAsync(int id)
        {
            return await _connection.Table<MedicamentoTratamiento>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteMedicamentoTratamientoAsync(int id, int id_trabajo)
        {
            return await _connection.Table<MedicamentoTratamiento>().Where(i => i.PatientId == id && i.Id == id_trabajo).DeleteAsync();
        }



        public async Task<int> AddEnfermedadesAsync(Enfermedades enfermedades)
        {
            await _connection.InsertAsync(enfermedades);
            return enfermedades.Id;
        }
        public async Task<int> UpdateEnfermedadesAsync(Enfermedades enfermedades)
        {
            return await _connection.UpdateAsync(enfermedades);
        }
        public async Task<List<Enfermedades>> GetEnfermedadesAsync(int id)
        {
            return await _connection.Table<Enfermedades>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteEnfermedadesAsync(int id, int id_enfermedad)
        {
            await _connection.Table<Medicamento>().Where(i => i.EmfermedadId == id_enfermedad).DeleteAsync();
            await _connection.Table<MedicamentoOtro>().Where(i => i.EmfermedadId == id_enfermedad).DeleteAsync();
            return await _connection.Table<Enfermedades>().Where(i => i.PatientId == id && i.Id == id_enfermedad).DeleteAsync();
        }
        public async Task<Enfermedades> GetEnfermedadesByIdAsync(int id)
        {
            return await _connection.Table<Enfermedades>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> NombreEnfermedadExists(int id, string nombre)
        {
            var enfermedad = await _connection.Table<Enfermedades>().Where(i => i.PatientId == id && i.Nombre == nombre).FirstOrDefaultAsync();
            if (enfermedad != null)
                return true;
            else
                return false;
        }
        public async Task<Enfermedades> GetEnfermedadesByNameAsync(int id, string nombre)
        {
            return await _connection.Table<Enfermedades>().Where(i => i.PatientId == id && i.Nombre == nombre).FirstOrDefaultAsync();
        }



        public async Task<int> AddMedicamentosAsync(Medicamento medicamento)
        {
            return await _connection.InsertAsync(medicamento);
        }
        public async Task<int> UpdateMedicamentosAsync(Medicamento medicamento)
        {
            return await _connection.UpdateAsync(medicamento);
        }
        public async Task<List<Medicamento>> GetMedicamentosAsync(int id)
        {
            return await _connection.Table<Medicamento>().Where(i => i.EmfermedadId == id).ToListAsync();
        }
        public async Task<int> DeleteMedicamentosAsync(int id, int id_medicamento)
        {
            return await _connection.Table<Medicamento>().Where(i => i.EmfermedadId == id && i.Id == id_medicamento).DeleteAsync();
        }

        public async Task<int> AddMedicamentosOtrosAsync(MedicamentoOtro medicamentoOtro)
        {
            return await _connection.InsertAsync(medicamentoOtro);
        }
        public async Task<int> UpdateMedicamentosOtrosAsync(MedicamentoOtro medicamentoOtro)
        {
            return await _connection.UpdateAsync(medicamentoOtro);
        }
        public async Task<List<MedicamentoOtro>> GetMedicamentosOtrosAsync(int id)
        {
            return await _connection.Table<MedicamentoOtro>().Where(i => i.EmfermedadId == id).ToListAsync();
        }
        public async Task<int> DeleteMedicamentosOtrosAsync(int id, int id_medicamento)
        {
            return await _connection.Table<MedicamentoOtro>().Where(i => i.EmfermedadId == id && i.Id == id_medicamento).DeleteAsync();
        }

        public async Task<int> AddFuncionalesAsync(Funcionales funcionales)
        {
            await _connection.InsertAsync(funcionales);
            return funcionales.Id;
        }
        public async Task<int> UpdateFuncionalesAsync(Funcionales funcionales)
        {
            return await _connection.UpdateAsync(funcionales);
        }
        public async Task<List<Funcionales>> GetFuncionalesAsync(int id)
        {
            return await _connection.Table<Funcionales>().Where(i => i.PatientId == id).ToListAsync();
        }
        public async Task<int> DeleteFuncionalesAsync(int id, int id_funcionales)
        {
            return await _connection.Table<Funcionales>().Where(i => i.PatientId == id && i.Id == id_funcionales).DeleteAsync();
        }
        public async Task<Funcionales> GetFuncionalesByIdAsync(int id)
        {
            return await _connection.Table<Funcionales>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

    }
}
