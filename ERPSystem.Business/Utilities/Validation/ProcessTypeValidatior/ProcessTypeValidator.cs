using ERPSystem.Entity.DTO.ProcessTypeDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Validation.ProcessTypeValidatior
{
    public class ProcessTypeValidator:AbstractValidator<ProcessTypeDTORequest>
    {
        public ProcessTypeValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İşlem tipi ismi boş olamaz!");
            RuleFor(x=>x.Name).MinimumLength(2).MaximumLength(50).WithMessage("İşlem tipi ismi 2 karakterden küçük, 50 karakterden büyük olamaz!");
        }
    }
}
