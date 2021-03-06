﻿using PnPTemplateManager.Managers.Contracts;
using PnPTemplateManager.Models;
using System.Collections.Generic;
using System.Web.Http;
using PnPTemplateManager.Licensing;

namespace PnPTemplateManager.Controllers
{
    [ValidWizdomLicense]
    [RoutePrefix("api/wizdom/pnpmanager/templates")]
    public class PnPTemplateController : ApiController
    {
        private ITemplateManager templateManager;

        public PnPTemplateController(ITemplateManager templateManager)
        {
            this.templateManager = templateManager;
        }
        [HttpGet]
        [Route]
        public List<PnPFileInfo> GetPnPTemplates()
        {
            return templateManager.GetPnPTemplates();
        }

        [HttpPost, Route("create")]
        public PnPFileInfo GetPnPTemplateFileFromSite(CreatePnPTemplateRequest request)
        {
            return templateManager.GetPnPTemplateFileFromSite(request);
        }


        [HttpPost, Route("apply")]
        public string ApplyPnPTemplateOnSite(ApplyPnPTemplateRequest request)
        {
            return templateManager.ApplyPnPTemplateOnSite(request);
        }

        [HttpGet, Route("delete")]
        public string DeletePnPPackageFile([FromUri] string pnpPackageName)
        {
            return templateManager.DeletePnPPackageFile(pnpPackageName);
        }

        [HttpGet, Route("download")]
        public string SendPnPPackageFile([FromUri] string pnpPackageName)
        {
            return templateManager.SendPnPPackageFile(pnpPackageName);
        }

        


        [HttpPost, Route("save")]
        public void SavePnPPackage()
        {
            templateManager.SavePnPPackage();
            Ok();
        }

    }
}
