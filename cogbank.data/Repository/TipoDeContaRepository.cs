using cogbank.data.Base;
using cogbank.helper.Attributes;
using cogbank.model;
using cogbank.model.Interfaces.Repository;

namespace cogbank.data.Repository
{
	[InterfaceMapping("ITipoDeContaRepository")]
	public class TipoDeContaRepository : RepositoryBase<TipoDeConta>, ITipoDeContaRepository
	{
	}
}
