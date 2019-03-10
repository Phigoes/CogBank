using Newtonsoft.Json;
using System;

namespace cogbank.model.ViewModels
{
	public class BaseViewModel
	{
		public BaseViewModel()
		{
			this.ValidationResult = new ValidationResult();
		}

		public Guid ID { get; set; }

		[JsonIgnore]
		public model.ValidationResult ValidationResult { get; set; }
	}
}
