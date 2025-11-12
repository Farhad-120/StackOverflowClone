using Microsoft.EntityFrameworkCore;
using StackOverflowClone.Data;
using StackOverflowClone.Models;

namespace StackOverflowClone.Service
{
    public class QAService
    {
        private readonly AppDbContext _context;
        public QAService(AppDbContext context) => _context = context;

        public async Task AddQuestionAsync(Question q)
        {
            _context.Questions.Add(q);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllQuestionsAsync() =>
            await _context.Questions.Include(q => q.Answers)
            .OrderByDescending(q => q.PostedDate).ToListAsync();

        public async Task<Question?> GetQuestionByIdAsync(int id) =>
            await _context.Questions.Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.Id == id);

        public async Task AddAnswerAsync(int qId, Answer a)
        {
            a.QuestionId = qId;
            _context.Answers.Add(a);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var q = await _context.Questions.FindAsync(id);
            if (q == null) return;
            _context.Questions.Remove(q);
            await _context.SaveChangesAsync();
        }


    }
}
