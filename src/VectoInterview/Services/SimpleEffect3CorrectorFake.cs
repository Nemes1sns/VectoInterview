using System.Threading.Tasks;
using VectoInterview.Models;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Services
{
    internal sealed class SimpleEffect3CorrectorFake : ISimpleEffectCorrector
    {
        public SimpleEffect Applicable => SimpleEffect.Effect3;

        public Task<byte[]> CorrectAsync(byte[] image)
        {
            //there should be an async logic
            return Task.FromResult(image);
        }
    }
}