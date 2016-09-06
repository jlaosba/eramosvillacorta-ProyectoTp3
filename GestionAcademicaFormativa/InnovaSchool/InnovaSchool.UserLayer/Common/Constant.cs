using System.Linq;
using System.Configuration;

namespace InnovaSchool.UserLayer.Common
{
    public static class Constant
    {
        /* ---------- MENSAJES ---------- */
        //Login
        public static string TituloErrorLogin = ConfigurationManager.AppSettings["TituloErrorLogin"].Trim();
        public static string MensajeErrorLogin = ConfigurationManager.AppSettings["MensajeErrorLogin"].Trim();
        //Inicio
        public static string TituloInicio = ConfigurationManager.AppSettings["TituloInicio"].Trim();
        public static string SubtituloTituloInicio = ConfigurationManager.AppSettings["SubtituloTituloInicio"].Trim();
        //Apertura General
        public static string TituloApertura = ConfigurationManager.AppSettings["TituloApertura"].Trim();
        public static string TituloErrorApertura = ConfigurationManager.AppSettings["TituloErrorApertura"].Trim();
        //Apertura Agenda
        public static string MensajeAperturaAgenda = ConfigurationManager.AppSettings["MensajeAperturaAgenda"].Trim();
        public static string MensajeErrorAperturaAgenda = ConfigurationManager.AppSettings["MensajeErrorAperturaAgenda"].Trim();
        //Generar Agenda
        public static string TituloGenerarAgenda = ConfigurationManager.AppSettings["TituloGenerarAgenda"].Trim();
        public static string MensajeGenerarAgenda = ConfigurationManager.AppSettings["MensajeGenerarAgenda"].Trim();
        public static string MensajeErrorGenerarAgenda = ConfigurationManager.AppSettings["MensajeErrorGenerarAgenda"].Trim();
        //Calendario Agenda
        public static string TituloCalendarioAgenda = ConfigurationManager.AppSettings["TituloCalendarioAgenda"].Trim();
        public static string MensajeCalendarioAgenda = ConfigurationManager.AppSettings["MensajeCalendarioAgenda"].Trim();
        //Apertura Calendario
        public static string MensajeAperturaCalendarioAcademico = ConfigurationManager.AppSettings["MensajeAperturaCalendarioAcademico"].Trim();
        public static string MensajeErrorAperturaCalendarioAcademico = ConfigurationManager.AppSettings["MensajeErrorAperturaCalendarioAcademico"].Trim();
        public static string MensajeErrorAperturaCalendarioAcademicoAgenda = ConfigurationManager.AppSettings["MensajeErrorAperturaCalendarioAcademicoAgenda"].Trim();
        //Guardar Actividad
        public static string TituloRegistroActividad = ConfigurationManager.AppSettings["TituloRegistroActividad"].Trim();
        public static string MensajeRegistroActividadAcademica = ConfigurationManager.AppSettings["MensajeRegistroActividadAcademica"].Trim();
        public static string MensajeErrorRegistroActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorRegistroActividadAcademica"].Trim();
        public static string MensajeEdicionActividadAcademica = ConfigurationManager.AppSettings["MensajeEdicionActividadAcademica"].Trim();
        public static string MensajeErrorEdicionActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorEdicionActividadAcademica"].Trim();
        //Eliminar Actividad
        public static string TituloEliminarActividad = ConfigurationManager.AppSettings["TituloEliminarActividad"].Trim();
        public static string MensajeEliminarActividadAcademica = ConfigurationManager.AppSettings["MensajeEliminarActividadAcademica"].Trim();
        public static string MensajeErrorEliminarActividadAcademica = ConfigurationManager.AppSettings["MensajeErrorEliminarActividadAcademica"].Trim(); 
        //Actividad Feriado
        public static string TituloActividadFeriado = ConfigurationManager.AppSettings["TituloActividadFeriado"].Trim();
        public static string MensajeActividadFeriado = ConfigurationManager.AppSettings["MensajeActividadFeriado"].Trim();
        //Actividad Académica
        public static string TituloNoActividadAcademica = ConfigurationManager.AppSettings["TituloNoActividadAcademica"].Trim();
        public static string MensajeNoActividadAcademica = ConfigurationManager.AppSettings["MensajeNoActividadAcademica"].Trim();

