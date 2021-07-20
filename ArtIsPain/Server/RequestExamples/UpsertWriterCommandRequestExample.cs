using ArtIsPain.Server.Commands.Writers;
using Bogus;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtIsPain.Server.RequestExamples
{
    public class UpsertWriterCommandRequestExample : BaseCommandExample<UpsertWriterCommand>
    {
        public override UpsertWriterCommand GetExamples()
        {
            Faker<UpsertWriterCommand> faker = new Faker<UpsertWriterCommand>();

            return faker
                .RuleFor(w => w.Title, (f, w) => string.Concat(f.Name.FirstName(), " ", f.Name.LastName()))
                .RuleFor(w => w.Biography, (f, w) => f.Lorem.Paragraphs(3))
                .RuleFor(w => w.StartActivityDate, (f, w) => f.Date.Past(20))
                    .Generate();
        }
    }
}
