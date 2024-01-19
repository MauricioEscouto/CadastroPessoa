const PopUp = (Estrutura) => {
    CarregarPopUp(Estrutura);
}

const CarregarPopUp = async (Estrutura) => {
    var Default = {
        TipoPopUp: Estrutura.TipoPopUp,
        Mensagem: Estrutura.Mensagem,
        FnConfirma: Estrutura.FnConfirma,
        FnCancela: Estrutura.FnCancela
    }

    await fetch(`/Shared/PopUp/PopUp?mensagem=${Default.Mensagem}&tipoPopUp=${Default.TipoPopUp}`)
        .then(response => response.text())
        .then(data => {
            var main = document.getElementsByTagName('main')[0];

            var existePopUp = document.getElementById('modal_popUp');
            if (existePopUp) {
                existePopUp.remove();
            }

            main.innerHTML += data;

            var popUpElemento = document.getElementById('modal_popUp');
            var instancia = new bootstrap.Modal(popUpElemento);
            instancia.show();

            var btnConfirma = document.getElementById('popUp_btnConfirma');
            var btnNega = document.getElementById('popUp_btnNega');

            if (btnConfirma !== "undefined" && Default.FnConfirma !== undefined) {
                btnConfirma.addEventListener('click', function () {
                    Default.FnConfirma();
                });
            }
            if (btnNega !== "undefined" && Default.FnCancela !== undefined) {
                btnNega.addEventListener('click', function () {
                    Default.FnCancela();
                });
            }
        })
        .catch(error => {
            console.error('Ocorreu um erro:', error);
        });
}