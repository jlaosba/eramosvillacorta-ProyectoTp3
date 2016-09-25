using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace InnovaSchools.Models
{
    public class InnovaSchoolsContextInitializer : DropCreateDatabaseIfModelChanges<InnovaSchoolsContext>
    {
        protected override void Seed(InnovaSchoolsContext context)
        {

            //List<Zona> zonas = new List<Zona>{
            //    new Zona {descripcion_zona="Miraflores"},
            //    new Zona {descripcion_zona="Chorrillos"}
                
            //};

            //foreach (Zona z in zonas)
            //    context.Zona.Add(z);

            //List<Tienda> tiendas = new List<Tienda>{
            //    new Tienda {descripcion_tienda="TDA-01",id_zona=1},
            //    new Tienda {descripcion_tienda="TDA-2",id_zona=1}

            //};

            //foreach (Tienda z in tiendas)
            //    context.Tienda.Add(z);

            //List<Turno> turnos = new List<Turno>{
            //    new Turno {descripcion_turno="Mañana"},
            //    new Turno {descripcion_turno="Tarde"}

            //};

            //foreach (Turno t in turnos)
            //    context.Turno.Add(t);

            //List<Puesto> puestos = new List<Puesto>{
            //    new Puesto {descripcion_puesto="Conductor"},
            //    new Puesto {descripcion_puesto="Operario"}
            //};

            //foreach (Puesto t in puestos)
            //    context.Puesto.Add(t);


           


           

            //List<Transporte> transportes = new List<Transporte>{
            //    new Transporte {id_transporte=1, modelo="MODELO 01", marca="MARCA B01", nro_placa="PLACA 01", capacidad=1000, soat="", tipo_transporte="PROPIO"},
            //    new Transporte {id_transporte=2, modelo="MODELO 02", marca="MARCA B02", nro_placa="PLACA 02", capacidad=1000, soat="", tipo_transporte="PROPIO"}
                
            //};
            

            //foreach (Transporte t in transportes)
            //    context.Transporte.Add(t);


            

           
                       

            //List<ProgramarPersonal> ProgPersonas = new List<ProgramarPersonal>{
            //    new ProgramarPersonal {id_programar_persona=1,id_turno=1},
            //    new ProgramarPersonal {id_programar_persona=2,id_turno=1}
            //};

            ////foreach (ProgramarPersonal t in ProgPersonas)
            ////    context.ProgramarPersonal.Add(t);

            //List<Persona> personas = new List<Persona>{
            //    new Persona {id_persona=1, apellido_paterno="TORRES", apellido_materno="PEREZ", nombre="JUAN", dni="12345678",id_puesto=1,id_programar_persona = 1},
            //    new Persona {id_persona=2, apellido_paterno="GARCIA", apellido_materno="HUAMAN", nombre="JUAN", dni="11111111",id_puesto=2,id_programar_persona=2}
                
            //};

            ////foreach (Persona t in personas)
            ////    context.Persona.Add(t);


            //List<ProgramarPersonalDet> ProgPersonasDet = new List<ProgramarPersonalDet>{
            //    new ProgramarPersonalDet {id_programar_personaDet=1,id_programar_persona=1,id_persona=1},
            //    new ProgramarPersonalDet {id_programar_personaDet=2,id_programar_persona=2,id_persona=2}
                
            //};

            ////foreach (ProgramarPersonalDet t in ProgPersonasDet)
            ////    context.ProgramarPersonalDet.Add(t);


            

            //List<Orden_despacho> ordenes = new List<Orden_despacho>{
            //    new Orden_despacho {id_orden_despacho=1,fecha_despacho="",estado_orden_despacho="Pend",tipo_prioridad_orden_despacho="Alta",id_transporte=1,id_programar_conductor=1,id_programar_operario=2},
            //    new Orden_despacho {id_orden_despacho=2,fecha_despacho="",estado_orden_despacho="Pend",tipo_prioridad_orden_despacho="Alta",id_transporte=2,id_programar_conductor=1,id_programar_operario=2}
                
            //};

            //foreach (Orden_despacho z in ordenes)
            //    context.Orden_despacho.Add(z);


            //List<Solicitud_compra> solicitudes = new List<Solicitud_compra>{
            //    new Solicitud_compra {id_orden_despacho=1,id_solicitud_compra=1,id_tienda=1},
            //    new Solicitud_compra {id_orden_despacho=1,id_solicitud_compra=2,id_tienda=2},
            //    new Solicitud_compra {id_orden_despacho=2,id_solicitud_compra=3,id_tienda=1},
            //    new Solicitud_compra {id_orden_despacho=2,id_solicitud_compra=4,id_tienda=2},
            //    new Solicitud_compra {id_orden_despacho=2,id_solicitud_compra=5,id_tienda=2}
                               
            //};

            //foreach (Solicitud_compra s in solicitudes)
            //    context.Solicitud_compra.Add(s);



            StringBuilder storedFunctionCode = new StringBuilder();
            StringBuilder storedProcedureCode = new StringBuilder();

            storedFunctionCode.Append("CREATE FUNCTION [dbo].[dn_fn_CalculaDistancia] " + Environment.NewLine);
            storedFunctionCode.Append("(@latitud1 float," + Environment.NewLine);
            storedFunctionCode.Append("@longitud1 float," + Environment.NewLine);
            storedFunctionCode.Append("@latitud2 float," + Environment.NewLine);
            storedFunctionCode.Append("@longitud2 float," + Environment.NewLine);
            storedFunctionCode.Append("@unidad_metrica char(1)) " + Environment.NewLine);
            storedFunctionCode.Append("RETURNS float " + Environment.NewLine);
            storedFunctionCode.Append("AS " + Environment.NewLine);
            storedFunctionCode.Append("BEGIN" + Environment.NewLine);
            storedFunctionCode.Append("" + Environment.NewLine);
            storedFunctionCode.Append("DECLARE @distancia float" + Environment.NewLine);
            storedFunctionCode.Append("DECLARE @radius float" + Environment.NewLine);
            storedFunctionCode.Append("" + Environment.NewLine);
            storedFunctionCode.Append("SET @radius = 6378.137" + Environment.NewLine);
            storedFunctionCode.Append("DECLARE @deg2radMultiplier float " + Environment.NewLine);
            storedFunctionCode.Append("SET @deg2radMultiplier = PI() / 180 " + Environment.NewLine);
            storedFunctionCode.Append("SET @latitud1 = @latitud1 * @deg2radMultiplier " + Environment.NewLine);
            storedFunctionCode.Append("SET @longitud1 = @longitud1 * @deg2radMultiplier " + Environment.NewLine);
            storedFunctionCode.Append("SET @latitud2 = @latitud2 * @deg2radMultiplier " + Environment.NewLine);
            storedFunctionCode.Append("SET @longitud2 = @longitud2 * @deg2radMultiplier " + Environment.NewLine);
            storedFunctionCode.Append("" + Environment.NewLine);
            storedFunctionCode.Append("DECLARE @dlongitud float" + Environment.NewLine);
            storedFunctionCode.Append("SET @dlongitud = @longitud2 - @longitud1" + Environment.NewLine);
            storedFunctionCode.Append("SET @distancia = ACOS(SIN(@latitud1) * SIN(@latitud2) + COS(@latitud1) * " + Environment.NewLine);
            storedFunctionCode.Append("                 COS(@latitud2) * COS(@dlongitud)) * @radius" + Environment.NewLine);
            storedFunctionCode.Append("" + Environment.NewLine);
            storedFunctionCode.Append("IF @unidad_metrica = 'M'  " + Environment.NewLine);
            storedFunctionCode.Append("    SET @distancia = @distancia * 1000" + Environment.NewLine);
            storedFunctionCode.Append("RETURN @distancia" + Environment.NewLine);
            storedFunctionCode.Append("END" + Environment.NewLine);

            context.Database.ExecuteSqlCommand(storedFunctionCode.ToString());

            storedProcedureCode.Append("	create procedure [dbo].[sp_ProgramarRuta]	 " + Environment.NewLine);
            storedProcedureCode.Append("	@fec_ini varchar(10)='01/05/2016',	 " + Environment.NewLine);
            storedProcedureCode.Append("	@fec_fin varchar(10)='06/05/2016',	 " + Environment.NewLine);
            storedProcedureCode.Append("	@id_zona int = 0,	 " + Environment.NewLine);
            storedProcedureCode.Append("	@prioridad varchar(15) = ''	 " + Environment.NewLine);
            storedProcedureCode.Append("	AS	 " + Environment.NewLine);
            storedProcedureCode.Append("	BEGIN	 " + Environment.NewLine);
            storedProcedureCode.Append("	begin try	 " + Environment.NewLine);
            storedProcedureCode.Append("	    declare @latitudPrincipal float,@longitudPrincipal float,@id_orden_despacho int=0,@IDSolicitudCompra int=0	 " + Environment.NewLine);
            storedProcedureCode.Append("	    declare @orden int = 0,@nRuta int = 0	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	select @latitudPrincipal = latitud,@longitudPrincipal = longitud from t_tienda where descripcion_tienda = 'PRINCIPAL' 	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	    select od.id_orden_despacho,od.tipo_prioridad as tipo_prioridad_orden_despacho,td.id_tienda,td.direccion,	 " + Environment.NewLine);
            storedProcedureCode.Append("	       dbo.dn_fn_CalculaDistancia(td.latitud,td.longitud,@latitudPrincipal,@longitudPrincipal,'K') as Distancia,sc.id_solicitud_compra	 " + Environment.NewLine);
            storedProcedureCode.Append("	    into #orden 	 " + Environment.NewLine);
            storedProcedureCode.Append("	    from t_orden_despacho od 	 " + Environment.NewLine);
            storedProcedureCode.Append("	    inner join t_orden_despacho_solicitud ds on od.id_orden_despacho = ds.id_orden_despacho	 " + Environment.NewLine);
            storedProcedureCode.Append("	    inner join t_solicitud_compra sc on ds.id_solicitud_compra = sc.id_solicitud_compra	 " + Environment.NewLine);
            storedProcedureCode.Append("	    inner join t_tienda td on sc.id_tienda = td.id_tienda	 " + Environment.NewLine);
            storedProcedureCode.Append("	    inner join t_zona zn on td.id_zona = zn.id_zona	 " + Environment.NewLine);
            storedProcedureCode.Append("	    where od.id_orden_despacho_estado = 4 -- pendiente.. 	 " + Environment.NewLine);
            storedProcedureCode.Append("	    -- ##########    FILTROS  ###################################################	 " + Environment.NewLine);
            storedProcedureCode.Append("	and convert(varchar,od.fecha_despacho,103) between CONVERT(varchar,@fec_ini,103) and CONVERT(varchar,@fec_fin,103) 	 " + Environment.NewLine);
            storedProcedureCode.Append("	and td.id_zona = case when @id_zona=0 then td.id_zona else @id_zona end	 " + Environment.NewLine);
            storedProcedureCode.Append("	and upper(od.tipo_prioridad) = case when len(rtrim(LTRIM(upper(@prioridad)))) = 0 then od.tipo_prioridad else UPPER(@prioridad) end	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	    order by od.id_orden_despacho,Distancia asc	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	declare @id_orden_despacho_anterior int=0,@noRuta int=0,@id_tienda int = 0	 " + Environment.NewLine);
            storedProcedureCode.Append("	select @nRuta = isnull(max(id_orden_despacho_ruta),0)+1 from t_orden_despacho_ruta 	 " + Environment.NewLine);
            storedProcedureCode.Append("	select top 1 @id_orden_despacho_anterior = id_orden_despacho from #orden	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	declare c1 cursor for	 " + Environment.NewLine);
            storedProcedureCode.Append("	select id_orden_despacho,id_solicitud_compra,id_tienda from #orden	 " + Environment.NewLine);
            storedProcedureCode.Append("	open c1 	 " + Environment.NewLine);
            storedProcedureCode.Append("	FETCH NEXT FROM c1 into @id_orden_despacho,@IDSolicitudCompra,@id_tienda	 " + Environment.NewLine);
            storedProcedureCode.Append("	while @@FETCH_STATUS = 0	 " + Environment.NewLine);
            storedProcedureCode.Append("	begin	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	if (@id_orden_despacho <> @id_orden_despacho_anterior)	 " + Environment.NewLine);
            storedProcedureCode.Append("	begin	 " + Environment.NewLine);
            storedProcedureCode.Append("	    set @orden = 0	 " + Environment.NewLine);
            storedProcedureCode.Append("	    select @nRuta = isnull(max(convert(int,nro_ruta)),0)+1  from t_orden_despacho_ruta 	 " + Environment.NewLine);
            storedProcedureCode.Append("	end	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	    set @orden = @orden + 1	 " + Environment.NewLine);
            storedProcedureCode.Append("	    insert into t_orden_despacho_ruta(id_orden_despacho,nro_ruta,orden,fecha_ruta,id_tienda)	 " + Environment.NewLine);
            storedProcedureCode.Append("	    select od.id_orden_despacho,right('000'+convert(varchar(4),@nRuta),4),@orden,convert(varchar(10),GETDATE(),103),@id_tienda	 " + Environment.NewLine);
            storedProcedureCode.Append("	    from #orden od	 " + Environment.NewLine);
            storedProcedureCode.Append("	where od.id_orden_despacho = @id_orden_despacho and od.id_solicitud_compra = @IDSolicitudCompra	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	-- #############################################################	 " + Environment.NewLine);
            storedProcedureCode.Append("	update t_orden_despacho set id_orden_despacho_estado = 5 -- cambia estado.. a Programado..	 " + Environment.NewLine);
            storedProcedureCode.Append("	where  id_orden_despacho = @id_orden_despacho	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	select @id_orden_despacho_anterior = id_orden_despacho from #orden od	 " + Environment.NewLine);
            storedProcedureCode.Append("	where od.id_orden_despacho = @id_orden_despacho and od.id_solicitud_compra = @IDSolicitudCompra	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	FETCH NEXT FROM c1 into @id_orden_despacho,@IDSolicitudCompra,@id_tienda	 " + Environment.NewLine);
            storedProcedureCode.Append("	END	 " + Environment.NewLine);
            storedProcedureCode.Append("	CLOSE C1	 " + Environment.NewLine);
            storedProcedureCode.Append("	DEALLOCATE C1	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	select 0 ErrorNumber,'' ErrorMessage	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	drop table #orden	 " + Environment.NewLine);
            storedProcedureCode.Append("	end try	 " + Environment.NewLine);
            storedProcedureCode.Append("	begin catch 	 " + Environment.NewLine);
            storedProcedureCode.Append("	    SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_MESSAGE() AS ErrorMessage	 " + Environment.NewLine);
            storedProcedureCode.Append("	end catch	 " + Environment.NewLine);
            storedProcedureCode.Append("	end	 " + Environment.NewLine);
            storedProcedureCode.Append("		 " + Environment.NewLine);
            storedProcedureCode.Append("	--select dbo.dn_fn_CalculaDistancia(10.22,12.23,123.32,12.32,'K')	 " + Environment.NewLine);

            context.Database.ExecuteSqlCommand(storedProcedureCode.ToString());

            context.SaveChanges();
        }
    }
}