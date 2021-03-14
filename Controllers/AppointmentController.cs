
using DoctoringScheduling.DAL.Repositories.Implementation;
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
    public class AppointmentController : ApiController
    {
        BookAppointmentRepositoriy _repository = new BookAppointmentRepositoriy();
        [HttpPost]
        public HttpResponseMessage BookAppointment(DoctorAppointment appointment)
        {
            
            try
            {

                var _bookAppointment = _repository.BookAppointment(appointment);
                if (!_bookAppointment)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                else
                {
                    return this.Request.CreateResponse<bool>(
                     HttpStatusCode.OK, _bookAppointment);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

    }
}
