window.addEventListener('DOMContentLoaded', (event) => {
    let mascaraDataNascimento = new Inputmask("99/99/9999");
    let mascaraCpf = new Inputmask("999.999.999-99");
    let mascaraRg = new Inputmask("999.999.99-9");
    mascaraDataNascimento.mask(document.getElementById("input_datanascimento"));
    mascaraCpf.mask(document.getElementById("input_documento"));
    mascaraRg.mask(document.getElementById("input_rg"));
});

var ActionPessoaCadastro = {
    AdicionarEndereco: async function () {
        let idEndereco = 0;
        var forms = document.getElementsByTagName('form');

        for (var i = 0; i < forms.length; i++) {
            if (forms[i].id.startsWith('form_pessoaDadosEndereco-')) {
                var parts = forms[i].id.split('-');
                var valorDinamico = parts[1];
                idEndereco = parseInt(valorDinamico);
            }
        }

        idEndereco += 1;

        await fetch(`/Pessoa/_PartialEndereco?id=${idEndereco}`)
            .then(response => response.text())
            .then(data => {
                document.getElementById('subDiv_cadastroEndereco').insertAdjacentHTML('beforeend', data);
                let mascaraCep = new Inputmask("99999-999");
                mascaraCep.mask(document.getElementById(`input_cep-${idEndereco}`));
            })
            .catch(error => {
                console.error('Ocorreu um erro:', error);
            });
    },
    AdicionarContato: async function () {
        let idContato = 0;
        var forms = document.getElementsByTagName('form');

        for (var i = 0; i < forms.length; i++) {
            if (forms[i].id.startsWith('form_pessoaDadosContato-')) {
                var parts = forms[i].id.split('-');
                var valorDinamico = parts[1];
                idContato = parseInt(valorDinamico);
            }
        }

        idContato += 1;

        await fetch(`/Pessoa/_PartialContato?id=${idContato}`)
            .then(response => response.text())
            .then(data => {
                document.getElementById('subDiv_cadastroContato').insertAdjacentHTML('beforeend', data);

            })
            .catch(error => {
                console.error('Ocorreu um erro:', error);
            });
    },
    RemoverEndereco: async function (id) {
        document.getElementById(`form_pessoaDadosEndereco-${id}`).remove();
    },
    RemoverContato: async function (id) {
        document.getElementById(`form_pessoaDadosContato-${id}`).remove();
    },
    Salvar: async function () {
        var dadosPessoais;
        var enderecos = [];
        var contatos = [];

        var forms = document.getElementsByTagName('form');
        var isFormsValidos = true;

        let formDadosPessoais = document.getElementById("form_pessoaDadosPessoais");
        isFormsValidos = validarFormCadastro(formDadosPessoais);
        let formData = new FormData(formDadosPessoais);
        dadosPessoais = Object.fromEntries(formData.entries());

        var dataNascimento = dadosPessoais.datanascimento;
        if (dataNascimento) {
            var partesData = dataNascimento.split('/');
            var dataFormatoCSharp = partesData[2] + '-' + partesData[1] + '-' + partesData[0];
            dadosPessoais.datanascimento = dataFormatoCSharp;
        }

        for (var i = 0; i < forms.length; i++) {
            if (forms[i].id.startsWith('form_pessoaDadosEndereco-')) {
                var resposta = validarFormCadastro(forms[i]);

                if (isFormsValidos) {
                    isFormsValidos = resposta;
                }

                var endereco = {};
                var formElements = forms[i].elements;

                for (var j = 0; j < formElements.length; j++) {
                    var input = formElements[j];
                    if (input.name) {
                        endereco[input.name] = input.value;
                    }
                }

                enderecos.push(endereco);
            }

            if (forms[i].id.startsWith('form_pessoaDadosContato-')) {
                var resposta = validarFormCadastro(forms[i]);
                if (isFormsValidos) {
                    isFormsValidos = resposta;
                }

                var contato = {};
                var formElements = forms[i].elements;

                for (var j = 0; j < formElements.length; j++) {
                    var input = formElements[j];
                    if (input.name) {
                        contato[input.name] = input.value;
                    }
                }

                contatos.push(contato);
            }
        }

        if (isFormsValidos) {
            var pessoaFisica = {
                ...dadosPessoais,
                enderecos,
                contatos
            };

            var json = JSON.stringify(pessoaFisica);
            const response = await fetch(`/Pessoa/CadastrarPessoaFisica?pessoaFisica=${json}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(pessoaFisica)
            });

            if (response.status === 200) {
                response.text().then(text => {
                    PopUp(
                        {
                            TipoPopUp: TipoPopUp.Sucesso,
                            Mensagem: "Pessoa cadastrada com sucesso.",
                            FnConfirma: async () => {
                                window.location.href = "/Pessoa";
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
        }
    },
}

const validarFormCadastro = (formVerificado) => {
    var inputs = formVerificado.getElementsByTagName("input");
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

const mudarTipoContato = (id) => {
    let inputDocumentoCadastro = document.getElementById(`input_informacao-${id}`);
    inputDocumentoCadastro.value = "";

    switch (parseInt(document.getElementById(`input_tipoContato-${id}`).value)) {
        case 0:
            inputDocumentoCadastro.type = "email";
            if (inputDocumentoCadastro.inputmask)
                inputDocumentoCadastro.inputmask.remove()
            break;
        case 1:
            inputDocumentoCadastro.type = "tel";
            let mascaraTelefone = new Inputmask("(99) 99999-9999");
            mascaraTelefone.mask(inputDocumentoCadastro);
        default:
    }
}