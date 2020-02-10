using System;
using System.Collections.Generic;
using System.Text;

namespace ArtIsPain.Shared
{
    public interface IFile
    {
        byte[] Content { get; set; }
    }
}