window.addEventListener('DOMContentLoaded', (event) => {
    var formTelaPessoa = document.getElementById('form_pessoa');
    if (formTelaPessoa) {
        document.body.addEventListener('click', async function (event) {
            if (event.target.id === 'pessoa_btnCadastrar') {
                event.preventDefault();
                window.location.href = document.getElementById("pessoa_tipoCadastro").value;
            }
        });
    }
});