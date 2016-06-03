var edicao;
var txtDescricao;
var txtDescricaoText;

function prepararEdicao() {
    var idTxtDescricao = "#" + txtDescricao;
    $(idTxtDescricao).summernote();
    $(idTxtDescricao).on('summernote.blur', function () {
        $(idTxtDescricao).html($(idTxtDescricao).summernote('code'));
    })
    if (edicao) {
        $(idTxtDescricao).summernote('code', txtDescricaoText);
    }
}