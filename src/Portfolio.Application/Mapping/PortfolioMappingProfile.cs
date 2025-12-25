using AutoMapper;
using Portfolio.Application.Dtos;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Mapping
{
    public class PortfolioMappingProfile : Profile
    {
        public PortfolioMappingProfile()
        {
            // Skill
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillCreateUpdateDto, Skill>();

            // Project
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectCreateUpdateDto, Project>();

            // Experience
            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceCreateUpdateDto, Experience>();

            // Content (note ContentText <-> Content)
            CreateMap<Content, ContentDto>()
                .ForMember(d => d.Content, opt => opt.MapFrom(s => s.ContentText));

            CreateMap<ContentCreateUpdateDto, Content>()
                .ForMember(d => d.ContentText, opt => opt.MapFrom(s => s.Content));

            // SocialMedia
            CreateMap<SocialMedia, SocialMediaDto>();
            CreateMap<SocialMediaCreateUpdateDto, SocialMedia>();

            // Qualification
            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationCreateUpdateDto, Qualification>();

            // ContactForm
            CreateMap<ContactForm, ContactFormDto>();
            CreateMap<ContactFormCreateDto, ContactForm>();

        }
    }
}
