using SistemaGestionData;
using SistemaGestionEntidades;


namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {

        public static Usuario ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            return UsuarioData.ObtenerUsuarioPorUsuarioYPassword(usuario, password);
        }


        public static List<Usuario> ObtenerUsuarioPorNombreDeUsuario(string nombreUsuario)
        {
            return UsuarioData.ObtenerUsuarioPorNombre(nombreUsuario);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            try 
            {

                UsuarioData.ModificarUsuario(usuario);

                return true;

            }
            catch
            {
                return false;
            }
            
                
        }

        public static void EliminarUsuario(int Id)
        {
            UsuarioData.EliminarUsuario(new Usuario { Id = Id });
        }


    }

}