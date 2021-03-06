﻿using ArtIsPain.Server.ViewModels.Poetry;
using System;
using System.Collections.Generic;

namespace ArtIsPain.Server.ViewModels.Writer
{
    public class WriterViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartActivityDate { get; set; }

        public DateTime? EndActivityDate { get; set; }

        public string Biography { get; set; }

        public ICollection<PoetryVolumePreviewModel> PoetryVolumes { get; set; }
    }
}