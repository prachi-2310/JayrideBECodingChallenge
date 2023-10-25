using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JayrideBECodingChallenge.Models;

namespace JayrideBECodingChallenge.Controllers
{
    public class CandidateController : ApiController
    {
        public CandidateClass Get()
        {
            CandidateClass candidateClass = new CandidateClass();
            candidateClass.name = "test";
            candidateClass.phone = "test";

            return candidateClass;
        }
    }
}
