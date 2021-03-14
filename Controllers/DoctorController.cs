using DoctorScheduling.DAL.Models;
using DoctorScheduling.DAL.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using DoctorScheduling.DAL;

namespace DoctorSchedulingApplication.Controllers
{
    public class DoctorController : ApiController
    {
        // GET api/values
        DoctorRepository _repository = new DoctorRepository();
       [HttpPost]
        public HttpResponseMessage FindDoctor(SearchSpec spec)
        {           
          
            try
            {
                var _doctors = _repository.FindDoctorBySpec(spec);
                if (_doctors.Count==0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return this.Request.CreateResponse<List<Doctor>>(
                     HttpStatusCode.OK, _doctors);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }


    }
}
