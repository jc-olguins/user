using System.Collections.Generic;

namespace User.EntityFramework
{
    public class EntityValidationResult
    {
        private static readonly EntityValidationResult _success = new EntityValidationResult(true);

        public EntityValidationResult(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                errors = new[] { $"{nameof(errors)} cannot be null" };
            }

            Succeeded = false;
            Errors = errors;
        }

        public EntityValidationResult(params string[] errors) : this((IEnumerable<string>)errors)
        {
        }

        protected EntityValidationResult(bool success)
        {
            Succeeded = success;
            Errors = new string[0];
        }

        public IEnumerable<string> Errors { get; private set; }
        public bool Succeeded { get; private set; }

        public static EntityValidationResult Success
        {
            get { return _success; }
        }

        public static EntityValidationResult Failed(params string[] errors)
        {
            return new EntityValidationResult(errors);
        }

    }
}
