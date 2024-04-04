using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EncuestaComunitaria.Models
{
    public class Enfermedades
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Dijo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Doctor", 1),
                new KeyValuePair<string, int>("Otro. Especifique", 2),
            };
        public int DijoId { get; set; }
        public string DijoOtro { get; set; } = string.Empty;

        //public DateTime DesdeCuando { get; set; } = DateTime.Now;
        public int DesdeCuando { get; set; }  

        public List<KeyValuePair<string, int>> TomaMedicamento = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int TomaMedicamentoId { get; set; }

        public List<KeyValuePair<string, int>> RecetaMedicamento = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Un doctor", 1),
                new KeyValuePair<string, int>("Un conocido", 2),
                new KeyValuePair<string, int>("Usted mismo se lo receta", 3),
                new KeyValuePair<string, int>("Otro ¿Cuál?", 4),
            };
        public int RecetaMedicamentoId { get; set; }
        public string RecetaMedicamentoOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> ComnsigueMedicamento = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Centro de salud",1),
                new KeyValuePair<string, int>("IMSS", 2),
                new KeyValuePair<string, int>("Hospital de Valladolidse lo receta", 3),
                new KeyValuePair<string, int>("Lo compra" , 4),
                new KeyValuePair<string, int>("Se lo regalan" , 5),
                new KeyValuePair<string, int>("Otro, especifique" , 6),
            };
        public int ComnsigueMedicamentoId { get; set; }
        public string ComnsigueMedicamentoOtro { get; set; } = string.Empty;

        public int CantidadMedicamento { get; set; }
        [OneToMany]
        public List<Medicamento> MedicamentoCollection { get; set; } = new List<Medicamento>();

        public List<KeyValuePair<string, int>> AtiendeEnfermedad = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Centro de salud",1),
                new KeyValuePair<string, int>("Hospital de Valladolid",2),
                new KeyValuePair<string, int>("Mérida",3),
                new KeyValuePair<string, int>("Privado",4),
                new KeyValuePair<string, int>("No me atiendo",5),
                new KeyValuePair<string, int>("Otro. Especifique",6),
            };
        public int AtiendeEnfermedadId { get; set; }
        public string AtiendeEnfermedadOtro { get; set; } = string.Empty;

        public int CantidadMedicamentoOtros { get; set; }
        [OneToMany]
        public List<MedicamentoOtro> MedicamentoOtrosCollection { get; set; } = new List<MedicamentoOtro>();

        public List<KeyValuePair<string, int>> ServicioSaludAcudioPrimero = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Centro de salud",1),
                new KeyValuePair<string, int>("Médico particular",2),
                new KeyValuePair<string, int>("Hospital de Valladolid",3),
                new KeyValuePair<string, int>("Hospital Izamal",4),
                new KeyValuePair<string, int>("Hospital en Mérida RAE",5),
                new KeyValuePair<string, int>("Hospital en Mérida O’horan",6),
                new KeyValuePair<string, int>("Hospital privado",7),
                new KeyValuePair<string, int>("Otro. Especifique",8),
            };
        public int ServicioSaludAcudioPrimeroId { get; set; }
        public string ServicioSaludAcudioPrimeroOtro { get; set; } = string.Empty;

        //public DateTime FechaAcudio { get; set; } = DateTime.Now;
        public int FechaAcudio { get; set; }
        //public bool Atendieron { get; set; } = false;
        public List<KeyValuePair<string, int>> Atendieron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int AtendieronId { get; set; }

        public List<KeyValuePair<string, int>> NoAtendieron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Costo",1),
                new KeyValuePair<string, int>("Muchos trámites",2),
                new KeyValuePair<string, int>("Esperó mucho tiempo",3),
                new KeyValuePair<string, int>("Sin servicio",4),
                new KeyValuePair<string, int>("Mal trato",5),
                new KeyValuePair<string, int>("Otro. Especifique",6), 
            };
        public int NoAtendieronId { get; set; }
        public string NoAtendieronOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> ServicioRecibio = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Consulta",1),
                new KeyValuePair<string, int>("Urgencias",2),
                new KeyValuePair<string, int>("Hospitalización",3),
                new KeyValuePair<string, int>("Cirugía",4),
                new KeyValuePair<string, int>("Otros. Especifique",5),
            };
        public int ServicioRecibioId { get; set; }
        public string ServicioRecibioOtro { get; set; } = string.Empty;
        public int ServicioRecibioCantidad { get; set; }

        public List<KeyValuePair<string, int>> DijeronTenia = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Enfermedad",1),
                new KeyValuePair<string, int>("Nada",2),
                new KeyValuePair<string, int>("No sabe",3),
                new KeyValuePair<string, int>("Otro, especifique",4),
            };
        public int DijeronTeniaId { get; set; }
        public string DijeronTeniaEnfermedad { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> RecomendadoHacer = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Nada",1),
                new KeyValuePair<string, int>("Tomar medicamento, ¿Cuáles?",2),
                new KeyValuePair<string, int>("Cuidados en casa",3),
                new KeyValuePair<string, int>("Cirugía",4),
                new KeyValuePair<string, int>("Envío a otro lado",5),
                new KeyValuePair<string, int>("Estudios. Especifique",6),
                new KeyValuePair<string, int>("Otro. Especifique",7),
            };
        public int RecomendadoHacerId { get; set; }
        public string RecomendadoHacerOtro { get; set; } = string.Empty;
        public string RecomendadoHacerMedicamentos { get; set; } = string.Empty;
        public string RecomendadoHacerEstudios { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> HizoRecomendado = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si",1),
                new KeyValuePair<string, int>("No, ¿por qué?",2),
            };
        public int HizoRecomendadoId { get; set; }
        public string HizoRecomendadoOtro { get; set; } = string.Empty;

        public float CuantoCosto { get; set; }

        public List<KeyValuePair<string, int>> ParecioCosto = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy caro",1),
                new KeyValuePair<string, int>("Caro",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Barato",4),
                new KeyValuePair<string, int>("Muy barato",5),
            };
        public int ParecioCostoId { get; set; }

        public List<KeyValuePair<string, int>> ParecioServicio = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy bueno",1),
                new KeyValuePair<string, int>("Bueno",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Malo",4),
                new KeyValuePair<string, int>("Muy malo",5),
            };
        public int ParecioServicioId { get; set; }

        public List<KeyValuePair<string, int>> RegresariaServicio = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si",1),
                new KeyValuePair<string, int>("No",2),
            };
        public int RegresariaServicioId { get; set; }

        public List<KeyValuePair<string, int>> RegresariaServicioRazon = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Mal trato",1),
                new KeyValuePair<string, int>("Desacuerdo con lo que dijeron",2),
                new KeyValuePair<string, int>("Desacuerdo con el tratamiento",3),
                new KeyValuePair<string, int>("Costo",4),
                new KeyValuePair<string, int>("Está muy lejos",5),
                new KeyValuePair<string, int>("Tiempo de espera largo",6),
                new KeyValuePair<string, int>("Mala comunicación",7),
                new KeyValuePair<string, int>("Otro. Especifique",8),
            };
        public int RegresariaServicioRazonId { get; set; }
        public string RegresariaServicioRazonOtro { get; set; } = string.Empty;
    }

    public class Medicamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public float Costo { get; set; }
        public int Duracion { get; set; }

        [ForeignKey(typeof(PatientModel))]
        public int EmfermedadId { get; set; }
    }
    public class MedicamentoOtro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public float Costo { get; set; }
        public int Duracion { get; set; }

        [ForeignKey(typeof(PatientModel))]
        public int EmfermedadId { get; set; }
    }
}
