// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
   
    $('.select-alimentos').select2({
        theme: "classic",
        placeholder: "Alimento",
        ajax: {
            url: "/ComposicaoAlimentos/PesquisarAlimentoParaMontarRefeicao",
            dataType: "json",
            delay: 250,
            data: function (params) {
                return { nome: params.term };
            },
            processResults: function (data) {
                return { results: data };
            }
        }
    });

});


ajaxMontarRefeição = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (data) {

                $('.div-tabela').empty();
                $('.div-tabela').html(data);
                //$('.div-tabela').removeClass('invisible');
                
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}


ajaxPostCAdastrarAlimento = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {

                if (res.isValid) {
                    AvisoConclusao('Salvo com sucesso!');
                    window.location.href = '/ComposicaoAlimentos/Index';
                }
                else {
                    AvisoDeErro(res.Mensagem);
                }
                    
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}





AjaxDeleteItemRefeicao = (url) => {   
    Swal.fire({
        title: 'Certeza que que fazer isso?',
        text: "Você está prestes a excluir um item!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, quero deletar!'
    }).then((result) => {

        if (result.value) {

            try {
                $.ajax({
                    type: 'POST',
                    url: url,
                    contentType: false,
                    processData: false,
                    success: function (res) {

                        if (res.isValid) {                                                       
                            AvisoConclusao('Operação Efetuada com Sucesso!');
                            AtualizaGridRefeicao('/ComposicaoAlimentos/GridRefeçao');
                        } else {
                            $('#view-all').html(res.html);
                            AvisoDeErro('Ops... não foi possivel excluir!');
                        }
                        
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            } catch (ex) {
                console.log(ex)
            }

        }

    })

}


//////Funcões de avisos globais de confirmação
// tipo(success,error)
AvisoConclusao = (mensagem) => {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: mensagem,
        showConfirmButton: false,
        timer: 1500
    })
}

AvisoDeErro = (mensagem) => {
    Swal.fire({
        icon: 'error',
        title: 'Erro:',
        text: mensagem,
    })
}


AtualizaGridRefeicao = (url) => {
    $.ajax({
        type: 'GET',
        url: url,
        contentType: false,
        processData: false,
        success: function (data) {
            $('.div-tabela').empty();
            $('.div-tabela').html(data);
        },
        error: function (err) {
            console.log(err)
        }
    })
}