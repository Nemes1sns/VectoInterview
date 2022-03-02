using System;
using System.Collections.Generic;

namespace VectoInterview.Models.Requests
{
    public sealed class BeautifyImagesRequest
    {
        public Guid Id { get; init; }
        public SimpleEffect[] SimpleEffects { get; init; }
        public Dictionary<ParameterizedEffect, double> ParameterizedEffects { get; init; }
    }
}