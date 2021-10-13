using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPdfFileSupport
    {
        Task SaveFileToServer(IFormFile file, string studentCode);
        Task<string> UploadFileToFirebase(string studentCode);
    }
}
