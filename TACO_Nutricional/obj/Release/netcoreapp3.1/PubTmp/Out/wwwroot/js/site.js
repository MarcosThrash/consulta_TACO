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