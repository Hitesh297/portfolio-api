using AutoMapper;
using Portfolio.Application.Abstractions;
using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _repo;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SocialMediaDto>> GetAsync(CancellationToken ct)
        {
            var entities = await _repo.GetAllAsync(ct);
            var ordered = entities
                .OrderBy(s => s.Sequence)
                .ToList();

            return _mapper.Map<IReadOnlyList<SocialMediaDto>>(ordered);
        }
    }
}
