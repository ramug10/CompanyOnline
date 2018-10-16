using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using CompanySystem.Web.Models;

namespace CompanySystem.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        private ICompanySystemRepository _repo;

        public BaseApiController(ICompanySystemRepository repo)
        {
            _repo = repo;
        }

        protected ICompanySystemRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        private ModelFactory _modelFactory;

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }
                return _modelFactory;
            }
        }
    }
}