$(document).ready(function () {
    $('#link-noticia').hide();
    $('#link-noticia').slideDown('slow');

    $('input').iCheck({
        checkboxClass: 'icheckbox_square-aero',
        radioClass: 'iradio_square-aero',
        increaseArea: '20%' // optional
    });

    $('.apagarNoFoco').focus(function () {
        if ($(this).val() == $(this).attr('valorPadrao'))
            $(this).val('');
    });

    $('.apagarNoFoco').blur(function () {
        if ($(this).val() == '')
            $(this).val($(this).attr('valorPadrao'));
    });

    $('form').submit(function () {
        if ($('.campo').val() == $('.campo').attr('valorPadrao'))
            $('.campo').val('');
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() != 0) {
            $('#voltar-para-topo').fadeIn();
        } else {
            $('#voltar-para-topo').fadeOut();
        }
    });

    $('#voltar-para-topo').click(function () {
        $('body,html').animate({ scrollTop: 0 }, 800);
    });
});