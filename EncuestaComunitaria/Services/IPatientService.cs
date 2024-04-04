using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncuestaComunitaria.Models;
using Microsoft.Datasync.Client;

namespace EncuestaComunitaria.Services
{
    public interface IPatientService
    {
        Task<List<PatientModel>> GetPatientsAsync();
        Task<PatientModel> AddPatientAsync(PatientModel patient);
        Task<int> UpdatePatientAsync(PatientModel patient);
        Task<int> DeletePatientAsync(PatientModel patient);
        Task<PatientModel> GetPatientByIdAsync(int id);

        Task<int> AddEnfermedadesAsync(Enfermedades enfermedades);
        Task<int> UpdateEnfermedadesAsync(Enfermedades enfermedades);
        Task<List<Enfermedades>> GetEnfermedadesAsync(int id);
        Task<int> DeleteEnfermedadesAsync(int id, int id_enfermedad);
        Task<Enfermedades> GetEnfermedadesByIdAsync(int id);
        Task<bool> NombreEnfermedadExists(int id, string nombre_enfermedad);
        Task<Enfermedades> GetEnfermedadesByNameAsync(int id, string nombre_enfermedad);

        Task<int> AddFuncionalesAsync(Funcionales funcionales);
        Task<int> UpdateFuncionalesAsync(Funcionales funcionales);
        Task<List<Funcionales>> GetFuncionalesAsync(int id);
        Task<int> DeleteFuncionalesAsync(int id, int id_funcionales);
        Task<Funcionales> GetFuncionalesByIdAsync(int id);


        Task<int> AddDolorSieteAsync(DolorSieteDias dolorSieteDias);
        Task<int> UpdateDolorSieteAsync(DolorSieteDias DolorSieteDias);
        Task<List<DolorSieteDias>> GetDolorSieteAsync(int id);
        Task<int> DeleteDolorSieteAsync(int id, int id_dolor);

        Task<int> AddDolorHistoricoAsync(DolorHistoirico dolorHistoirico);
        Task<int> UpdateDolorHistoricoAsync(DolorHistoirico dolorHistoirico);
        Task<List<DolorHistoirico>> GetDolorHistoricoAsync(int id);
        Task<int> DeleteDolorHistoricoAsync(int id, int id_dolor);

        Task<int> AddTrabajoAsync(CargaBiomecanica cargaBiomecanica);
        Task<int> UpdateTrabajoAsync(CargaBiomecanica cargaBiomecanica);
        Task<List<CargaBiomecanica>> GetTrabajoAsync(int id);
        Task<int> DeleteTrabajoAsync(int id, int id_trabajo);

        Task<int> AddMedicamentoTratamientoAsync(MedicamentoTratamiento medicamentoTratamiento);
        Task<int> UpdateMedicamentoTratamientoAsync(MedicamentoTratamiento medicamentoTratamiento);
        Task<List<MedicamentoTratamiento>> GetMedicamentoTratamientoAsync(int id);
        Task<int> DeleteMedicamentoTratamientoAsync(int id, int id_trabajo);

        Task<int> AddMedicamentosAsync(Medicamento medicamento);
        Task<int> UpdateMedicamentosAsync(Medicamento medicamento);
        Task<List<Medicamento>> GetMedicamentosAsync(int id);
        Task<int> DeleteMedicamentosAsync(int id, int id_medicamento);

        Task<int> AddMedicamentosOtrosAsync(MedicamentoOtro medicamentoOtro);
        Task<int> UpdateMedicamentosOtrosAsync(MedicamentoOtro medicamentoOtro);
        Task<List<MedicamentoOtro>> GetMedicamentosOtrosAsync(int id);
        Task<int> DeleteMedicamentosOtrosAsync(int id, int id_medicamento);

        Task SaveFile(CancellationToken cancellationToken);
        Task ReplaceDatabaseAsync();
    }
}
