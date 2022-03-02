using System.Threading.Tasks;
using VectoInterview.Models;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Services
{
    internal sealed class SimpleEffect1CorrectorFake : ISimpleEffectCorrector
    {
        public SimpleEffect Applicable => SimpleEffect.Effect1;

        public Task<byte[]> CorrectAsync(byte[] image)
        {
            //there should be an async logic
            return Task.FromResult(image);
        }
    }
}