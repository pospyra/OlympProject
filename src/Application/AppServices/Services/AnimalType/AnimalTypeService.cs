﻿using AppServices.IRepository;
using AutoMapper;
using Contracts.AnimalType;
using Domain;
using Infrastructure.Repositoty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.AnimalType
{
    public class AnimalTypeService : IAnimalTypeService
    {
        public readonly IAnimalTypeRepository _animalTypeRepository;
        public readonly IMapper _mapper;

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository, IMapper mapper) 
        {
            _animalTypeRepository = animalTypeRepository; 
            _mapper = mapper;
        }

        public async  Task<InfoTypeNameResponse> AddType(AddOrUpdateTypeRequest requestType)
        {
            var newType = _mapper.Map<Domain.AnimalType>(requestType);
            await _animalTypeRepository.AddType(newType);

            return _mapper.Map<InfoTypeNameResponse>(newType);
        }

        public async Task DeleteType(long id)
        {
            var existingType = await _animalTypeRepository.GetAnimalTypeById(id);

            await _animalTypeRepository.DeleteType(existingType);
        }

        public async Task<InfoTypeNameResponse> EditType(long Id, AddOrUpdateTypeRequest requestType)
        {
            var existingType = await _animalTypeRepository.GetAnimalTypeById(Id);

            await _animalTypeRepository.EditType(_mapper.Map(requestType, existingType));

            return _mapper.Map<InfoTypeNameResponse>(requestType);
        }

        public async Task<InfoTypeNameResponse> GetInfoAnimalType(long id)
        {
            var animalType = await _animalTypeRepository.GetAnimalTypeById(id);

            InfoTypeNameResponse typeRes= null;
            if (animalType == null)
                return typeRes;

            return _mapper.Map<InfoTypeNameResponse>(animalType);      
        }
    }
}
