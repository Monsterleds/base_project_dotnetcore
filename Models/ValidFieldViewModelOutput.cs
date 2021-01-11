using System.Collections.Generic;

namespace curso.api.Models
{
    public class ValidFieldViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }
        public ValidFieldViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
