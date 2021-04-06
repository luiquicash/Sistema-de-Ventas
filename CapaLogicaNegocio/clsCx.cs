using System.Data.SqlClient;

namespace CapaLogicaNegocio
{
    public class clsCx
    {
        public string conet = "Data Source=.;Initial Catalog=SalesSystemGym;Integrated Security=True";
        public SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SalesSystemGym;Integrated Security=True");
    }
}
