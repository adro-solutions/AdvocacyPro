using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdvocacyPro.Web.Controllers.Base;
using AdvocacyPro.Models;
using AdvocacyPro.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using AdvocacyPro.Models.Constants;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvocacyPro.Web.Controllers
{
    [Route("api/cases/{caseId}/documents"), Authorize(Policy = ProductFeatures.CaseDocuments)]
    public class CaseDocumentsController : CaseChildBaseController<CaseDocumentLogic, CaseDocument>
    {
        public CaseDocumentsController(CaseDocumentLogic logic) : base(logic)
        {
        }

        [HttpPost("{id}/file")]
        public async Task<IActionResult> PostFile(int caseId, int id)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.First();
                if (file.Length > 5 * 1024 * 1024)
                    return BadRequest("File size greater than 5MB.");

                var s = new MemoryStream();
                await file.CopyToAsync(s);
                var fileBytes = s.ToArray();
                return Ok(await logic.Upload(id, caseId, this.OrganizationId, this.UserId, file.FileName, fileBytes));
            }
            else
                return BadRequest();
        }

        [HttpGet("{id}/file")]
        public async Task<FileStreamResult> GetFile(int caseId, int id)
        {
            Stream s = new MemoryStream(await logic.Download(id, caseId, this.OrganizationId));
            return new FileStreamResult(s, "application/octet-stream");
        }
    }
}
