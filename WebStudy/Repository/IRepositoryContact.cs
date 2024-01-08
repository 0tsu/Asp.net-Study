using EstudoWeb.Models;

namespace EstudoWeb.Repository
{
    public interface IRepositoryContact
    {
        ContactsModel ListById(int id);
        List<ContactsModel> searchAll();
        ContactsModel Add(ContactsModel contact);
        ContactsModel Update(ContactsModel contact);
        bool Delete(int id);
    }
}
