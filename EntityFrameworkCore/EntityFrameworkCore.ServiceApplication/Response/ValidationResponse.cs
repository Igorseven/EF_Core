using System.Collections.Generic;

namespace EFCore.Business.Validation
{
    public class ValidationResponse
    {
        public Dictionary<string, string> Erros { get; private set; }
        public bool Valid => Erros.Count == 0;

        private ValidationResponse(Dictionary<string, string> erros)
        {
            this.Erros = erros;
        }

        public static ValidationResponse CreateValidation(Dictionary<string, string> erros)
        {
            return new ValidationResponse(erros);
        }
    }
}
