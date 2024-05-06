using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Core.Exceptions;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services;

public class SetsService:ISetsService
{
    private readonly SetMapper _mapper;
    private readonly ApplicationDbContext _context;

    public SetsService(ApplicationDbContext context)
    {
        _context = context;
        _mapper = new SetMapper();
    }

    public async Task<Guid> CreateAsync(CreateSetModel model)
    {
        Set setToCreate = _mapper.CreateSetToSet(model);

        await _context.AddAsync(setToCreate);

        await _context.SaveChangesAsync();

        return setToCreate.Id;
    }

    public async Task UpdateAsync(Guid id, UpdateSetModel model)
    {
        Set? setToUpdate = await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);

        if (setToUpdate == null)
        {
            throw new NotFoundException($"Set '{id}' not found");
        }

        _mapper.UpdateSetToSet(model,setToUpdate);

        _context.Update(setToUpdate);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        Set? setToDelete = await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);

        if (setToDelete == null)
        {
            throw new NotFoundException($"Set '{id}' not found");
        }

        _context.Sets.Remove(setToDelete);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Set>> GetAllAsync(int page, string? search)
    {
        int take = 10;

        var query = _context.Sets.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(s => s.Title.ToLower().Contains(search.ToLower()));
        }
        
        return await query.OrderByDescending(s=>s.CreatedAt)
            .Skip((page-1)*10)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Set?> GetByIdAsync(Guid id)
    {
        return await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);
    }
}