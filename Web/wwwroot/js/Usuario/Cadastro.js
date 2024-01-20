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

        let input_telefoneUsuario = document.getElementById("input_telefone");
        if (input_telefoneUsuario) {
            let mascaraTelefone = new Inputmask("(99) 99999-9999");
            mascaraTelefone.mask(input_telefoneUsuario);
        }
    }
});

var ActionCadastro = {
    Cadastrar: async function () {
        let formCadastroUsuario = document.getElementById('form_cadastro');
        let formData = new FormData(formCadastroUsuario);
        let usuario = Object.fromEntries(formData.entries());

        const response = await fetch(`/Usuario/Cadastrar`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(usuario)
        });

        if (response.status === 200) {
            response.text().then(text => {
                PopUp(
                    {
                        TipoPopUp: TipoPopUp.Sucesso,
                        Mensagem: "Usuário cadastrado com sucesso.",
                        FnConfirma: async () => {
                            window.location.href = "/";
                        }
                    }
                );
            });
        }
        else {
            response.text().then(text => {
                if (text.startsWith('"') && text.endsWith('"')) {
                    text = text.slice(1, -1);
                }
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