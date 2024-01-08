using EstudoWeb.Models;
using EstudoWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EstudoWeb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IRepositoryContact _repositoryContact;

        public ContactsController(IRepositoryContact repositoryContact)
        {
            _repositoryContact = repositoryContact;
        }

        public IActionResult Index()
        {
            List<ContactsModel> contacts = _repositoryContact.searchAll();
            return View(contacts);
        }
        public IActionResult UpdatePage(int id)
        {
            ContactsModel contacts = _repositoryContact.ListById(id);
            return View(contacts);
        }
        public IActionResult CreatePage()
        {
            return View();
        }
        public IActionResult ConfirmationPage(int id)
        {
            ContactsModel contact = _repositoryContact.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            //A way that I did alone that I intend to analyze more calmly
            //try
            //{
            //    bool wasRemoved = _repositoryContact.Delete(id);
            //    TempData["SucessesMenseger"] = "Contato Removido com sucesso";
            //    return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{
            //    TempData["ErrorMensager"] = $"Houve algum erro na Remoção do contato {ex.ToString}";
            //    return RedirectToAction("Index");
            //}

            //the way it was in the study material
            try
            {
                bool wasRemoved = _repositoryContact.Delete(id);
                if (wasRemoved)
                {
                    TempData["SucessesMenseger"] = "Contato Removido com sucesso";
                }
                else
                {
                    TempData["ErrorMensager"] = $"Houve algum erro na Remoção do contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMensager"] = $"Houve algum erro na Remoção do contato {ex.ToString}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactsModel contacts)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _repositoryContact.Add(contacts);
                    TempData["SucessesMenseger"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("CreatePage",contacts);

            }
            catch (Exception ex)
            {
                TempData["ErrorMensager"] = $"Houve algum erro no Cadastrado do contato {ex.ToString}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(ContactsModel contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryContact.Update(contacts);
                    TempData["SucessesMenseger"] = "Contato Atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("UpdatePage", contacts);
            }
            catch (Exception ex)
            {
                TempData["ErrorMensager"] = $"Houve algum erro na Atualição do contato {ex.ToString}";
                return RedirectToAction("Index");
            }
        }
    }
}
