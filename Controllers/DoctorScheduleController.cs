using DoctoringScheduling.DAL.Repositories.Implementation;
using DoctorScheduling.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoctorSchedulingApplication.Controllers
{
    public class DoctorScheduleController : ApiController
    {
        DoctorAvailableScheduleRepository _avblScdrepository = new DoctorAvailableScheduleRepository();
        public HttpResponseMessage  CheckDoctorAvailableSchedule(int doctorId, DateTime date)
        {
            try
            {
                var _avlschedule = _avblScdrepository.FindDoctorAvailableSchedule(doctorId, date);
                if (_avlschedule.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return this.Request.CreateResponse<List<DoctorScheduling.DAL.Models.DoctorSchedule>>(
                     HttpStatusCode.OK, _avlschedule);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
