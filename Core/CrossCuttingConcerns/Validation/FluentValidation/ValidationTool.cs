using Core.Entities;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {

        // Hatalı olur. Çünkü buraya sadece IEntity taşıyanlar değil aynı zamanda IDTO referansını kullananlarda gelebilir. Evrensel Olmasını istiyorsak Object istememiz
        // Daha mantıklı.
        //public static void Validate<T>(IValidator validator,T tentity)
        //{
        //    var context = new ValidationContext<T>(tentity);
        //    var result = validator.Validate(context);
        //    if (!result.IsValid)
        //    {
        //        throw new ValidationException(result.Errors);
        //    }

        //}

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }


























    }
}


       
