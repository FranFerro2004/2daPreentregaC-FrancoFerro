using SistemaGestionData;
using SistemaGestionEntidades;


namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        public static List<Usuario> ObtenerUsuario(int IdUsuario)
        {
            return UsuarioData.ObtenerUsuario(IdUsuario);
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