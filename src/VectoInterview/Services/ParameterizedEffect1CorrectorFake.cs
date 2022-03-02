using System.Threading.Tasks;
using VectoInterview.Models;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Services
{
    internal sealed class ParameterizedEffect1CorrectorFake : IParameterizedEffectCorrector
    {
        public ParameterizedEffect Applicable => ParameterizedEffect.ParameterizedEffect1;

        public Task<byte[]> CorrectAsync(byte[] image, double value)
        {
            //there should be an async logic
            return Task.FromResult(image);
        }
    }
}