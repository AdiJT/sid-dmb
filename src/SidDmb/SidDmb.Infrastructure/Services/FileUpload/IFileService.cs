using Microsoft.AspNetCore.Http;
using SidDmb.Domain.Shared;

namespace SidDmb.Infrastructure.Services.FileUpload;

public interface IFileService
{
    bool IsExist(Uri uri);
    Result Delete(Uri uri);
    Task<Result<Uri>> UploadFile<TModel>(IFormFile formFile, string folderPath, string[] permittedExtension, long minSizeLimit, long maxSizeLimit);
}
