using FluentValidation.Results;
using System.Collections.Generic;

namespace EFCore.Domain.Extention
{
    public static class ValidationExtention
    {
        public static Dictionary<string, string> ToDictionary(this IList<ValidationFailure> erros)
        {
            var result = new Dictionary<string, string>();

            foreach (var erro in erros)
            {
                if (!result.ContainsKey(erro.PropertyName))
                {
                    result.Add(erro.PropertyName.ToString(), erro.ErrorMessage.ToString());
                }
            }

            return result;
        }
    }
}
