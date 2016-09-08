using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InnovaSchools.Util
{
    public enum EstadoDetalleSolicitudCompra
    {
        Pendiente = 1,
        Despachada = 2,
        Devuelta = 3
    }

    public enum TipoPrioridadOrdenDespacho
    {
        Baja = 1,
        Media = 2,
        Alta = 3
    }

    public enum EstadoOrdenDespacho
    {
        Creada = 1,
        Aprobada = 2
    }

    public enum TipoPersona
    {
        Conductor = 1,
        Operario = 2
    }

    public enum TipoProducto
    {
        Perecible = 1,
        [Description("No Perecible")]
        NoPerecible = 2,
        Devuelto = 3
    }

    public enum CategoriaProducto
    {
        [Description("Carnes y Embutidos")]
        CarnesYEmbutidos = 1,

        [Description("Frutas y Verduras")]
        FrutasYVerduras = 2,

        [Description("Panaderia y Dulces")]
        PanaderiaYDulces = 3,

        [Description("Huevos, Lacteos y Cafe")]
        HuevosLacteosYCafe = 4,

        [Description("Aceite, Pasta y Legumbre")]
        AceitePastaYLegumbre = 5,

        [Description("Conservas Y Comida Preparada")]
        ConservasYComidaPreparada = 6,

        [Description("Zumos y Bebidas")]
        ZumosYBebidas = 7,

        Aperitivos = 8,

        [Description("Algas, Tofu Y Preparados")]
        AlgasTofuYPreparados = 9,

        Infantil = 10,

        [Description("Cosmetica Y Cuidado Personal")]
        CosmeticaYCuidadoPersonal = 11,

        [Description("Hogar Y Limpieza")]
        HogarYLimpieza = 12
    }

    public enum EstadoSolicitudCompra
    {
        Pendiente = 1,
        Devuelto = 2
    }

    public enum TipoTransporte
    {
        Publico = 1,
        Privado = 2
    }

    public enum Disponibilidad
    {
        Programada = 1,
        [Description("Por programar")]
        Porprogramar = 2
    }

    //*********************************************************//
    public enum EstadoVerificacionDocumento
    {
        Observado = 1,
        Todos = 2
    }

}