using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncuestaComunitaria.Models
{
    public class PatientModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string LugarAplicacion { get; set; } = string.Empty;
        public DateTime FechaCaptura { get; set; } = DateTime.Now;
        [Required]
        public string NombreEncuestador { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ApellidoP { get; set; } = string.Empty;
        [Required]
        public string ApellidoM { get; set; } = string.Empty;
        //Dirección
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string EntreCalles { get; set; } = string.Empty;
        public string Comunidad { get; set; } = string.Empty;
        public string NumeroTelefono { get; set; } = string.Empty;

        public int Edad { get; set; }
        public List<KeyValuePair<string, int>> Sexo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Hombre", 1),
                new KeyValuePair<string, int>("Mujer", 2),
            };
        public int SexoId { get; set; }

        public List<KeyValuePair<string, int>> Municipio = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Yaxcabá cabecera, Yaxcabá", 1),
                new KeyValuePair<string, int>("Yaxunah, Yaxcabá", 2),
                new KeyValuePair<string, int>("Chankom cabecera, Chankom", 3),
                new KeyValuePair<string, int>("Xcopteil, Chankom", 4),
                new KeyValuePair<string, int>("Ticimul, Chankom", 5),
                new KeyValuePair<string, int>("Xkalakdzonot, Chankom", 6),
                new KeyValuePair<string, int>("Komchén, Mérida", 7),
            };
        public int MunicipioId { get; set; }

        public int Estudios { get; set; }

        public List<KeyValuePair<string, int>> Ecivil = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("No casado", 1),
                new KeyValuePair<string, int>("Casado", 2),
                new KeyValuePair<string, int>("Juntado (Unión libre)", 3),
                new KeyValuePair<string, int>("Viudo(a)", 4),
                new KeyValuePair<string, int>("Separados", 5),
                new KeyValuePair<string, int>("Otro", 6),
            };
        public int EcivilId { get; set; }

        public string LugarNacimiento { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Hijos = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int HijosId { get; set; }
        public int HijosCuantos { get; set; }

        public List<KeyValuePair<string, int>> HablasEspanol = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int HablasEspanolId { get; set; }
        public List<KeyValuePair<string, int>> EscribesEspanol = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int EscribesEspanolId { get; set; }
        public List<KeyValuePair<string, int>> HablasMaya = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int HablasMayaId { get; set; }
        public List<KeyValuePair<string, int>> EscribesMaya = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int EscribesMayaId { get; set; }

        //vivienda  
        public int PersonasViven { get; set; }

        public List<KeyValuePair<string, int>> Techos = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Palma de guano (vegetal)", 1),
                new KeyValuePair<string, int>("Losa de vigueta y bovedilla", 2),
                new KeyValuePair<string, int>("Cartón", 3),
                new KeyValuePair<string, int>("Lámina de Zinc", 4),
                new KeyValuePair<string, int>("Madera", 5),
                new KeyValuePair<string, int>("Otro. Especifique", 6),
            };
        public int TechosId { get; set; }
        public string TechosOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Paredes = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Block / Ladrillo", 1),
                new KeyValuePair<string, int>("Piedra", 2),
                new KeyValuePair<string, int>("Cartón", 3),
                new KeyValuePair<string, int>("Lámina de Zinc", 4),
                new KeyValuePair<string, int>("Madera", 5),
                new KeyValuePair<string, int>("Otro. Especifique", 6),
            };
        public int ParedesId { get; set; }
        public string ParedesOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Piso = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Tierra", 1),
                new KeyValuePair<string, int>("Cemento/Firme", 2),
                new KeyValuePair<string, int>("Mosaico (20x20cm)", 3),
                new KeyValuePair<string, int>("Vitropiso", 4),
                new KeyValuePair<string, int>("Otro. Especifique", 5),
            };
        public int PisoId { get; set; }
        public string PisoOtro { get; set; } = string.Empty;

        public int NumeroCuartos { get; set; }

        public List<KeyValuePair<string, int>> CuartoCocina = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int CuartoCocinaId { get; set; }

        public List<KeyValuePair<string, int>> DuermeCocina = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int DuermeCocinaId { get; set; }

        public List<KeyValuePair<string, int>> Combustible = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Fogón 3 piedras o candela", 1),
                new KeyValuePair<string, int>("Estufa ahorradora de leña", 2),
                new KeyValuePair<string, int>("Estufa de gas", 3),
                new KeyValuePair<string, int>("Ambos (leña y gas)", 4),
                new KeyValuePair<string, int>("Estufa eléctrica", 5),
                new KeyValuePair<string, int>("Otro. Especifique", 6),
            };
        public int CombustibleId { get; set; }
        public string CombustibleOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Electricidad = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Servicio público(CFE)", 1),
                new KeyValuePair<string, int>("Planta particular", 2),
                new KeyValuePair<string, int>("Panel Solar", 3),
                new KeyValuePair<string, int>("Otro. Especifique", 4),
            };
        public int ElectricidadId { get; set; }
        public string ElectricidadOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> Agua = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Agua entubada dentro de la casa", 1),
                new KeyValuePair<string, int>("Agua entubada en cocina/baño", 2),
                new KeyValuePair<string, int>("Agua entubada de llave pública", 3),
                new KeyValuePair<string, int>("Agua entubada acarreada de otro solar", 4),
                new KeyValuePair<string, int>("Agua pipa", 5),
                new KeyValuePair<string, int>("Agua de pozo", 6),
            };
        public int AguaId { get; set; }
        public List<KeyValuePair<string, int>> AguaDias = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Diario", 1),
                new KeyValuePair<string, int>("Cada tercer día", 2),
                new KeyValuePair<string, int>("Dos veces por semana", 3),
                new KeyValuePair<string, int>("Una vez por semana", 4),
                new KeyValuePair<string, int>("De vez en cuando", 5),
            };
        public int AguaDiasId { get; set; }

        public List<KeyValuePair<string, int>> Drenaje = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sumidero / Fosa Séptica", 1),
                new KeyValuePair<string, int>("Biodigestor / Rotoplas", 2),
                new KeyValuePair<string, int>("Letrina", 3),
                new KeyValuePair<string, int>("Aire Libre", 4),
                new KeyValuePair<string, int>("Red Pública (Drenaje)", 5),
            };
        public int DrenajeId { get; set; }

        public List<KeyValuePair<string, int>> DrenajeComparte = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int DrenajeComparteId { get; set; }

        public List<KeyValuePair<string, int>> Basura = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("la recoge el servicio de basura?", 1),
                new KeyValuePair<string, int>("la tiran en el basurero público?", 2),
                new KeyValuePair<string, int>("la tiran en un contenedor o depósito?", 3),
                new KeyValuePair<string, int>("la queman?", 4),
                new KeyValuePair<string, int>("la entierran?", 5),
                new KeyValuePair<string, int>("la tiran en un terreno baldío o calle?", 6),
                new KeyValuePair<string, int>("la tiran al cenote, barranca o grieta?", 7),
                new KeyValuePair<string, int>("la tiran al río o laguna?", 8),
            };
        public int BasuraId { get; set; }

        //¿En tu vivienda tienen…
        public bool vivienda_tienen_1 { get; set; } = false;
        public bool vivienda_tienen_2 { get; set; } = false;
        public bool vivienda_tienen_3 { get; set; } = false;
        public bool vivienda_tienen_4 { get; set; } = false;
        public bool vivienda_tienen_5 { get; set; } = false;
        public bool vivienda_tienen_6 { get; set; } = false;
        public bool vivienda_tienen_7 { get; set; } = false;
        public bool vivienda_tienen_8 { get; set; } = false;
        public bool vivienda_tienen_9 { get; set; } = false;
        public bool vivienda_tienen_10 { get; set; } = false;
        public bool vivienda_tienen_11 { get; set; } = false;
        public bool vivienda_tienen_12 { get; set; } = false;
        public bool vivienda_tienen_13 { get; set; } = false;
        public bool vivienda_tienen_14 { get; set; } = false;
        public bool vivienda_tienen_15 { get; set; } = false;
        public bool vivienda_tienen_16 { get; set; } = false;
        public bool vivienda_tienen_17 { get; set; } = false;
        public bool vivienda_tienen_18 { get; set; } = false;
        public bool vivienda_tienen_19 { get; set; } = false;
        public bool vivienda_tienen_20 { get; set; } = false;
        public bool vivienda_tienen_21 { get; set; } = false;
        public bool vivienda_tienen_22 { get; set; } = false;
        public bool vivienda_tienen_23 { get; set; } = false;

        //SECCIÓN C. DATOS CLÍNICO
        public float Peso { get; set; }
        public float Talla { get; set; }
        public int Presion_Sys { get; set; }
        public int Presion_Dia { get; set; }
        public bool GlucosaAyuno { get; set; } = false;
        public bool GlucosaCasual { get; set; } = false;
        public float GlucosaValor { get; set; }

        //SECCIÓN D. COMORBILIDAD
        public bool Comorbilidad_1 { get; set; } = false;
        public bool Comorbilidad_2 { get; set; } = false;
        public bool Comorbilidad_3 { get; set; } = false;
        public bool Comorbilidad_4 { get; set; } = false;
        public bool Comorbilidad_5 { get; set; } = false;
        public bool Comorbilidad_6 { get; set; } = false;
        public bool Comorbilidad_7 { get; set; } = false;
        public bool Comorbilidad_8 { get; set; } = false;
        public bool Comorbilidad_9 { get; set; } = false;
        public bool Comorbilidad_10 { get; set; } = false;
        public bool Comorbilidad_11 { get; set; } = false;
        public bool Comorbilidad_12 { get; set; } = false;
        public bool Comorbilidad_13 { get; set; } = false;
        public bool Comorbilidad_14  { get; set; } = false;
        public string Comorbilidad_Otro { get; set; } = string.Empty;

        //SECCIÓN E.HISTORIA DE TRABAJO
        public List<KeyValuePair<string, int>> Trabajaste = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int TrabajasteId { get; set; }

        public List<KeyValuePair<string, int>> TrabajasteNo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Por enfermedad", 1),
                new KeyValuePair<string, int>("No encuentra trabajo", 2),
                new KeyValuePair<string, int>("Otros. Especifique", 3),
            };
        public int TrabajasteNoId { get; set; }
        public string TrabajasteNoOtro { get; set; } = string.Empty;

        public string Dedicas { get; set; } = string.Empty;

        public int HorasTrabajas { get; set; }

        public List<KeyValuePair<string, int>> Milpa = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int MilpaId { get; set; }

        public int GanasSemana { get; set; }

        public int GastasSemana { get; set; }

        public List<KeyValuePair<string, int>> ApoyoEconomico = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int ApoyoEconomicoId { get; set; }
        public float ApoyoEconomicoCantidad { get; set; }

        //SECCIÓN F. DOLOR, INFLAMACIÓN O RIGIDEZ
        //coordinate click image and data
        public List<KeyValuePair<string, int>> ReumaFamilia = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int ReumaFamiliaId { get; set; }
        
        public List<KeyValuePair<string, int>> TenidoDolorSieteDias = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int TenidoDolorSieteDiasId { get; set; }
        [OneToMany]
        public List<DolorSieteDias> DolorSieteDiasCollecion { get; set; } = new List<DolorSieteDias>();

        public List<KeyValuePair<string, int>> TenidoDolorHistoirico = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int TenidoDolorHistoiricoId { get; set; }
        [OneToMany]
        public List<DolorHistoirico> DolorHistoiricoCollecion { get; set; } = new List<DolorHistoirico>();

        //SECCIÓN G. INCAPACIDAD LABORAL 
        public List<KeyValuePair<string, int>> DejaHacerE = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
                new KeyValuePair<string, int>("Hoy no pero antes Sí", 3),
            };
        public int DejaHacerEId { get; set; }

        public int DejaHacerSiDias { get; set; }
        public int DejaHacerSiSemanas { get; set; }
        public int DejaHacerSiMeses { get; set; }
        public int DejaHacerSiAnos { get; set; }
        public int DejaHacerSiHDias { get; set; }
        public int DejaHacerSiHSemanas { get; set; }
        public int DejaHacerSiHMeses { get; set; }
        public int DejaHacerSiHAnos { get; set; }

        //SECCIÓN H. TRATAMIENTO 
        public List<KeyValuePair<string, int>> TratamientoIdo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Con un doctor", 1),
                new KeyValuePair<string, int>("Con otro (yerbero, huesero, curandero, brujo, espiritista)", 2),
                new KeyValuePair<string, int>("Con nadie", 3),
                new KeyValuePair<string, int>("Otro. Especifique", 4),
            };
        public int TratamientoIdoId { get; set; }
        public string TratamientoIdoOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> MedicamentoDolor = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int MedicamentoDolorId { get; set; }
        public string MedicamentoDolorNombre { get; set; } = string.Empty;
        public string OtroDolorNombre { get; set; } = string.Empty;

        //SECCIÓN I. DIFICULTAD PARA REALIZAR ACTIVIDADES ESPECÍFICAS
        public List<string> ActividadEspecificaQ = new List<string> {
            "Vestirse, ponerse  zapatos y  abotonarse la  ropa",
            "Enjuagar el cabello",
            "Pararte de un banquillo sin apoyarte",
            "Acostarse o  levantarse de tu  cama o hamaca",
            "Cortar en trozos",
            "Agarrar una taza o  un vaso lleno",
            "Abrir una botella  de refresco",
            "Caminar alrededor  de la casa en un  lugar plano",
            "Subir 5 escalones",
            "Bañarte y secarte",
            "Cuando vas al baño",
            "Agarrar y bajar algo que tiene un poco más de un kilo que está por encima de tu cabeza",
            "Inclinarte y levantar las cosas del suelo",
            "Abrir la puerta de un coche o de la casa",
            "Abrir un frasco",
            "Abrir y cerrar la llave del agua",
            "Ir a comprar",
            "Entrar y salir de un coche",
            "Hacer algo en la  casa, lavar, lavar  trastes, hacer  comida, chapear  terreno.",
            "Bordar a mano, urdir hamaca o costurar en máquina  de coser."
        };
        public List<string> ActividadEspecificaA = new List<string> {
            "No me costó trabajo",
            "Un poco de trabajo ",
            "Me dió mucho  trabajo",
            "No pude hacerlo"
        };
        public int ActividadEspecifica1 { get; set; } = 0;
        public int ActividadEspecifica2 { get; set; } = 0;
        public int ActividadEspecifica3 { get; set; } = 0;
        public int ActividadEspecifica4 { get; set; } = 0;
        public int ActividadEspecifica5 { get; set; } = 0;
        public int ActividadEspecifica6 { get; set; } = 0;
        public int ActividadEspecifica7 { get; set; } = 0;
        public int ActividadEspecifica8 { get; set; } = 0;
        public int ActividadEspecifica9 { get; set; } = 0;
        public int ActividadEspecifica10 { get; set; } = 0;
        public int ActividadEspecifica11 { get; set; } = 0;
        public int ActividadEspecifica12 { get; set; } = 0;
        public int ActividadEspecifica13 { get; set; } = 0;
        public int ActividadEspecifica14 { get; set; } = 0;
        public int ActividadEspecifica15 { get; set; } = 0;
        public int ActividadEspecifica16 { get; set; } = 0;
        public int ActividadEspecifica17 { get; set; } = 0;
        public int ActividadEspecifica18 { get; set; } = 0;
        public int ActividadEspecifica19 { get; set; } = 0;
        public int ActividadEspecifica20 { get; set; } = 0;
        // Dictionary to hold the selected answer index for each question
        public Dictionary<int, int> ActividadEspecificaSA = new Dictionary<int, int>();

        public bool AyudaBaston { get; set; } = false;
        public bool AyudaAndadera { get; set; } = false;
        public bool AyudaMuletas { get; set; } = false;
        public bool AyudaSillaDeRuedas { get; set; } = false;
        public bool AyudaSillaArreglada { get; set; } = false;
        public bool AyudaEstufaAdaptada { get; set; } = false;
        public bool AyudaPonertezapato { get; set; } = false;
        public bool AyudaOtracosa { get; set; } = false;
        public string AyudaOtracosaString { get; set; } = string.Empty;

        public bool AyudaCosaSillaIrBano  { get; set; } = false;
        public bool AyudaCosaSillaBanarse { get; set; } = false;
        public bool AyudaCosaAbrirFrasco { get; set; } = false;
        public bool AyudaCosaAgarrarseBano { get; set; } = false;
        public bool AyudaCosaLargoAlcanzar { get; set; } = false;
        public bool AyudaCosaAlgoBanarse { get; set; } = false;
        public bool AyudaCosaOtro { get; set; } = false;
        public string AyudaCosaOtroString { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> dolorreuma = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Nada", 1),
                new KeyValuePair<string, int>("Solo un poco", 2),
                new KeyValuePair<string, int>("No muy fuerte", 3),
                new KeyValuePair<string, int>("Fuerte", 4),
                new KeyValuePair<string, int>("Muy fuerte", 5),
            };
        public int dolorreumaId { get; set; }

        public int CargaBiomecanicaTrabajosTotales { get; set; } = 0;
        [OneToMany]
        public List<CargaBiomecanica> CargaBiomecanicaCollection { get; set; } = new List<CargaBiomecanica>();

        public List<KeyValuePair<string, int>> CansadoFatiga = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Siempre",1),
                new KeyValuePair<string, int>("A veces",2),
                new KeyValuePair<string, int>("Nunca",3),
            };
        public int CansadoFatigaId { get; set; }

        public List<KeyValuePair<string, int>> ActividadDiver = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int ActividadDiverId { get; set; }
        public string ActividadDiverNombre { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> ActividadDiverDif = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Siempre",1),
                new KeyValuePair<string, int>("A veces",2),
                new KeyValuePair<string, int>("Nunca",3),
            };
        public int ActividadDiverDifId { get; set; }


        public List<KeyValuePair<string, int>> Movilidad = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Puede caminar",1),
                new KeyValuePair<string, int>("Le da trabajo caminar",2),
                new KeyValuePair<string, int>("No puede caminar (está en la hamaca)",3),
            };
        public int MovilidadId { get; set; }
        public List<KeyValuePair<string, int>> CuidadoPersonal = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Puede bañarse y vestirse",1),
                new KeyValuePair<string, int>("Tiene algunos problemas para bañarse o vestirse",2),
                new KeyValuePair<string, int>("No puede bañarse o vestirse",3),
            };
        public int CuidadoPersonalId { get; set; }
        public List<KeyValuePair<string, int>> ActividadesDiarias = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("No tiene problemas para hacer sus actividades diarias",1),
                new KeyValuePair<string, int>("Tiene algunos problemas para hacer sus actividades diarias",2),
                new KeyValuePair<string, int>("No puede hacer todas sus actividades diarias",3),
            };
        public int ActividadesDiariasId { get; set; }
        public List<KeyValuePair<string, int>> DolorCalidaddeVida = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("No tiene dolor",1),
                new KeyValuePair<string, int>("Ha tenido un poco de dolor",2),
                new KeyValuePair<string, int>("Tiene mucho dolor",3),
            };
        public int DolorCalidaddeVidaId { get; set; }
        public List<KeyValuePair<string, int>> AnsiedadDepresion = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("No está triste ni inquieto",1),
                new KeyValuePair<string, int>("Esta un poco inquieto y triste",2),
                new KeyValuePair<string, int>("Está muy inquieto y triste",3),
            };
        public int AnsiedadDepresionId { get; set; }
        public List<KeyValuePair<string, int>> EstadoSalud = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy bueno",1),
                new KeyValuePair<string, int>("Bueno",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Malo",4),
            };
        public int EstadoSaludId { get; set; }
        [OneToMany]
        public List<Enfermedades> EnfermedadesCollection { get; set; } = new List<Enfermedades>();



        //Considerando todas sus enfermedades…
        public int MedicamentoTratamientoTotales { get; set; } = 0;
        [OneToMany]
        public List<MedicamentoTratamiento> MedicamentoTratamientoCollection { get; set; } = new List<MedicamentoTratamiento>();

        public bool TrasporteAmbulacia { get; set; } = false;
        public float TrasporteAmbulaciaCosto { get; set; }
        public bool Flete { get; set; } = false;
        public float FleteCosto { get; set; }
        public bool VehiculoPersonal { get; set; } = false;
        public float VehiculoPersonalCosto { get; set; }
        public bool VehiculoVecino { get; set; } = false;
        public float VehiculoVecinoCosto { get; set; }
        public bool TransporteOtro { get; set; } = false;
        public string TransporteOtroCual { get; set; } = string.Empty;
        public float TransporteOtroCosto { get; set; }

        public string QuienAcompana { get; set; } = string.Empty;

        public float TiempoToma { get; set; }

        public bool PagaGastos { get; set; } = false;

        public List<KeyValuePair<string, int>> ConsigueMedicamentos = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public string ConsigueMedicamentosString { get; set; } = string.Empty;
        public int ConsigueMedicamentosId { get; set; }

        //public bool Hospitalizado { get; set; } = false;
        public List<KeyValuePair<string, int>> Hospitalizado = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int HospitalizadoId { get; set; }
        public string HospitalizadoString { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> HospitalEstuvo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Hospital de Valladolid",1),
                new KeyValuePair<string, int>("Hospital Regional de Alta Especialidad (HRAE)",2),
                new KeyValuePair<string, int>("Hospital O´Horan",3),
                new KeyValuePair<string, int>("Otro ¿Cuál?",4),
            };
        public int HospitalEstuvoId { get; set; }
        public string HospitalEstuvoOtro { get; set; } = string.Empty;

        public int DiasHospital { get; set; }
        public float PagoHospital { get; set; }
    
        public List<KeyValuePair<string, int>> QuienPagoHospital = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Yo",1),
                new KeyValuePair<string, int>("un familiar",2),
                new KeyValuePair<string, int>("un amigo",3),
                new KeyValuePair<string, int>("vecinos",4),
                new KeyValuePair<string, int>("municipio",5),
                new KeyValuePair<string, int>("Otros",6),
            };
        public int QuienPagoHospitalId { get; set; }
        public string QuienPagoHospitalOtro { get; set; } = string.Empty;


        //USO DE SERVICIOS EN EL HOSPITAL 
        //public bool VisitaHospital { get; set; } = false;
        public List<KeyValuePair<string, int>> VisitaHospital = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Sí", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int VisitaHospitalId { get; set; }

        public List<KeyValuePair<string, int>> HospitalFue = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Hospital de Valladolid",1),
                new KeyValuePair<string, int>("Hospital Regional de Alta Especialidad (HRAE)",2),
                new KeyValuePair<string, int>("Hospital O´Horan",3),
                new KeyValuePair<string, int>("Otro. Especifique",4),
            };
        public int HospitalFueId { get; set; }
        public string HospitalFueOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> HospitalFueNumero = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Ninguna (pasar a la pregunta L53)",1),
                new KeyValuePair<string, int>("1 vez",2),
                new KeyValuePair<string, int>("2-5 veces",3),
                new KeyValuePair<string, int>("6-10 veces",4),
                new KeyValuePair<string, int>("Más de 10 veces",5),
            };
        public int HospitalFueNumeroId { get; set; }
   



        public int HospitalVisitaExternaNum = 0;
        public string VisitaExternaDateList = string.Empty;

        public List<KeyValuePair<string, int>> VisitaHospitalCobraron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int VisitaHospitalCobraronId { get; set; }
        public float VisitaHospitalCobraronCuanto { get; set; }

        public bool VisitaHospitalGastoTransporteRecuerda { get; set; } = false;
        public float VisitaHospitalGastoTransporte { get; set; }

        public List<KeyValuePair<string, int>> HospitalTrataron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy bien",1),
                new KeyValuePair<string, int>("Bien",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Mal",4),
                new KeyValuePair<string, int>("Muy mal",5),
            };
        public int HospitalTrataronId { get; set; }




        public int HospitalVisitaUrgenciasNum { get; set; }
        public string VisitaUrgenciaDateList = string.Empty;

        public List<KeyValuePair<string, int>> VisitaUrgenciaHospitalCobraron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int VisitaUrgenciaHospitalCobraronId { get; set; }
        public float VisitaUrgenciaHospitalCobraronCuanto { get; set; }

        public bool VisitaUrgenciaHospitalGastoTransporteRecuerda { get; set; } = false;
        public float VisitaUrgenciaHospitalGastoTransporte { get; set; }

        public List<KeyValuePair<string, int>> HospitalTrataronUrgencia = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy bien",1),
                new KeyValuePair<string, int>("Bien",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Mal",4),
                new KeyValuePair<string, int>("Muy mal",5),
            };
        public int HospitalTrataronUrgenciaId { get; set; }


        public int HospitalVisitaHospNum { get; set; }
        public string VisitaHospDateList = string.Empty;

        public List<KeyValuePair<string, int>> VisitaHospciaHospitalCobraron = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int VisitaHospHospitalCobraronId { get; set; }
        public float VisitaHospHospitalCobraronCuanto { get; set; }

        public bool VisitaHospHospitalGastoTransporteRecuerda { get; set; } = false;
        public float VisitaHospHospitalGastoTransporte { get; set; }

        public List<KeyValuePair<string, int>> HospitalTrataronHosp = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy bien",1),
                new KeyValuePair<string, int>("Bien",2),
                new KeyValuePair<string, int>("Regular",3),
                new KeyValuePair<string, int>("Mal",4),
                new KeyValuePair<string, int>("Muy mal",5),
            };
        public int HospitalTrataronHospId { get; set; }

        //IMPACTO SOCIOECONÓMICO DE LAS ENFERMEDADES
        public List<KeyValuePair<string, int>> DejadoTrabajar = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Nunca", 1),
                new KeyValuePair<string, int>("A veces", 2),
                new KeyValuePair<string, int>("Frecuentemente", 3),
                new KeyValuePair<string, int>("Siempre", 4),
            };
        public int DejadoTrabajarId { get; set; }

        public List<KeyValuePair<string, int>> SituacionEconomica = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Empeorado mucho", 1),
                new KeyValuePair<string, int>("Empeorado un poco", 2),
                new KeyValuePair<string, int>("Mejorado un poco", 3),
                new KeyValuePair<string, int>("Mejorado mucho", 4),
            };
        public int SituacionEconomicaId { get; set; }

        public List<KeyValuePair<string, int>> ModEnfermedad = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int ModEnfermedadId { get; set; }

        public List<KeyValuePair<string, int>> ModEnfermedadHecho = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int ModEnfermedadHechoId { get; set; }
        public string ModEnfermedadHechoExp { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> AyudaFamAmi = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int AyudaFamAmiId { get; set; }

        public List<KeyValuePair<string, int>> AyudaFamAmiQuien = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Familiar (especifique parentesco)", 1),
                new KeyValuePair<string, int>("Amigo", 2),
                new KeyValuePair<string, int>("Municipio", 3),
                new KeyValuePair<string, int>("Otro", 4),
            };
        public int AyudaFamAmiQuienId { get; set; }
        public string AyudaFamAmiQuienPariente { get; set; } = string.Empty;
        public string AyudaFamAmiQuienOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> PedirPrestado = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int PedirPrestadoId { get; set; }

        public List<KeyValuePair<string, int>> FamDejadoTrabajo = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
            };
        public int FamDejadoTrabajoId { get; set; }
    }

    public class ActividadesEspecificas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Actividad { get; set; }
        public string Respuesta { get; set; }
    }

    public class DolorSieteDias
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int TiempoSemanas { get; set; }
        public int TiempoMeses { get; set; }
        public int TiempoAnos { get; set; }

        public List<KeyValuePair<string, int>> DolorPaso = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
                new KeyValuePair<string, int>("No lo se", 3),
            };
        public int DolorPasoId { get; set; }

        public List<KeyValuePair<string, int>> DolorPasoCausa = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Quebradura", 1),
                new KeyValuePair<string, int>("Torcedura", 2),
                new KeyValuePair<string, int>("Dislocación", 3),
                new KeyValuePair<string, int>("Otro, especifique", 4),
            };
        public int DolorPasoCausaId { get; set; }
        public string DolorPasoCausaOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> DolorCuanto = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy fuerte", 1),
                new KeyValuePair<string, int>("Fuerte", 2),
                new KeyValuePair<string, int>("No muy fuerte", 3),
                new KeyValuePair<string, int>("Poco", 4),
                new KeyValuePair<string, int>("Nada", 5),
            };
        public int DolorCuantoId { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class DolorHistoirico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int TiempoSemanas { get; set; }
        public int TiempoMeses { get; set; }
        public int TiempoAnos { get; set; }

        public List<KeyValuePair<string, int>> DolorPaso = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Si", 1),
                new KeyValuePair<string, int>("No", 2),
                new KeyValuePair<string, int>("No lo se", 3),
            };
        public int DolorPasoId { get; set; }

        public List<KeyValuePair<string, int>> DolorPasoCausa = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Quebradura", 1),
                new KeyValuePair<string, int>("Torcedura", 2),
                new KeyValuePair<string, int>("Dislocación", 3),
                new KeyValuePair<string, int>("Otro, especifique", 4),
            };
        public int DolorPasoCausaId { get; set; }
        public string DolorPasoCausaOtro { get; set; } = string.Empty;

        public List<KeyValuePair<string, int>> DolorCuanto = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Muy fuerte", 1),
                new KeyValuePair<string, int>("Fuerte", 2),
                new KeyValuePair<string, int>("No muy fuerte", 3),
                new KeyValuePair<string, int>("Poco", 4),
                new KeyValuePair<string, int>("Nada", 5),
            };
        public int DolorCuantoId { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class CargaBiomecanica 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool CargaBiomecanicaSacudirMano { get; set; } = false;
        public bool CargaBiomecanicaCaragar20kg { get; set; } = false;
        public bool CargaBiomecanicaEmpujar20kg { get; set; } = false;
        public bool CargaBiomecanicaSubirBajar { get; set; } = false;
        public bool CargaBiomecanicaParadoMasMH { get; set; } = false;
        public bool CargaBiomecanicaAgachadoMasMH { get; set; } = false;
        public bool CargaBiomecanicaCaminandoMasMH { get; set; } = false;
        public bool CargaBiomecanicaPararSentarse { get; set; } = false;

        public List<KeyValuePair<string, int>> NombreActividad = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("Campesino", 1),
                new KeyValuePair<string, int>("Crianza de animales", 2),
                new KeyValuePair<string, int>("Urdir hamacas", 3),
                new KeyValuePair<string, int>("Bordar", 4),
                new KeyValuePair<string, int>("Costurar a máquina", 5),
                new KeyValuePair<string, int>("Ama de casa", 6),
                new KeyValuePair<string, int>("Tallador de madera", 7),
                new KeyValuePair<string, int>("Turismo", 8),
                new KeyValuePair<string, int>("Otros. ¿Cuál?", 9),
            };
        public string NombreActividadString { get; set; } = string.Empty;
        public int NombreActividadId { get; set; }

        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class MedicamentoTratamiento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public float Costo { get; set; }
        public int Duracion { get; set; }
        public string Enfermedad { get; set; } = string.Empty;

        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class FechaVisitaExterna
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class FechaVisitaUrgencia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }

    public class FechaVisitaHosp
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(typeof(PatientModel))]
        public int PatientId { get; set; }
    }
}
