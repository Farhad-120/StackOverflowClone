using Microsoft.AspNetCore.Mvc;
using StackOverflowClone.Models;
using StackOverflowClone.Service;


namespace StackOverflowClone.Controllers
{
    public class AnswersController : Controller
    {
        private readonly QAService _qaService;

        public AnswersController(QAService qaService)
        {
            _qaService = qaService;
        }

        // GET: /Answers/Create?qId=5
        [HttpGet]
        public async Task<IActionResult> Create(int qId)
        {
            var question = await _qaService.GetQuestionByIdAsync(qId);
            if (question == null) return NotFound();

            // blank answer to bind
            var answer = new Answer { QuestionId = qId };

            // Passing question and existing answers to the view via ViewBag
            ViewBag.Question = question;

            return View(answer);
        }

        // POST: /Answers/Create?qId=5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int qId, Answer answer)
        {
            if (ModelState.IsValid)
            {
                await _qaService.AddAnswerAsync(qId, answer);
                return RedirectToAction("Create", new { qId = qId });
            }

            var question = await _qaService.GetQuestionByIdAsync(qId);
            ViewBag.Question = question;

            return View(answer);
        }
    }
}