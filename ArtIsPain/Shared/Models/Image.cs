﻿using ArtIsPain.Shared.Interfaces;
using System;

namespace ArtIsPain.Shared.Models
{
    public abstract class Image : IEntity, IFile
    {
        public Guid Id { get; set; }

        public int ObjectTypeId { get; set; }

        public Guid? ObjectId { get; set; }

        public byte[] Content { get; set; }
    }
}