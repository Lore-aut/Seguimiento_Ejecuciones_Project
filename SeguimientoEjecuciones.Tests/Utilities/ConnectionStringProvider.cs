using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.DataAccess.Tests.Utilities
{/// <summary>
/// Proveedor de cadena de conexion
/// </summary>
    public static class ConnectionStringProvider
    {    ///<summary> Obtiene la cadena de conexion a utilizar en las pruebas </summary>
        public static string GetConnectionString() => "Data Source=Data.sqlite";
    }
}
