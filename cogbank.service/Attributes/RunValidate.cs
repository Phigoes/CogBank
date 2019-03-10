namespace cogbank.service.Attributes
{
	public class RunValidate : System.Attribute
	{
		public RunValidate(string name)
		{
			this.Name = name;
		}

		public string Name { get; set; }
	}
}
