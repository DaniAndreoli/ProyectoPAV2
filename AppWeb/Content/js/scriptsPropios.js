/*************************************************************************************************************************
*                                         Funciones JavaScript Propias
**************************************************************************************************************************
*En este documento recopilamos las funciones JS escritas por nosotros, para resolver situaciones del lado del cliente    */



//Funcion para setear el item actual del navbar
function MostrarNavActivo() {
    $(".nav").find(".active").removeClass("active");
    $('a[href="' + this.location.pathname + '"]').parents('li,ul').addClass('active');
}

/*Configuraciones de jQueryDataTable. 
Documentacion obtenida de: https://datatables.net/plug-ins/i18n/Spanish
La siguiente funcion se ejecuta al finalizar el randerizado de la vista*/
$(document).ready(function () {
    $(".grilla").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });

    MostrarNavActivo();
});

//Funcion para controlar el cambio de tab del menu principal
$(".dropdown-menu a").on("click", function (e) {
    waitingDialog.show();
    $(this).parents(".dropdown").addClass("active");
    $(".nav").find(".active").removeClass("active");
    $("#tabActivo").val($(e.target).attr('id'));
});

/*Script para mensajes de informacion al usuario
La llamada de esta funcion debe ser realizada desde el servidor*/
function MostrarMensaje(mensaje, tipoMensaje) {
    var cssclass;
    switch (tipoMensaje) {
        case 'Exito':
            cssclass = 'alert-success'
            break;
        case 'Error':
            cssclass = 'alert-danger'
            break;
        case 'Aviso':
            cssclass = 'alert-warning'
            break;
        default:
            cssclass = 'alert-info'
    }
    //En la siguiente linea, jQuery($) busca al elememto que tenga el id:alert_container, y le agrega el contenido a traves de la funcion 'append', 
    //seteando un div con el contenido del mensaje que sera mostrado al usuario
    $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '">' +
        '<a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>' +
            '<strong>' + tipoMensaje + '!</strong> <span>' + mensaje + '</span></div>');
};

/*Script para soliciar confirmacion al usuario
La llamada de esta funcion debe ser realizada desde el servidor*/
function PedirConfirmacion() {
    $('#dialogoConfirmacion').modal('show');
};

//TODO: Prueba.. No funciona aun
function CambiarColorFila(idFila) {
    var color = document.getElementById(idFila).style.backgroundColor;
    alert(color);

    if (color != 'yellow')
        document.getElementById("hiddenColor").style.backgroundColor = color;

    alert(oldColor);

    if (color == 'yellow')
        document.getElementById(rowID).style.backgroundColor = document.getElementById("hiddenColor").style.backgroundColor;
    else
        document.getElementById(rowID).style.backgroundColor = 'yellow';

}