using DoctorScheduling.DAL.Models;
using DoctorScheduling.DAL.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorSchedulingApplication.Controllers
{
    public class PatientController : ApiController
    {
        PatientRepository _patientRepository = new PatientRepository();
        [HttpPost]
        // This method checks if patient exist by email
        // if not create the new patient
        public HttpResponseMessage AddPatient(Patient patient )
        {

            try
            {
                var _Patient = _patientRepository.AddPatient(patient);
                if (_Patient.PatientID==0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    return this.Request.CreateResponse<Patient>(
                     HttpStatusCode.OK, _Patient);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }


    }
}
