using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SidDmb.Domain.Shared;
using SidDmb.Infrastructure.Configurations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace SidDmb.Infrastructure.Services.FileUpload;

internal class FileService : IFileService
{
    private static readonly byte[] _allowedChars = { };

    //TODO:Tambah file signature untuk file pdf
    private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".gif", new List<byte[]> { new byte[] { 0x47, 0x49, 0x46, 0x38 } } },
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
            { ".zip", new List<byte[]>
                {
                    new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                    new byte[] { 0x50, 0x4B, 0x4C, 0x49, 0x54, 0x45 },
                    new byte[] { 0x50, 0x4B, 0x53, 0x70, 0x58 },
                    new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                    new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                    new byte[] { 0x57, 0x69, 0x6E, 0x5A, 0x69, 0x70 },
                }
            },
        };

    private readonly ILogger<FileService> _logger;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly FileConfigurationOptions _fileConfigurationOptions;

    public FileService(
        ILogger<FileService> logger,
        FileConfigurationOptions fileConfigurationOptions,
        IHostingEnvironment hostingEnvironment)
    {
        _logger = logger;
        _fileConfigurationOptions = fileConfigurationOptions;
        _hostingEnvironment = hostingEnvironment;
    }

    public bool IsExist(Uri uri)
    {
        var filePath = uri.ToString();

        var fileInfo = _hostingEnvironment.WebRootFileProvider.GetFileInfo(filePath);

        return fileInfo.Exists;
    }

    public Result Delete(Uri uri)
    {
        var filePath = Path.GetFullPath($"{_hostingEnvironment.WebRootPath}{uri.ToString()}");

        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Hapus File : {@filePath}!", filePath);

            return new Error("FileService.Delete", "Hapus file gagal!");
        }

        return Result.Success();
    }

    public async Task<Result<Uri>> UploadFile<TModel>(
        IFormFile formFile,
        string folderPath,
        string[] permittedExtension,
        long minSizeLimit,
        long maxSizeLimit)
    {
        var fullFolderPath = Path.GetFullPath(
            $"{_hostingEnvironment.WebRootPath}" +
            $"{_fileConfigurationOptions.FolderPath}" +
            $"{folderPath}");

        try
        {
            EnsureDirectoryCreated(fullFolderPath);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create Directory Failed. Exception : {0}", ex.ToString());
            return new Error("FileService.UploadFailed", "Upload File Gagal");
        }

        var result = await ProcessFormFile<TModel>(formFile, permittedExtension, minSizeLimit, maxSizeLimit);
        if (result.IsFailure) return result.Error;

        var fileId = string.Join("", Guid.NewGuid().ToString().Split("-", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
        var fileName = $"{fileId}{Path.GetExtension(formFile.FileName)}";
        var filePath = $"{fullFolderPath}{Path.DirectorySeparatorChar}{fileName}";

        try
        {
            using (var fileStream = File.Create(filePath))
            {
                await fileStream.WriteAsync(result.Value);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Saving File to storage failed. Exception {0}", ex.ToString());

            return new Error("FileService.UploadFailed", "Upload File Gagal");
        }

        return new Uri($"{_fileConfigurationOptions.FolderPath}/{folderPath}/{fileName}", UriKind.Relative);
    }

    private void EnsureDirectoryCreated(string folderPath)
    {
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }

    private async Task<Result<byte[]>> ProcessFormFile<TModel>(IFormFile formFile,
            string[] permittedExtensions,
            long minSizeLimit,
            long maxSizeLimit)
    {
        var fieldDisplayName = string.Empty;

        // Use reflection to obtain the display name for the model
        // property associated with this IFormFile. If a display
        // name isn't found, error messages simply won't show
        // a display name.
        MemberInfo? property =
            typeof(TModel).GetProperty(
                formFile.Name.Substring(formFile.Name.IndexOf(".",
                StringComparison.Ordinal) + 1));

        if (property is not null)
        {
            if (property.GetCustomAttribute(typeof(DisplayAttribute)) is
                DisplayAttribute displayAttribute)
            {
                fieldDisplayName = $"{displayAttribute.Name} ";
            }
        }

        // Don't trust the file name sent by the client. To display
        // the file name, HTML-encode the value.
        var trustedFileNameForDisplay = WebUtility.HtmlEncode(
            formFile.FileName);

        //Scan Anti-Virus
        //var apiResponseResult = await _scaniiApiService.Files(formFile);
        //if(apiResponseResult.IsFailure) return apiResponseResult.Error;

        //if(apiResponseResult.Value.Findings.Length > 0) 
        //    return new Error("FileHelpers.ScanFailed", "File yang anda coba upload memiliki virus!");

        // Check the file length. This check doesn't catch files that only have 
        // a BOM as their content.
        if (formFile.Length == 0)
            return new Error("FileHelpers.FileEmpty",
                $"{fieldDisplayName}({trustedFileNameForDisplay}) kosong");

        if (formFile.Length < minSizeLimit)
        {
            var megabyteSizeLimit = minSizeLimit / (double)1048576;

            return new Error(
                "FileHelpers.FileSizeTooSmall",
                $"Ukuran {fieldDisplayName}({trustedFileNameForDisplay}) kurang dari " +
                $"{megabyteSizeLimit:N3} MB.");
        }

        if (formFile.Length > maxSizeLimit)
        {
            var megabyteSizeLimit = maxSizeLimit / (double)1048576;

            return new Error(
                "FileHelpers.FileSizeTooBig",
                $"Ukuran {fieldDisplayName}({trustedFileNameForDisplay}) lebih besar dari " +
                $"{megabyteSizeLimit:N3} MB.");
        }

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                // Check the content length in case the file's only
                // content was a BOM and the content is actually
                // empty after removing the BOM.
                if (memoryStream.Length == 0)
                    return new Error(
                        "FileHelpers.FileEmpty", $"{fieldDisplayName}({trustedFileNameForDisplay}) kosong.");

                if (!IsValidFileExtensionAndSignature(
                    formFile.FileName, memoryStream, permittedExtensions))
                    return new Error(
                        "FileHelpers.ExtensionAndSignatureNotValid",
                        $"Tipe file {fieldDisplayName}({trustedFileNameForDisplay}) " +
                        $"tidak didukung atau signature file tidak cocok dengan ekstensi file");

                return memoryStream.ToArray();
            }
        }
        catch (Exception ex)
        {
            // Log the exception

            return new Error(
                "FileHelpers.UploadFailed",
                $"{fieldDisplayName}({trustedFileNameForDisplay}) upload failed. " +
                $"Please contact the Help Desk for support. Error: {ex.HResult}");
        }
    }

    private bool IsValidFileExtensionAndSignature(string fileName,
        Stream data, string[] permittedExtensions)
    {
        if (string.IsNullOrEmpty(fileName) || data == null || data.Length == 0)
        {
            return false;
        }

        var ext = Path.GetExtension(fileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
        {
            return false;
        }

        data.Position = 0;

        using (var reader = new BinaryReader(data))
        {
            if (ext.Equals(".txt") || ext.Equals(".csv") || ext.Equals(".prn"))
            {
                if (_allowedChars.Length == 0)
                {
                    // Limits characters to ASCII encoding.
                    for (var i = 0; i < data.Length; i++)
                    {
                        if (reader.ReadByte() > sbyte.MaxValue)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    // Limits characters to ASCII encoding and
                    // values of the _allowedChars array.
                    for (var i = 0; i < data.Length; i++)
                    {
                        var b = reader.ReadByte();
                        if (b > sbyte.MaxValue ||
                            !_allowedChars.Contains(b))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            // Uncomment the following code block if you must permit
            // files whose signature isn't provided in the _fileSignature
            // dictionary. We recommend that you add file signatures
            // for files (when possible) for all file types you intend
            // to allow on the system and perform the file signature
            // check.

            if (!_fileSignature.ContainsKey(ext))
            {
                return true;
            }


            // File signature check
            // --------------------
            // With the file signatures provided in the _fileSignature
            // dictionary, the following code tests the input content's
            // file signature.
            var signatures = _fileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature =>
                headerBytes.Take(signature.Length).SequenceEqual(signature));
        }
    }
}
