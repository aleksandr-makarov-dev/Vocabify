using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Core.Exceptions;
using Vocabify.API.Modules.Terms.Models;

namespace Vocabify.API.Modules.Terms.Services
{
    public class TermsService:ITermsService
    {
        private readonly ApplicationDbContext _context;
        private readonly TermMapper _mapper;

        public TermsService(ApplicationDbContext context)
        {
            _context = context;
            _mapper = new TermMapper();
        }

        public async Task<Guid> CreateAsync(CreateTermModel model)
        {
            Term term = _mapper.CreateTermToTerm(model);

            await _context.AddAsync(term);

            await _context.SaveChangesAsync();

            return term.Id;
        }

        public async Task UpdateAsync(Guid id, UpdateTermModel model)
        {
            Term? termToUpdate = await _context.Terms.FirstOrDefaultAsync(t => t.Id == id);

            if (termToUpdate == null)
            {
                throw new NotFoundException($"Term '{id}' not found");
            }

            _mapper.UpdateTermToTerm(model, termToUpdate);

            _context.Update(termToUpdate);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Term? termToDelete = await _context.Terms.FirstOrDefaultAsync(t => t.Id == id);

            if (termToDelete == null)
            {
                throw new NotFoundException($"Term '{id}' not found");
            }

            _context.Terms.Remove(termToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Term>> GetBySetIdAsync(Guid setId)
        {
            return await _context.Terms.Where(t => t.SetId == setId).ToListAsync();
        }

        public async Task<IEnumerable<Guid>> CreateRangeAsync(IEnumerable<CreateTermModel> list)
        {
            IEnumerable<Term> termsToAdd = list.Select(_mapper.CreateTermToTerm).ToList();

            await _context.Terms.AddRangeAsync(termsToAdd);

            await _context.SaveChangesAsync();

            return termsToAdd.Select(t => t.Id);
        }
    }
}
