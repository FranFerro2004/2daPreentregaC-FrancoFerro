using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiC_.Models
{
    public class Venta
    {

        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public Venta()
        {
            _id = 0;
            _comentarios = string.Empty;
            _idUsuario = 0;

        }

        public Venta(int id, string comentarios, int idUsuario)
        {
            this._id = id;
            this._comentarios = comentarios;
            this._idUsuario = idUsuario;

        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }

        public int IDUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

    }
}
