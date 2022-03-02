using System.Threading.Tasks;
using VectoInterview.Models;

namespace VectoInterview.Services.Interfaces
{
    internal interface IParameterizedEffectCorrector
    {
        public ParameterizedEffect Applicable { get; }

        public Task<byte[]> CorrectAsync(byte[] image, double value);
    }
}