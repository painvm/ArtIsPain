using System;

namespace ArtIsPain.Shared
{
    public abstract class ImageEntity : IObjectType, IFile
    {
        public Guid Id { get; set; }
        public int ObjectTypeId { get; set; }
        public string Name { get; set; }
    }
}