using BlueSense.Models;

namespace BlueSense.Persistence.Interface
{
    public interface INotificacaoRepositorio
    {
        IEnumerable<Notificacao> GetAll();

        Notificacao GetById(int? ID);

        void Add(Notificacao notificacao);

        void Update(Notificacao notificacao);

        void Delete(Notificacao notificacao);
    }
}
