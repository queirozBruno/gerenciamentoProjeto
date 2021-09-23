using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterUsuariosClassificadosPorNome()
        {
            return context.usuarios.OrderBy(n => n.UsuarioNome);
        }

        public void GravarUsuarios(Usuario usuario)
        {
            if (usuario.UsuarioId == null)
            {
                context.usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Usuario ObterUsuarioPorId(long id) => context.usuarios.Where(u => u.UsuarioId == id).First();

        public Usuario ObterTodosOsDadosDoUsuarioPorId(long id)
        {
            return context.usuarios.Where(u => u.UsuarioId == id).Include(cuu => cuu.CursoUsuarios).Include(ceu => ceu.CertificadoUsuarios).Include(idu => idu.IdiomaUsuarios).Include(liu => liu.LinguagemUsuarios).Include(puu => puu.PublicacaoUsuarios).Include(cou => cou.CompetenciaUsuarios).Include(fou => fou.FormacaoAcademicas).Include(exu => exu.Experiencias).First();
        }

        public Usuario ObterUsuarioPorEmail(Usuario usuario)
        {
            return context.usuarios.Where(u => u.UsuarioEmail.Equals(usuario.UsuarioEmail)).FirstOrDefault();
        }

        public Usuario AdicionarIntegrantePorEmail(string email) => context.usuarios.Where(u => u.UsuarioEmail.Equals(email)).FirstOrDefault();

        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = ObterUsuarioPorId(id);
            context.usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }

        public IQueryable ObterUsuarioPorCPF(string cpf) => context.usuarios.Where(u => u.UsuarioCPF.Contains(cpf));
    }
}
