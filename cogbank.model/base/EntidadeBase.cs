using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;

namespace cogbank.model
{
	public class EntidadeBase
	{
		[ExplicitKey]
		public Guid ID { get; set; }

		[Write(false), JsonIgnore]
		public ValidationResult ValidationResult { get; set; }
	}
}
