using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(int Id)
        {
            UsuarioData.EliminarUsuario(new Usuario { Id = Id });
        }


    }

}