

using app.Models;
using ContratoPersistencia;

namespace app.Servicos;
 public class Persistencia
    {
        public Persistencia(APersistencia _persistencia)
        {
            this.persistencia = _persistencia;
        }

        private APersistencia persistencia;

        public void Salvar(Cliente cliente)
        {
            persistencia.Incluir(cliente);
        }

        public List<IEntidade> Lista()
        {
            return persistencia.Buscar(typeof(Cliente));
        }
    }
