using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.WebApi.RequestModels.TagRequestModels;
using OnionLibrary.WebApi.ResponseModels.TagResponseModel;

namespace OnionLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagManager _tagManager;
        private readonly IMapper _mapper;

        public TagController(ITagManager tagManager, IMapper mapper)
        {
            _tagManager = tagManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TagDto> dtos = await _tagManager.GetAllAsync();
            var response = _mapper.Map<List<TagResponseModel>>(dtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TagDto dto = await _tagManager.GetByIdAsync(id);
            var response = _mapper.Map<TagResponseModel>(dto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagRequestModel model)
        {
            TagDto dto = _mapper.Map<TagDto>(model);
            await _tagManager.CreateAsync(dto);
            return Ok("Etiket başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTagRequestModel model)
        {
            TagDto dto = _mapper.Map<TagDto>(model);
            await _tagManager.UpdateAsync(dto);
            return Ok("Etiket başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result = await _tagManager.DeleteAsync(id);
            return Ok(result);
        }
    }
}
