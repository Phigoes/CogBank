function ExibirNotificacao(tipoDeNotificacao, tituloDaNotificacao, conteudoDaNotificao) {

	if (tituloDaNotificacao == '') tituloDaNotificacao = 'Notificação';
	if (conteudoDaNotificao == '') conteudoDaNotificao = 'Nenhuma mensagem de notificação foi informada.';

	Messenger().post({
		message: conteudoDaNotificao,
		type: tipoDeNotificacao,
		showCloseButton: true
	});
}