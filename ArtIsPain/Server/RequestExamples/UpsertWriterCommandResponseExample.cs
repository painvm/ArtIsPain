using System;
using ArtIsPain.Server.RequestExamples;
using ArtIsPain.Server.ViewModels.Writer;
using Bogus;

namespace Server.RequestExamples
{
    public class UpsertWriterCommandResponseExample : BaseCommandExample<WriterViewModel>
    {
        public override WriterViewModel GetExamples()
        {
            Faker<WriterViewModel> faker = new Faker<WriterViewModel>();

            return faker
                .RuleFor(w => w.Title, (f) => string.Concat(f.Name.FirstName(), " ", f.Name.LastName()))
                .RuleFor(w => w.Biography, (f) => f.Lorem.Paragraphs(3))
                .RuleFor(w => w.StartActivityDate, (f) => f.Date.Past(20))
                .RuleFor(w => w.Id, () => Guid.NewGuid())
                    .Generate();
        }
    }
}