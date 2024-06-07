using BlueSense.Models;
using BlueSense.Persistence.Interface;
using BlueSense.Persistence;

namespace BlueSense.Persistence.Repositorios
{
    public class NotificacaoRepositorio : INotificacaoRepositorio
    {
        private readonly FIAPDbContext _context;

        public NotificacaoRepositorio(FIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Notificacao notificacao)
        {
            _context.Add(notificacao);

            _context.SaveChanges();
        }

        public void Delete(Notificacao notificacao)
        {
            _context.Remove(notificacao);

            _context.SaveChanges();
        }

        public IEnumerable<Notificacao> GetAll()
        {
            throw new NotImplementedException();
        }

        public Notificacao GetById(int? ID)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Notificacao> GetAll()
        //{
        //    return _context.Notificacoes.ToList();
        //}

        //public Notificacao GetById(int? id)
        //{
        //    return _context.Notificacoes.Find(id);
        //}

        public void Update(Notificacao notificacao)
        {
            _context.Update(notificacao);

            _context.SaveChangesAsync();
        }
    }
}
