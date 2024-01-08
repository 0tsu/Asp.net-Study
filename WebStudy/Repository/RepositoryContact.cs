using EstudoWeb.Data;
using EstudoWeb.Models;

namespace EstudoWeb.Repository
{
    public class RepositoryContact : IRepositoryContact
    {
        private readonly BancoContext _bancoContext;

        public RepositoryContact(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContactsModel ListById(int id)
        {
            return _bancoContext.contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactsModel> searchAll()
        {
            return _bancoContext.contacts.ToList();
        }


        public ContactsModel Add(ContactsModel contact)
        {
            try
            {
                _bancoContext.contacts.Add(contact);
                _bancoContext.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return contact;
        }

        public ContactsModel Update(ContactsModel contact)
        {
            ContactsModel contactDB = ListById(contact.Id);
            if (contactDB == null) throw new Exception("Houve um erro na atualização");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;

            _bancoContext.contacts.Update(contactDB);
            _bancoContext.SaveChanges();
            
            return contactDB;
        }

        public bool Delete(int id)
        {
            ContactsModel contactDB = ListById(id);
            if (contactDB == null) throw new Exception("Houve um erro na deleção do contato");

            _bancoContext.contacts.Remove(contactDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
