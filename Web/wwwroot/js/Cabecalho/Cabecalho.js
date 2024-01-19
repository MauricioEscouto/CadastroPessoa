window.addEventListener('DOMContentLoaded', (event) => {
    var cabecalho_btnEntrar = document.getElementById('cabecalho_btnEntrar');
    var cabecalho_btnCadastrar = document.getElementById('cabecalho_btnCadastrar');

    if (cabecalho_btnEntrar) {
        cabecalho_btnEntrar.addEventListener('click', async function (event) {
            window.location.href = "/Usuario/Login"
        });
    }

    if (cabecalho_btnCadastrar) {
        cabecalho_btnCadastrar.addEventListener('click', async function (event) {
            window.location.href = "/Usuario/Cadastro"
        });
    }
});