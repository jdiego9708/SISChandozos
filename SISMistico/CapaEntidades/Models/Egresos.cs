﻿namespace CapaEntidades.Models
{
    using CapaEntidades.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Egresos
    {
        public Egresos()
        {

        }

        public Egresos(DataRow row)
        {
            try
            {
                this.Id_egreso = Convert.ToInt32(row["Id_egreso"]);
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Empleado = new Empleados(row);
                this.Fecha_egreso = Convert.ToDateTime(row["Fecha_egreso"]);
                this.Hora_egreso = ConvertValueHelper.ConvertirHora(row["Hora_egreso"]);
                this.Valor_egreso = Convert.ToDecimal(row["Valor_egreso"]);
                this.Descripcion_egreso = Convert.ToString(row["Descripcion_egreso"]);
                this.Estado_egreso = Convert.ToString(row["Estado_egreso"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_egreso { get; set; }
        public int Id_empleado { get; set; }
        public int Id_turno { get; set; }
        public Empleados Empleado { get; set; }
        public DateTime Fecha_egreso{ get; set; } = DateTime.Now;
        public TimeSpan Hora_egreso { get; set; }
        public decimal Valor_egreso { get; set; }
        public string Descripcion_egreso { get; set; }
        public string Estado_egreso { get; set; }
    }
}
