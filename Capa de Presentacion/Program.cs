using System;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.      
        /// </summary>
        /// 
        public static bool abierto;
        public static bool abiertosecundarias;
        public static int Evento;
        public static int Eid;
        public static int idgastos;
        public static string LoginStatus;
        public static string ReImpresion;
        public static string Esabono;

        //Datos del Cliente
        public static int IdCliente;
        public static string DocumentoIdentidad;
        public static string NombreCliente;
        public static string ApellidosCliente;
        public static string datoscliente;

        //Datos del Cliente2
        public static int IdCliente2;

        //Datos del Equipo
        public static int Id;
        public static string cedula;
        public static string nombres;
        public static int Id4;
        public static string nombre4;
        public static string apellido4;
        public static string tipopago4;
        public static string fecha4;
        public static decimal precio;
        public static decimal pago;
        public static decimal pago4;
        public static decimal ST;
        public static decimal igv;
        public static string nota;
        public static string fecha;

        //Datos del Comprobante
        public static string tipo;
        public static string NCF;
        public static string NroComprobante;

        //Datos del Producto
        public static int IdProducto;
        public static int IdCategoria;
        public static string Descripcion;
        public static string Marca;
        public static int Stock;
        public static decimal itbis;
        public static decimal PrecioVenta;
        public static string tipogoma;

        //Datos del Empleado
        public static int IdCargo;
        public static string EstadoCivil;
        public static int IdEmpleado;

        //Variables de Sesion
        public static int IdEmpleadoLogueado;
        public static string NombreEmpleadoLogueado;
        public static string CargoEmpleadoLogueado;

        public static int IdEmpleadoLogueado1;
        public static string NombreEmpleadoLogueado1;
        public static string CargoEmpleadoLogueado1;
        public static bool realizopago;

        //turno
        public static double turno;

        //Pagos
        public static decimal pagocon;
        public static decimal pagoRealizado;
        public static decimal Devuelta;
        public static decimal Monto;
        public static decimal Caja;
        public static int idPago;
        public static int idcaja;
        public static string Fechapago;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
