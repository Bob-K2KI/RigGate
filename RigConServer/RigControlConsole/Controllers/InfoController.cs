﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Wa1gon.Models;
using System.IO.Ports;
using Wa1gon.ServerInfrastructure;
using Microsoft.Owin;
namespace Wa1gon.RigControl.Controllers
{
    [RoutePrefix("api/v1")]
    public class InfoController : ApiController 
    {

        // GET api/values 
        [Route("Info")]
        public ServerInfo Get()
        {
            var ctx = new OwinContext();
            var info = ServerState.Create();
            var q = ctx.Request.Query;
            return info.ServerInfo;
        }      
    }
}
