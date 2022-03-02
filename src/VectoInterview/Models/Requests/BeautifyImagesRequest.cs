using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VectoInterview.Models.Requests
{
    public sealed class BeautifyImagesRequest
    {
        [Required]
        public Guid Id { get; init; }

        public SimpleEffect[] SimpleEffects { get; init; }

        public Dictionary<ParameterizedEffect, double> ParameterizedEffects { get; init; }
    }
}