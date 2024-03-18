using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var streamFile = file.OpenReadStream();

        var isImage = streamFile.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
        {
          
            var user = GetFromDatabase();

            _storageService.Upload(file, user);
        }
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Test",
            Email = "matheusphillipo@gmail.com",
            RefreshToken = "1//04xrS30laiISUCgYIARAAGAQSNwF-L9IrkHdRMjkRXYJeEJO1x9p7E6vrjv_pdJgx9R3z0xMU6krLOuzfkwyaYwvexNPZon01hUY",
            AccessToken = "ya29.a0Ad52N3_gMCPZFfUbpQ1CWOWriiwkHWDVBSgTTtVDFN8im7Pn8RoTVxCP_NuPY4qQxNOuMbrAqg2Jqho1fj3nkgiGFguS2LT2gKx61zgeT4KVlSC23EiemI5drCUMypWrmLkxBba9aRlE1d8h_vyOKzzS5q2fJ5pwKibNaCgYKAZoSARMSFQHGX2MijLOdh_K64Sx3Hkci93etmQ0171"
        };
    }
}


