using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VectoInterview.Models;
using VectoInterview.Models.Requests;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Services
{
    internal sealed class ImageService : IImageService
    {
        private readonly IReadOnlyDictionary<ParameterizedEffect, IParameterizedEffectCorrector> _parameterizedEffectCorrectors;
        private readonly IReadOnlyDictionary<SimpleEffect, ISimpleEffectCorrector> _simpleEffectCorrectors;
        private readonly ConcurrentDictionary<Guid, byte[]> _cache = new();

        public ImageService(
            IEnumerable<IParameterizedEffectCorrector> parameterizedEffectCorrectors,
            IEnumerable<ISimpleEffectCorrector> simpleEffectCorrectors)
        {
            _parameterizedEffectCorrectors = parameterizedEffectCorrectors.ToDictionary(corrector => corrector.Applicable);
            _simpleEffectCorrectors = simpleEffectCorrectors.ToDictionary(corrector => corrector.Applicable);
        }

        public async Task<Guid> UploadImageAsync(IFormFile file)
        {
            var buffer = new byte[file.Length];
            await using var stream = new MemoryStream(buffer);
            await file.CopyToAsync(stream);

            var key = Guid.NewGuid();
            _cache.TryAdd(key, buffer);
            return key;
        }

        public void DeleteImage(Guid id)
        {
            _cache.TryRemove(id, out _);
        }

        public async Task<byte[]> BeautifyAsync(BeautifyImagesRequest request)
        {
            if (!_cache.TryGetValue(request.Id, out var image))
                throw new ArgumentException("Image was not found.");

            var newImage = (byte[])image.Clone();
            if (request.SimpleEffects != null)
                foreach (var effect in request.SimpleEffects)
                {
                    var corrector = _simpleEffectCorrectors[effect];
                    newImage = await corrector.CorrectAsync(image);
                }

            if (request.ParameterizedEffects != null)
                foreach (var effect in request.ParameterizedEffects)
                {
                    var corrector = _parameterizedEffectCorrectors[effect.Key];
                    newImage = await corrector.CorrectAsync(image, effect.Value);
                }

            _cache.TryUpdate(request.Id, newImage, image);
            return newImage;
        }
    }
}