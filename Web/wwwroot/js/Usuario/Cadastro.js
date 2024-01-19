window.addEventListener('DOMContentLoaded', (event) => {
    var formCadastro = document.getElementById('form_cadastro');
    if (formCadastro) {
        document.body.addEventListener('click', async function (event) {
            if (event.target.id === 'btn_entrarCadastro') {
                event.preventDefault();
                if (validarFormCadastro()) {
                    await ActionCadastro.Cadastrar();
                }
            }
        });
    }
});

var ActionCadastro = {
    Cadastrar: async function () {
        let inputNome = document.getElementById("input_nome");
        let inputEmail = document.getElementById("input_email");
        let inputTelefone = document.getElementById("input_telefone");
        let inputSenha = document.getElementById("input_senha");

        const usuario = {
            nome: inputNome.value,
            email: inputEmail.value,
            telefone: inputTelefone.value,
            senha: inputSenha.value
        };

        const response = await fetch(`/Usuario/Cadastrar`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(usuario)
        });

        if (response.status === 200) {
            window.location.href = '/';
        }
        else {
            response.text().then(text => {
                PopUp(
                    {
                        TipoPopUp: TipoPopUp.Erro,
                        Mensagem: text,
                    }
                );
            });
        }
    },
}

const validarFormCadastro = () => {
    let formCadastro = document.getElementById('form_cadastro');
    var inputs = formCadastro.getElementsByTagName("input");
    var isValid = true;
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].hasAttribute("required")) {
            if (inputs[i].value == "") {
                inputs[i].classList.add("is-invalid");
                isValid = false;
            } else {
                inputs[i].classList.remove("is-invalid");
            }
        }
        inputs[i].addEventListener('input', function () {
            this.classList.remove('is-invalid');
        });
    }
    return isValid;
}