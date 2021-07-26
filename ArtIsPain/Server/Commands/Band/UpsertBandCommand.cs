using ArtIsPain.Server.ViewModels.Band;
using System;

namespace ArtIsPain.Server.Commands.Band
{
    public class UpsertBandCommand : IUpsertEntityCommand<BandViewModel>
    {
        public Guid? EntityId { get; set; }

        /// <example>David Bowie was an English singer-songwriter and actor. He was a leading figure in the music industry and is considered one of the most influential musicians of the 20th century, acclaimed by critics and musicians, particularly for his innovative work during the 1970s. His career was marked by reinvention and visual presentation, with his music and stagecraft having a significant impact on popular music. During his lifetime, his record sales, estimated at over 100 million records worldwide, made him one of the world's best-selling music artists. In the UK, he was awarded ten platinum album certifications, eleven gold and eight silver, and released eleven number-one albums. In the US, he received five platinum and nine gold certifications. He was inducted into the Rock and Roll Hall of Fame in 1996</example>
        public string Description { get; set; }

        /// <example>1947-01-12T00:00:00</example>
        public DateTimeOffset FormationDate { get; set; }

        /// <example>2016-01-12T00:00:00</example>
        public DateTimeOffset? DisbandDate { get; set; }

        /// <example>David Bowie</example>
        public string Name { get; set; }
    }
}