using System.Threading.Tasks;
using VectoInterview.Models;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Services
{
    internal sealed class ParameterizedEffect2CorrectorFake : IParameterizedEffectCorrector
    {
        public ParameterizedEffect Applicable => ParameterizedEffect.ParameterizedEffect2;

        public Task<byte[]> CorrectAsync(byte[] image, double value)
        {
            //there should be an async logic
            return Task.FromResult(image);
        }
    }
}