using ArtIsPain.Shared.Models;
using Bogus;
using MediatR;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.RequestExamples
{
    public abstract class BaseCommandExample<TRequest> : IExamplesProvider<TRequest> where TRequest : class, new()
    {
        public abstract TRequest GetExamples();
    }
}
