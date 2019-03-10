using cogbank.model.Interfaces.Service;
using cogbank.model.ViewModels;
using cogbank.staticlist;
using System;
using System.Web.Mvc;

namespace cogbank.web.Controllers
{
	public class MovimentacaoController : BaseController
	{
		public MovimentacaoController(IMovimentacaoService service)
		{
			this.service = service;
		}

		readonly IMovimentacaoService service;

		public ActionResult Consultar(Guid id)
		{
			ViewBag.ContaID = id;

			return View(this.service.ObterMovimentacoesDaConta(id));
		}

		public ActionResult Acao(Guid id)
		{
			InicializarViewBagDeTipoDeMovimentacao();

			return View(new MovimentacaoViewModel(id));
		}

		[HttpPost]
		public ActionResult Acao(MovimentacaoViewModel dados)
		{
			if (!ModelState.IsValid)
				return View(dados);

			dados = this.service.Adicionar(dados);

			if (!dados.ValidationResult.IsOK)
			{
				this.RegisterNotificationInModelState(dados.ValidationResult.Erros);
				return View(dados);
			}
			else
			{
				TempData["Success"] = "Movimentação realizada com sucesso";
				TempData["Type"] = "success";
			}

			return RedirectToAction("Consultar", new { ID = dados.ContaID });
		}

		void InicializarViewBagDeTipoDeMovimentacao()
		{
			ViewBag.TiposDeMovimentacao = TiposDeMovimentacao.ObterTiposDeMovimentacao();
		}
	}
}