        //Solicitud Actividad
        public static string TituloNoAgendaAprobada = ConfigurationManager.AppSettings["TituloNoAgendaAprobada"].Trim();
        public static string MensajeNoAgendaAprobada = ConfigurationManager.AppSettings["MensajeNoAgendaAprobada"].Trim();
        public static string TituloNoAgendaAperturada = ConfigurationManager.AppSettings["TituloNoAgendaAperturada"].Trim();
        public static string MensajeNoAgendaAperturada = ConfigurationManager.AppSettings["MensajeNoAgendaAperturada"].Trim();
        public static string TituloGuardarSolicitud = ConfigurationManager.AppSettings["TituloGuardarSolicitud"].Trim();
        public static string MensajeGuardarSolicitud = ConfigurationManager.AppSettings["MensajeGuardarSolicitud"].Trim();        
        public static string MensajeErrorGuardarSolicitud = ConfigurationManager.AppSettings["MensajeErrorGuardarSolicitud"].Trim();
        public static string TituloEnviarSolicitud = ConfigurationManager.AppSettings["TituloEnviarSolicitud"].Trim();
        public static string MensajeEnviarSolicitud = ConfigurationManager.AppSettings["MensajeEnviarSolicitud"].Trim();
        public static string MensajeConfirmarEnviarSolicitud = ConfigurationManager.AppSettings["MensajeConfirmarEnviarSolicitud"].Trim();
        public static string MensajeErrorEnviarSolicitud = ConfigurationManager.AppSettings["MensajeErrorEnviarSolicitud"].Trim();
            
        
        
        /* ---------- PARAMETROS ---------- */
        public static int ParametroTipoCalendario = int.Parse(ConfigurationManager.AppSettings["ParametroTipoCalendario"]);
        public static int ParametroEstadoAgenda = int.Parse(ConfigurationManager.AppSettings["ParametroEstadoAgenda"]);
        public static int ParametroEstadosCalendario = int.Parse(ConfigurationManager.AppSettings["ParametroEstadosCalendario"]);
        public static string ParametroCalendarioAprobado = ConfigurationManager.AppSettings["ParametroCalendarioAprobado"].Trim();
        public static string ParametroTipoCalendarioAcademico = ConfigurationManager.AppSettings["ParametroTipoCalendarioAcademico"];
        public static string ParametroTipoCalendarioExtracurricular = ConfigurationManager.AppSettings["ParametroTipoCalendarioExtracurricular"];


        public static string ParametroTipoActividad = ConfigurationManager.AppSettings["ParametroTipoActividad"].Trim();
        
        public static string ParametroAlcance = ConfigurationManager.AppSettings["ParametroAlcance"].Trim();
        public static string ParametroUbicacion = ConfigurationManager.AppSettings["ParametroUbicacion"].Trim();

        public static string ParametroHora = ConfigurationManager.AppSettings["ParametroHora"].Trim();
        public static string ParametroMinuto = ConfigurationManager.AppSettings["ParametroMinuto"].Trim();

        public static string ParametroUbicacionInterna = ConfigurationManager.AppSettings["ParametroUbicacionInterna"].Trim();
        public static string ParametroUbicacionExterna = ConfigurationManager.AppSettings["ParametroUbicacionExterna"].Trim();


        public static string ParametroAgendaEstadoVigente = ConfigurationManager.AppSettings["ParametroAgendaEstadoVigente"].Trim();
        public static string ParametroTipoActividadAcademica = ConfigurationManager.AppSettings["ParametroTipoActividadAcademica"].Trim();
        public static string ParametroTipoActividadExtracurricular = ConfigurationManager.AppSettings["ParametroTipoActividadExtracurricular"].Trim();

        //Correo
        public static string FlagCorreo = ConfigurationManager.AppSettings["FlagCorreo"].Trim();
        public static string CorreoAprobacion = ConfigurationManager.AppSettings["CorreoAprobacion"].Trim();
        public static string PasswordAprobacion = ConfigurationManager.AppSettings["PasswordAprobacion"].Trim();
        
    }
}