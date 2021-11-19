using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.Description).NotEmpty();
			RuleFor(c => c.Description).MinimumLength(3);
			RuleFor(c => c.DailyPrice).NotEmpty();
			RuleFor(c => c.DailyPrice).GreaterThan(0);
		}
	}
}
