using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EncuestaComunitaria.Models
{
    public class Funcionales
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }

        public float Peso { get; set; }

        public float Dinatest_1 { get; set; }
        public float Dinatest_2 { get; set; }
        public float Dinatest_3 { get; set; }

        public float Dinatest_A { get; set; }

        public List<KeyValuePair<string, int>> TocaPies = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int TocaPiesId { get; set; }
        public float TocaPiesDistDedo { get; set; }
        public float TocaPiesDistMas { get; set; }

        public float Cadencia { get; set; }
        public float LongitudPaso { get; set; }
        public float TempMarcha { get; set; }
        public float VelMarcha { get; set; }

        public float BancoAltura { get; set; }
        public float NumCiclos { get; set; }
        public float VO2 { get; set; }
        public float PotenciaMecanica { get; set; }
        public float Trabajo { get; set; }
        public float Julios { get; set; }

        public List<KeyValuePair<string, int>> CuantoDolor = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Intenso", 1),
                new KeyValuePair<string, int>("Fuerte", 2),
                new KeyValuePair<string, int>("No muy fuerte", 3),
                new KeyValuePair<string, int>("Poco", 4),
                new KeyValuePair<string, int>("Nada", 5),
            };
        public int CuantoDolorId { get; set; }

        public float FC_I { get; set; }
        public float FC_O { get; set; }
    }
}
