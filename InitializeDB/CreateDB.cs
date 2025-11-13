
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CEN.Diag;
using DiagGen.Infraestructure.Repository.Diag;
using DiagGen.Infraestructure.CP;
using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.CP.Diag;
using DiagGen.Infraestructure.Repository;
using DiagGen.ApplicationCore.Enumerated.Diag;
using DiagGen.Infraestructure.EN.Diag;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                RolRepository rolrepository = new RolRepository ();
                RolCEN rolcen = new RolCEN (rolrepository);
                FavoritoRepository favoritorepository = new FavoritoRepository ();
                FavoritoCEN favoritocen = new FavoritoCEN (favoritorepository);
                DireccionEnvioRepository direccionenviorepository = new DireccionEnvioRepository ();
                DireccionEnvioCEN direccionenviocen = new DireccionEnvioCEN (direccionenviorepository);
                MetodoPagoRepository metodopagorepository = new MetodoPagoRepository ();
                MetodoPagoCEN metodopagocen = new MetodoPagoCEN (metodopagorepository);
                ProductoRepository productorepository = new ProductoRepository ();
                ProductoCEN productocen = new ProductoCEN (productorepository);
                PedidoItemRepository pedidoitemrepository = new PedidoItemRepository ();
                PedidoItemCEN pedidoitemcen = new PedidoItemCEN (pedidoitemrepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
                int idRolComprador = rolcen.Crear ("Comprador", "Usuario que compra productos");
                int idRolAdmin = rolcen.Crear ("Administrador", "Usuario que gestiona el sistema");

                Console.WriteLine ("se han creado los roles:", idRolAdmin, idRolComprador);

                int usuComprador = usuariocen.Registrarse ("carmen", "cvm@ua.es", "Av. ronda", idRolComprador, "1234");
                int usuAdmin = usuariocen.Registrarse ("Juan", "juan@ua.es", "Calle Mayor 5", idRolAdmin, "abcd");

                Console.WriteLine ("Se ha creado los usuarios:", usuComprador, usuAdmin);

                int idProd1 = productocen.Publicar ("Ordenador", "Ordenador de segunda mano", 15.99f, "ordenador.jpg", 100, 5.0, "PC");
                int idProd2 = productocen.Publicar ("Rat�n", "Rat�n de segunda mano", 29.99f, "raton.jpg", 50, 3.0, "Ratón");
                int idProd3 = productocen.Publicar ("Cable", "Cable sin usar", 59.99f, "cable.jpg", 25, 5.0, "Cable");

                Console.WriteLine ("productos:" + idProd1 + idProd2 + idProd3);

                int idDir1 = direccionenviocen.Guardar ("Calle Primavera", "Alicante", "03001", "Espa�a", usuComprador);
                int idDir2 = direccionenviocen.Guardar ("Av. Mediterr�neo", "Elche", "03201", "Espa�a", usuAdmin);

                Console.WriteLine ("direcciones de envio:" + idDir1 + idDir2);

                int idMetodoPago1 = metodopagocen.Guardar ("Tarjeta", "1234567890123456", DateTime.Parse ("2027-05-01"), usuComprador);
                int idMetodoPago2 = metodopagocen.Guardar ("PayPal", "juan@paypal.com", DateTime.Parse ("2028-10-15"), usuAdmin);

                Console.WriteLine ("Metodo de pago:" + idMetodoPago1 + idMetodoPago2);

                var idPed1 = pedidocen.RealizarPedido (new DateTime (2025, 11, 12), 50, usuComprador, idDir1, idMetodoPago1);

                int fav1 = favoritocen.MarcarFavorito (usuComprador, idProd3);
                int fav2 = favoritocen.MarcarFavorito (usuAdmin, idProd1);

                Console.WriteLine ("productos en favoritos:" + favoritocen);

                int idPedItem1 = pedidoitemcen.New_ (1, 50.21f, idProd3, idPed1);

                IList<ProductoEN> productosPorPalabra = productocen.BuscarPorPalabra ("Ordenador", "Ordenador de segunda mano");

                Console.WriteLine ("Consultar por palabra: 'Ordenador'");

                foreach (ProductoEN prod in productosPorPalabra) {
                        Console.WriteLine ("ID: " + prod.IdProducto +
                                ", Nombre: " + prod.Nombre +
                                ", Descripción: " + prod.Descripcion);
                }

                IList<ProductoEN> productosPorCategoria = productocen.Categoria ("PC");

                Console.WriteLine ("Consultar por categoria:");

                foreach (ProductoEN prod in productosPorCategoria) {
                        Console.WriteLine ("ID: " + prod.IdProducto +
                                ", Nombre: " + prod.Nombre +
                                ", Descripción: " + prod.Descripcion +
                                ", Precio: " + prod.Precio);
                }

                IList<ProductoEN> valorarPorCategoria = productocen.ValorarPorCategoria ("PC");

                Console.WriteLine ("Valorar por categoria: ''");

                foreach (ProductoEN prod in productosPorCategoria) {
                        Console.WriteLine ("ID: " + prod.IdProducto +
                                ", Nombre: " + prod.Nombre +
                                ", Descripción: " + prod.Descripcion +
                                ", Precio: " + prod.Precio);
                }

                IList<ProductoEN> productosPorPrecio = productocen.PorPrecio (29.99f);

                Console.WriteLine ("Consultar productos con precio entre 20 y 60:");

                foreach (ProductoEN prod in productosPorPrecio) {
                        Console.WriteLine ("ID: " + prod.IdProducto +
                                ", Nombre: " + prod.Nombre +
                                ", Descripción: " + prod.Descripcion +
                                ", Precio: " + prod.Precio);
                }

                Console.WriteLine ("\nConsultar pedido por item:");

                IList<PedidoEN> pedidosPorItem = pedidocen.DamePedidoPorItem (idPedItem1);

                foreach (PedidoEN pedido in pedidosPorItem) {
                        Console.WriteLine ("Pedido encontrado: ID = " + pedido.IdPedido +
                                ", Fecha: " + pedido.Fecha +
                                ", Total: " + pedido.PrecioTotal );
                }






                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
