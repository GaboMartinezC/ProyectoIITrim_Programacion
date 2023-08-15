using DAL;using ET;
using ET.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EnsamblajeBL
    {
        private EnsamblajeDAL dal = new();
        public int IngresarEnsamblaje(Ensamblaje ensamblaje)
        {
            //Si el ensamblaje involucra una fuente, valida la alimentación
            if (ensamblaje.IdFuente != 0)
            {
                if (!ValidarAlimentacion(ensamblaje))
                    return 1;
            }
            if (ensamblaje.IdProcesador != 0 && ensamblaje.IdPlacaMadre != 0)
            {
                if (!ValidarSocket(ensamblaje))
                    return 2;

            }
            if (ensamblaje.IdRam != 0 && ensamblaje.CantidadRam != 0)
            {
                if (!ValidarRAM(ensamblaje))
                    return 3;
            }
            if (ensamblaje.IdUnidadAlmacenamiento != 0 && ensamblaje.CantidadUnidades != 0)
            {
                if (!ValidarAlimentacion(ensamblaje))
                    return 4;
            }
            if (ensamblaje.IdFuente != 0 && ensamblaje.IdCase != 0 && ensamblaje.IdPlacaMadre != 0)
            {
                if (ValidarFactorForma(ensamblaje))
                    return 5;
            }
            if (ensamblaje.IdGrafica != 0)
            {
                if (ValidarGPU(ensamblaje))
                    return 6;
            }    
            dal.IngresarEnsamblaje(ensamblaje);
            return 0;
        }
        private bool ValidarGPU (Ensamblaje ensamblaje)
        {
            GPU gpu = new GPU_DAL().BuscarGPU(ensamblaje.IdGrafica);
            PlacaMadre placa = new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre);
            FuentePoder fuente = new FuentePoderDAL().BuscarFuentePoder(ensamblaje.IdFuente);
            if (gpu.CantidadConectores > fuente.CantidadConectoresPCIe)
                return false;
            if(gpu.Pcie16)
            {
                if (placa.CantidadPCIe16 < 1)
                    return false;
            }
            else
            {
                if (placa.CantidadPCIe8 < 1)
                    return false;
            }
            return true;
        }
        private bool ValidarFactorForma(Ensamblaje ensamblaje)
        {
            FuentePoder fuente = new FuentePoderDAL().BuscarFuentePoder(ensamblaje.IdFuente);
            Case casePc = new CaseDAL().BuscarCase(ensamblaje.IdCase);
            PlacaMadre placa = new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre);
            FactorForma facForma = new FactorFormaDAL().BuscarFactorForma(placa.IdFactorForma);
            if (casePc.IdFactorForma != placa.IdFactorForma)
                return false;
            if (facForma.Ancho < fuente.Ancho || facForma.Largo < fuente.Ancho) 
                return false;
            return true;
        }
        private bool ValidarAlmacenamiento(Ensamblaje ensamblaje)
        {
            PlacaMadre placa = new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre);
            Almacenamiento alm = new AlmacenamientoDAL().BuscarAlmacenamiento(ensamblaje.IdUnidadAlmacenamiento);
            if (alm.M2)
            {
                if (placa.CantidadM2 < ensamblaje.CantidadUnidades)
                    return false;
            }
            else
            {
                if (placa.CantidadSATA < ensamblaje.CantidadUnidades)
                    return false;
            }    
            return true;
        }
        private bool ValidarRAM(Ensamblaje ensamblaje)
        {
            PlacaMadre placa = new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre);
            RAM ram = new RAM_DAL().BuscarRAM(ensamblaje.IdRam);
            if ((ram.Capacidad * ensamblaje.CantidadRam) > placa.LimiteRAM)
                return false;
            else if (ram.VersionDDR != placa.VersionDDR)
                return false;
            else
                return true;
        }
        private bool ValidarSocket(Ensamblaje ensamblaje)
        {
            SocketDAL sDal = new();
            int socketPlaca = new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre).IdSocket,
                socketCPU = new CPU_DAL().BuscarCPU(ensamblaje.IdProcesador).IdSocket,
                socketSistEnfriamiento = new EnfriamientoDAL().BuscarEnfriamiento(ensamblaje.IdEnfriamiento).IdSocket;
            if (socketPlaca != socketCPU || socketPlaca != socketSistEnfriamiento)
                return false;
            else
                return true;
        }
        private bool ValidarAlimentacion(Ensamblaje ensamblaje)
        {
            double energiaTotalFuente = new FuentePoderDAL().BuscarFuentePoder(ensamblaje.IdFuente).Potencia;
            double consumoEnergiaTotal = 0;
            consumoEnergiaTotal += new AlmacenamientoDAL().BuscarAlmacenamiento(ensamblaje.IdUnidadAlmacenamiento).ConsumoEnergia * ensamblaje.CantidadUnidades;
            consumoEnergiaTotal += new RAM_DAL().BuscarRAM(ensamblaje.IdRam).ConsumoEnergia * ensamblaje.CantidadRam;
            if (ensamblaje.IdProcesador != -1)
                consumoEnergiaTotal += new CPU_DAL().BuscarCPU(ensamblaje.IdProcesador).ConsumoEnergetico;
            if (ensamblaje.IdPlacaMadre != -1)
                consumoEnergiaTotal += new PlacaMadreDAL().BuscarPlacaMadre(ensamblaje.IdPlacaMadre).ConsumoEnergia;
            if (ensamblaje.IdGrafica != -1)
                consumoEnergiaTotal += new GPU_DAL().BuscarGPU(ensamblaje.IdGrafica).ConsumoEnergia;
            if (energiaTotalFuente < consumoEnergiaTotal)
                return false;
            else
                return true;
        }
        public int ActualizarEnsamblaje(Ensamblaje ensamblaje)
        {
            dal.ActualizarEnsamblaje(ensamblaje);
            return 0;
        }
        public bool EliminarEnsamblaje(int id)
        {
            return dal.EliminarEnsamblaje(id);
        }
        public List<Ensamblaje_DTO> BuscarTodoEnsamblaje()
        {
            List<Ensamblaje_DTO> retVal = new();
            DataTable dt = dal.BuscarTodoEnsamblaje();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ensamblaje_DTO dto = new();
                dto.id = Convert.ToInt32(dt.Rows[i]["ID"]);
                dto.idPlacaMadre = Convert.ToInt32(dt.Rows[i]["ID_PLACA_MADRE"]);
                dto.descripPlacaMadre = dt.Rows[i]["DESCRIPCION_PLACA"].ToString();
                dto.idProcesador = Convert.ToInt32(dt.Rows[i]["ID_PROCESADOR"]);
                dto.descripProcesador = dt.Rows[i]["DESCRIPCION_CPU"].ToString();
                dto.idEnfriamiento = Convert.ToInt32(dt.Rows[i]["ID_ENFRIAMIENTO"]);
                dto.descripcionSistEnfriamiento = dt.Rows[i]["DESCRIPCION_ENFRIAMIENTO"].ToString();
                dto.idRam = Convert.ToInt32(dt.Rows[i]["ID_RAM"]);
                dto.descripcionRam = dt.Rows[i]["DESCRIPCION_RAM"].ToString();
                dto.cantidadRam = Convert.ToInt32(dt.Rows[i]["CANTIDAD_RAM"]);
                dto.idUnidadAlmacenamiento = Convert.ToInt32(dt.Rows[i]["ID_ALMACENAMIENTO"]);
                dto.descripcionAlmacenamiento = dt.Rows[i]["DESCRIPCION_ALMACENAMIENTO"].ToString();
                dto.cantidadUnidades = Convert.ToInt32(dt.Rows[i]["CANTIDAD_UNIDADES"]);
                dto.idFuente = Convert.ToInt32(dt.Rows[i]["ID_FUENTE"]);
                dto.descripcionFuente = dt.Rows[i]["DESCRIPCION_FUENTE"].ToString();
                dto.idCase = Convert.ToInt32(dt.Rows[i]["ID_CASE"]);
                dto.descripcionCase = dt.Rows[i]["DESCRIPCION_CASE"].ToString();
                dto.idGrafica = Convert.ToInt32(dt.Rows[i]["ID_GRAFICA"]);
                dto.descripcionGrafica = dt.Rows[i]["DESCRIPCION_GPU"].ToString();
                retVal.Add(dto);
            }
            return retVal;
        }
    }
}