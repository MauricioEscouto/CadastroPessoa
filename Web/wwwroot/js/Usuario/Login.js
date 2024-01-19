window.addEventListener('DOMContentLoaded', (event) => {
    var formLogin = document.getElementById('form_login');
    if (formLogin) {
        document.body.addEventListener('click', async function (event) {
            if (event.target.id === 'login_btnEntrar') {
                event.preventDefault();
                if (validarFormLogin()) {
                    await ActionLogin.Logar();
                }
            }
        });
    }
});

var ActionLogin = {
    Logar: async function () {
        let formLoginUsuario = document.getElementById('form_login');
        let formData = new FormData(formLoginUsuario);
        let usuario = Object.fromEntries(formData.entries());

        const response = await fetch(`/Usuario/Logar`, {
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

const validarFormLogin = () => {
    let formLogin = document.getElementById('form_login');
    var inputs = formLogin.getElementsByTagName("input");
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