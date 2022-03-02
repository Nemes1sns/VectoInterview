using System.Threading.Tasks;
using VectoInterview.Models;

namespace VectoInterview.Services.Interfaces
{
    internal interface ISimpleEffectCorrector
    {
        public SimpleEffect Applicable { get; }

        public Task<byte[]> CorrectAsync(byte[] image);
    }
}