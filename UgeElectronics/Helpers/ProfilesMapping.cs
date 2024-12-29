using AutoMapper;
using Microsoft.AspNetCore.Http;
using UgeElectronics.Core.Dto;
using UgeElectronics.Core.Entity;
using UgeElectronics.Core.Entity.Basket;
using UgeElectronics.Dtos.BasketDto;

namespace Sales_System.Api.Helpers
{
    public class ProfilesMapping : Profile
    {
        public ProfilesMapping()
        {
            #region Map ProductRequestDto to Product
            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductGallery, opt => opt.MapFrom(src => SaveFilesPhoto(src.ProductGallery!, "ProductGallery")));
            #endregion

            #region Map ProductRequestDto to Product
            CreateMap<CategoryRequestDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemsDto, BasketItems>();
        }



















        // Method to save the files and return the list of file URLs
        private List<string> SaveFilesPhoto(List<IFormFile> files, string folderName)
        {
            var images = new List<string>();

            foreach ( var file in files )
            {
                var fileUrl = SaveFile(file, folderName);
                if ( !string.IsNullOrEmpty(fileUrl) )
                {
                    images.Add(fileUrl); // Save the file URL in the list
                }
            }

            return images;
        }

        // Method to save a single file and return its URL
        private string SaveFile(IFormFile file, string folderName)
        {
            if ( file==null||file.Length==0 )
                return null;

            // Construct the path where the file will be saved
            string uploadsFolder = Path.Combine("wwwroot", "Photos", folderName);
            string uniqueFileName = Guid.NewGuid().ToString()+"_"+file.FileName;

            // Full path to the file
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Ensure the folder exists
            Directory.CreateDirectory(uploadsFolder);

            // Save the file to the specified path
            using ( var fileStream = new FileStream(filePath, FileMode.Create) )
            {
                file.CopyTo(fileStream);
            }

            // Construct the relative path (URL) for accessing the file
            string relativePath = Path.Combine("Photos", folderName, uniqueFileName);

            // Return the URL with forward slashes for web access
            return $"/{relativePath.Replace("\\", "/")}";
        }
    }
}
