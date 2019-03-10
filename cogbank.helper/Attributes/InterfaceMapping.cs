namespace cogbank.helper.Attributes
{
	public class InterfaceMapping : System.Attribute
	{
		public InterfaceMapping(string className)
			=> this.ClassName = className;

		public string ClassName { get; set; }
	}
}
