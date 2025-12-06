using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionLibrary.Application.DTOClasses;
using OnionLibrary.Application.ManagerInterfaces;
using OnionLibrary.WebApi.RequestModels.CategoryRequestModels;
using OnionLibrary.WebApi.ResponseModels.CategoryResponseModel;

namespace OnionLibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        // QUERY: Tüm Kategorileri Listele
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // 1. Manager'dan DTO listesini çek
            List<CategoryDto> dtos = await _categoryManager.GetAllAsync();

            // 2. DTO'ları UI dostu ResponseModel'e çevir
            var response = _mapper.Map<List<CategoryResponseModel>>(dtos);

            return Ok(response);
        }

        // QUERY: ID'ye Göre Kategori Getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // 1. Manager'dan tekil veriyi çek
            CategoryDto dto = await _categoryManager.GetByIdAsync(id);

            // 2. DTO'yu ResponseModel'e çevir
            var response = _mapper.Map<CategoryResponseModel>(dto);

            return Ok(response);
        }

        // COMMAND: Yeni Kategori Ekle
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequestModel model)
        {
            // 1. Gelen RequestModel'i DTO'ya dönüştür
            CategoryDto dto = _mapper.Map<CategoryDto>(model);

            // 2. Manager üzerinden veritabanına kaydet
            await _categoryManager.CreateAsync(dto);

            return Ok("Kategori başarıyla eklendi");
        }

        // COMMAND: Kategoriyi Güncelle
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequestModel model)
        {
            // 1. Gelen Update modelini DTO'ya dönüştür
            CategoryDto dto = _mapper.Map<CategoryDto>(model);

            // 2. Manager üzerinden güncelleme işlemini yap
            await _categoryManager.UpdateAsync(dto);

            return Ok("Kategori başarıyla güncellendi");
        }

        // COMMAND: Kategoriyi Sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Manager'dan dönen string mesajı (örn: "Id'li veri silindi") direkt kullanıcıya dön
            string result = await _categoryManager.DeleteAsync(id);
            return Ok(result);
        }
    }
}
