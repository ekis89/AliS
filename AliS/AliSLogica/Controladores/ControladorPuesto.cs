﻿using System;
using System.Collections.Generic;
using AliSDatos.Catalogos;
using System.Data;
using System.Linq;
using System.Text;

namespace AliSLogica.Controladores
{
    public class ControladorPuesto
    {
        public static DataTable RecuperarPuestosPorEmpresa(int codigoEmpresa)
        {
            try
            {
                return CatalogoPuesto.RecuperarPuestosPorEmpresa(codigoEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarPuestoPorEmpresaYLegajo(int codigoEmpresa, string numeroLegajo)
        {
            try
            {
                return CatalogoPuesto.RecuperarPuestoPorEmpresaYLegajo(codigoEmpresa, numeroLegajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string InsertarAcualizarPuesto(int codigoEmpresa, string codigo, int codigoPuesto, string descripcion, int tipoPuesto, string montoBasico)
        {
            try
            {
                DataTable rta = CatalogoPuesto.InsertarAcualizarPuesto(codigoEmpresa, codigo, codigoPuesto, descripcion, tipoPuesto, montoBasico);
                return Convert.ToString(rta.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string EliminarPuestoPorCodigo(int codigoPuesto)
        {
            try
            {
                DataTable rta = CatalogoPuesto.EliminarPuestoPorCodigo(codigoPuesto);

                return Convert.ToString(rta.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
