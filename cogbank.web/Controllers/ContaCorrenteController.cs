using cogbank.model.Interfaces.Service;
using cogbank.model.ViewModels;
using cogbank.staticlist;
using System;
using System.Web.Mvc;

namespace cogbank.web.Controllers
{
	public class ContaCorrenteController : BaseController
	{
		public ContaCorrenteController(IContaCorrenteService service)
		{
			this.service = service;
		}

		readonly IContaCorrenteService service;

		public ActionResult Index()
		{
			return View(this.service.ObterTodos());
		}

		public ActionResult Adicionar()
		{
			InicializarViewBagDeTipoDeConta();

			return View(new ContaCorrenteViewModel());
		}

		[HttpPost]
		public ActionResult Adicionar(ContaCorrenteViewModel dados)
		{
			if (!ModelState.IsValid)
			{
				InicializarViewBagDeTipoDeConta();

				return View(dados);
			}

			dados = this.service.Adicionar(dados);

			if (!dados.ValidationResult.IsOK)
			{
				InicializarViewBagDeTipoDeConta();

				TempData["Success"] = dados.ValidationResult.Erros[0].ToString();
				TempData["Type"] = "error";

				this.RegisterNotificationInModelState(dados.ValidationResult.Erros);
				return View(dados);
			}
			else
			{
				TempData["Success"] = "Conta corrente cadastrada com sucesso";
				TempData["Type"] = "success";
			}

			return RedirectToAction("Index");
		}

		public ActionResult Excluir(Guid id)
		{
			this.service.Excluir(this.service.ObterPorId(id));

			TempData["Success"] = "Conta corrente excluída com sucesso";
			TempData["Type"] = "success";

			return RedirectToAction("Index");
		}

		//public decimal ObterConversao(decimal valor)
		//{
		//	return Convert.ToDecimal((valor / Convert.ToDecimal(Dolar.ValorHoje())).ToString("0.00"));
		//}

		void InicializarViewBagDeTipoDeConta()
		{
			ViewBag.TiposDeConta = TiposDeConta.ObterTiposDeConta();
		}
	}
}