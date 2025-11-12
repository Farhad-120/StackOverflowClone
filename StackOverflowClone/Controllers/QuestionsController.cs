using Microsoft.AspNetCore.Mvc;
using StackOverflowClone.Models;
using StackOverflowClone.Service;

namespace StackOverflowClone.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QAService _ser;
        public QuestionsController(QAService ser)
        {
            _ser = ser;
        }
        public async Task<IActionResult> Index()
        {
            var questions = await _ser.GetAllQuestionsAsync();
            return View(questions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var q= await _ser.GetQuestionByIdAsync(id);
            if (q == null) return NotFound();
            return View(q);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Question question)
        {

            if(ModelState.IsValid)
            {
                question.PostedDate = DateTime.UtcNow;
                await _ser.AddQuestionAsync(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var q = await _ser.GetQuestionByIdAsync(id);
            if (q == null) return NotFound();
            return View(q);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ser.DeleteQuestionAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
 