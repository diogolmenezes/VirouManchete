using System.Collections.Generic;
using System.Linq;
using VirouManchete.Entidade;
using VirouManchete.Negocio.Framework;

namespace VirouManchete.Negocio
{
    public class NoticiaBusiness : ServicoBase<Noticia>
    {
        public IList<Noticia> ListarMaisVistas(int inicio, int total)
        {

            return base.Filtrar().OrderByDescending(x => x.Visualizacoes).Skip(inicio).Take(total).ToList();
        }

        public IList<Noticia> ListarMaisRecentes(int inicio, int total)
        {
            return base.Filtrar().OrderByDescending(x => x.Data).Skip(inicio).Take(total).ToList();
        }

        public dynamic ListarMaisRecentesPorFormato(string formato, int total)
        {
            return base.Filtrar().Where(x=> x.Formato == formato).OrderByDescending(x => x.Data).Take(total).ToList();
        }
    }
}
